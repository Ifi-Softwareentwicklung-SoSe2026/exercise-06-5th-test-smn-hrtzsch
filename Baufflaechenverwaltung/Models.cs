namespace Baufflaechenverwaltung;

public class Bauflaeche
{
    public Bauflaeche(int id, string name, double groesse)
    {
        Id = id;
        Name = name;
        Groesse = groesse;
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Groesse { get; set; }
    public string Status { get; set; } = "frei";
    public string Bebaubarkeit { get; set; } = "ja";
}

public class Bauvorhaben
{
    public int Id { get; set; }
    public string Beschreibung { get; set; } = string.Empty;
    public string Status { get; set; } = "geplant";
}
