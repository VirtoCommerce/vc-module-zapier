using System;
using System.Runtime.Serialization;

namespace Altsoft.ShopifyImportModule.Web.Models.Shopify.Base
{
    [DataContract]
    public class ShopifyUpdatableEntity:ShopifyEntity
    {
        [DataMember(Name="updated_at")]
        public DateTime UpdatedAt { get; set; }
         
    }
}