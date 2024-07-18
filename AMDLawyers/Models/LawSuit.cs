namespace AMDLawyers.Models
{
    public class LawSuit
    {
        public int LawSuitId { get; set; }
        public string LawSuitType { get;} = null!;
        public string LawSuitNumber { get; set; } = null!;
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
        public bool Status { get; set; }
        public string? Note { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public bool Update { get; set; }
        public string UpdateMessage { get; set; } = null!;
    }
}
