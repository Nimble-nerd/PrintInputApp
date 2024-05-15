namespace PrintInputApp;
internal static class ProcessInput
{

    /// <summary>
    /// Processes the input data.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>A list of intergers</returns>
    internal static List<int> GetNumbers(string input)
    {
        List<int> numbersToBePrinted = [];
        var ranges = input.Split(',');

        foreach (string range in ranges)
        {
            if (!range.Contains('-'))
            {
                if (numbersToBePrinted.Contains(int.Parse(range)))
                {
                    continue;
                }
                numbersToBePrinted.Add(int.Parse(range));
            }
            else
            {
                var rangOfInput = range.Split('-');

                if (rangOfInput.Length == 2)
                {
                    foreach (var item in GetNumberFromRange(rangOfInput))
                    {
                        if (!numbersToBePrinted.Contains(item))
                        {
                            numbersToBePrinted.Add(item);
                        }
                    }
                }
            }
        }

        return numbersToBePrinted.ToList();
    }
    /// <summary>
    /// Gets the number from range.
    /// </summary>
    /// <param name="rangOfInput">The rang of input.</param>
    /// <returns>A list of number based on the range of input i.e. 1-5</returns>
    private static IEnumerable<int> GetNumberFromRange(string[] rangOfInput)
    {
        if (!int.TryParse(rangOfInput[0], out int start)
            || !int.TryParse(rangOfInput[1], out int end))
        {
            return Array.Empty<int>();
        }
        if (start > end)
        {
            (start, end) = SwapIfStartIsGreater(start, end);
        }

        List<int> range = [];
        for (int i = start; i <= end; i++)
        {
            range.Add(i);
        }

        return range.AsEnumerable();
    }
    /// <summary>
    /// Swaps if start is greater than end.
    /// </summary>
    /// <param name="start">The start.</param>
    /// <param name="end">The end.</param>
    /// <returns>A swaped integer touple</returns>
    private static (int, int) SwapIfStartIsGreater(int start, int end)
    {
        return start > end ? (end, start) : (start, end);
    }
}