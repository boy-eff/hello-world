namespace Domain.Entities.Users
{
    public partial class User
    {
        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}