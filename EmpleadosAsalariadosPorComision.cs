class EmpleadosAsalariadosPorComision : Empleado
{  
    public string? categoria = "A";
    public double pagoDiario = 0;
    public double valSueldoBruto = 0;
    public string? VerificarCategoria(double antiguedad)
    {
        if (antiguedad < 1) { categoria = "A [MENOS DE 1 AÑO][$0]"; } 
        else if (antiguedad >= 1 && antiguedad < 3) { categoria = "B [A PARTIR DE 1 AÑO][$500]"; } 
        else if (antiguedad >= 3 && antiguedad < 5) { categoria = "C [A PARTIR DE 3 AÑOS][$1000]"; }
        else if (antiguedad >= 5 && antiguedad < 10) { categoria = "D [A PARTIR DE 5 AÑOS][$1500]"; }
        else { categoria = "E [A PARTIR DE 10 AÑOS][$2000]"; }  

        return categoria;
    }

    public double sueldoBruto(double sueldo,double venta, double comision,double salarioSemanal, double vales, string? categoria)
    {
        double sal_sem = sueldo*7;
        double salario = sal_sem+(sal_sem*.10);
        double ProcenV = (venta*comision)/100;
        
        valSueldoBruto = (salario + ProcenV) + vales;

        switch (categoria)
        {
            case "A [MENOS DE 1 AÑO][$0]":
                valSueldoBruto = valSueldoBruto + 0;
            break;

            case "B [A PARTIR DE 1 AÑO][$500]":
                valSueldoBruto = valSueldoBruto + 500;
            break;

            case "C [A PARTIR DE 3 AÑOS][$1000]":
                valSueldoBruto = valSueldoBruto + 1000;
            break;

            case "D [A PARTIR DE 5 AÑOS][$1500]":
                valSueldoBruto = valSueldoBruto + 1500;
            break;

            case "E [A PARTIR DE 10 AÑOS][$2000]":
                valSueldoBruto = valSueldoBruto + 2000;
            break;
        }
        return valSueldoBruto;
    }
    
    public double CalcularImpuestos(double sueldoBruto, double impuesto)
    {
        impuesto /= 100;

        impuesto = sueldoBruto * impuesto;

        return impuesto;
    }
       public double procesoPagoEmpleado(double sueldoBruto, double impuesto)
    {
        impuesto /= 100;

        pago =  sueldoBruto - (sueldoBruto * impuesto);

        return pago;
    }
    public new void pagoEmpleado ()
   {    
        do
        {
            try
            {
                Console.Clear();
                Console.Write($"Ingrese el valor del sueldo diario del empleado llamado {nombre}: --> ");
                double sueldo = Convert.ToDouble(Console.ReadLine());
                Console.Write($"Ingrese el valor de \"vales\" que se le otorgarán al empleado {nombre} \nEn caso de no otorgarle, ingrese 0  --> ");
                vales = Convert.ToDouble(Console.ReadLine());
                Console.Write($"Ingrese el porcentaje[0 a 100] de impuestos que se le descontarán de su pago al empleado {nombre} --> ");
                impuesto = Convert.ToDouble(Console.ReadLine());
                Console.Write($"Ingrese la cantidad del valor de las ventas generadas por el empleado {nombre}: -->  ");
                double venta = Convert.ToDouble(Console.ReadLine());
                do
                {
                    Console.Write($"Ingrese el porcentaje[0 a 100] de venta que recibirá el empleado {nombre}: -->  ");
                    double comision = Convert.ToDouble(Console.ReadLine());
                    if (comision <0 || comision > 100)
                    {
                        Console.WriteLine("Comision no valida");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Empleado asalariados por comision: {nombre}");
                        Console.WriteLine($"Edad: {edad}");
                        Console.WriteLine($"Antigüedad: {antiguedad} años");
                        Console.WriteLine($"Categoria: {VerificarCategoria(antiguedad)}");
                        Console.WriteLine($"El empleado {nombre} vendió ${venta}, su comisión es del {comision}%: {venta*(comision/100)}\nAdicional a eso, su salario base es de {sueldo*7} semanal, por lo que su bonificación del 10% de su salario es de {(sueldo*7) * .10}.");
                        Console.WriteLine($"Vales: ${vales}");
                        Console.WriteLine($"Sueldo bruto: {sueldoBruto(sueldo,venta,comision, pagoDiario, vales, VerificarCategoria(antiguedad))}");
                        Console.WriteLine($"Impuestos [{impuesto}%]: {CalcularImpuestos(valSueldoBruto, impuesto)}");
                        Console.WriteLine($"\nEl sueldo del empledo {nombre} es de: {procesoPagoEmpleado(valSueldoBruto, impuesto)}");
                        break;
                    }
                } while (true);
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