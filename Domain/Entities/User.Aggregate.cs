

namespace Domain.Entities
{
    public partial class User
    {
        private User()
        {
            
        }
        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            WordDictionary = new WordDictionary(this);
            WordCollections = new HashSet<WordCollection>();
        }
    }
}