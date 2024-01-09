namespace Lab3;
class Program
{
    static void Main(string[] args)
    {
        ICalculator calculator = new Calculator();
        IDisplay display = new Display();
        IDatabase database = new JsonDatabase();
        var equation = new Equation(calculator, display, database);
        equation.Run();
    }
}
