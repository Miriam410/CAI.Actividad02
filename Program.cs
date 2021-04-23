using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI.Actividad02
{
    class Program
    {
        static List<Operador> operadores = new List<Operador>();
        static Queue<Orden> ordenes = new Queue<Orden>();

        static void Main(string[] args)
        {
            IngresoOperadores();
            if (operadores.Count == 0)
            {
                Console.WriteLine("No ha ingresado operadores. Programa terminado.");
                Console.ReadKey();
                return;
            }

            IngresoOrdenes();
            if (ordenes.Count == 0)
            {
                Console.WriteLine("No ha ingresado ordenes. Programa terminado.");
                Console.ReadKey();
                return;
            }

            Asignacion();

            MostrarResultados();

            Console.ReadKey();
        }

        static void MostrarResultados()
        {
            Console.WriteLine("Ordenes cumplidas por operador:");

            foreach (var operador in operadores)
            {
                string ordenPendiente = "";
                if (operador.OrdenActual != null)
                {
                    ordenPendiente = $" - Asignada: {operador.OrdenActual.Numero}.";
                }

                Console.WriteLine($"{operador.Numero} - Cumplidas: {operador.OrdenesCumplidas} {ordenPendiente}");
            }

            Console.WriteLine("Ordenes pendientes de asignar:");
            foreach (var orden in ordenes)
            {
                Console.WriteLine(orden.Numero);
            }
        }

        static void Asignacion()
        {
            do
            {
                bool salir = false;
                int numeroOperador = 0;

                while (numeroOperador == 0)
                {
                    numeroOperador = 0;
                    Console.WriteLine($"Quedan {ordenes.Count} órdenes sin asignar.");
                    Console.WriteLine($"Asignacion de orden {ordenes.Peek().Numero}");
                    Console.WriteLine("Ingrese número de operador o [ENTER] para terminar.");
                    var ingreso = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ingreso))
                    {
                        salir = true;
                        break;
                    }

                    if (!int.TryParse(ingreso, out numeroOperador))
                    {
                        Console.WriteLine("Debe ingresar un número entero.");
                        continue;
                    }

                    if (!operadores.Any(o => o.Numero == numeroOperador))
                    {                        
                        Console.WriteLine($"El operador {numeroOperador} no existe.");
                        numeroOperador = 0;
                        continue;
                    }
                }

                if (salir)
                {
                    return;
                }

                var operador = operadores.Find(o => o.Numero == numeroOperador);
                var orden = ordenes.Dequeue();
                operador.Asignar(orden);

            } while (ordenes.Count > 0); //ciclo por asignacion
        }

        static void IngresoOrdenes()
        {
            var salir = false;
            do
            {
                do
                {
                    Console.WriteLine("Ingrese número de orden o [ENTER] para continuar.");
                    var ingreso = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ingreso))
                    {
                        salir = true;
                        break;
                    }

                    if (!int.TryParse(ingreso, out int numeroOrden))
                    {
                        Console.WriteLine("Debe ingresar un número entero.");
                        continue;
                    }

                    if (ordenes.Any(o => o.Numero == numeroOrden))
                    {
                        Console.WriteLine($"Ya ha ingresado el número de orden {numeroOrden}");
                        continue;
                    }

                    ordenes.Enqueue(new Orden(numeroOrden));


                } while (true);

            } while (!salir);
        }

        static void IngresoOperadores()
        {
            var salir = false;
            do
            {
                do
                {
                    Console.WriteLine("Ingrese número de operador o [ENTER] para continuar.");
                    var ingreso = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ingreso))
                    {
                        salir = true;
                        break;
                    }

                    if (!int.TryParse(ingreso, out int numeroOperador))
                    {
                        Console.WriteLine("Debe ingresar un número entero.");
                        continue;
                    }

                    var ok = true;
                    foreach (var operador in operadores)
                    {
                        if (operador.Numero == numeroOperador)
                        {
                            Console.WriteLine($"Ud. ya ha ingresado al operador número {numeroOperador}");
                            ok = false;
                            break;
                        }
                    }
                    if (!ok)
                    {
                        continue;
                    }

                    operadores.Add(new Operador(numeroOperador));


                } while (true);

            } while (!salir);
        }
    }
}
