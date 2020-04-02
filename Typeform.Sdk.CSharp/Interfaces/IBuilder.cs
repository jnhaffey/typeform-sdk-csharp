namespace Typeform.Sdk.CSharp.Interfaces
{
    public interface IBuilder<out TResult>
    {
        /// <summary>
        ///     Generates the final model and returns it.
        /// </summary>
        /// <returns></returns>
        TResult Build();
    }
}