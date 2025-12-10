using DictionaryWebApp.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace DictionaryWebApp.Services
{
    public class DictionaryService
    {
        private readonly HttpClient _http;

        public DictionaryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<WordEntry?> SearchAsync(string word)
        {
            try
            {
                string url = $"https://api.dictionaryapi.dev/api/v2/entries/en/{word}";

                // Fetch JSON as a document
                var document = await _http.GetFromJsonAsync<JsonElement>(url);

                // Extract the definition safely
                string meaning =
                    document[0]
                    .GetProperty("meanings")[0]
                    .GetProperty("definitions")[0]
                    .GetProperty("definition")
                    .GetString() ?? "";

                return new WordEntry
                {
                    Word = word,
                    Definition = meaning
                };
            }
            catch
            {
                // API or parsing error → return null
                return null;
            }
        }
    }
}
