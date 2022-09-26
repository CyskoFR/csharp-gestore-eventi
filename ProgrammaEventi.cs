public class ProgrammaEventi
{
    private string Title { get; set; }

    List<SingleEvent> EventList = new List<SingleEvent>();

    public ProgrammaEventi(string title)
    {
        Title = title;
        EventList = new List<SingleEvent>();
    }
    public void AddEvent(SingleEvent singleEvent)
    {
        EventList.Add(singleEvent);
    }
    public static void PrintList(List<SingleEvent> EventList)
    {
        Console.WriteLine("I tuoi eventi della serata:");
        foreach (SingleEvent singleEvent in EventList)
        {
            Console.WriteLine(singleEvent.ToString());
        }
    }
    //public List<SingleEvent> SearchForDate(DateTime date)
    //{
    //    List<SingleEvent> searchResults = EventList.FindAll(date);
    //    return searchResults;
    //}
    public int EventsCount()
    {
        return EventList.Count;
    }
    public void EmptyList()
    {
        EventList.Clear();
    }
    public string ProgramRecap()
    {
        Console.WriteLine("Info programma evento");
        string result = "";
        foreach (SingleEvent singleEvent in EventList)
        {
            result += $"{singleEvent.ToString()}\n";
        }
        return result;
    }
}