using System;
using System.Runtime.Serialization;

namespace Altsoft.ShopifyImportModule.Web.Models.Shopify.Base
{
    [DataContract]
    public class ShopifyCreatableEntity:ShopifyUpdatableEntity
    {
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }    
    }
}