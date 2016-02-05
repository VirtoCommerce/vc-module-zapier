using Newtonsoft.Json;

namespace Altsoft.ShopifyImportModule.Web.Models
{
    public class ShopifyImportProgress
    {
        [JsonProperty("totalCount")]
        public long TotalCount { get; set; }

        [JsonProperty("processedCount")]
        public long ProcessedCount { get; set; }

        [JsonProperty("errorCount")]
        public long ErrorCount { get; set; }
    }
}