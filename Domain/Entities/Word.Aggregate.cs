
namespace Domain.Entities
{
    public partial class Word
    {
        private Word()
        {
            
        }
        public Word(string value, string translation, WordCollection wordCollection)
        {
            Value = value;
            Translation = translation;
            WordCollection = wordCollection;
            WordDictionaries = new HashSet<WordDictionary>();
        }
    }
}