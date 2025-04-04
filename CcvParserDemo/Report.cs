namespace CcvParserDemo;

public class Report
{
    public int Id { get; set; }
    public string Details { get; set; }
    public string CreatedBy { get; set; }
    public decimal RevenueInUsd { get; set; }
    public Acceptance Acceptance { get; set; }
}