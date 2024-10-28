using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Graph.Authentication; // Include this for ClientCredentialProvider
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Diagnostics.CodeAnalysis;

namespace O365Apps
{
    internal class Program
    {
        private const string clientId = "MeghaS219"; //  Azure app client ID
        private const string tenantId = "MeghaTenent1"; //  Azure tenant ID
        private const string clientSecret = "Megsv9mn"; //  Azure app client secret

        static async Task Main(string[] args)
        {
            Console.Write("SharePoint Site URL: ");
            string siteUrl = Console.ReadLine();

            Console.Write("List Name: ");
            string listName = Console.ReadLine();

            Console.Write("Item ID: ");
            string itemId = Console.ReadLine();

            Console.Write("Updated Title: ");
            string updatedTitle = Console.ReadLine();

            try
            {
                // Authenticate and create Graph client
                var graphClient = GetGraphServiceClient();

                // Get the site ID from the URL
                var siteId = await GetSiteId(graphClient, siteUrl);

                // Update the list item
                await UpdateListItem(graphClient, siteId, listName, itemId, updatedTitle);

                Console.WriteLine($"Item updated successfully: Task ID {itemId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static GraphServiceClient GetGraphServiceClient()
        {
            IConfidentialClientApplication app = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithTenantId(tenantId)
                .WithClientSecret(clientSecret)
                .Build();

            var authProvider = new ClientCredentialProvider(app);
            return new GraphServiceClient(authProvider);
        }

        private static async Task<string> GetSiteId(GraphServiceClient graphClient, string siteUrl)
        {
            var uriParts = new Uri(siteUrl).AbsolutePath.Trim('/').Split('/');
            string siteName = uriParts.Length > 0 ? uriParts[0] : "";

            var site = await graphClient.Sites
                .GetByPath(siteName, "MeghaTenent1.sharepoint.com")
                .Request()
                .GetAsync();

            return site.Id;
        }

        private static async Task UpdateListItem(GraphServiceClient graphClient, string siteId, string listName, string itemId, string updatedTitle)
        {
            var listItem = new Microsoft.Graph.Models.ListItem
            {
                Fields = new Microsoft.Graph.Models.FieldValueSet
                {
                    AdditionalData = new Dictionary<string, object>
                    {
                        { "Title", updatedTitle }
                    }
                }
            };

            await graphClient.Sites[siteId].Lists[listName].Items[itemId]
                .Request()
                .UpdateAsync(listItem);
        }
    }

    internal class ClientCredentialProvider : IRequestAdapter
    {
        private IConfidentialClientApplication app;

        public ClientCredentialProvider(IConfidentialClientApplication app)
        {
            this.app = app;
        }

        public ISerializationWriterFactory SerializationWriterFactory => throw new NotImplementedException();

        public string? BaseUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<T?> ConvertToNativeRequestAsync<T>(RequestInformation requestInfo, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void EnableBackingStore(IBackingStoreFactory backingStoreFactory)
        {
            throw new NotImplementedException();
        }

        public Task<ModelType?> SendAsync<ModelType>(RequestInformation requestInfo, ParsableFactory<ModelType> factory, Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null, CancellationToken cancellationToken = default) where ModelType : IParsable
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ModelType>?> SendCollectionAsync<ModelType>(RequestInformation requestInfo, ParsableFactory<ModelType> factory, Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null, CancellationToken cancellationToken = default) where ModelType : IParsable
        {
            throw new NotImplementedException();
        }

        public Task SendNoContentAsync(RequestInformation requestInfo, Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ModelType?> SendPrimitiveAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] ModelType>(RequestInformation requestInfo, Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ModelType>?> SendPrimitiveCollectionAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] ModelType>(RequestInformation requestInfo, Dictionary<string, ParsableFactory<IParsable>>? errorMapping = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
