class EmpleadosPorComisión : Empleado
{  
    public double CalcularImpuestos(double impuesto,double venta, double comision )      //METODO HECHO PARA SER HEREDADO Y CALCULA LOS IMPUESTOS GENERADOS DEL EMPLEADO
    {
        impuesto /= 100;
        impuesto = ((venta*comision)/100) * impuesto;
        return impuesto;
    }
     
    public double ProcesoPagoEmpleado (double venta, double comision,double impuesto)      
    {
        impuesto /= 100;
        pago = ((venta*comision)/100) - (((venta*comision)/100)*impuesto);
        return pago;
    }
    public new void pagoEmpleado()
    {
        do
        {
            try
            {
                
                Console.Clear();
                Console.Write($"Ingrese la cantidad de valor de las ventas generadas por el empleado {nombre} --> ");
                double venta = Convert.ToDouble(Console.ReadLine());
                do
                {
                    Console.Write($"Ingrese el porcentaje[0 a 100] que recibirá de las ventas generadas por el empleado empleado {nombre} --> ");
                    double comision = Convert.ToDouble(Console.ReadLine());
                    if (comision <0 || comision > 100)
                    {
                        Console.WriteLine("Comision no valida");
                    }
                    else
                    {
                        Console.Write($"Ingrese el porcentaje[0 a 100] de impuestos que se le descontarán de su pago al empleado {nombre} --> ");
                        impuesto = Convert.ToDouble(Console.ReadLine());
                        
                        Console.Clear();
                        Console.WriteLine($"Empleado por comisión: {nombre}");
                        Console.WriteLine($"Edad: {edad}");
                        Console.WriteLine($"Ventas: ${venta}");
                        Console.WriteLine($"Comisión del {comision}%.");
                        Console.WriteLine($"Impuestos [{impuesto}%]: {CalcularImpuestos(impuesto,venta,comision)}");
                        Console.WriteLine($"El sueldo del empledo {nombre} es de {ProcesoPagoEmpleado(venta,comision,impuesto)}");
                        
                        break;
                    }
                }while (true);
                break; 
            } 
            catch(Exception)
            {
                Console.WriteLine("Dato no válido, presione enter e intente de nuevo.");
                Console.ReadKey();
            }
        }while (true);
    }
}