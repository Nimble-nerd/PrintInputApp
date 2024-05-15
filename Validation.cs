using System.Text.RegularExpressions;

namespace PrintInputApp;
internal static class Validation
{
    /// <summary>
    /// Validate input params
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>A list of issues, if there are any</returns>
    internal static IReadOnlyCollection<string> IsValidInput(string input)
    {
        var validationIssues = new List<string>();

        if (string.IsNullOrEmpty(input))
        {
            validationIssues.Add("Input is empty.");
        }

        var inputData = input.Trim();

        var pattern = @"^(\d+(-\d+)?,)*\d+(-\d+)?$";

        bool IsInputValidated = true;

        if (!Regex.IsMatch(inputData, pattern))
        {
            IsInputValidated = false;
        }

        foreach (char c in inputData)
        {
            if (!char.IsDigit(c) && c != '-' && c != ',')
            {
                IsInputValidated = false;
                continue;
            }
        }

        if (!IsInputValidated)
        {
            validationIssues.Add("Input contains invalid data.");
        }

        if (inputData.Contains('-') &&
            !string.IsNullOrEmpty(ValdiateRangeInput(inputData)))
        {
            validationIssues.Add(ValdiateRangeInput(inputData));
        }
        return validationIssues.AsReadOnly();
    }

    private static string ValdiateRangeInput(string input)
    {
        var ranges = input.Split(',');
        foreach (var range in ranges)
        {
            if (!range.Contains('-'))
            {
                continue;
            }
            var parts = range.Split('-');
            //More validations can be added here
            if (parts.Length != 2 
                || parts[0] == "" 
                || parts[1] == "")
            {
                return "Input contains invalid characters in range data.";
            }
        }
        return string.Empty;
    }
}
