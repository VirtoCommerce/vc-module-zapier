using System;
using System.Runtime.Serialization;
using Altsoft.ShopifyImportModule.Web.Models.Shopify.Base;

namespace Altsoft.ShopifyImportModule.Web.Models.Shopify
{
    [DataContract]
    public class ShopifyPage : ShopifyUpdatableEntity
    {
        [DataMember(Name = "author")]
        public string Author { get; set; }

        [DataMember(Name = "body_html")]
        public string BodyHtml { get; set;  }

        [DataMember(Name = "handle")]
        public string Handle { get; set;  }

        [DataMember(Name = "published_at")]
        public DateTime PublishedAt { get; set;  }

        [DataMember(Name = "shop_id")]
        public long ShopId { get; set;  }

        [DataMember(Name = "template_suffix")]
        public string TemplateSuffix { get; set;  }

        [DataMember(Name = "title")]
        public string Title { get; set;  }
    }

    [DataContract]
    public class ShopifyPageList
    {
        [DataMember(Name = "pages")]
        public ShopifyPage[] Pages { get; set; }
    }
}