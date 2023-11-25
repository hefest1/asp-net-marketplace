using FluentValidation.Results;
using System.Text.RegularExpressions;

namespace Extensions;

public static class ValidationExtensions
{
    public static bool IsValidEmail(this string str)
    {
        return Regex.IsMatch(str, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    public static bool HasLength(this string password)
    {
        return Regex.IsMatch(password, "^.{8,32}$");
    }

    public static bool HasUppercaseLetters(this string password)
    {
        return Regex.IsMatch(password, "^(?=.*?[A-Z])");
    }

    public static bool HasLowercaseLetters(this string password)
    {
        return Regex.IsMatch(password, "^(?=.*?[a-z])");
    }

    public static bool HasSpecialChars(this string password)
    {
        return Regex.IsMatch(password, "^(?=.*?[#?!@$%^&*-])");
    }

    public static bool HasNumbers(this string password)
    {
        return Regex.IsMatch(password, "^(?=.*?[0-9])");
    }

    public static Dictionary<string, string> GetFieldsErrorsMap(this ValidationResult validationResult)
    {
        var map = new Dictionary<string, string>();
        foreach (var field in validationResult.Errors)
        {
            map[field.PropertyName] = field.ErrorMessage;
        }

        return map;
    }
}