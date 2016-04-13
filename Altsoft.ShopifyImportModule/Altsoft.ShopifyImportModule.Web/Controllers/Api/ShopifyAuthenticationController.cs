using System.Web.Http;
using System.Web.Http.Description;
using Altsoft.ShopifyImportModule.Web.Interfaces;
using Altsoft.ShopifyImportModule.Web.Models;

namespace Altsoft.ShopifyImportModule.Web.Controllers.Api
{
    [RoutePrefix("api/shopifyAuthentication")]
    public class ShopifyAuthenticationController : ApiController
    {
        private readonly IShopifyAuthenticationService _shopifyAuthenticationService;
        public ShopifyAuthenticationController(IShopifyAuthenticationService shopifyAuthenticationService)
        {
            _shopifyAuthenticationService = shopifyAuthenticationService;
        }

        [HttpGet]
        [Route("is-authenticated")]
        public IHttpActionResult IsAuthenticated()
        {
            var isAuthenticated = _shopifyAuthenticationService.IsAuthenticated();

            return Ok(new { IsAuthenticated = isAuthenticated });
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(AuthenticationModel model)
        {
            _shopifyAuthenticationService.Authenticate(model.ApiKey, model.Password, model.ShopName);

            return Ok();
        }

        [HttpGet]
        [ResponseType(typeof(AuthenticationModel))]
        [Route("get-cridentials")]
        public IHttpActionResult GetCridentials()
        {
            var result = _shopifyAuthenticationService.GetSavedCridentials();

            return Ok(result);
        }
    }
}