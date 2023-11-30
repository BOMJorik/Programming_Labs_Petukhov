namespace Console_Lab2;

class Program
{
     static void Main(string[] args)
     {
         IDisplay view = new Display();
         StartProgramm controller = new Equation(view);
         controller.Run();
     }
}