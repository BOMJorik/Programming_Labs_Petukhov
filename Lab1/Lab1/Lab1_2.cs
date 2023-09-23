namespace Lab1;

public class Lab1_2
{
    public static void Second()
    {
        var isIntY = int.TryParse(Console.ReadLine(), out int y); // размер массива
        if (!isIntY || y <= 0)
        {
            throw new Exception("Недействительное значение размера массива.");
        }

        var isIntX = int.TryParse(Console.ReadLine(), out int x); // размер массива
        if (!isIntX || x <= 0)
        {
            throw new Exception("Недействительное значение размера массива.");
        }
        int [,] matrix = new int[y, x]; // двумерный массив
        Random rnd = new Random();
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {
                matrix [i, j] = rnd.Next(-100, 100);
                Console.Write(matrix [i, j] + " ");
            }
            Console.WriteLine("");
        }
        Console.WriteLine("");
        Console.WriteLine("Количество столбцов, не содержащих ни одного нулевого элемента: " + ZeroInY(matrix));
        Console.WriteLine("Расположение матрицы в соответствии с характеристикой:");
        Console.WriteLine("");
        RightQueue(matrix);
    }

    static int ZeroInY(int[,] v)
    {
        int k = 0;
        for (int j = 0; j < v.Length/(v.GetUpperBound(0)+1); j++)
        {
            for (int i = 0; i < (v.GetUpperBound(0)+1); i++)
            {
                if (v[i, j] == 0)
                {
                    break;
                }

                if (i == v.GetUpperBound(0))
                {
                    k += 1;
                }
            }
        }
        return k;
    }

    static void RightQueue(int[,] v)
    {
        int[] Count = new int [v.GetUpperBound(0) + 1];
        for (int i = 0; i < v.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < v.Length / (v.GetUpperBound(0) + 1); j++)
            {
                if ((v[i, j] > 0) & (v[i, j] % 2 == 0))
                {
                    Count[i] += v[i, j];
                }
            }
        }
        for (int c = 0; c < Count.Length; c++)
        {
            int i = Count.ToList().IndexOf(Count.Max());
            for (int j = 0; j < v.Length / (v.GetUpperBound(0) + 1); j++)
            {
                Console.Write(v[i, j] + " ");
            }
            Console.WriteLine("");
            Count[Count.ToList().IndexOf(Count.Max())] = -1;
        }
    }
}