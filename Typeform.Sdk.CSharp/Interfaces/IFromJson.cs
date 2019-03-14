namespace Typeform.Sdk.CSharp.Interfaces
{
    public interface IFromJson<out TModel>
    {
        TModel FromJson(string jsonData);
    }
}