namespace Typeform.Sdk.CSharp.Models.Shared
{
    public class QueryParameters
    {
        private QueryParameters()
        {
        }

        /// <summary>
        ///     Search Filter to be used.
        /// </summary>
        public string SearchFilter { get; private set; }

        /// <summary>
        ///     Page to return.
        /// </summary>
        public int Page { get; private set; }

        /// <summary>
        ///     Total items per page.
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        ///     Create an instance of the Query Parameters Object.
        /// </summary>
        /// <param name="searchFilter">Filter items that contain the specified string.</param>
        /// <param name="page">The page of results to retrieve. Default 1 is the first page of results. Minimum is 1.</param>
        /// <param name="pageSize">Number of results to retrieve per page. Default is 10. Minimum is 1. Maximum is 200.</param>
        /// <returns></returns>
        public static QueryParameters Create(string searchFilter = "", int page = 1, int pageSize = 10)
        {
            return new QueryParameters().SetPage(page).SetPageSize(pageSize).SetSearchFilter(searchFilter);
        }

        /// <summary>
        ///     Number of results to retrieve per page. Minimum is 1. Maximum is 200.
        /// </summary>
        /// <param name="pageSize">Page Size</param>
        /// <returns></returns>
        public QueryParameters SetPageSize(int pageSize)
        {
            Guard.ForMinValue(pageSize, 1, nameof(pageSize));
            Guard.ForMaxValue(pageSize, 200, nameof(pageSize));
            PageSize = pageSize;
            return this;
        }

        /// <summary>
        ///     The page of results to retrieve. Default 1 is the first page of results. Minimum is 1.
        /// </summary>
        /// <param name="page">Page Number(</param>
        /// <returns></returns>
        public QueryParameters SetPage(int page)
        {
            Guard.ForMinValue(page, 1, nameof(page));
            Page = page;
            return this;
        }

        /// <summary>
        ///     Sets the search filter value.
        /// </summary>
        /// <param name="searchFilter"></param>
        /// <returns></returns>
        public QueryParameters SetSearchFilter(string searchFilter)
        {
            SearchFilter = searchFilter;
            return this;
        }

        /// <summary>
        ///     Clears the SearchFilter Filter.
        /// </summary>
        /// <returns></returns>
        public QueryParameters ClearSearchFilter()
        {
            SearchFilter = string.Empty;
            return this;
        }

        /// <summary>
        ///     Returns the object for setting Query Parameter Values in Flurl.
        /// </summary>
        /// <returns></returns>
        public object GetQueryParametersForUrl()
        {
            return new
            {
                search = SearchFilter,
                page = Page,
                page_size = PageSize
            };
        }
    }
}