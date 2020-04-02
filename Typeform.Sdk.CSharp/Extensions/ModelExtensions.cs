using Typeform.Sdk.CSharp.Interfaces;

namespace Typeform.Sdk.CSharp.Extensions
{
    internal static class ModelExtensions
    {
        internal static bool IsNew<TModel>(this TModel model)
            where TModel : IHasId
        {
            return string.IsNullOrWhiteSpace(model.Id);
        }
    }
}