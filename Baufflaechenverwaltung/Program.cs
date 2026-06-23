using System;

namespace Baufflaechenverwaltung;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Bitte nutzen Sie 'sample' oder 'list' als Argument.");
            return;
        }

        var verwaltung = new Bauverwaltung();
        string command = args[0].ToLower();

        if (command == "sample")
        {
            verwaltung.AddFlaeche(new Bauflaeche { Id = 1, Name = "Zentralfläche A", Groesse = 1200.5, Status = "frei" });
            verwaltung.AddFlaeche(new Bauflaeche { Id = 2, Name = "Industriegebiet Nord", Groesse = 5000.0, Status = "reserviert" });
            verwaltung.AddVorhaben(new Bauvorhaben { Id = 101, Beschreibung = "Wohnkomplex Sonnenblick", Status = "geplant" });
            verwaltung.AddVorhaben(new Bauvorhaben { Id = 102, Beschreibung = "Logistikzentrum Ost", Status = "in Bearbeitung" });
            
            Console.WriteLine("Beispieldaten wurden hinzugefügt:");
            verwaltung.ListAll();
        }
        else if (command == "list")
        {
            verwaltung.ListAll();
        }
        else
        {
            Console.WriteLine($"Unbekannter Befehl: {command}");
        }
    }
}