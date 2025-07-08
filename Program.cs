using System.Text.RegularExpressions;

namespace DK2_EasySupplySetter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dir = Directory.GetCurrentDirectory();

            int newSupply = 1;
            Console.WriteLine("Enter the new supply value (press enter for default 1): ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "":
                    break;
                default:
                    if (int.TryParse(input, out int parsedValue))
                    {
                        newSupply = parsedValue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Using default supply value of 1.");
                    }
                    break;
            }

            string confirmInput;
            Console.WriteLine($"Confirm changing all supply to {newSupply} (y/n)?");
            confirmInput = Console.ReadLine()?.ToLower();

            switch (confirmInput)
            {
                case "n":
                    Console.WriteLine("Operation cancelled.");
                    return;
                case "y":
                    Console.WriteLine($"Changing all supply to {newSupply}...");
                    break;
            }

            foreach (string file in Directory.GetFiles(dir, "*unit*.xml", SearchOption.AllDirectories))
            {
                string[] lines = File.ReadAllLines(file);
                bool fileChanged = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    string pattern = @"supply=""[^""]*""";
                    string replacement = $"supply=\"{newSupply}\"";

                    string updatedLine = Regex.Replace(lines[i], pattern, replacement);

                    if (updatedLine != lines[i])
                    {
                        lines[i] = updatedLine;
                        fileChanged = true;
                    }
                }

                if (fileChanged)
                {
                    File.WriteAllLines(file, lines);
                    Console.WriteLine($"Updated supply values in: {file}");
                }
            }
        }
    }
}
