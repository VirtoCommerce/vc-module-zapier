using System.Runtime.Serialization;
using Altsoft.ShopifyImportModule.Web.Models.Shopify.Base;

namespace Altsoft.ShopifyImportModule.Web.Models.Shopify
{
    [DataContract]
    public class ShopifyCollect:ShopifyCreatableEntity
    {
        [DataMember(Name = "collection_id")]
        public long CollectionId { get; set; }

        [DataMember(Name = "featured")]
        public bool Featured { get; set; }

        [DataMember(Name = "position")]
        public int Position { get; set; }

        [DataMember(Name = "product_id")]
        public long ProductId { get; set; }

        [DataMember(Name = "sort_value")]
        public string SortValue { get; set; }
    }

    [DataContract]
    public class ShopifyCollectList
    {
        [DataMember(Name = "collects")]
        public ShopifyCollect[] Collects { get; set; }
    }
}