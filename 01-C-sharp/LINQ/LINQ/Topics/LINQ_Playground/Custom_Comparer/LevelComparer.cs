public class LevelComparer : IComparer<string>
{

    public int Compare(string? x, string? y)
    {
        if (x == null || y == null)
        {
            return 0;
        }
        var order = new Dictionary<string, int>
        {
            { "Junior", 1 },
            { "Mid",    2 },
            { "Senior", 3 }
        };
        return order[x].CompareTo(order[y]);
    }
}