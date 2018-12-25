namespace News.Repositories
{
    public interface IUserService
    {
        void Login(string email, string password);
        void Logout();
    }
}