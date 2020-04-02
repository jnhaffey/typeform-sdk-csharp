namespace Typeform.Sdk.CSharp.Interfaces
{
    public interface IModifier<out TResult>
    {
        /// <summary>
        ///     Generates the final model and returns it.
        /// </summary>
        /// <returns></returns>
        TResult Modify();
    }
}