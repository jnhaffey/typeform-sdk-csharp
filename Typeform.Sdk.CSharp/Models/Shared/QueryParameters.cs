namespace Typeform.Sdk.CSharp.Models.Shared
{
    public class QueryParameters
    {
        private QueryParameters()
        {
        }

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
        /// <param name="page">The page of results to retrieve. Default 1 is the first page of results. Minimum is 1.</param>
        /// <param name="pageSize">Number of results to retrieve per page. Default is 10. Minimum is 1. Maximum is 200.</param>
        /// <returns></returns>
        public static QueryParameters Create(int page = 1, int pageSize = 10)
        {
            return new QueryParameters().SetPage(page).SetPageSize(pageSize);
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
    }
}