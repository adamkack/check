using check.Data;
using check.Models;
using Microsoft.EntityFrameworkCore;

public class FakeAuthService
{
    private readonly IDbContextFactory<checkContext> _contextFactory;

    public string? CurrentUser { get; private set; }

    public event Action? OnChange;

    private TaskCompletionSource<bool>? _loginCompletionSource;

    public FakeAuthService(IDbContextFactory<checkContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task Login(string username)
    {
        CurrentUser = username;
        NotifyStateChanged();

        using var context = _contextFactory.CreateDbContext();
        var session = new UserSession
        {
            Username = username,
            StartTime = DateTime.Now
        };
        context.UserSessions.Add(session);
        await context.SaveChangesAsync();

        _loginCompletionSource?.TrySetResult(true);
    }

    public Task WaitForLoginCompleteAsync()
    {
        _loginCompletionSource = new TaskCompletionSource<bool>();
        return _loginCompletionSource.Task;
    }

    public async Task Logout()
    {
        if (CurrentUser != null)
        {
            using var context = _contextFactory.CreateDbContext();
            var latestSession = await context.UserSessions
                .Where(s => s.Username == CurrentUser && s.EndTime == null)
                .OrderByDescending(s => s.StartTime)
                .FirstOrDefaultAsync();

            if (latestSession != null)
            {
                latestSession.EndTime = DateTime.Now;
                await context.SaveChangesAsync();
            }
        }

        CurrentUser = null;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
