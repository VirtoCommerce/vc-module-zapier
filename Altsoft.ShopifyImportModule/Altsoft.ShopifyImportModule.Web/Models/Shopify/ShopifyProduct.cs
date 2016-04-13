using System;
using System.Runtime.Serialization;
using Altsoft.ShopifyImportModule.Web.Models.Shopify.Base;

namespace Altsoft.ShopifyImportModule.Web.Models.Shopify
{
    [DataContract]
    public class ShopifyProduct : ShopifyCreatableEntity
    {
        [DataMember(Name = "body_html")]
        public string BodyHtml { get; set; }

        [DataMember(Name = "handle")]
        public string Handle { get; set; }

        [DataMember(Name = "image")]
        public ShopifyImage Image { get; set; }

        [DataMember(Name = "images")]
        public ShopifyImage[] Images { get; set; }

        [DataMember(Name = "options")]
        public ShopifyOption[] Options { get; set; }

        [DataMember(Name = "product_type")]
        public string ProductType { get; set; }

        [DataMember(Name = "published_at")]
        public DateTime PublishedAt { get; set; }

        [DataMember(Name = "published_scope")]
        public string PublishedScope { get; set; }

        [DataMember(Name = "tags")]
        public string Tags { get; set; }

        [DataMember(Name = "template_suffix")]
        public string TemplateSuffix { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "variants")]
        public ShopifyVariant[] Variants { get; set; }

        [DataMember(Name = "vendor")]
        public string Vendor { get; set; }
    }

    [DataContract]
    public class ShopifyProductList
    {
        [DataMember(Name = "products")]
        public ShopifyProduct[] Products { get; set; }
    }
}