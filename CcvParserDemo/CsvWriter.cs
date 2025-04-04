using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace CcvParserDemo;

public static class CsvWriter
{
    public static void WriteToCsv()
    {
        var reports = new List<Report>
        {
            new Report
            {
                Id = 5,
                Details = "Special report",
                CreatedBy = "Vasiliskr",
                RevenueInUsd = 1000,
                Acceptance = new Acceptance
                {
                    AcceptedBy = "John Doe",
                    AcceptanceNote = "Correct report"
                }
            },
            new Report
            {
                Id = 2,
                Details = "Special2 report2",
                CreatedBy = "Vasiliskr2",
                RevenueInUsd = 1000,
                Acceptance = new Acceptance
                {
                    AcceptedBy = "John Doe2",
                    AcceptanceNote = "Correct report2"
                }
            }
        };

        var conf = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            NewLine = Environment.NewLine,
            Delimiter = ";",
        };

        using var stream = new StreamWriter("/Users/vasiliskr/Desktop/testfilefromWriter.csv");
        using var csv = new CsvHelper.CsvWriter(stream, conf);
        csv.WriteRecords(reports);
    }
}