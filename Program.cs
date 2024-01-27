namespace A8_Equipo_Empleados;

class Program
{
    static void Main(string[] args)
    {
        do  //INICIA EL PROGRAMA 
        {
            Console.Clear();
            var empleado = new Empleado();
            empleado.tipoEmpleado(); //DEFINE EL TIPO DE EMPLEADO.

            switch (empleado.tipoDeEmpleado)
            {
                case "1":   //EMPLEADO ASALARIADO
                    var EmpleadosAsalariados = new EmpleadosAsalariados();
                    EmpleadosAsalariados.datosEmpleado();   //REGISTRA DATOS DEL EMPLEADO
                    EmpleadosAsalariados.pagoEmpleado();    //MUESTRA EL PAGO DEL EMPLEADO

                    Console.WriteLine("\nPresione ENTER");   //ESPERA ESPUESTA DEL USUARIO PARA TERMINAR
                    Console.ReadKey();
                break;


                case "2":   //EMPLEADO POR HORAS
                    var EmpleadoPorHoras = new EmpleadoPorHoras();
                    EmpleadoPorHoras.datosEmpleado();   //REGISTRA DATOS DEL EMPLEADO
                    EmpleadoPorHoras.pagoEmpleado();    //MUESTRA EL PAGO DEL EMPLEADO

                    Console.WriteLine("\nPresione ENTER");   //ESPERA ESPUESTA DEL USUARIO PARA TERMINAR
                    Console.ReadKey();
                break;


                case "3":   //EMPLEADO POR COMISION
                    var EmpleadosPorComisión = new EmpleadosPorComisión();
                    EmpleadosPorComisión.datosEmpleado();   //REGISTRA DATOS DEL EMPLEADO
                    EmpleadosPorComisión.pagoEmpleado();    //MUESTRA EL PAGO DEL EMPLEADO
   

                    Console.WriteLine("\nPresione ENTER");   //ESPERA ESPUESTA DEL USUARIO PARA TERMINAR
                    Console.ReadKey();
                break;


                case "4":   //EMPLEADO ASALARIADO POR COMISION
                    var EmpleadosAsalariadosPorComision = new EmpleadosAsalariadosPorComision();
                    EmpleadosAsalariadosPorComision.datosEmpleado();   //REGISTRA DATOS DEL EMPLEADO
                    EmpleadosAsalariadosPorComision.pagoEmpleado();    //MUESTRA EL PAGO DEL EMPLEADO

                    Console.WriteLine("\nPresione ENTER");   //ESPERA ESPUESTA DEL USUARIO PARA TERMINAR
                    Console.ReadKey();
                break;


                default:
                    Console.WriteLine($"No existen esa clase de empleados.");

                    Console.WriteLine("\nPresione ENTER");   //ESPERA ESPUESTA DEL USUARIO PARA TERMINAR
                    Console.ReadKey();
                break;
            }  

            //MENU DE SALIDA  
            Console.Clear();    //LIMPIA PANTALLA
            string? opcion;
            Console.Write("\n¿Desea agregar otro empleado?\n1. Si\n2. No\n--> ");
            do  //VERIFICADOR DE ERROR AL NO SER 1 O 2
            {
                opcion = Console.ReadLine();
                if (opcion is "1" or "2"){break;}
                else{Console.Write("\nOpción no valida, seleccione correctamente --> ");}
            } while (true);
            if (opcion is "2"){break;} //TERMINA EL PROGRAMA

        } while (true);
    }
}
