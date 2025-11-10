using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Libreria
{
    string[] nombres = new string[0];
    decimal[] precios = new decimal[0];


    class Program
    {
        static void Main()
        {
            Libreria lib = new Libreria();
            string opcion;

            do
            {
                Console.WriteLine("\n    MENÚ PRINCIPAL    "); // Creamos el menu principal 
                Console.WriteLine("1. Registrar libro");
                Console.WriteLine("2. Mostrar libros");
                Console.WriteLine("3. Modificar libro");
                Console.WriteLine("4. Eliminar libro");
                Console.WriteLine("5. Salir");
                Console.Write("Elige una opción: ");
                opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    lib.Registrar();// aca le decimos al programa que depende de lo que selecciones se habrira la clase correspondiente 
                }
                else if (opcion == "2")
                {
                    lib.Mostrar();
                }
                else if (opcion == "3")
                {
                    lib.Modificar();
                }
                else if (opcion == "4")
                {
                    lib.Eliminar();
                }
                else if (opcion == "5")
                {
                    Console.WriteLine("Saliendo del programa ");
                }
                else
                {
                    Console.WriteLine("Opción inválida.");// aca si el usuario pone cualquier otra opcion se imprime el siguiente mensaje (esto es opcional poero iguaol lo puse )
                }

            } while (opcion != "5");
        }
    }
    public void Registrar()
    {
        string nombre;
        string dato;
        decimal precio;
        int pos;

        Console.WriteLine("\n    REGISTRAR LIBRO    ");
        Console.Write(" Ingrese ombre del libro: ");
        nombre = Console.ReadLine();

        if (nombre == "")
        {
            Console.WriteLine("Debes escribir un nombre.");
            return;// aca mandamos al usuario a que si o si ponga el nombre del libro ya sea nombre o numero 

        }

        pos = Buscar(nombre);
        if (pos != -1)
        {
            Console.WriteLine("Ese libro ya está registrado.");
            return;
        }

        Console.Write("Precio: ");
        dato = Console.ReadLine();

        if (!decimal.TryParse(dato, out precio))
        {
            Console.WriteLine("Debe ser un número válido.");
            return;
        }

        if (precio < 0 || precio > 999)
        {
            Console.WriteLine("Precio fuera de rango (0 - 1000).");
            Console.WriteLine(" Ingrese nuevamente");
            return;
        }

        string[] nuevosNombres = new string[nombres.Length + 1];
        decimal[] nuevosPrecios = new decimal[precios.Length + 1];

        for (int i = 0; i < nombres.Length; i++)
        {
            nuevosNombres[i] = nombres[i];// esta funcion ayuda a mostrar los libros que hallamos guardado 
            nuevosPrecios[i] = precios[i];
        }

        nuevosNombres[nuevosNombres.Length - 1] = nombre;
        nuevosPrecios[nuevosPrecios.Length - 1] = precio;

        nombres = nuevosNombres;
        precios = nuevosPrecios;


        Console.WriteLine("Libro guardado correctamente.");
    }



    public void Mostrar()
    {
        Console.WriteLine("\n    LISTA DE LIBROS    ");
        if (nombres.Length == 0)// si no hay libros guardados, se muestra el siguiente mensaje 
        {
            Console.WriteLine("No hay libros registrados.");
            return;
        }

        for (int i = 0; i < nombres.Length; i++)
        {
            Console.WriteLine((i + 1) + ". " + nombres[i] + " - S/ " + precios[i]);
        }
    }




    public void Modificar()
    {
        string buscar;
        string nuevoNombre;
        string nuevoDato;
        decimal nuevoPrecio;
        int pos;
        int repetido;

        Console.WriteLine("\n    MODIFICAR LIBRO    ");
        Console.Write("Nombre del libro a modificar: ");// ACA PEDIMOS EL NOMBRE DEL LIBRO QUE QUEREMOS MODIFICAR 
        buscar = Console.ReadLine();

        pos = Buscar(buscar);// buscamos el libro en el arreglo 
        if (pos == -1)// Validamos si el libro existe 
        {
            Console.WriteLine("No se encontró ese libro.");
            return;
        }

        Console.Write("Nuevo nombre (deja vacío si no cambias): ");
        nuevoNombre = Console.ReadLine();

        if (nuevoNombre != "")// 
        {
            repetido = Buscar(nuevoNombre);
            if (repetido != -1 && repetido != pos)// aca nos aseguramos de que el usuario escriba un nuevo nombre y se valide 
            {
                Console.WriteLine("Ya existe otro libro con ese nombre.");
                return;
            }
            nombres[pos] = nuevoNombre;
        }

        Console.Write("Nuevo precio (deja vacío si no cambias): ");
        nuevoDato = Console.ReadLine();

        if (nuevoDato != "")
        {
            if (!decimal.TryParse(nuevoDato, out nuevoPrecio))
            {
                Console.WriteLine("Precio inválido.");
                return;
            }

            if (nuevoPrecio < 0 || nuevoPrecio > 999)// validamos el nuevo precio 
            {
                Console.WriteLine("Precio fuera de rango.");
                return;
            }

            precios[pos] = nuevoPrecio;
        }

        Console.WriteLine("Libro modificado correctamente.");// MOSTRAMOS EN PANTALLA la ejecucion 
    }





    public void Eliminar()
    {
        string buscar;
        int pos;

        Console.WriteLine("\n    ELIMINAR LIBRO    ");
        Console.Write("Nombre del libro a eliminar: ");
        buscar = Console.ReadLine();

        pos = Buscar(buscar);// ACA BUSCAMOS EL LIBRO EN EL ARREGLO 
        if (pos == -1)// Validamos si existe 
        {
            Console.WriteLine("No se encontró ese libro.");
            return;
        }

        for (int i = pos; i < nombres.Length - 1; i++)
        {
            nombres[i] = nombres[i + 1];// ACA MOVEMOS LOS ELEMENTOS 
            precios[i] = precios[i + 1];
        }

        Array.Resize(ref nombres, nombres.Length - 1);// ACA se usa la siguiente funcion para que el codigo elimine el libro que desee el usuario 
        Array.Resize(ref precios, precios.Length - 1);

        Console.WriteLine("Libro eliminado correctamente.");
    }

    int Buscar(string nombre)
    {
        for (int i = 0; i < nombres.Length; i++)
        {
            if (nombres[i].ToLower() == nombre.ToLower())// aca ignoramos las letras mayusculas o minusculas para buscar sin problemas los libros para eliminaelos 
                return i;
        }
        return -1;
    }
}


