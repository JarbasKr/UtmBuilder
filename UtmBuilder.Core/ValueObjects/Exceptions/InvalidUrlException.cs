using System.Text.RegularExpressions;

namespace UtmBuilder.Core.ValueObjects.Exceptions;

public partial class InvalidUrlException : Exception
{
    private const string DefaultErrorMessage = "Invalid URL";

    public InvalidUrlException (string message = DefaultErrorMessage) : base(message)
    {

    }

    public static void ThrowIfInvalidUrl(string address, string message = DefaultErrorMessage){
        if (string.IsNullOrEmpty(address)){
            throw new InvalidUrlException(message);
        }

        if (!UrlRegex().IsMatch(address)){
            throw new InvalidUrlException(message);
        }
    }

    [GeneratedRegex(pattern:"^(http|https):(\\/\\/)")]
    private static partial Regex UrlRegex();
}