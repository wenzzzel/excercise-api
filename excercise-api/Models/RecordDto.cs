namespace excercise_api.Models;

public class RecordDto
{
    public int? Id { get; set; }
    public decimal? Weight { get; set; }
    public decimal? BodyFat { get; set; }
    public decimal? FatMass { get; set;}
    public decimal? LeanMass { get; set; }
    public DateTime? Timestamp { get; set; }
}
