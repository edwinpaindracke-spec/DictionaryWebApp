namespace DictionaryWebApp.Models
{
    public class WordEntry
    {
        public string Word { get; set; }
        public string Definition { get; set; }
        public string PartOfSpeech { get; set; }
        public List<string> Examples { get; set; } = new();
        public List<string> Synonyms { get; set; } = new();
        public List<string> Antonyms { get; set; } = new();
    }
}
