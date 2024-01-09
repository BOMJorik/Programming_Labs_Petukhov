namespace Lab3;

public class Display: IDisplay
{
    public void DisplayResult(ICalculator model)
    {
        Console.WriteLine($"Уравнение: {model.ResultEquation}");
        Console.WriteLine("Решение(я):");
        foreach (var solution in model.Solutions)
        {
            Console.WriteLine(solution);
        }
    }
}