using System;
using System.Collections.Generic;

namespace TelerikAspNetCoreApp.EF
{
    public partial class OpenIddictAuthorizations
    {
        public OpenIddictAuthorizations()
        {
            OpenIddictTokens = new HashSet<OpenIddictTokens>();
        }

        public string Id { get; set; }
        public string ApplicationId { get; set; }
        public string ConcurrencyToken { get; set; }
        public string Scopes { get; set; }
        public string Status { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }

        public OpenIddictApplications Application { get; set; }
        public ICollection<OpenIddictTokens> OpenIddictTokens { get; set; }
    }
}
