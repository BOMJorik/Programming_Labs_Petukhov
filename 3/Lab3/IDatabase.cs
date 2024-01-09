namespace Lab3;
using System.Collections.Generic;

public interface IDatabase
{
    void SaveResults(List<ICalculator> results, string fileName);
    List<ICalculator> LoadResults(string fileName);
    List<ICalculator> GetResults();
}
