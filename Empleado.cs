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
}

class EmpleadosAsalariadosPorComision : Empleado
{  
}