public class Meeting
{
    public string Title { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public TimeOnly StartAt { get; set; }
    public TimeOnly EndAt { get; set; }
    public List<Employee> Participants { get; set; } = new();

     public override string ToString()
    {
        var participantsList = string.Join("\n", Participants.Select((p, i) => 
            $"\t\t{(i < Participants.Count - 1 ? "├" : "└")}─── {p}"));

        return $"\n\t┌ {Date:D} [{StartAt:hh:mm} - {EndAt:hh:mm}] '{Title}' ({Participants.Count}) participants" +
               $"\n\t└───────┐\n{participantsList}";
    }

     public override int GetHashCode() => 
        HashCode.Combine(Title, Date, StartAt, EndAt);
     public override bool Equals(object? obj) => 
        obj is Meeting other &&
        Title == other.Title &&
        Date == other.Date &&
        StartAt == other.StartAt &&
        EndAt == other.EndAt &&
        Participants.SequenceEqual(other.Participants);
}