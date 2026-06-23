using System;
using System.Collections.Generic;

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

    public void ListAll()
    {
        Console.WriteLine("--- Bauflächen ---");
        foreach (var f in _flaechen)
        {
            Console.WriteLine($"ID: {f.Id}, Name: {f.Name}, Größe: {f.Groesse}m², Status: {f.Status}");
        }
        Console.WriteLine("\n--- Bauvorhaben ---");
        foreach (var v in _vorhaben)
        {
            Console.WriteLine($"ID: {v.Id}, Beschreibung: {v.Beschreibung}, Status: {v.Status}");
        }
    }
}