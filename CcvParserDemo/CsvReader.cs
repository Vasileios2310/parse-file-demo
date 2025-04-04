using System.Globalization;
using CsvHelper.Configuration;

namespace CcvParserDemo;

public static class CsvReader
{
    public static void ReadCsvFile()
    {
        var conf = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            NewLine = Environment.NewLine,
            Delimiter = ";",
            HeaderValidated = null,
            MissingFieldFound = null,
            BadDataFound = null,
        };
        
       using var reader = new StreamReader("/Users/vasiliskr/Desktop/testfile.csv");
       using var csv = new CsvHelper.CsvReader(reader, conf);

       var firstlines = reader.ReadLine();
       Console.WriteLine("HEADERS"+ firstlines);

       csv.Context.RegisterClassMap<ReportReadMap>();
       var records = csv.GetRecords<Report>();

       foreach (var record in records)
       {
           Console.WriteLine($"{nameof(record.Id)}: {record.Id} , {nameof(record.Details)} : {record.Details} , {nameof(record.CreatedBy)} : {record.CreatedBy}");
           Console.WriteLine($"{nameof(record.Acceptance)}: {nameof(Acceptance.AcceptedBy)}: {record.Acceptance.AcceptedBy}");
       }
    }
}
