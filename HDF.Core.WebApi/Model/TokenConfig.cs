using Newtonsoft.Json;

namespace HDF.Core.WebApi.Model
{
    public class TokenConfig
    {

        public string Secret { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int AccessExpiration { get; set; }

        public int RefreshExpiration { get; set; }
    }
}