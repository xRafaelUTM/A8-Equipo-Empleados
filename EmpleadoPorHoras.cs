class EmpleadoPorHoras : Empleado
{
    public double ProcesoPagoEmpleado(double horasTrabajadas,double sueldoPorHora, bool flag, double PagohorasExtras)
    {
        if (flag == true)
        {
            double CantidadDeHorasExtras = horasTrabajadas - 40;
            horasTrabajadas = horasTrabajadas - CantidadDeHorasExtras;
            pago = (horasTrabajadas * sueldoPorHora) + ( PagohorasExtras * CantidadDeHorasExtras);
        }
        else
        {
            pago = horasTrabajadas * sueldoPorHora;
        }
        return pago;
    }
    public new void pagoEmpleado()
    {
        
        do
        {
            try
            {
                Console.Clear();
                bool flag = false;
                double PagohorasExtras = 0;
                Console.Write($"Ingrese el sueldo por hora para el empleado de nombre {nombre} --> ");
                double sueldoPorHora = Convert.ToDouble(Console.ReadLine());

                Console.Write("Ingrese la cantidad de horas laboradas del empleado --> ");
                double horasTrabajadas = Convert.ToDouble(Console.ReadLine());

                if (horasTrabajadas > 40)
                {
                flag = true;
                Console.Write($"El empleado {nombre} ha laboado mas de 40 horas.\n¿Cual será su pago por cada hora extra? --> ");
                PagohorasExtras = Convert.ToDouble(Console.ReadLine());
                }

                double pagoTotal = ProcesoPagoEmpleado(horasTrabajadas, sueldoPorHora, flag, PagohorasExtras);
                Console.Write($"El sueldo de esta semana para el tabajador llamado {nombre} es de: {pagoTotal}");
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Dato no válido, presione enter e intente de nuevo.");
                Console.ReadKey();
            }
        }while (true);   
    }

}