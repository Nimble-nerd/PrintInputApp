using PrintInputApp;

class Program
{
    /// <summary>
    /// Defines the entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    static void Main(string[] args)
    {
        bool exitRequested = false;
        InitMessage();

        while (!exitRequested)
        {
            var input = Console.ReadLine();

            if (input?.ToLower() == "clear" || input?.ToLower() == "cls")
            {
                Console.Clear();
                InitMessage();
                continue;
            }

            if (input?.ToLower() == "exit")
            {
                Console.WriteLine("Exiting...");
                exitRequested = true;
            }
            else
            {
                //This is an attempt to seperate validation from the actual input processing.

                var validationIssues = Validation.IsValidInput(input);
                if (validationIssues.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Validation issues: ");
                    foreach (var validationIssue in validationIssues)
                    {
                        Console.WriteLine(validationIssue);
                    }
                    Console.WriteLine();
                    InitMessage();
                    continue;
                }

                var result = ProcessInput.GetNumbers(input);

                if (result?.Any() != null)
                {
                    Console.WriteLine("Output: " + string.Join(",", result));
                    Console.WriteLine();
                    Console.WriteLine();
                    InitMessage();
                }
            }
        }

        if (exitRequested)
        {
            Environment.Exit(0);
        }
    }

    static void InitMessage()
    {
        Console.WriteLine("Enter the input (type 'exit' to quit): ");
    }
}