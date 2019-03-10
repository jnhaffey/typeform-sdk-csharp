using System;
using System.Net;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Builders;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Exceptions;
using Typeform.Sdk.CSharp.Extensions;
using Typeform.Sdk.CSharp.Models.Accounts;
using Typeform.Sdk.CSharp.Models.Shared;
using Typeform.Sdk.CSharp.Models.Themes;
using Typeform.Sdk.CSharp.Models.Workspaces;
using static Typeform.Sdk.CSharp.Constants;

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
        /// <exception cref="AuthenticationException"></exception>
        /// <returns>Account details.</returns>
        public async Task<Account> RetrieveAccount(CancellationToken token = default(CancellationToken))
        {
            var urlQuery = BaseUrl
                .AppendPathSegment(_accountPathSegment)
                .WithOAuthBearerToken(_apiKey);
            _logger.LogUrlCall(urlQuery.Url);

            try
            {
                var apiResults = await urlQuery.GetAsync(token);
                _logger.DebugRawData(DebugNames.ApiResults, apiResults);
                _logger.DebugRawData(DebugNames.ApiContent, await apiResults.Content.ReadAsStringAsync());
                return JsonConvert.DeserializeObject<Account>(
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
        /// <param name="queryParameters">Query Parameters to use. (Page and Page Size)</param>
        /// <param name="token">Cancellation Token (Optional)</param>
        /// <exception cref="AuthenticationException">Thrown if unable to authenticate.</exception>
        /// <returns>Paginated List of Themes.</returns>
        public async Task<QueryResponse<Theme>> RetrieveThemes(QueryParameters queryParameters,
            CancellationToken token = default(CancellationToken))
        {
            var urlQuery = BaseUrl
                .AppendPathSegment(_themeUrlPathSegment)
                .SetQueryParams(queryParameters.GetQueryParametersForUrl())
                .WithOAuthBearerToken(_apiKey);
            _logger.LogUrlCall(urlQuery.Url);

            try
            {
                var apiResults = await urlQuery.GetAsync(token);
                _logger.DebugRawData(DebugNames.ApiResults, apiResults);
                _logger.DebugRawData(DebugNames.ApiContent, await apiResults.Content.ReadAsStringAsync());
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
        /// <param name="themeId">Typeform Id for a theme.</param>
        /// <param name="token">Cancellation Token (Optional)</param>
        /// <exception cref="AuthenticationException">Thrown if unable to authenticate.</exception>
        /// <exception cref="Exception"></exception>
        /// <returns>Single Theme.</returns>
        public async Task<Theme> RetrieveTheme(string themeId, CancellationToken token = default(CancellationToken))
        {
            Guard.ForNullOrEmptyOrWhitespace(themeId, nameof(themeId));

            var urlQuery = BaseUrl
                .AppendPathSegments(_themeUrlPathSegment, themeId)
                .WithOAuthBearerToken(_apiKey);
            _logger.LogUrlCall(urlQuery.Url);

            try
            {
                var apiResults = await urlQuery.GetAsync(token);
                _logger.DebugRawData(DebugNames.ApiResults, apiResults);
                _logger.DebugRawData(DebugNames.ApiContent, await apiResults.Content.ReadAsStringAsync());
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
        /// <param name="queryParametersWithSearch">Query Parameters to use. (Search Filter, Page and Page Size</param>
        /// <param name="token">Cancellation Token (Optional)</param>
        /// <exception cref="AuthenticationException">Thrown if unable to authenticate.</exception>
        /// <returns>Paginated List of Workspaces.</returns>
        public async Task<QueryResponse<Workspace>> RetrieveWorkSpaces(
            QueryParametersWithSearch queryParametersWithSearch,
            CancellationToken token = default(CancellationToken))
        {
            var urlQuery = BaseUrl
                .AppendPathSegment(_workspaceUrlPathSegment)
                .SetQueryParams(queryParametersWithSearch.GetQueryParametersForUrl())
                .WithOAuthBearerToken(_apiKey);
            _logger.LogUrlCall(urlQuery.Url);

            try
            {
                var apiResults = await urlQuery.GetAsync(token);
                _logger.DebugRawData(DebugNames.ApiResults, apiResults);
                _logger.DebugRawData(DebugNames.ApiContent, await apiResults.Content.ReadAsStringAsync());
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
        /// <param name="workspaceId">Typeform Id for a workspace.</param>
        /// <param name="token">Cancellation Token (Optional)</param>
        /// <exception cref="RecordNotFoundException">Thrown if no workspace can be found with the id provided.</exception>
        /// <exception cref="AuthenticationException">Thrown if unable to authenticate.</exception>
        /// <returns>Single Theme.</returns>
        public async Task<Workspace> RetrieveWorkspace(string workspaceId,
            CancellationToken token = default(CancellationToken))
        {
            Guard.ForNullOrEmptyOrWhitespace(workspaceId, nameof(workspaceId));

            var urlQuery = BaseUrl
                .AppendPathSegments(_workspaceUrlPathSegment, workspaceId)
                .WithOAuthBearerToken(_apiKey);
            _logger.LogUrlCall(urlQuery.Url);

            try
            {
                var apiResults = await urlQuery.GetAsync(token);
                _logger.DebugRawData(DebugNames.ApiResults, apiResults);
                _logger.DebugRawData(DebugNames.ApiContent, await apiResults.Content.ReadAsStringAsync());
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

        /// <summary>
        ///     Create a workspace.
        /// </summary>
        /// <param name="workspaceName">Name of the new workspace.</param>
        /// <param name="token">Cancellation Token (Optional)</param>
        /// <exception cref="AuthenticationException">Thrown if unable to authenticate.</exception>
        /// <returns>Single Theme.</returns>
        public async Task<Workspace> CreateWorkspace(string workspaceName,
            CancellationToken token = default(CancellationToken))
        {
            Guard.ForNullOrEmptyOrWhitespace(workspaceName, nameof(workspaceName));

            var urlQuery = BaseUrl
                .AppendPathSegments(_workspaceUrlPathSegment)
                .WithHeader("Content-Type","application/json")
                .WithOAuthBearerToken(_apiKey);
            _logger.LogUrlCall(urlQuery.Url);

            try
            {
                var createModel = new {name = workspaceName};
                var apiResults = await urlQuery.PostJsonAsync(createModel, token);
                _logger.DebugRawData(DebugNames.ApiResults, apiResults);
                _logger.DebugRawData(DebugNames.ApiContent, await apiResults.Content.ReadAsStringAsync());
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
            }
            catch (Exception ex)
            {
                _logger.LogError("An unknown error has occured. {exception}", ex);
                throw;
            }

            return null;
        }

        /// <summary>
        ///     Update a workspace.
        /// </summary>
        /// <param name="workspaceId">Unique ID for the workspace.</param>
        /// <param name="token">Cancellation Token (Optional)</param>
        /// <exception cref="AuthenticationException">Thrown if unable to authenticate.</exception>
        /// <exception cref="RecordNotFoundException">Thrown if no workspace can be found with the id provided.</exception>
        /// <returns></returns>
        public async Task UpdateWorkspace(WorkspaceUpdateBuilder builder,
            CancellationToken token = default(CancellationToken))
        {
            // TODO : Add Validation Check

            var urlQuery = BaseUrl
                .AppendPathSegments(_workspaceUrlPathSegment, builder.WorkspaceId)
                .WithOAuthBearerToken(_apiKey);
            _logger.LogUrlCall(urlQuery.Url);

            try
            {
                _logger.DebugRawData(DebugNames.JsonPatch, builder.ToJsonPatch());
                var apiResults = await urlQuery.PatchJsonAsync(builder.ToJsonPatch(), token);
                _logger.DebugRawData(DebugNames.ApiResults, apiResults);
                _logger.DebugRawData(DebugNames.ApiContent, await apiResults.Content.ReadAsStringAsync());
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
                    throw new RecordNotFoundException(RecordType.Workspace, builder.WorkspaceId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An unknown error has occured. {exception}", ex);
                throw;
            }
        }

        /// <summary>
        ///     Delete a workspace.
        /// </summary>
        /// <param name="workspaceId">Unique ID for the workspace.</param>
        /// <param name="token">Cancellation Token (Optional)</param>
        /// <exception cref="RecordNotFoundException">Thrown if no workspace can be found with the id provided.</exception>
        /// <exception cref="AuthenticationException">Thrown if unable to authenticate.</exception>
        public async Task DeleteWorkspace(string workspaceId,
            CancellationToken token = default(CancellationToken))
        {
            Guard.ForNullOrEmptyOrWhitespace(workspaceId, nameof(workspaceId));

            var urlQuery = BaseUrl
                .AppendPathSegments(_workspaceUrlPathSegment, workspaceId)
                .WithOAuthBearerToken(_apiKey);
            _logger.LogUrlCall(urlQuery.Url);

            try
            {
                var apiResults = await urlQuery.DeleteAsync(token);
                _logger.DebugRawData(DebugNames.ApiResults, apiResults);
                _logger.DebugRawData(DebugNames.ApiContent, await apiResults.Content.ReadAsStringAsync());
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
        }

        #endregion
    }
}