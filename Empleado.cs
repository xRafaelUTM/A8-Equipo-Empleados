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
        Console.Write($"Ingrese el tipo de empleado \n1. Empleados asalariados \n2. Empleados por horas \n3. Empleados por comisión \n4. Empleados asalariados por comisión. \n  [ELIJA UN NUMERO CORRESPONDIENTE]\n--> ");
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

class EmpleadosAsalariados : Empleado
{ 
    public string? categoria = "A";
    public double pagoDiario = 0;
    public double valSueldoBruto = 0;
    public string? VerificarCategoria(double antiguedad)
    {
        if (antiguedad < 1) { categoria = "A [MENOS DE 1 AÑO][$0]"; } 
        else if (antiguedad > 1 && antiguedad < 3) { categoria = "B [A PARTIR DE 1 AÑO][$500]"; } 
        else if (antiguedad > 3 && antiguedad < 5) { categoria = "C [A PARTIR DE 3 AÑOS][$1000]"; }
        else if (antiguedad > 5 && antiguedad < 10) { categoria = "D [A PARTIR DE 5 AÑOS][$1500]"; }
        else { categoria = "E [A PARTIR DE 10 AÑOS][$2000]"; }  

        return categoria;
    }

    public double sueldoBruto(double salarioSemanal, double vales, string? categoria)
    {
        valSueldoBruto = (salarioSemanal * 7) + vales;

        switch (categoria)
        {
            case "A":
                valSueldoBruto =+ 0;
            break;

            case "B":
                valSueldoBruto =+ 500;
            break;

            case "C":
                valSueldoBruto =+ 1000;
            break;

            case "D":
                valSueldoBruto =+ 1500;
            break;

            case "E":
                valSueldoBruto =+ 2000;
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
    
    public new void pagoEmpleado()
    {
        do
        {
            try
            {
                Console.Clear();
                Console.Write($"Ingrese el salario (pago diario) de esta semana para empleado de nombre {nombre} --> ");
                pagoDiario = Convert.ToDouble(Console.ReadLine());

                Console.Write($"Ingrese el valor de \"vales\" que se le otorgarán al empleado {nombre} \nEn caso de no otorgarle, ingrese 0  --> ");
                vales = Convert.ToDouble(Console.ReadLine());

                Console.Write($"Ingrese el porcentaje[0 a 100] de impuestos que se le descontarán de su pago al empleado {nombre} --> ");
                impuesto = Convert.ToDouble(Console.ReadLine());

                Console.Clear();
                Console.WriteLine($"Empleado asalariado: {nombre}");
                Console.WriteLine($"Edad: {edad}");
                Console.WriteLine($"Antigüedad: {antiguedad} años");
                Console.WriteLine($"Categoria: {VerificarCategoria(antiguedad)}");
                Console.WriteLine($"Vales: ${vales}");
                Console.WriteLine($"Sueldo bruto: {sueldoBruto(pagoDiario, vales, VerificarCategoria(antiguedad))}");
                Console.WriteLine($"Impuestos [{impuesto}%]: {CalcularImpuestos(valSueldoBruto, impuesto)}");
                Console.WriteLine($"Sueldo mensual: {procesoPagoEmpleado(valSueldoBruto, impuesto)}");
                
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Dato no válido, presione enter e intente de nuevo.");
                Console.ReadKey();
            }
        }while(true);  
    }
}

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
        pago = ((venta*comision)/100)- (((venta*comision)/100)*impuesto);
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
                    Console.Write($"Ingrese el porcentaje que recibirá de las ventas generadas por el empleado empleado {nombre} --> ");
                    double comision = Convert.ToDouble(Console.ReadLine());
                    if (comision <0 || comision > 100)
                    {
                        Console.WriteLine("Comision no valida");
                    }
                    else
                    {
                        Console.Write($"Ingrese el porcentaje[0 a 100] de impuestos que se le descontarán de su pago al empleado {nombre} --> ");
                        impuesto = Convert.ToDouble(Console.ReadLine());
                        
                        Console.WriteLine($"Impuestos [{impuesto}%]: {CalcularImpuestos(impuesto,venta,comision)}");
                        Console.WriteLine($"El empleado {nombre} vendió ${venta}, su comisión es del {comision}%.");
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

class EmpleadosAsalariadosPorComision : Empleado
{  
     public string? categoria = "A";
    public double pagoDiario = 0;
    public double valSueldoBruto = 0;
    public string? VerificarCategoria(double antiguedad)
    {
        if (antiguedad < 1) { categoria = "A [MENOS DE 1 AÑO][$0]"; } 
        else if (antiguedad > 1 && antiguedad < 3) { categoria = "B [A PARTIR DE 1 AÑO][$500]"; } 
        else if (antiguedad > 3 && antiguedad < 5) { categoria = "C [A PARTIR DE 3 AÑOS][$1000]"; }
        else if (antiguedad > 5 && antiguedad < 10) { categoria = "D [A PARTIR DE 5 AÑOS][$1500]"; }
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
            case "A":
                valSueldoBruto =+ 0;
            break;

            case "B":
                valSueldoBruto =+ 500;
            break;

            case "C":
                valSueldoBruto =+ 1000;
            break;

            case "D":
                valSueldoBruto =+ 1500;
            break;

            case "E":
                valSueldoBruto =+ 2000;
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
                    Console.Write($"Ingrese el porcentaje de venta que recibirá el empleado {nombre}: -->  ");
                    double comision = Convert.ToDouble(Console.ReadLine());
                    if (comision <0 || comision > 100)
                    {
                        Console.WriteLine("Comision no valida");
                    }
                    else
                    {
                        Console.WriteLine($"Antigüedad: {antiguedad} años");
                        Console.WriteLine($"Categoria: {VerificarCategoria(antiguedad)}");

                        Console.WriteLine($"\nEl empleado {nombre} vendió ${venta}, su comisión es del {comision}%\nAdicional a eso, su salario base es de {sueldo*7} semanal, por lo que su bonificación del 10% de su salario es de {(sueldo*7) * .10}.");
                        
                        Console.WriteLine($"Vales: ${vales}");
                        Console.WriteLine($"Sueldo bruto: {sueldoBruto(sueldo,venta,comision, pagoDiario, vales, VerificarCategoria(antiguedad))}");
                        Console.WriteLine($"Impuestos [{impuesto}%]: {CalcularImpuestos(valSueldoBruto, impuesto)}");
                        Console.WriteLine($"\nEl sueldo del empledo {nombre} es {procesoPagoEmpleado(valSueldoBruto, impuesto)}");
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