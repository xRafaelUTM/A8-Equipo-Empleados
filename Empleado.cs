class Empleado     //CLASE PADRE EMPLEADO
{
        //DATOS GENERALES
    private string? Nombre = "Sin nombre";
    private int Edad = 18;
    private string? TipoDeEmpleado = "Sin tipo de empleado";
    private double Impuesto = 0;
    private int Antiguedad = 0;
    private double Vales = 0;
    private double Pago = 0;

    public string? nombre {get =>Nombre; set =>Nombre=value;}
    public int edad {get =>Edad; set =>Edad=value;}
    public string? tipoDeEmpleado {get =>TipoDeEmpleado; set =>TipoDeEmpleado=value;}
    public double impuesto {get =>Impuesto; set =>Impuesto=value;}
    public int antiguedad {get =>Antiguedad; set =>Antiguedad=value;}
    public double vales {get =>Vales; set =>Vales=value;}
    public double pago {get =>Pago; set =>Pago=value;}

    public void tipoEmpleado()    //METODO QUE MUESTRA EL MENÚ DE LOS TIPOS DE EMPLEADOS
    {
        Console.Write($"Ingrese el tipo de empleado \n1. Empleados asalariados \n2. Empleados por horas \n3. Empleados por comisión \n4. Empleados asalariados por comisión. \n5. Salir \n  [ELIJA UN NUMERO CORRESPONDIENTE]\n--> ");
        tipoDeEmpleado = Console.ReadLine();
    }

    public void datosEmpleado()     //METODO PARA INGRESAR DATOS PERSONALES DE LOS EMPLEADOS
    {
        Console.Write("Ingrese el nombre y apellido del empleado. --> ");
        nombre = Console.ReadLine();
        
        Console.Write($"\nIngrese la edad del empleado llamado {nombre} --> ");
        do
        {
            try
            {
                edad = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Dato no válido, ingrese la edad correctamente --> ");
            }
        }while(true);  

        Console.Write($"\n¿Cuanto tiempo[años] lleva laborando el empleado llamado {nombre} en la empresa? --> ");
        do
        {
            try
            {
                antiguedad = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Dato no válido, ingrese la edad correctamente --> ");
            }
        }while(true); 

    }

    public double VerificacionVales(double vales)      //METODO HECHO PARA SER HEREDADO Y VERIFICA SI EL EMPLEADO TENDRÁ VALES
    {
        return vales;
    }

    public double sueldoBruto(double pago, double vales)      //METODO HECHO PARA SER HEREDADO Y MUESTRA EL SUELDO BRUTO (SIN IMPUESTOS)
    {
        pago += vales;
        return pago;
    }
    
    public double CalcularImpuestos(double impuesto)      //METODO HECHO PARA SER HEREDADO Y CALCULA LOS IMPUESTOS GENERADOS DEL EMPLEADO
    {
        return impuesto;
    }

    public double procesoPagoEmpleado(double pago)      //METODO HECHO PARA SER HEREDADO Y CALCULA EL PROCESO DE SU PAGO FINAL.
    {
        return pago;
    }

    public void pagoEmpleado()      //METODO HECHO PARA SER HEREDADO Y MOSTRAR EL PAGO FINAL
    {  
        Console.WriteLine($"Empleado TIPO DE EMPLEADO: {nombre}");
        Console.WriteLine($"Edad: {edad}");
        Console.WriteLine($"Antigüedad: {antiguedad}");
        Console.WriteLine($"Vales: [Aplica/No Aplica]: {VerificacionVales(vales)}");
        Console.WriteLine($"Impuestos: {CalcularImpuestos(impuesto)}");
        Console.WriteLine($"Sueldo mensual: {procesoPagoEmpleado(pago)}");
    }
}