namespace BlazorApp.Services;

public sealed class UnauthorizedApiException : Exception
{
    public UnauthorizedApiException()
        : base("Brak autoryzacji. Zaloguj się ponownie.")
    {
    }
}
