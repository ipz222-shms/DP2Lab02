using System.Security;

namespace SingletonLibrary;

public static class Authenticator
{
    private static bool _isAuthenticated = false;
    private static readonly string _login = "admin";
    private static string _password = "admin";

    public static bool Auth(string login, string password)
    {
        if (!login.Equals(_login, StringComparison.Ordinal))
            throw new ArgumentException("Unknown user!");
        if (!password.Equals(_password, StringComparison.Ordinal))
            throw new ArgumentException("Wrong password!");

        _isAuthenticated = true;
        return _isAuthenticated;
    }

    public static void Logout() => _isAuthenticated = false;

    public static bool IsAuth() => _isAuthenticated;

    public static bool ChangePassword(string oldPassword, string newPassword)
    {
        if (!_isAuthenticated)
            throw new SecurityException("Please, authenticate first!");
        if (!oldPassword.Equals(_password, StringComparison.Ordinal))
            throw new ArgumentException("Wrong password!");

        Logout();
        _password = newPassword;
        return true;
    }
}
