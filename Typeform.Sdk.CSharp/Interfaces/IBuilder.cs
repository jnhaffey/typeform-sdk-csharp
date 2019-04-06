namespace Typeform.Sdk.CSharp.Interfaces
{
    public interface IBuilder<TResult>
    {
        /// <summary>
        /// Created the final model and returns it.
        /// </summary>
        /// <returns></returns>
        TResult Build();
    }
}
