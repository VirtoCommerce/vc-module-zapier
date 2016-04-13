using System;
using System.Net;
using Altsoft.ShopifyImportModule.Web.Interfaces;
using Altsoft.ShopifyImportModule.Web.Models;
using VirtoCommerce.Platform.Core.Settings;

namespace Altsoft.ShopifyImportModule.Web.Services
{
    public class ShopifyAuthenticationService:IShopifyAuthenticationService
    {
        private const string ApiKeyKeyName = "Altsoft.ShopifyImport.Credentials.APIKey";
        private const string PasswordKeyName = "Altsoft.ShopifyImport.Credentials.Password";
        private const string ShopNameKeyName = "Altsoft.ShopifyImport.Credentials.ShopName";

        private readonly ISettingsManager _settingsManager;
        public ShopifyAuthenticationService(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }


        public ICredentials GetCridentials()
        {
            var apiKey = _settingsManager.GetValue(ApiKeyKeyName, string.Empty);
            var password = _settingsManager.GetValue(PasswordKeyName, string.Empty);

            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("Api key is empty!");

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password is empty!");

            var result = new NetworkCredential(apiKey, password);

            return result;
        }

        public string GetShopName()
        {
            var result = _settingsManager.GetValue(ShopNameKeyName, string.Empty);

            return result;
        }

        public bool IsAuthenticated()
        {
            var apiKey = _settingsManager.GetValue(ApiKeyKeyName, string.Empty);
            var password = _settingsManager.GetValue(PasswordKeyName, string.Empty);
            var shopName = _settingsManager.GetValue(ShopNameKeyName, string.Empty);

            var isAuthenticated = !string.IsNullOrWhiteSpace(apiKey) &&
                                  !string.IsNullOrWhiteSpace(password) &&
                                  !string.IsNullOrWhiteSpace(shopName);

            if (isAuthenticated)
            {
                isAuthenticated = IsProperCridentials();
            }

            return isAuthenticated;
        }

        private bool IsProperCridentials()
        {
            var result = true;
            try
            {
                var shopName = GetShopName();
                var param = "products.json";
                var requestUrl =  string.Format("https://{0}.myshopify.com/admin/{1}", shopName, param);
                var cridentials = GetCridentials();
                using (var webClient = new WebClient())
                {
                    webClient.Credentials = cridentials;

                    var json = webClient.DownloadString(requestUrl);
                }
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }

        public void Authenticate(string apiKey, string password, string shopName)
        {
            _settingsManager.SetValue(ApiKeyKeyName, apiKey);
            _settingsManager.SetValue(PasswordKeyName, password);
            _settingsManager.SetValue(ShopNameKeyName, shopName);
        }

        public AuthenticationModel GetSavedCridentials()
        {
            var apiKey = _settingsManager.GetValue(ApiKeyKeyName, string.Empty);
            var password = _settingsManager.GetValue(PasswordKeyName, string.Empty);
            var shopName = _settingsManager.GetValue(ShopNameKeyName, string.Empty);

            var result = new AuthenticationModel {ApiKey = apiKey, Password = password, ShopName = shopName};

            return result;
        }
    }
}