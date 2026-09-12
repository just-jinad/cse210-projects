using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        IncludeFields = true,
        WriteIndented = true
    };

    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

     public void SaveToFile(string filename)
    {
        string json = JsonSerializer.Serialize(_entries, _jsonOptions);
        File.WriteAllText(filename, json);
    }

    public void LoadFromFile(string filename)
    {
        string json = File.ReadAllText(filename);
        _entries = JsonSerializer.Deserialize<List<Entry>>(json, _jsonOptions) ?? new List<Entry>();
    }
}