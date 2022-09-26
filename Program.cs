using System.Data;
using System.Globalization;


DateTime now = DateTime.Now;

Console.WriteLine("Inserisci il nome dell'evento:");
string title = Console.ReadLine();

Console.WriteLine("Inserisci la data dell'evento (gg/mm/yyyy):");
DateTime eventDateTime = DateTime.Parse(Console.ReadLine());

Console.WriteLine("Inserisci il numero di posti totali:");
int maxCapacity = Convert.ToInt32(Console.ReadLine());

try
{
    SingleEvent singleEvent = new SingleEvent(title, eventDateTime, maxCapacity);

    Console.WriteLine("Quanti posti desideri prenotare?");
    int seatsToReserve = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Numero di posti prenotati: " + seatsToReserve);
    Console.WriteLine("Numero di posti disponibili: " + singleEvent.AvailableSeats());

    bool goAhead = true;

    while (goAhead)
    {
        Console.WriteLine("Vuoi disdire dei posti (si/no)?");
        string response = Console.ReadLine();
        switch (response)
        {
            case "si":
                Console.WriteLine("Indica il numero di posti da disdire:");
                int seatsToCancel = Convert.ToInt32(Console.ReadLine());
                singleEvent.CancelSeat(seatsToCancel);
                Console.WriteLine("Numero di posti prenotati: " + singleEvent.ReservedSeats);
                Console.WriteLine("Numero di posti liberi: " + singleEvent.AvailableSeats());
                break;

            case "no":
                Console.WriteLine("Ok va bene!");
                Console.WriteLine("Numero di posti prenotati: " + singleEvent.ReservedSeats);
                Console.WriteLine("Numero di posti disponibili: " + singleEvent.AvailableSeats());
                goAhead = false;
                break;
        }
    }
}
catch (EmptyTitle e)
{
    Console.WriteLine(e.Message);
}
catch (DateExeption e)
{
    Console.WriteLine(e.Message);
}
catch (MinCapacity e)
{
    Console.WriteLine(e.Message);
}
catch (CantReserveException e)
{
    Console.WriteLine(e.Message);
}
catch (CantCancelException e)
{
    Console.WriteLine(e.Message);
}
