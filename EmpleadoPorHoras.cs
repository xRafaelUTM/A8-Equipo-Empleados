class EmpleadoPorHoras : Empleado
{
    // Método para calcular el sueldo bruto antes de impuestos
    public static double CalcularSueldoBruto(double horasTrabajadas, double sueldoPorHora, double PagohorasExtras)
    {
        double sueldoBruto;
        sueldoBruto = horasTrabajadas * sueldoPorHora;
        if (horasTrabajadas > 40)
        {
            double CantidadDeHorasExtras = horasTrabajadas - 40;
            sueldoBruto += (CantidadDeHorasExtras * PagohorasExtras);
        }
        return sueldoBruto;
    }

    // Método sobreescrito para calcular el pago y mostrarlo junto con otros detalles
    public new void pagoEmpleado()
    {
        do
        {
            try
            {
                Console.Clear();
                double PagohorasExtras = 0;

                // Entrada para el salario por hora
                Console.Write($"Ingrese el sueldo por hora para el empleado de nombre {nombre} --> ");
                double sueldoPorHora = Convert.ToDouble(Console.ReadLine());

                // Entrada para las horas trabajadas
                Console.Write("Ingrese la cantidad de horas laboradas del empleado --> ");
                double horasTrabajadas = Convert.ToDouble(Console.ReadLine());

                // Verificar si hay horas extras trabajadas
                if (horasTrabajadas > 40)
                {
                    Console.Write($"El empleado {nombre} ha laborado más de 40 horas.\n¿Cuál será su pago por cada hora extra? --> ");
                    PagohorasExtras = Convert.ToDouble(Console.ReadLine());
                }

                Console.Write($"Ingrese el porcentaje[0 a 100] de impuestos que se le descontarán de su pago al empleado {nombre} --> ");
                impuesto = Convert.ToDouble(Console.ReadLine());

                double sueldoBruto = CalcularSueldoBruto(horasTrabajadas, sueldoPorHora, PagohorasExtras);
                double horasExtra = 0;
                if (horasTrabajadas > 40){ horasExtra = horasTrabajadas - 40; horasTrabajadas -= horasExtra;} else{}
                Console.Clear();
                Console.WriteLine($"Tipo de empleado: Por horas");
                Console.WriteLine($"Nombre: {nombre}");
                Console.WriteLine($"Sueldo por hora: {sueldoPorHora}");
                Console.WriteLine($"Horas trabajadas: {horasTrabajadas}");
                Console.WriteLine($"Horas extras: {horasExtra}");
                Console.WriteLine($"Pago bruto: {sueldoBruto}");
                Console.WriteLine($"Impuestos {impuesto}%: {sueldoBruto * (impuesto / 100):N2}");
                Console.WriteLine($"pago final:{sueldoBruto - (sueldoBruto * (impuesto / 100)):N2}");
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Dato no válido, presione enter e intente de nuevo.");
                Console.ReadKey();
            }
        } while (true);
    }
}