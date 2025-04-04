using System.Text.Json;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CcvParserDemo;

public class Converter<T> : DefaultTypeConverter
{
    public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(text ?? "{}");
        }
        catch (JsonException)
        {
            Console.WriteLine("Faile to parse JSON in field" + text);
            return null;
        }
    }

    public override string? ConvertToString(object? value, IWriterRow row, MemberMapData memberMapData)
    {
        return JsonSerializer.Serialize(value);
    }
}