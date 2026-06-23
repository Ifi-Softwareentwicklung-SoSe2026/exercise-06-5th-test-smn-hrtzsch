using Baufflaechenverwaltung;

if (args.Length == 0)
{
    Console.WriteLine("Bitte nutzen Sie 'sample' oder 'list'.");
    return;
}

var verwaltung = new Bauverwaltung();

if (args[0] == "sample")
{
    verwaltung.AddFlaeche(new Bauflaeche { Id = 1, Name = "Zentrum A", Groesse = 500.5, Status = "frei" });
    verwaltung.AddFlaeche(new Bauflaeche { Id = 2, Name = "Nordrand B", Groesse = 1200.0, Status = "reserviert" });
    verwaltung.AddVorhaben(new Bauvorhaben { Id = 101, Beschreibung = "Wohnkomplex Nord", Status = "in Bearbeitung" });
    Console.WriteLine("Beispieldaten wurden hinzugefügt.");
    verwaltung.ListAll();
}
else if (args[0] == "list")
{
    verwaltung.ListAll();
}
