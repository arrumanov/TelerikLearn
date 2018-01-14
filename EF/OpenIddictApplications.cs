using System;
using System.Collections.Generic;

namespace TelerikAspNetCoreApp.EF
{
    public partial class OpenIddictApplications
    {
        public OpenIddictApplications()
        {
            OpenIddictAuthorizations = new HashSet<OpenIddictAuthorizations>();
            OpenIddictTokens = new HashSet<OpenIddictTokens>();
        }

        public string Id { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ConcurrencyToken { get; set; }
        public string DisplayName { get; set; }
        public string PostLogoutRedirectUris { get; set; }
        public string RedirectUris { get; set; }
        public string Type { get; set; }

        public ICollection<OpenIddictAuthorizations> OpenIddictAuthorizations { get; set; }
        public ICollection<OpenIddictTokens> OpenIddictTokens { get; set; }
    }
}
