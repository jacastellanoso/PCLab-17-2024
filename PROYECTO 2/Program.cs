using System.Text.RegularExpressions;
/*
 Javier Alexander Castellanos Oliva - 1050324
 */
class Proyecto2_JavierCastellanos_1050324
{
    // Declaración de variables fuera de los métodos
    static string TipoDeCuenta;
    static string nombre;
    static string numdpi;
    static string numtelefono;
    static string direccion;
    static double nuevosb;
    static string tc;
    //Listado de transacciones para la opción 6 y los diversos usuarios
    static List<string> transacciones = new List<string>();
    static List<Usuario> usuarios = new List<Usuario>();

    // Método principal e inicio del programa
    static void Main(string[] args)
    {
        Console.WriteLine("BANCO COUNTRY BANK");
        Console.WriteLine("Sede en Ciudad de Guatemala");
        Console.WriteLine("");
        Console.WriteLine("Bienvenido, digite el número de opción que desea utilizar del siguiente menú.");
        Console.WriteLine("");

        bool menuMostrado = false;
        int tipo_de_cuenta;
        do
        {
            if (!menuMostrado)
            {
                Console.WriteLine("TIPO DE CUENTA");
                Console.WriteLine("1. Monetaria Quetzales - Q");
                Console.WriteLine("2. Monetaria Dólares - $");
                Console.WriteLine("3. Ahorro Quetzales - Q");
                Console.WriteLine("4. Ahorro Dólares - $");

                menuMostrado = true;
            }

            if (!int.TryParse(Console.ReadLine(), out tipo_de_cuenta) || tipo_de_cuenta < 1 || tipo_de_cuenta > 4)
            {
                Console.WriteLine("Opción no válida. Por favor, ingresa una opción válida.");
                continue;
            }

            switch (tipo_de_cuenta)
            {
                case 1:
                    Console.WriteLine("Ha seleccionado la opción 1 correctamente.");
                    Console.WriteLine("");
                    TipoDeCuenta = "Monetaria Quetzales";
                    tc = "Q";
                    break;
                case 2:
                    Console.WriteLine("Ha seleccionado la opción 2 correctamente.");
                    Console.WriteLine("");
                    TipoDeCuenta = "Monetaria Dólares";
                    tc = "$";
                    break;
                case 3:
                    Console.WriteLine("Ha seleccionado la opción 3 correctamente.");
                    Console.WriteLine("");
                    TipoDeCuenta = "Ahorro Quetzales";
                    tc = "Q";
                    break;
                case 4:
                    Console.WriteLine("Ha seleccionado la opción 4 correctamente.");
                    Console.WriteLine("");
                    TipoDeCuenta = "Ahorro Dólares";
                    tc = "$";
                    break;
            }
            
            Console.WriteLine("");
            Console.WriteLine("Ahora ingresa tu nombre: ");
            while (true)
            {
                nombre = Console.ReadLine();
                if (!Regex.IsMatch(nombre, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$"))
                {
                    Console.WriteLine("Error: El nombre no puede contener números ni signos. Por favor, ingrésalo nuevamente.");
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Ahora ingresa tu número de DPI (5 dígitos): ");
                numdpi = Console.ReadLine();
                if (!Regex.IsMatch(numdpi, @"^\d{5}$"))
                {
                    Console.WriteLine("Error: El número de DPI debe contener exactamente 5 dígitos y solo deben ser números. Por favor, ingrésalo nuevamente.");
                }
                else
                {
                    break;
                }
            }

            bool direccionCorrecta = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Ingresa tu dirección: ");
                string direcjav = Console.ReadLine();

                // Validar si la dirección ingresada está vacía o es solo un espacio en blanco
                if (string.IsNullOrWhiteSpace(direcjav))
                {
                    Console.WriteLine("Error: Debes ingresar una dirección válida.");
                }
                else
                {
                    if (EsDireccionValida(direcjav))
                    {
                        Console.WriteLine("Dirección guardada, pero hemos encontrado anomalías.");
                        Console.WriteLine("¿Está seguro de que esa es su dirección? (1: Sí, 2: No)");
                        string respuesta = Console.ReadLine();

                        if (respuesta == "1")
                        {
                            direccionCorrecta = true;
                            direccion = direcjav; // Solo asignar la dirección si el usuario confirma que es correcta
                        }
                        else if (respuesta == "2")
                        {
                            direccionCorrecta = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dirección inválida. Inténtalo de nuevo.");
                    }
                }
            } while (!direccionCorrecta);

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Ahora ingresa tu número de teléfono (8 dígitos): ");
                numtelefono = Console.ReadLine();
                if (!Regex.IsMatch(numtelefono, @"^\d{8}$"))
                {
                    Console.WriteLine("Error: El número de teléfono en Guatemala debe contener exactamente 8 dígitos sin contar el +502 y solo deben ser números. Por favor, ingrésalo nuevamente.");
                }
                else
                {
                    break;
                }
            }

            MenuPrincipal();

        } while (tipo_de_cuenta != 4);
    }

    static bool EsDireccionValida(string direccion)
    {
        return !Regex.IsMatch(direccion, @"[^\w\s]""^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$");
    }

    static void MenuPrincipal()
    {
        string opmenu;

        // Contadores de opciones
        int icveces = 0, cpfveces = 0, vpfveces = 0, aboveces = 0, tiempoveces = 0, rtveces = 0, mctveces = 0, taocveces = 0, pserveces = 0, impreveces = 0;
        
        //Sumas y resultados
        int SumaDeUno;
        SumaDeUno = 1;
        int resultado = 0;

        //SALDO BANCARIO
        nuevosb = 2500.00;


        do
        {
            MostrarMenu();
            opmenu = Console.ReadLine();

            if (!EsOpcionValida(opmenu))
            {
                Console.WriteLine("Error: Debes ingresar un número válido del menú.");
                continue;
            }

            int opcion = int.Parse(opmenu);

            switch (opcion)
            {
                case 1:
                    //Conteo de veces
                    icveces += SumaDeUno;
                    //Acciones completas
                    Console.WriteLine("");
                    Console.WriteLine("INFORMACIÓN DE CUENTA");
                    Console.WriteLine("");
                    Console.WriteLine("El propietario de la cuenta actual es " + nombre + " con el tipo de cuenta " + TipoDeCuenta);
                    Console.WriteLine("Número de DPI: " + numdpi);
                    Console.WriteLine("Dirección: " + direccion);
                    Console.WriteLine("Número de teléfono: " + numtelefono);
                    Console.WriteLine("El saldo actual es de " + tc + nuevosb);
                    Console.WriteLine("");
                    Console.WriteLine("REGISTRO DE ACCIONES");
                    Console.WriteLine("");
                    Console.WriteLine("1. Ver información de la cuenta - " + icveces + " veces se ha accionado.");
                    Console.WriteLine("2. Comprar producto financiero - " + cpfveces + " veces se ha accionado.");
                    Console.WriteLine("3. Vender producto financiero - " + vpfveces + " veces se ha accionado.");
                    Console.WriteLine("4. Abonar a cuenta - " + aboveces + " veces se ha accionado.");
                    Console.WriteLine("5. Simular paso de tiempo - " + tiempoveces + " veces se ha accionado.");
                    Console.WriteLine("6. Registro de transacciones - " + rtveces + " veces se ha accionado.");
                    Console.WriteLine("7. Mantenimiento de cuentas de terceros - " + mctveces + " veces se ha accionado.");
                    Console.WriteLine("8. Realizar transferencias a otras cuentas - " + taocveces + " veces se ha accionado.");
                    Console.WriteLine("9. Pago de servicios - " + pserveces + " veces se ha accionado.");
                    Console.WriteLine("10. Imprimir informe de transacciones - " + impreveces + " veces se ha accionado.");
                    Console.WriteLine("");
                    break;

                case 2:
                    //Conteo de veces
                    cpfveces += SumaDeUno;
                    //Acciones completas
                    nuevosb -= nuevosb * 0.10;
                    Console.WriteLine("Tu saldo actual ahora es de " + tc + nuevosb);
                    transacciones.Add("Compra de producto financiero. Saldo actual: " + tc + nuevosb);
                    break;
                case 3:
                    //Conteo de veces
                    vpfveces += SumaDeUno;
                    //Acciones completas
                    if (nuevosb > 500)
                    {
                        nuevosb += nuevosb * 0.11;
                        Console.WriteLine("Tu saldo actual ahora es de " + tc + nuevosb);
                        transacciones.Add("Venta de producto financiero. Saldo actual: " + tc + nuevosb);
                    }
                    else
                    {
                        Console.WriteLine("El monto actual no es suficiente para realizar esta operación.");
                    }
                    break;
                case 4:
                    //Conteo de veces
                    aboveces += SumaDeUno;
                    //Acciones completas
                    if (aboveces >= 3)
                    {
                        Console.WriteLine("Haz alcanzado la cantidad máxima de abonos para este mes.");
                        aboveces = 2;
                    }
                    else if (nuevosb > 2500)
                    {
                        Console.WriteLine("El monto actual no es suficiente para realizar esta operación.");
                    }
                    else
                    {
                        nuevosb += nuevosb * 2;
                        Console.WriteLine("Tu saldo actual ahora es de " + tc + nuevosb);
                        transacciones.Add("Abono a cuenta. Saldo actual: " + tc + nuevosb);
                    }
                    break;
                case 5:
                    // Acción para simular paso de tiempo
                    //Conteo de veces
                    if (opcion == 5)
                    {
                        resultado = resultado + tiempoveces + SumaDeUno;
                        tiempoveces += SumaDeUno;
                    }
                    //Acciones completas
                    Console.WriteLine("Escriba el número de opción de simulación de tiempo que desea realizar:");
                    Console.WriteLine("1. Una vez al mes");
                    Console.WriteLine("2. Dos veces al mes");
                    Console.Write("Elija una opción (1 o 2): ");

                    int seleccion;
                    if (!int.TryParse(Console.ReadLine(), out seleccion) || (seleccion != 1 && seleccion != 2))
                    {
                        Console.WriteLine("La opción seleccionada no es válida, vuelva a intentarlo.");
                    }
                    else
                    {
                        double tasaInteres = 0.02; // Tasa de interés del 2%

                        // Calcular el tiempo en meses
                        int tiempoMeses = 0;
                        switch (seleccion)
                        {
                            case 1:
                                tiempoMeses = 1;
                                break;
                            case 2:
                                tiempoMeses = 2;
                                break;
                        }
                        // Calcular el saldo bancario
                        double interes = nuevosb * tasaInteres * tiempoMeses / 12;
                        nuevosb = nuevosb + interes;
                        Console.WriteLine("El saldo bancario después de " + tiempoMeses + " es de: " + tc + nuevosb);
                    }
                    break;

                case 6:
                    //Conteo de veces
                    rtveces += SumaDeUno;
                    //Registro de transacciones
                    Console.WriteLine("REGISTRO DE TRANSACCIONES");
                    foreach (string transaccion in transacciones)
                    {
                        Console.WriteLine(transaccion);
                    }
                    Console.WriteLine("");
                    break;
                case 7:
                    //Conteo de veces
                    mctveces += SumaDeUno;
                    //Gestionar cuentas con método
                    GestionarCuentasTerceros();
                    break;
                case 8:
                    //Conteo de veces
                    taocveces += SumaDeUno;
                    //Realizar transferencias con método
                    RealizarTransferencias();
                    break;
                case 9:
                    //Conteo de veces
                    pserveces += SumaDeUno;
                    //Realizar Pago de Servicios con método
                    RealizarPagoServicios();
                    break;
                case 10:
                    //Conteo de veces
                    impreveces += SumaDeUno;
                    //Imprimir el Informe de todas las Transacciones con método
                    ImprimirInformeTransacciones();
                    break;
                case 11:
                    // Acción para salir
                    Console.WriteLine("..Saliendo del programa..");
                    Console.WriteLine("");
                    Console.WriteLine("..Le desea un felíz día..");
                    Console.WriteLine("      -----");
                    Console.WriteLine("BANCO COUNTRY BANK");
                    Console.WriteLine("Sede en Ciudad de Guatemala");
                    Console.WriteLine("          y");
                    Console.WriteLine("Javier Alexander Castellanos Oliva");
                    Console.WriteLine("      -----");
                    Console.WriteLine("");
                    Environment.Exit(0);
                    break;

            }

        } while (opmenu != "11");
    }

    static bool EsOpcionValida(string opcion)
    {
        return Regex.IsMatch(opcion, @"^[0-9]+$");
    }

    static void MostrarMenu()
    {
        Console.WriteLine("");
        Console.WriteLine("MENU DE ACCIONES");
        Console.WriteLine("");
        Console.WriteLine("1. Ver información de cuenta.");
        Console.WriteLine("2. Comprar producto financiero.");
        Console.WriteLine("3. Vender producto financiero.");
        Console.WriteLine("4. Abonar a cuenta.");
        Console.WriteLine("5. Simular paso del tiempo.");
        Console.WriteLine("6. Registro de transacciones.");
        Console.WriteLine("7. Mantenimiento de cuentas de terceros.");
        Console.WriteLine("8. Realizar transferencias a otras cuentas.");
        Console.WriteLine("9. Pago de servicios.");
        Console.WriteLine("10. Imprimir informe de transacciones.");
        Console.WriteLine("11. Salir del programa.");
        Console.WriteLine("");
    }

    // Métodos de las opciones (7 a la 10) del menú de acciones

    /*
     OPCIÓN DEL MENU NO. 7
     */
    static void GestionarCuentasTerceros()
    {
        if (usuarios.Count > 0)
        {
            Console.WriteLine("Usuarios registrados:");
            for (int i = 0; i < usuarios.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {usuarios[i].Nombre} - Número de cuenta: {usuarios[i].NumeroCuenta}");
            }
        }
        else
        {
            Console.WriteLine("No hay usuarios registrados.");
        }
        Console.WriteLine("Puede registrar un nuevo usuario escribiendo el número 8,");
        Console.WriteLine("para ello le mostraré el menu principal para registrarlo."); // Agrega una línea en blanco para separar visualmente el resultado
        MenuPrincipal(); // Llama al método MenuPrincipal() para volver al menú principal
    }

    /*
     OPCIÓN DEL MENU NO. 8
     */
    static void RealizarTransferencias()
    {
        Console.WriteLine("REALIZAR TRANSFERENCIAS");

        // Crear lista de usuarios anteriores
        List<Cuenta> usuariosAnteriores = new List<Cuenta>();

        // Mostrar lista de usuarios anteriores
        if (usuariosAnteriores.Count > 0)
        {
            Console.WriteLine("Usuarios anteriores:");
            for (int i = 0; i < usuariosAnteriores.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + usuariosAnteriores[i].Nombre + " (" + usuariosAnteriores[i].NumeroCuenta + ")");
            }
        }

        // Pedir al usuario que seleccione un usuario o cree uno nuevo
        int opcionUsuario;

        while (true)
        {
            Console.WriteLine("Ingrese el número correspondiente al usuario al que desea transferir o 0 para crear un nuevo usuario:");
            string opcionUsuarioInput = Console.ReadLine();

            if (Regex.IsMatch(opcionUsuarioInput, @"^[0-9]+$") && int.TryParse(opcionUsuarioInput, out opcionUsuario))
            {
                if (opcionUsuario >= 0 && opcionUsuario <= usuariosAnteriores.Count)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: El número ingresado está fuera del rango. Por favor, ingrese un número válido.");
                }
            }
            else
            {
                Console.WriteLine("Error: Entrada inválida. Por favor, ingrese un número entero válido.");
            }
        }


        Cuenta cuentaDestino = null;

        if (opcionUsuario > 0 && opcionUsuario <= usuariosAnteriores.Count)
        {
            // El usuario seleccionó un usuario anterior
            cuentaDestino = usuariosAnteriores[opcionUsuario - 1];
        }
        else if (opcionUsuario == 0)
        {
            // El usuario desea crear un nuevo usuario
            string nombre;
            while (true)
            {
                Console.WriteLine("Ingrese el nombre del nuevo usuario:");
                nombre = Console.ReadLine();
                if (Regex.IsMatch(nombre, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$"))
                {
                    break;
                }
                Console.WriteLine("Error: El nombre debe contener solo letras y espacios. Por favor, ingréselo nuevamente.");
            }

            string numeroCuenta;
            while (true)
            {
                Console.WriteLine("Ingrese el número de cuenta del nuevo usuario:");
                numeroCuenta = Console.ReadLine();
                if (Regex.IsMatch(numeroCuenta, @"^[0-9]+$"))
                {
                    // Validar que la cuenta no esté repetida
                    if (usuariosAnteriores.Any(u => u.NumeroCuenta == numeroCuenta))
                    {
                        Console.WriteLine("El número de cuenta ingresado ya está en uso. Por favor, ingrese otro número de cuenta.");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Error: El número de cuenta debe contener solo números. Por favor, ingréselo nuevamente.");
                }
            }

            cuentaDestino = new Cuenta(nombre, numeroCuenta);
            usuariosAnteriores.Add(cuentaDestino);
        }

        double monto;
        while (true)
        {
            Console.WriteLine("Ingrese el monto a transferir (200 o 2000):");
            string montoInput = Console.ReadLine();

            if (Regex.IsMatch(montoInput, @"^[0-9]+$") && double.TryParse(montoInput, out monto) && (monto == 200 || monto == 2000))
            {
                break;
            }
            Console.WriteLine("Error: El monto ingresado no es válido. Por favor, ingrese 200 o 2000.");
        }

        // Validar que el saldo sea suficiente
        if (monto > nuevosb)
        {
            Console.WriteLine("Saldo insuficiente, inténtelo en otra oportunidad.");
            return;
        }

        // Realizar la transferencia
        nuevosb -= monto;
        Console.WriteLine("Transferencia realizada. Tu saldo actual es: " + tc + nuevosb);
        transacciones.Add("Transferencia de " + tc + monto + " a la cuenta " + cuentaDestino.NumeroCuenta + ". Saldo actual: " + tc + nuevosb);
    }
    class Cuenta
    {
        public string Nombre { get; set; }
        public string NumeroCuenta { get; set; }

        public Cuenta(string nombre, string numeroCuenta)
        {
            Nombre = nombre;
            NumeroCuenta = numeroCuenta;
        }
    }

    /*
     OPCIÓN DEL MENU NO. 9
     */
    static void RealizarPagoServicios()
    {
        Console.WriteLine("REALIZAR PAGO DE SERVICIOS");
        Console.WriteLine("1. Empresa de agua");
        Console.WriteLine("2. Empresa Eléctrica");
        Console.WriteLine("3. Empresa Telefónica");

        string opcion;
        while (true)
        {
            Console.Write("Ingrese el número de opción del servicio: ");
            string input = Console.ReadLine();
            if (Regex.IsMatch(input, @"^[1-3]$"))
            {
                opcion = input;
                break;
            }
            else
            {
                Console.WriteLine("Error: La opción a ingresar solo puede ser (1, 2 o 3). Por favor, ingrésalo nuevamente.");
            }
        }

        double monto = 0;
        while (true)
        {
            Console.Write("Ingrese el monto a pagar: ");
            string montoInput = Console.ReadLine();
            if (Regex.IsMatch(montoInput, @"^[0-9]+(\.[0-9]+)?$") && double.TryParse(montoInput, out monto) && monto > 0)
            {
                if (monto > nuevosb)
                {
                    Console.WriteLine("El monto que ha escrito es demasiado alto para el saldo bancario actual. Su saldo actual es: " + nuevosb);
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("Error: El monto debe ser un número positivo sin letras ni símbolos. Por favor, ingrésalo nuevamente.");
            }
        }

        nuevosb -= monto;
        string empresa = opcion == "1" ? "EMPRESA DE AGUA" : opcion == "2" ? "EMPRESA ELÉCTRICA" : "EMPRESA TELEFÓNICA";
        Console.WriteLine($"SE HA REALIZADO EXITOSAMENTE EL PAGO A LA {empresa} Y TU SALDO ACTUAL ES DE {nuevosb}");
    }

    /*
     OPCIÓN DEL MENU NO. 10
     */
    static void ImprimirInformeTransacciones()
    {
        Console.WriteLine("INFORME DE TRANSACCIONES");
        foreach (var transaccion in transacciones)
        {
            Console.WriteLine(transaccion);
        }
        Console.WriteLine("");
        Console.WriteLine("Y ahora tú saldo actual es de " + tc + nuevosb);
    }

    // Clase para representar usuarios de cuentas de terceros
    class Usuario
    {
        public string Nombre { get; set; }
        public string NumeroCuenta { get; set; }
    }
}