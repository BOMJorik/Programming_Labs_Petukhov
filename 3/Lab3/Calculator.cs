namespace Lab3;
public class Calculator : ICalculator
{
    public int Degree { get; set; }
    public List<double> Coefficients { get; set; }
    public string ResultEquation { get; set; }
    public List<double> Solutions { get; set; }
}
