using Lab1;

public class Lab1_1
{
    public static void Main(String[] args)
    {
        var isInt = int.TryParse(Console.ReadLine(), out int s); // размер массива
        if (!isInt || s <= 0)
        {
            throw new Exception("Размер массива имеет недействительное значение.");
        }
        double[] a = new double[s];
        Random rnd = new Random();
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = rnd.Next(-100, 100) / 10.0;
            Console.Write(a[i] + "  ");
        }

        Console.WriteLine("");
        Console.WriteLine("Сумма положительных элементов массива: " + Positive(a));
        Console.WriteLine("Произведение элементов массива, расположенных между максимальным по модулю и минимальным по модулю элементами: " +
                          Multiply(a));
        Console.WriteLine("");
        Lab1_2.Second();
    }

    static double Positive(double[] v)
        {
            double j = 0.0;
            foreach (double i in v)
            {
                if (i > 0)
                {
                    j += i;
                }
            }

            return double.Round(j, 1);
        }

        static double Multiply(double[] arr)
        {
            double[] b = new double[arr.Length];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = Math.Abs(arr[i]);
            }

            int maximum = b.ToList().IndexOf(b.Max());
            int minimum = b.ToList().IndexOf(b.Min());
            if (Math.Abs(maximum - minimum) == 1)
            {
                return 0;
            }
            else
            {
                double j = 1.0;
                int k = 0;
                for (int i = int.Min(minimum, maximum) + 1; i < int.Max(minimum, maximum); i++)
                {
                    j *= arr[i];
                    k += 1;
                }

                return double.Round(j, k);

            }
        }
}