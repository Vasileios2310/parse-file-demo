using CsvHelper.Configuration;

namespace CcvParserDemo;

public class ReportReadMap : ClassMap<Report>
{
    public ReportReadMap()
    {
        Map(r => r.Id).Name("ID");
        Map(r => r.Details).Name("Report_Details");
        Map(r => r.CreatedBy).Name("Creator");
        Map(r => r.RevenueInUsd).Name("Revenue");
        Map(r => r.Acceptance).Name("Acceptance_Object").TypeConverter<Converter<Acceptance>>();
    }
} 