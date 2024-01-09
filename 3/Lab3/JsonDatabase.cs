namespace Lab3;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class JsonDatabase : IDatabase
{
    public void SaveResults(List<ICalculator> results, string fileName)
    {
        string json = JsonSerializer.Serialize(results);
        File.WriteAllText(fileName, json);
    }

    public List<ICalculator> LoadResults(string fileName)
    {
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<ICalculator>>(json);
        }
        return new List<ICalculator>();
    }
    public List<ICalculator> GetResults()
    {
        return new List<ICalculator>();
    }
}

