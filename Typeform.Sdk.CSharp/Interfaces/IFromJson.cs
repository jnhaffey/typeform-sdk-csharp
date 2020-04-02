namespace Typeform.Sdk.CSharp.Interfaces
{
    public interface IFromJson<out TModel>
    {
        TModel CreateFromJson(string jsonData);
    }
}