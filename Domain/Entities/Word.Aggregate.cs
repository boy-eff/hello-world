
namespace Domain.Entities
{
    public partial class Word
    {
        public Word(string value, string translation, WordCollection wordCollection)
        {
            Value = value;
            Translation = translation;
            WordCollection = wordCollection;
            Dictionaries = new HashSet<WordDictionary>();
        }
    }
}