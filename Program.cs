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

        Console.WriteLine("Enter the input (type 'exit' to quit): ");

        while (!exitRequested)
        {
            var input = Console.ReadLine();

            if (input?.ToLower() == "clear" || input?.ToLower() == "cls")
            {
                Console.Clear();
                Console.WriteLine("Enter the input (type 'exit' to quit): ");
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
                    foreach (var validationIssue in validationIssues)
                    {
                        Console.WriteLine(validationIssue);
                    }
                    continue;
                }

                var result = ProcessInput.GetOutput(input);

                if (result?.Any() != null)
                {
                    Console.WriteLine("Output: " + string.Join(",", result));
                }
            }
        }

        if (exitRequested)
        {
            Environment.Exit(0);
        }
    }
}