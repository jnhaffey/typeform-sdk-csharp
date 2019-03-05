using System.Collections.Generic;

namespace Typeform.Sdk.CSharp.Models
{
    public class Logic
    {
        public Logic()
        {
            Actions = new List<Action>();
        }

        public string Type { get; set; }
        public string Ref { get; set; }
        public List<Action> Actions { get; set; }
    }
}