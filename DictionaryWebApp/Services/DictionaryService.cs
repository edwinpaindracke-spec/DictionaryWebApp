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

        // Unified multi-language search
        public async Task<WordEntry?> SearchAsync(string word, string language = "en")
        {
            try
            {
                // You can change API URL depending on language if needed
                string url = language.ToLower() switch
                {
                    "es" => $"https://api.dictionaryapi.dev/api/v2/entries/es/{word}",
                    "fr" => $"https://api.dictionaryapi.dev/api/v2/entries/fr/{word}",
                    "de" => $"https://api.dictionaryapi.dev/api/v2/entries/de/{word}",
                    _ => $"https://api.dictionaryapi.dev/api/v2/entries/en/{word}"
                };

                // Fetch JSON as a document
                var document = await _http.GetFromJsonAsync<JsonElement[]>(url);

                if (document == null || document.Length == 0)
                    return null;

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
