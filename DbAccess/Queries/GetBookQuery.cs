using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.Queries
{
    public class GetBookQuery //ten obiekt sie parametryzuje i z bazy danych wyciaga
        //potrzebne informacje
        // jest to lepsze niz zwykły CRUD bo nie rosnie tu 
        // kaskadowo ilosc metod do napisania aby wykonać 
        // zapytanie o pojedyncza rzecz z bazy
        // w CRUD zwykle jedna metoda do wyszukania np. 
        // po tytule w bazie danych, osobna metoda do wyszukania po autorze itd
        // [przy wiekszej ilosci wyszukiwan robi się to nieoptymalne

        // tutaj jesli chce wykonac searcha to Title to ustawiam tylko pole title
        // i wykonuje zapytanie do bazy danych
        // jesli chce miec zapytanie po title i autorze to 
        // rowniez to jest lepsze rozwiazanie niz CRUD
        // bo ustawiam te dwa pola i obsluguje wyszukiwanie potem w handlerze :)
        // MAGIC!!!
    {
        public int? BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
    }
}
