using System.Runtime.Serialization;
using Altsoft.ShopifyImportModule.Web.Models.Shopify.Base;

namespace Altsoft.ShopifyImportModule.Web.Models.Shopify
{
    [DataContract]
    public class ShopifyAsset:ShopifyUpdatableEntity
    {
        [DataMember(Name = "attachment")]
        public string Attachment { get; set; }

        [DataMember(Name = "content_type")]
        public string ContentType { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "public_url")]
        public string PublicUrl { get; set; }

        [DataMember(Name = "size")]
        public int Size { get; set; }

        [DataMember(Name = "source_key")]
        public string SourceKey { get; set; }

        [DataMember(Name = "src")]
        public string Src { get; set; }

        [DataMember(Name = "theme_id")]
        public long ThemeId { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }
    }

    [DataContract]
    public class ShopifyAssetList
    {
        [DataMember(Name="assets")]
        public ShopifyAsset[] Assets { get; set; }
    }

    [DataContract]
    public class ShopifyAssetContainer
    {
        [DataMember(Name = "asset")]
        public ShopifyAsset Asset { get; set; }
    }
}