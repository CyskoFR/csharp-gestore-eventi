public class Event
{
    public string Title
    {
        get
        {
            return Title;
        }
        set
        {
            if (Title == "")
            {
                throw new EmptyTitle("Il titolo non puó essere vuoto");
            }
            Title = value;
        }
    }
    public DateTime EventDateTime {
        get
        {
            return EventDateTime;
        }
        set
        {
            if (EventDateTime < DateTime.Now)
            {
                throw new DateExeption("La data inserita deve essere successiva alla data odierna");
            }
            EventDateTime = value;
        }
    }
    public int MaxCapacity {
        get
        {
            return MaxCapacity;
        }
        private set
        {
            if (MaxCapacity < 1)
            {
                throw new MinCapacity("La capienza massima deve essere un numero positivo");
            }
            MaxCapacity = value;
        }
    }
    public int ReservedSeats { get; private set; }

    public Event(string title, DateTime eventDateTime, int maxCapacity)
    {
        Title = title;
        EventDateTime = eventDateTime;
        MaxCapacity = maxCapacity;
        ReservedSeats = 0;
    }

    // Methods
    public int AvailableSeats()
    {
        return MaxCapacity - ReservedSeats; 
    }

    public void ReserveSeat(int seatsNumber)
    {
        if (ReservedSeats + seatsNumber > MaxCapacity || EventDateTime < DateTime.Now)
        {
            throw new CantReserveException("L'evento non ha piú posti disponibili o é scaduto");
        }
        ReservedSeats += seatsNumber;
    }

    public void CancelSeat(int seatsNumber)
    {
        if (ReservedSeats - seatsNumber < 0 || EventDateTime < DateTime.Now)
        {
            throw new CantCancelException("Non é possibile disdire i posti assegnati o l'evento é scaduto");
        }
        ReservedSeats -= seatsNumber;
    }

    public override string ToString()
    {
        string eventDateString = EventDateTime.ToString("dd/MM/yyyy");
        return $"{eventDateString} - {this.Title}";
    }
}

// Exceptions
public class EmptyTitle : Exception
{
    public EmptyTitle(string message) : base(message) { }
}
public class DateExeption : Exception
{
    public DateExeption(string message) : base(message) { }
}
public class MinCapacity : Exception
{
    public MinCapacity(string message) : base(message) { }
}
public class CantReserveException : Exception
{
    public CantReserveException(string message) : base(message) { }
}
public class CantCancelException : Exception
{
    public CantCancelException(string message) : base(message) { }
}
