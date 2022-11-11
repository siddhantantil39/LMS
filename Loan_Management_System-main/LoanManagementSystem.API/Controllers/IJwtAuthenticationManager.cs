namespace LoanManagementSystem.API.Controllers
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string role);
    }
}
