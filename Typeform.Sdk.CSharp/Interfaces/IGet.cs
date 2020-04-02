using System.Threading.Tasks;

namespace Typeform.Sdk.CSharp.Interfaces
{
    public interface IGet<TResult>
    {
        Task<TResult> Get();
    }
}