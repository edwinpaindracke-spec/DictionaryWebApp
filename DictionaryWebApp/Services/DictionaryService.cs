using DictionaryWebApp.Models;

namespace DictionaryWebApp.Services
{
    public class DictionaryService
    {
        private readonly List<WordEntry> _entries = new()
        {
            new WordEntry { Word = "apple", Definition = "A round fruit from an apple tree." },
            new WordEntry { Word = "computer", Definition = "An electronic device that processes data." }
        };

        public WordEntry? Search(string term)
        {
            return _entries.FirstOrDefault(w =>
                w.Word.Equals(term, StringComparison.OrdinalIgnoreCase));
        }
    }
}
