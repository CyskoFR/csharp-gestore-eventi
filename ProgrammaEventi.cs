public class ProgrammaEventi
{
    private string Title { get; set; }

    List<Event> EventList = new List<Event>();

    public ProgrammaEventi(string titolo)
    {
        Title = titolo;
        EventList = new List<Event>();
    }
    public void AddEvent(Event event)
    {
        EventList.Add(event);
    }
}