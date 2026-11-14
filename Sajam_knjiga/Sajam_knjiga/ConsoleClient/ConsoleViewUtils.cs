namespace Sajam_knjiga.ConsoleClient;

/*
 * Pomocne metode za siguran unos podataka iz konzole.
 * SafeInputInt preuzet sa vjezbi (CRUDExample, ConsoleViewUtils.cs).
 */
public static class ConsoleViewUtils
{
    public static int SafeInputInt()
    {
        string rawInput = Console.ReadLine() ?? string.Empty;
        int input;
        while (!int.TryParse(rawInput, out input))
        {
            Console.WriteLine("Neispravan broj, pokusajte ponovo: ");
            rawInput = Console.ReadLine() ?? string.Empty;
        }
        return input;
    }

    public static DateOnly SafeInputDate()
    {
        string rawInput = Console.ReadLine() ?? string.Empty;
        DateOnly input;
        while (!DateOnly.TryParseExact(rawInput, "dd.MM.yyyy", out input))
        {
            Console.WriteLine("Neispravan datum (format dd.MM.yyyy), pokusajte ponovo: ");
            rawInput = Console.ReadLine() ?? string.Empty;
        }
        return input;
    }

    public static string SafeInputString()
    {
        string input = Console.ReadLine() ?? string.Empty;
        while (input == string.Empty || input.Contains('|'))
        {
            Console.WriteLine("Unos ne smije biti prazan niti sadrzati znak '|', pokusajte ponovo: ");
            input = Console.ReadLine() ?? string.Empty;
        }
        return input;
    }

    public static int SafeInputStatus()
    {
        string rawInput = Console.ReadLine() ?? string.Empty;
        int input;
        while (!int.TryParse(rawInput, out input) || (input != 1 || input != 2))
        {
            Console.WriteLine("Neispravan unos, pokusajte ponovo: ");
            rawInput = Console.ReadLine() ?? string.Empty;
        }
        return input;
    }

    public static double SafeInputDouble()
    {
        string rawInput = Console.ReadLine() ?? string.Empty;
        double input;
        while (!double.TryParse(rawInput, out input))
        {
            Console.WriteLine("Neispravan broj, pokusajte ponovo: ");
            rawInput = Console.ReadLine() ?? string.Empty;
        }
        return input;
    }
}