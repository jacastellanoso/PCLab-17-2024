internal class ProgramParte1
{
    private static void Main(string[] args)
    {     
        // Variables
        string snombre;
        string sedad;
        string scarrera;
        string scarne;

        //Solicitar al usuario datos
        Console.WriteLine("Ingrese su nombre");
        snombre = Console.ReadLine();

        Console.WriteLine("Ingrese su edad");
        sedad = Console.ReadLine();

        Console.WriteLine("Ingrese su carrera");
        scarrera = Console.ReadLine();

        Console.WriteLine("Ingrese su carné");
        scarne = Console.ReadLine();


        //Inicio de programa
        Console.WriteLine("Mi segundo programa");
        Console.WriteLine("Nombre: " +  snombre);
        Console.WriteLine("Edad: " + sedad);
        Console.WriteLine("Carrera: " +  scarrera);
        Console.WriteLine("Carné: " + scarne);

        Console.WriteLine("Es decir:");
        Console.WriteLine("Soy " + snombre + ", tengo " + sedad + " años y estudio la carrera de " + scarrera + " y mi número de carné es " + snombre);
        Console.ReadKey();
    }
}
