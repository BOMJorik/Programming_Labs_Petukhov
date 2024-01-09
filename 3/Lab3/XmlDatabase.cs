namespace Lab3;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class XmlDatabase : IDatabase
{
    public void SaveResults(List<ICalculator> results, string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<ICalculator>));
        using (TextWriter writer = new StreamWriter(fileName))
        {
            serializer.Serialize(writer, results);
        }
    }

    public List<ICalculator> LoadResults(string fileName)
    {
        if (File.Exists(fileName))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ICalculator>));
            using (TextReader reader = new StreamReader(fileName))
            {
                return (List<ICalculator>)serializer.Deserialize(reader);
            }
        }
        return new List<ICalculator>();
    }

    public List<ICalculator> GetResults()
    {
        return new List<ICalculator>();
    }
}