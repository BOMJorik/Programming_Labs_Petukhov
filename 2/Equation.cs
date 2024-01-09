using System.IO.Enumeration;

namespace Console_Lab2;

public class Equation : StartProgramm
{
    private List<ICalculator> results;
    private IDisplay view;

    public Equation(IDisplay view)
    {
        this.results = new List<ICalculator>();
        this.view = view;
    }

    public void Run()
    {
        string action;

        do
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("solve - решить уравнение");
            Console.WriteLine("find - найти уравнение в памяти");
            Console.WriteLine("exit - выйти");

            action = Console.ReadLine().ToLower();

            switch (action)
            {
                case "solve":
                    Console.WriteLine("---------------------------");
                    ICalculator model = new Calculator();
                    // Ввод данных
                    Console.WriteLine("Выберите тип уравнения:");
                    Console.WriteLine("1 - kx + b = 0");
                    Console.WriteLine("2 - ax^2 + bx + c = 0");
                    model.Degree = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Введите коэффициенты (от a до {(model.Degree == 1 ? "b" : "c")}):");
                    model.Coefficients = new List<double>();
                    for (int i = 0; i <= model.Degree; i++)
                    {
                        Console.Write($"{(char)('a' + i)} = ");
                        model.Coefficients.Add(double.Parse(Console.ReadLine()));
                    }

                    // Решение уравнения
                    SolveEquation(model);
                    results.Add(model);
                    view.DisplayResult(model);
                    break;

                case "find":
                    Console.WriteLine("---------------------------");
                    // Вывод сохраненных результатов
                    Console.WriteLine("Сохраненные результаты:");
                    for (int i = 0; i < results.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {results[i].ResultEquation}");
                    }

                    // Поиск по порядковому номеру
                    Console.Write("Введите порядковый номер решения для вывода информации: ");
                    int index;
                    if (int.TryParse(Console.ReadLine(), out index) && index >= 1 && index <= results.Count)
                    {
                        view.DisplayResult(results[index - 1]);
                    }
                    else
                    {
                        Console.WriteLine("Решение с таким порядковым номером не найдено.");
                    }
                    Console.WriteLine("---------------------------");
                    break;

                case "exit":
                    Console.WriteLine("-------------покедова)))--------------");
                    break;

                default:
                    Console.WriteLine("Некорректная команда. Попробуйте еще раз.");
                    Console.WriteLine("---------------------------");
                    break;
            }

        } while (action != "exit");
    }

    private void SolveEquation(ICalculator model)
    {
        if (model.Degree == 1)
        {
            SolveLinearEquation(model);
        }
        else if (model.Degree == 2)
        {
            SolveQuadraticEquation(model);
        }
        else
        {
            Console.WriteLine("Поддерживаются уравнения только 1 и 2 степени.");
        }
    }

    private void SolveLinearEquation(ICalculator model)
    {
        double a = model.Coefficients[0];
        double b = model.Coefficients[1];

        if (a == 0)
        {
            Console.WriteLine("Уравнение вырождено.");
            return;
        }

        double solution = -b / a;
        model.ResultEquation = $"{a}x + {b} = 0";
        model.Solutions = new List<double> { solution };
    }

    private void SolveQuadraticEquation(ICalculator model)
    {
        double a = model.Coefficients[0];
        double b = model.Coefficients[1];
        double c = model.Coefficients[2];

        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            model.ResultEquation = $"{a}x^2 + {b}x + {c} = 0";
            model.Solutions = new List<double> { root1, root2 };
        }
        else if (discriminant == 0)
        {
            double root = -b / (2 * a);
            model.ResultEquation = $"{a}x^2 + {b}x + {c} = 0";
            model.Solutions = new List<double> { root };
        }
        else
        {
            Console.WriteLine("Уравнение не имеет действительных корней.");
        }
    }
}