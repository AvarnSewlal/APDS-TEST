public class Node
{
    public string Track { get; set; }
    public Node Next { get; set; }
    public Node Prev { get; set; }

    public Node(string track)
    {
        Track = track;
        Next = null;
        Prev = null;
    }
}
