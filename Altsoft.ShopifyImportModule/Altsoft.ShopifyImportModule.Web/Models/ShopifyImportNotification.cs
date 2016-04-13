using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using VirtoCommerce.Platform.Core.PushNotifications;

namespace Altsoft.ShopifyImportModule.Web.Models
{
    public class ShopifyImportNotification : PushNotification
    {
        public ShopifyImportNotification(string creator)
            : base(creator)
        {
            NotifyType = "CatalogShopifyImport";
            Errors = new List<string>();
            Progresses = new Dictionary<string, ShopifyImportProgress>();
        }
        
		[JsonProperty("finished")]
		public DateTime? Finished { get; set; }

        [JsonProperty("progresses")]
        public Dictionary<string, ShopifyImportProgress> Progresses { get; set; }

        [JsonProperty("errors")]
		public ICollection<string> Errors { get; set; }

        [JsonProperty("errorCount")]
        public int ErrorCount { get; set; }
    }
}