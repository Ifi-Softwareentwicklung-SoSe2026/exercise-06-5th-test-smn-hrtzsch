using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Baufflaechenverwaltung;

public class Bauverwaltung
{
    private readonly List<Bauflaeche> _flaechen = new();
    private readonly List<Bauvorhaben> _vorhaben = new();

    public void AddFlaeche(Bauflaeche flaeche)
    {
        _flaechen.Add(flaeche);
    }

    public void AddVorhaben(Bauvorhaben vorhaben)
    {
        _vorhaben.Add(vorhaben);
    }

    public bool BebaubarkeitPruefen(int flaechenId)
    {
        var flaeche = _flaechen.Find(f => f.Id == flaechenId);
        return flaeche is not null
            && flaeche.Status.Equals("frei", StringComparison.OrdinalIgnoreCase)
            && !flaeche.Bebaubarkeit.Equals("nein", StringComparison.OrdinalIgnoreCase);
    }

    public bool ReserviereFlaeche(int flaechenId)
    {
        if (!BebaubarkeitPruefen(flaechenId))
        {
            return false;
        }

        var flaeche = _flaechen.Find(f => f.Id == flaechenId)!;
        flaeche.Status = "reserviert";
        return true;
    }

    public void ListAll()
    {
        Console.WriteLine("--- Bauflächen ---");
        foreach (var f in _flaechen)
        {
            Console.WriteLine($"ID: {f.Id}, Name: {f.Name}, Größe: {f.Groesse}m², Status: {f.Status}, Bebaubarkeit: {f.Bebaubarkeit}");
        }
        Console.WriteLine("\n--- Bauvorhaben ---");
        foreach (var v in _vorhaben)
        {
            Console.WriteLine($"ID: {v.Id}, Beschreibung: {v.Beschreibung}, Status: {v.Status}");
        }
    }

    public void SaveToJson(string filePath)
    {
        var data = new { Flaechen = _flaechen, Vorhaben = _vorhaben };
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    public void LoadFromJson(string filePath)
    {
        if (!File.Exists(filePath)) return;
        string json = File.ReadAllText(filePath);
        var data = JsonSerializer.Deserialize<PersistenceData>(json);
        if (data != null)
        {
            _flaechen.Clear();
            _flaechen.AddRange(data.Flaechen ?? new List<Bauflaeche>());
            _vorhaben.Clear();
            _vorhaben.AddRange(data.Vorhaben ?? new List<Bauvorhaben>());
        }
    }

    private class PersistenceData
    {
        public List<Bauflaeche>? Flaechen { get; set; }
        public List<Bauvorhaben>? Vorhaben { get; set; }
    }
}