using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class Variables
    {
        /// <summary>
        ///     Variable for keeping score as users answer each question (for example, for quizzes).
        /// </summary>
        [JsonProperty("score")]
        public int Score { get; set; }

        /// <summary>
        ///     Variable for tracking the total price of all items users select (for example, for shopping carts, donation
        ///     campaigns, and payment collections).
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}