using System.Threading.Tasks;

namespace Typeform.Sdk.CSharp.Interfaces
{
    public interface IPost<TResult>
    {
        Task<TResult> Post();
    }
}