using System.ComponentModel;

Dictionary<Type, string> types = new()
{
    { typeof(byte), "byte" },
    { typeof(sbyte), "sbyte" },
    { typeof(short), "short" },
    { typeof(ushort), "ushort" },
    { typeof(int), "int" },
    { typeof(uint), "uint" },
    { typeof(long), "long" },
    { typeof(ulong), "ulong" },
    { typeof(float), "float" },
    { typeof(double), "double" },
};

try
{
    if (args.Length == 1)
    {
        double.Parse(args[0]);
        for (int i = 0; i < types.Count; i++)
        {
            KeyValuePair<Type, string> type = types.ElementAt(i);
            if (tryConvert(type.Key, args[0]))
            {
                Console.WriteLine($"{i + 1}. {type.Value} - true");
            }
            else
            {
                double difference = getDifference(type.Key, args[0]);
                Console.WriteLine($"{i + 1}. {type.Value} - false (over limit = {difference})");
            }
        }
    } else
    {
        Console.WriteLine("Only one numeric argument is allowed!");
    }
} catch (FormatException)
{
    Console.WriteLine($"'{args[0]}' is not a number!");
}
finally
{
    waitEnter();
}

bool tryConvert(Type type, string input)
{
    try
    {
        TypeDescriptor.GetConverter(type).ConvertFromString(input);
        return true;
    }
    catch
    {
        return false;
    }
}

double getDifference(Type type, string input)
{
    double.TryParse(input, out double number);
    double maxValue = Convert.ToDouble(type.GetField("MaxValue")?.GetValue(type));
    double minValue = Convert.ToDouble(type.GetField("MinValue")?.GetValue(type));
    return number > 0 ? number - maxValue : number + minValue;
}

void waitEnter()
{
    Console.Write("\nPress 'Enter' to exit the programm...");
    while (Console.ReadKey().Key != ConsoleKey.Enter)
    {
    }
    Environment.Exit(0);
}