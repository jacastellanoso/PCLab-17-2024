using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese el valor de N (mayor que 0):");
        int N = ValidarEnteroPositivo();

        // Serie a
        double sumaA = CalcularSerieA(N);
        Console.WriteLine("La suma de la serie a es: " + sumaA);

        // Serie b
        double sumaB = CalcularSerieB(N);
        Console.WriteLine("La suma de la serie b es: " + sumaB);

        // Serie c
        Console.WriteLine("Ingrese el valor de x:");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingrese el valor de a:");
        int a = ValidarEnteroPositivo();
        Console.WriteLine("Ingrese el valor de n:");
        int n = ValidarEnteroPositivo();

        double sumaC = CalcularSerieC(x, a, n);
        Console.WriteLine("La suma de la serie c es: " + sumaC);
    }

    static int ValidarEnteroPositivo()
    {
        int num;
        while (!int.TryParse(Console.ReadLine(), out num) || num <= 0)
        {
            Console.WriteLine("Por favor, ingrese un número entero mayor que 0:");
        }
        return num;
    }

    static double CalcularSerieA(int N)
    {
        double suma = 0;
        for (int i = 1; i <= N; i++)
        {
            suma += 1.0 / i;
        }
        return suma;
    }

    static double CalcularSerieB(int N)
    {
        double suma = 0;
        for (int i = 1; i <= N; i++)
        {
            suma += 1.0 / Math.Pow(2, i);
        }
        return suma;
    }

    static double CalcularSerieC(int x, int a, int n)
    {
        double suma = 0;
        for (int k = 0; k <= n; k++)
        {
            suma += (Math.Pow(x, k) * BinomialCoefficient(a, n - k)) / Math.Pow(n, k);
        }
        return suma;
    }

    static double BinomialCoefficient(int a, int b)
    {
        double result = 1;
        for (int i = 1; i <= b; i++)
        {
            result *= (a - (b - i)) / (double)i;
        }
        return result;
    }
}
