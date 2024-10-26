using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andres_Gutierrez_Roland_Ramirez
{
    internal class save
    {
        public void Escribir(string Dato)
        {
            StreamWriter W1 = new StreamWriter(@"C:\andres_roland\G51.txt", true);
            W1.WriteLine(Dato);
            W1.Close();
        }
        public List<string> Leer()
        {
            List<string> nombres = new List<string>(); //Almacenara la linea con los nombres
            StreamReader R1 = new StreamReader(@"C:\andres_roland\G51.txt"); 

            string linea; //para leer cada linea
            while ((linea = R1.ReadLine()) != null) //para leer hasta la ultima linea
            {
                nombres.Add(linea); //agrega cada linea a la lista de nombres
            }

            R1.Close();
            return nombres; 
        }

        public string Leeruno(string nombre)
        {
            using (StreamReader reader = new StreamReader(@"C:\andres_roland\G51.txt"))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    if (linea.Contains(nombre))
                    {
                        return linea;
                    }
                }
            }
            return null; // Si no se encuentra ninguna coincidencia, devolver null
        }
    }
}
