namespace Baufflaechenverwaltung;

public class Bauflaeche
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Groesse { get; set; }
    public string Status { get; set; } = "frei";
}

public class Bauvorhaben
{
    public int Id { get; set; }
    public string Beschreibung { get; set; } = string.Empty;
    public string Status { get; set; } = "geplant";
}