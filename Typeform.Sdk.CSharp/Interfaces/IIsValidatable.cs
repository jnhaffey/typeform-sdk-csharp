using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace Typeform.Sdk.CSharp.Interfaces
{
    public interface IIsValidatable<TValidator, TModel> where TValidator
        : AbstractValidator<TModel>
    {
        /// <summary>
        ///     Validates the model.
        /// </summary>
        Task<bool> IsValid(CancellationToken token = default(CancellationToken));
    }
}