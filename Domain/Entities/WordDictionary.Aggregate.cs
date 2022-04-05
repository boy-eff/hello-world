namespace Domain.Entities
{
    public partial class WordDictionary
    {
        public WordDictionary(User owner)
        {
            Owner = owner;
            Words = new HashSet<Word>();
        }
    }
}