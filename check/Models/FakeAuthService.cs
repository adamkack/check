
namespace check.Models
{
    public class FakeAuthService
    {
        public string? CurrentUser { get; private set; }

        public event Action? OnChange;

        public void Login(string username)
        {
            CurrentUser = username;
            NotifyStateChanged();
        }

        public void Logout()
        {
            Console.WriteLine("FakeAuthService.Logout called");
            CurrentUser = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
        
    }
}
