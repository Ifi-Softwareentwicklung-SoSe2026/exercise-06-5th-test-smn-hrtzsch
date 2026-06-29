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
            verwaltung.AddFlaeche(new Bauflaeche(1, "Zentralfläche A", 1200.5) { Status = "frei", Bebaubarkeit = "ja" });
            verwaltung.AddFlaeche(new Bauflaeche(2, "Industriegebiet Nord", 5000.0) { Status = "bebaut", Bebaubarkeit = "ja" });
            verwaltung.AddVorhaben(new Bauvorhaben { Id = 101, Beschreibung = "Wohnkomplex Sonnenblick", Status = "geplant" });
            verwaltung.AddVorhaben(new Bauvorhaben { Id = 102, Beschreibung = "Logistikzentrum Ost", Status = "in Bearbeitung" });

            Console.WriteLine(verwaltung.ReserviereFlaeche(1)
                ? "Fläche 1 wurde reserviert."
                : "Fläche 1 konnte nicht reserviert werden.");
            Console.WriteLine(verwaltung.ReserviereFlaeche(2)
                ? "Fläche 2 wurde reserviert."
                : "Fläche 2 konnte nicht reserviert werden, weil sie nicht bebaubar oder nicht frei ist.");
            
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
