namespace HelloWorld.Domain.Entities
{
    public class WordToWordDictionary
    {
        public int WordId { get; set; }
        public Word Word { get; set; }
        public int WordDictionaryId { get; set; }
        public WordDictionary WordDictionary { get; set; }
    }
}