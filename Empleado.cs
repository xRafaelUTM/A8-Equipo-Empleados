class Empleado     //CLASE PADRE EMPLEADO
{
        //DATOS GENERALES
    public string? Nombre = "Sin nombre";
    public int Edad = 18;
    public string? Pais = "México";
    public string? TipoDeEmpleado = "Sin tipo de empleado";
    public double Pago = 0;

    public string? nombre {get =>Nombre; set =>Nombre=value;}
    public int edad {get =>Edad; set =>Edad=value;}
    public string? pais {get =>Pais; set =>Pais=value;}
    public string? tipoDeEmpleado {get =>TipoDeEmpleado; set =>TipoDeEmpleado=value;}
    public double pago {get =>Pago; set =>Pago=value;}


    
    public void tipoEmpleado()    //METODO QUE MUESTRA EL MENÚ DE LOS TIPOS DE EMPLEADOS
    {
        Console.Write($"\nIngrese el tipo de empleado \n1. Empleados asalariados \n2. Empleados por horas \n3. Empleados por comisión \n4. Empleados asalariados por comisión. \n  [ELIJA UN NUMERO CORRESPONDIENTE]\n--> ");
        tipoDeEmpleado = Console.ReadLine();
    }

    public void datosEmpleado()     //METODO PARA INGRESAR DATOS PERSONALES DE LOS EMPLEADOS
    {
        Console.Write("Ingrese el nombre y apellido del empleado. --> ");
        nombre = Console.ReadLine();

        Console.Write($"\nIngrese la edad del empleado llamado {nombre} --> ");
        edad = Convert.ToInt32(Console.ReadLine());

        Console.Write($"\nIngrese el país/ciudad de procedencia del empleado llamado {nombre} \n--> ");
        pais = Console.ReadLine();

    }

    public double procesoPagoEmpleado(double sueldo)      //METODO HECHO PARA SER HEREDADO Y CALCULA EL PROCESO DE SU PAGO FINAL.
    {
        return pago;
    }

    public void pagoEmpleado()      //METODO HECHO PARA SER HEREDADO Y MOSTRAR EL PAGO FINAL
    {  
        Console.Write($"\nEl sueldo mensual del trabajador llamado {nombre} es de {procesoPagoEmpleado(Pago)}");
    }
}

class EmpleadosAsalariados : Empleado
{ 
}
class EmpleadoPorHoras : Empleado
{
}

class EmpleadosPorComisión : Empleado
{  
     public double procesoPagoEmpleado(double venta, int comision)      
    {
        pago = (venta*comision)/100;
        return pago;
    }
    public new void pagoEmpleado()
    {
        do
        {
            try
            {
                Console.WriteLine($"Ingrese la cantida del valor de las ventas generadas por el empleado {nombre}");
                double venta = Convert.ToDouble(Console.ReadLine());
                do
                {
                    Console.WriteLine($"Ingrese el porcentaje que recibiras de las ventas del empleado {nombre}");
                    int comision = Convert.ToInt32(Console.ReadLine());
                    if (comision <0 || comision > 100)
                    {
                        Console.WriteLine("Comision no valida");
                    }
                    else
                    {
                        Console.WriteLine($"El sueldo del empledo {nombre} es {procesoPagoEmpleado(venta,comision)}");
                        break;
                    }
                }while (true);break; 
            } 
            catch(Exception)
            {
            Console.WriteLine("Dato no valido\nIngrese todos los datos de nuevo");
            }
        }while (true);
    }
}

class EmpleadosAsalariadosPorComision : Empleado
{  
     public double procesoPagoEmpleado(double sueldo,double venta, int comision)      
    {   double sal_mes = sueldo*30;
        double salario = sal_mes+(sal_mes*.10);
        double ProcenV = (venta*comision)/100;
        double pago = salario + ProcenV;
        return pago;
    }
    public new void pagoEmpleado ()
   {    
        do
        {
            try
            {
                Console.WriteLine($"Ingrese el valor del sueldo diario del empleado llamado {nombre}");
                double sueldo = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Ingrese la cantida del valor de las ventas generadas por el empleado {nombre} ");
                double venta = Convert.ToDouble(Console.ReadLine());
                do
                {
                    Console.WriteLine($"Ingrese el porcentaje que recibiras de las ventas del empleado {nombre}");
                    int comision = Convert.ToInt32(Console.ReadLine());
                    if (comision <0 || comision > 100)
                    {
                        Console.WriteLine("Comision no valida");
                    }
                    else
                    {
                        Console.WriteLine($"El sueldo del empledo {nombre} es {procesoPagoEmpleado(sueldo,venta,comision)}");
                        break;
                    }
                }while (true);break;
            }
            catch(Exception)
            {
                Console.WriteLine("Dato no valido\nIngrese todos los datos de nuevo");
            }
        }while (true);
   }
}