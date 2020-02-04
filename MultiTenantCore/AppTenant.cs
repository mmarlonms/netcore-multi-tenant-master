using System.Collections.Generic;

namespace MultiTenantCore
{
    public class Portal
    {
        public string Name { get; set; }
        public IEnumerable<string> Hostnames { get; set; }
    }
}
