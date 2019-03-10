using System;
using System.Net;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Exceptions;
using Typeform.Sdk.CSharp.Extensions;
using Typeform.Sdk.CSharp.Models.Accounts;
using Typeform.Sdk.CSharp.Models.Shared;
using Typeform.Sdk.CSharp.Models.Themes;
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

        /// <summary>
        ///     Retrieve your own account information.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="AuthenticationException"></exception>
        public async Task<Account> RetrieveAccount(CancellationToken token = default(CancellationToken))
        {
            var urlQuery = Constants.BaseUrl
                .AppendPathSegment(_accountPathSegment)
                .WithOAuthBearerToken(_apiKey);
            _logger.LogUrlCall(urlQuery.Url);

            var apiResults = await urlQuery.GetAsync(token);
            _logger.DebugRawData(apiResults);

            if (apiResults.IsSuccessStatusCode)
            {
                _logger.DebugRawData(await apiResults.Content.ReadAsStringAsync());
                return JsonConvert.DeserializeObject<Account>(
                    await apiResults.Content.ReadAsStringAsync());
            }

            if (apiResults.StatusCode == HttpStatusCode.Forbidden)
            {
                var errorResponse =
                    JsonConvert.DeserializeObject<ErrorResponse>(await apiResults.Content.ReadAsStringAsync());
                _logger.LogError("API call failed: {failureDetails}", errorResponse);
                throw new AuthenticationException(errorResponse.Description);
            }

            throw new Exception("Unknown Error");
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

        /// <summary>
        ///     Retrieves a list of descriptions for all themes in your Typeform account (public and private).
        ///     Themes are listed in reverse-chronological order based on the date you added them to your account.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="AuthenticationException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<QueryResponse<Theme>> RetrieveThemes(CancellationToken token = default(CancellationToken))
        {
            var urlQuery = Constants.BaseUrl
                .AppendPathSegment(_themeUrlPathSegment)
                .WithOAuthBearerToken(_apiKey);
            _logger.LogUrlCall(urlQuery.Url);

            try
            {
                var apiResults = await urlQuery.GetAsync(token);
                _logger.DebugRawData(apiResults);
                _logger.DebugRawData(await apiResults.Content.ReadAsStringAsync());
                return JsonConvert.DeserializeObject<QueryResponse<Theme>>(
                    await apiResults.Content.ReadAsStringAsync());
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == HttpStatusCode.Forbidden)
                {
                    var errorResponse =
                        JsonConvert.DeserializeObject<ErrorResponse>(await ex.Call.Response.Content
                            .ReadAsStringAsync());
                    _logger.LogError("API call failed: {@failureDetails}", errorResponse);
                    throw new AuthenticationException(errorResponse.Description);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An unknown error has occured. {exception}", ex);
                throw;
            }

            return null;
        }

        /// <summary>
        ///     Retrieves a theme in your Typeform account.
        /// </summary>
        /// <param name="themeId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="AuthenticationException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<Theme> RetrieveTheme(string themeId, CancellationToken token = default(CancellationToken))
        {
            Guard.ForNullOrEmptyOrWhitespace(themeId, nameof(themeId));

            var urlQuery = Constants.BaseUrl
                .AppendPathSegments(_themeUrlPathSegment, themeId)
                .WithOAuthBearerToken(_apiKey);
            _logger.LogUrlCall(urlQuery.Url);

            try
            {
                var apiResults = await urlQuery.GetAsync(token);
                _logger.DebugRawData(apiResults);
                _logger.DebugRawData(await apiResults.Content.ReadAsStringAsync());
                return JsonConvert.DeserializeObject<Theme>(
                    await apiResults.Content.ReadAsStringAsync());
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == HttpStatusCode.Forbidden)
                {
                    var errorResponse =
                        JsonConvert.DeserializeObject<ErrorResponse>(await ex.Call.Response.Content
                            .ReadAsStringAsync());
                    _logger.LogError("API call failed: {@failureDetails}", errorResponse);
                    throw new AuthenticationException(errorResponse.Description);
                }

                if (ex.Call.HttpStatus == HttpStatusCode.NotFound)
                {
                    var errorResponse =
                        JsonConvert.DeserializeObject<ErrorResponse>(await ex.Call.Response.Content
                            .ReadAsStringAsync());
                    _logger.LogError("API call failed: {@failureDetails}", errorResponse);
                    throw new RecordNotFoundException(RecordType.Theme, themeId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An unknown error has occured. {exception}", ex);
                throw;
            }

            return null;
        }

        public void CreateTheme()
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

        /// <summary>
        ///     Retrieve all workspaces in your account.
        /// </summary>
        /// <param name="queryParametersWithSearch"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="AuthenticationException"></exception>
        public async Task<QueryResponse<Workspace>> RetrieveWorkSpaces(
            QueryParametersWithSearch queryParametersWithSearch,
            CancellationToken token = default(CancellationToken))
        {
            var urlQuery = Constants.BaseUrl
                .AppendPathSegment(_workspaceUrlPathSegment)
                .SetQueryParams(queryParametersWithSearch.GetQueryParametersForUrl())
                .WithOAuthBearerToken(_apiKey);
            _logger.LogUrlCall(urlQuery.Url);

            try
            {
                var apiResults = await urlQuery.GetAsync(token);
                _logger.DebugRawData(apiResults);
                _logger.DebugRawData(await apiResults.Content.ReadAsStringAsync());
                return JsonConvert.DeserializeObject<QueryResponse<Workspace>>(
                    await apiResults.Content.ReadAsStringAsync());
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == HttpStatusCode.Forbidden)
                {
                    var errorResponse =
                        JsonConvert.DeserializeObject<ErrorResponse>(await ex.Call.Response.Content
                            .ReadAsStringAsync());
                    _logger.LogError("API call failed: {@failureDetails}", errorResponse);
                    throw new AuthenticationException(errorResponse.Description);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An unknown error has occured. {exception}", ex);
                throw;
            }

            return null;
        }

        /// <summary>
        ///     Retrieve a workspace.
        /// </summary>
        /// <param name="workspaceId"></param>
        /// <param name="token"></param>
        /// <exception cref="RecordNotFoundException"></exception>
        /// <exception cref="AuthenticationException"></exception>
        /// <returns></returns>
        public async Task<Workspace> RetrieveWorkspace(string workspaceId,
            CancellationToken token = default(CancellationToken))
        {
            Guard.ForNullOrEmptyOrWhitespace(workspaceId, nameof(workspaceId));

            var urlQuery = Constants.BaseUrl
                .AppendPathSegments(_workspaceUrlPathSegment, workspaceId)
                .WithOAuthBearerToken(_apiKey);
            _logger.LogUrlCall(urlQuery.Url);

            try
            {
                var apiResults = await urlQuery.GetAsync(token);
                _logger.DebugRawData(apiResults);
                _logger.DebugRawData(await apiResults.Content.ReadAsStringAsync());
                return JsonConvert.DeserializeObject<Workspace>(
                    await apiResults.Content.ReadAsStringAsync());
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == HttpStatusCode.Forbidden)
                {
                    var errorResponse =
                        JsonConvert.DeserializeObject<ErrorResponse>(await ex.Call.Response.Content
                            .ReadAsStringAsync());
                    _logger.LogError("API call failed: {@failureDetails}", errorResponse);
                    throw new AuthenticationException(errorResponse.Description);
                }

                if (ex.Call.HttpStatus == HttpStatusCode.NotFound)
                {
                    var errorResponse =
                        JsonConvert.DeserializeObject<ErrorResponse>(await ex.Call.Response.Content
                            .ReadAsStringAsync());
                    _logger.LogError("API call failed: {@failureDetails}", errorResponse);
                    throw new RecordNotFoundException(RecordType.Workspace, workspaceId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An unknown error has occured. {exception}", ex);
                throw;
            }

            return null;
        }

        public void CreateWorkspace()
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