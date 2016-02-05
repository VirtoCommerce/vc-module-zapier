using System.Runtime.Serialization;
using Altsoft.ShopifyImportModule.Web.Models.Shopify.Base;

namespace Altsoft.ShopifyImportModule.Web.Models.Shopify
{
    [DataContract]
    public class ShopifyMetafield:ShopifyCreatableEntity
    {
        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "namespace")]
        public string Namespace { get; set; }

        [DataMember(Name = "owner_id")]
        public string OwnerId { get; set; }

        [DataMember(Name = "owner_resource")]
        public string OwnerResource { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }

        [DataMember(Name = "value_type")]
        public string ValueType { get; set; }


    }
}