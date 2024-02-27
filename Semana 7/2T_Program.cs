using System;

class Program
{
    static void Main(string[] args)
    {
        // Solicitar al usuario la velocidad inicial
        Console.Write("Ingrese la velocidad inicial (m/s): ");
        double v0 = double.Parse(Console.ReadLine());

        // Solicitar al usuario la aceleración
        Console.Write("Ingrese la aceleración (m/s^2): ");
        double a = double.Parse(Console.ReadLine());

        // Solicitar al usuario el tiempo
        Console.Write("Ingrese el tiempo (s): ");
        double t = double.Parse(Console.ReadLine());

        // Calcular la velocidad final usando la fórmula proporcionada
        double vf = v0 + a * t;

        // Mostrar el resultado al usuario
        Console.WriteLine($"La velocidad final es: {vf} m/s");

        //PARTE 2
        Console.WriteLine("A continuación ejecutaré el segundo programa");

        // Solicitar al usuario la cantidad en quetzales
        Console.Write("Ingrese la cantidad en quetzales (0 - 999.99): ");
        double cantidad = double.Parse(Console.ReadLine());

        // Verificar que la cantidad esté en el rango permitido
        if (cantidad < 0 || cantidad > 999.99)
        {
            Console.WriteLine("La cantidad ingresada está fuera del rango permitido.");
            return;
        }

        // Convertir la cantidad a centavos para facilitar los cálculos
        int cantidadCentavos = (int)(cantidad * 100);

        // Calcular los billetes y monedas necesarios
        int billete100 = cantidadCentavos / 10000;
        cantidadCentavos %= 10000;

        int billete50 = cantidadCentavos / 5000;
        cantidadCentavos %= 5000;

        int billete20 = cantidadCentavos / 2000;
        cantidadCentavos %= 2000;

        int billete10 = cantidadCentavos / 1000;
        cantidadCentavos %= 1000;

        int billete5 = cantidadCentavos / 500;
        cantidadCentavos %= 500;

        int moneda1Quetzal = cantidadCentavos / 100;
        cantidadCentavos %= 100;

        int moneda25Centavos = cantidadCentavos / 25;
        cantidadCentavos %= 25;

        int moneda1Centavo = cantidadCentavos;

        // Mostrar los resultados
        Console.WriteLine($"Billetes de 100 quetzales: {billete100}");
        Console.WriteLine($"Billetes de 50 quetzales: {billete50}");
        Console.WriteLine($"Billetes de 20 quetzales: {billete20}");
        Console.WriteLine($"Billetes de 10 quetzales: {billete10}");
        Console.WriteLine($"Billetes de 5 quetzales: {billete5}");
        Console.WriteLine($"Monedas de 1 quetzal: {moneda1Quetzal}");
        Console.WriteLine($"Monedas de 25 centavos: {moneda25Centavos}");
        Console.WriteLine($"Monedas de 1 centavo: {moneda1Centavo}");
    }
}
