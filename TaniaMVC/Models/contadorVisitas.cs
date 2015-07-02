using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace TaniaMVC.Models
{
    public class contadorVisitas
    {
        const string counterfile = @"Content\Counter.txt";
        const string sessionvar = "checkCounter";

        public contadorVisitas()
        {
            //constructor
        }

        public static bool CountNewVisitor()
        {
            //Si existe variable de estado asociada al visitante: TERMINAR return false
            if (HttpContext.Current.Session[sessionvar] != null) { return false; }

            HttpContext.Current.Session[sessionvar] = (byte)0; //Crea la variable de sesion

            string path = AppDomain.CurrentDomain.BaseDirectory;
            string fcounter = path + counterfile; //Leyendo el fichero
            string line = "1";

            //Si el fichero existe incrementar el valor
            if (File.Exists(fcounter) == true)
            {
                using (StreamReader sr = new StreamReader(fcounter)) //Incrementar el contador
                {
                    line = sr.ReadLine();
                    try { line = Convert.ToString(Convert.ToInt32(line) + 1); }
                    catch { line = "0"; } //Proteccion contra corrupción de fichero
                    sr.Close();
                }
            }

            //Si no existe guarda 1, si existe guarda el valor incrementado
            using (StreamWriter wr = File.CreateText(fcounter))
            {
                wr.Write(line);
                wr.Flush();
                wr.Close();
            }
            return true;
        }

        public static int GetNumberVisitor()
        {
            try
            {
                //Si no existe variable de estado asociada al visitante: return -1 TERMINAR
                if (HttpContext.Current.Session[sessionvar] == null) { return -1; }

                //Si no existe fichero de conteo: return -2 TERMINAR
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string fcounter = path + counterfile;
                if (File.Exists(fcounter) != true) { return -2; }
                //Abrir fichero de conteo, leer variable, cerrar fichero de conteo
                using (StreamReader sr = new StreamReader(fcounter))
                {
                    int num = 0;
                    try { num = Convert.ToInt32(sr.ReadLine()); }
                    catch { num = -4; } //Proteccion contra corrupción de fichero
                    sr.Close();
                    return num; //return valor de conteo
                }
                

            }
            catch
            { return -3; }
        }
    }
}
