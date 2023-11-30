using System;
namespace Console_Lab2;

public interface ICalculator
{
    int Degree { get; set; }
    List<double> Coefficients { get; set; }
    string ResultEquation { get; set; }
    List<double> Solutions { get; set; }
}