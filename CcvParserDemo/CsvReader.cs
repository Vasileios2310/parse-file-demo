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
        // Opens and reads your CSV file
       using var reader = new StreamReader("/Users/vasiliskr/Desktop/testfile.csv");
       using var csv = new CsvHelper.CsvReader(reader, conf);

       // var firstlines = reader.ReadLine();
       // Console.WriteLine("HEADERS"+ firstlines);
       
       // Registers the ReportReadMap so CsvHelper knows how to map columns
       csv.Context.RegisterClassMap<ReportReadMap>();
       
       // Reads and deserializes the file into Report objects
       var records = csv.GetRecords<Report>();

       // Loops through each report and prints details, including nested Acceptance
       foreach (var record in records)
       {
           Console.WriteLine($"{nameof(record.Id)}: {record.Id} , {nameof(record.Details)} : {record.Details} , {nameof(record.CreatedBy)} : {record.CreatedBy}");
           Console.WriteLine($"{nameof(record.Acceptance)}: {nameof(Acceptance.AcceptedBy)}: {record.Acceptance.AcceptedBy}");
       }
    }
}
