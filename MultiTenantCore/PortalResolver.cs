using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using SaasKit.Multitenancy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTenantCore
{
    public class PortalResolver : MemoryCacheTenantResolver<Portal>
    {
        private readonly Dictionary<string, string> mappings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "localhost:60000", "Default"},
            { "localhost:60001", "Outro"}
        };

        public PortalResolver(IMemoryCache cache, ILoggerFactory loggerFactory) 
            : base(cache, loggerFactory)
        {

        }

        protected override string GetContextIdentifier(HttpContext context)
        {
            return context.Request.Host.Value.ToLower();
        }

        protected override IEnumerable<string> GetTenantIdentifiers(TenantContext<Portal> context)
        {
            return context.Tenant.Hostnames;
        }

        protected override Task<TenantContext<Portal>> ResolveAsync(HttpContext context)
        {
            TenantContext<Portal> tenantContext = null;

            if (mappings.TryGetValue(context.Request.Host.Value, out string tenantName))
            {
                tenantContext = new TenantContext<Portal>(
                    new Portal { Name = tenantName, Hostnames = new[] { context.Request.Host.Value } });
            }

            return Task.FromResult(tenantContext);
        }

        protected override MemoryCacheEntryOptions CreateCacheEntryOptions()
        {
            return base.CreateCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5));
        }
    }
}
