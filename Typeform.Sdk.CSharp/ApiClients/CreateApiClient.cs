using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models;
using Typeform.Sdk.CSharp.Models.Workspaces;

namespace Typeform.Sdk.CSharp.ApiClients
{
    /// <summary>
    ///     Typeform Create API Client.
    /// </summary>
    public sealed class CreateApiClient
    {
        private readonly string _accountPathSegment;
        private readonly string _apiKey;
        private readonly string _formUrlPathSegment;
        private readonly string _imageUrlPathSegment;
        private readonly ILogger<CreateApiClient> _logger;
        private readonly string _themeUrlPathSegment;
        private readonly string _workspaceUrlPathSegment;

        /// <summary>
        ///     Instantiate an instance of the Create API Client.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="logger"></param>
        public CreateApiClient(string apiKey, ILogger<CreateApiClient> logger = null)
        {
            _apiKey = apiKey;
            _logger = logger;
            _accountPathSegment = "me";
            _formUrlPathSegment = "forms";
            _imageUrlPathSegment = "images";
            _themeUrlPathSegment = "themes";
            _workspaceUrlPathSegment = "workspaces";
        }

        #region Account

        public void RetrieveAccount()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Form

        public void CreateForm()
        {
            throw new NotImplementedException();
        }

        public void RetrieveForms()
        {
            throw new NotImplementedException();
        }

        public void UpdateForm()
        {
            throw new NotImplementedException();
        }

        public void UpdateForm(string wholeForm)
        {
            throw new NotImplementedException();
        }

        public void RetrieveForm()
        {
            throw new NotImplementedException();
        }

        public void DeleteForm()
        {
            throw new NotImplementedException();
        }

        public void RetrieveCustomFormMessages()
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomMessages()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Image

        public void RetrieveImageBySize()
        {
            throw new NotImplementedException();
        }

        public void RetrieveBackgroundBySize()
        {
            throw new NotImplementedException();
        }

        public void RetrieveChoiceImageBySize()
        {
            throw new NotImplementedException();
        }

        public void CreateImage()
        {
            throw new NotImplementedException();
        }

        public void RetrieveImagesCollection()
        {
            throw new NotImplementedException();
        }

        public void RetrieveImage()
        {
            throw new NotImplementedException();
        }

        public void DeleteImage()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Theme

        public void CreateTheme()
        {
            throw new NotImplementedException();
        }

        public void RetrieveThemes()
        {
            throw new NotImplementedException();
        }

        public void RetrieveTheme()
        {
            throw new NotImplementedException();
        }

        public void UpdateTheme()
        {
            throw new NotImplementedException();
        }

        public void DeleteTheme()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Workspaces

        public async Task<QueryResponse<Workspace>> RetrieveWorkSpaces(QueryParameters queryParameters,
            CancellationToken token = default(CancellationToken))
        {
            var urlQuery = Constants.BaseUrl
                .AppendPathSegment(_workspaceUrlPathSegment)
                .SetQueryParams(queryParameters.GetQueryParametersForUrl())
                .WithOAuthBearerToken(_apiKey);
            _logger.LogDebug("Calling Url: {urlQuery}", urlQuery.Url);

            var apiResults = await urlQuery.GetAsync(token);
            _logger.LogDebug("Call Results: {@apiResults}", apiResults);

            if (apiResults.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<QueryResponse<Workspace>>(
                    await apiResults.Content.ReadAsStringAsync());

            if (apiResults.StatusCode == HttpStatusCode.Forbidden)
            {
                var errorResponse =
                    JsonConvert.DeserializeObject<ErrorResponse>(await apiResults.Content.ReadAsStringAsync());
                _logger.LogError("API call failed: {failureDetails}", errorResponse);
                throw new Exception(errorResponse.Description);
            }

            return null;
        }

        public void CreateWorkspace()
        {
            throw new NotImplementedException();
        }

        public void RetrieveWorkspace()
        {
            throw new NotImplementedException();
        }

        public void UpdateWorkspace()
        {
            throw new NotImplementedException();
        }

        public void DeleteWorkspace()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}