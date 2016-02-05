using System.Runtime.Serialization;
using Altsoft.ShopifyImportModule.Web.Models.Shopify.Base;

namespace Altsoft.ShopifyImportModule.Web.Models.Shopify
{
    [DataContract]
    public class ShopifyTheme : ShopifyUpdatableEntity
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "role")]
        public string Role { get; set; }

        [DataMember(Name = "previewable")]
        public bool Previewable { get; set; }

        [DataMember(Name = "processing")]
        public bool Processing { get; set; }
    }

    [DataContract]
    public class ShopifyThemeList
    {
        [DataMember(Name = "themes")]
        public ShopifyTheme[] Themes { get; set; }
    }
}