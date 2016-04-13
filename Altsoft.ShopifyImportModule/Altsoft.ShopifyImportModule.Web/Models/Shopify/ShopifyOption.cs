using System.Runtime.Serialization;
using Altsoft.ShopifyImportModule.Web.Models.Shopify.Base;

namespace Altsoft.ShopifyImportModule.Web.Models.Shopify
{
    [DataContract]
    public class ShopifyOption : ShopifyEntity
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "position")]
        public int Position { get; set; }

        [DataMember(Name = "product_id")]
        public long ProductId { get; set; }
    }
}