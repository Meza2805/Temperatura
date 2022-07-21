using System.Data;
using System.Collections;
internal class Program
{
    public static ArrayList datos = new ArrayList();
    public static StreamWriter fichero; 
    public static int cantidad;
    private static void Main(string[] args)
    {
        string txt = "Temperatura.txt";
        int media;
        ArrayList salida = new ArrayList();
        AgregarTemperaturas(txt);
        salida = leerArchivo(txt);
        MostrarDatos(salida);
        media = Media(salida);
        Console.WriteLine("La temperatura media es "+media);
        Temperatura_Mayor_Media(salida, media);
    }




    public static void AgregarTemperaturas(string archivo)
    {    
         fichero = File.CreateText(archivo); //Creamos un fichero
        Console.WriteLine("Ingrese el numero de temperaturas a procesar: ");
        cantidad = (Convert.ToInt32(Console.ReadLine()));

        for (int i=0;i<cantidad;i++)
        {
             Console.WriteLine("Ingrese la temperatura No. " + (i+1));
             fichero.WriteLine(Console.ReadLine());
        }
        fichero.Close();
    }

    public static ArrayList leerArchivo(string archivo)
    {
        ArrayList temp = new ArrayList();
        StreamReader lector  = new StreamReader (archivo);
        string linea;
            while ((linea = lector.ReadLine()) != null)
            {
                temp.Add(linea);
            }
        return temp;
    }

    public static void MostrarDatos(ArrayList datos)
    
    {   
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("SE MUESTRAN A CONTINUACION LAS TEMPERATURAS INGRESADAS");
        foreach(var item in datos)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("---------------------------------------------------------");
    }

    public static int Media(ArrayList datos)
    {
       
        int media=0;
        foreach(var item in datos)
        {
            media += Convert.ToInt32(item);
        }
        media = media/cantidad;
        return media;
    }

    public static void Temperatura_Mayor_Media(ArrayList datos,int media)
    {
         foreach(var item in datos)
        {
            if (media >Convert.ToInt32(item))
            {
                Console.WriteLine("La temperatura "+ item + " es mayor que la media");
            }
        }
            Console.WriteLine("---------------------------FIN-----------------------------");
    }
  

}