namespace News.Service
{
    public interface IUserService
    {
        void Login(string email, string password);
        void Logout();
    }
}