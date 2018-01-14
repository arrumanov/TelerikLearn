using System;
using System.Collections.Generic;

namespace TelerikAspNetCoreApp.EF
{
    public partial class OpenIddictTokens
    {
        public string Id { get; set; }
        public string ApplicationId { get; set; }
        public string AuthorizationId { get; set; }
        public string ConcurrencyToken { get; set; }
        public DateTimeOffset? CreationDate { get; set; }
        public DateTimeOffset? ExpirationDate { get; set; }
        public string Payload { get; set; }
        public string ReferenceId { get; set; }
        public string Status { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }

        public OpenIddictApplications Application { get; set; }
        public OpenIddictAuthorizations Authorization { get; set; }
    }
}
