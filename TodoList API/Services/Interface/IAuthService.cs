namespace TodoList_API.Services.Interface
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(string username, string password);
    }
}
