namespace Domain.Entities
{
    public partial class WordCollection
    {
        private WordCollection()
        {
            
        }
        public WordCollection(ICollection<Word> words, User owner)
        {
            Words = words;
            Owner = owner;
        }
    }
}