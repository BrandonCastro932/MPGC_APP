using System;
using System.Collections.Generic;
using System.Text;

namespace MPGC_APP.Tools
{
    public static class ObjetosGlobales
    {
        //Rutas de consumo (Producción y pruebas)
        public static string RutaProduccion = "http://192.168.100.173:45455/api/";
        public static string RutaPruebas = "http://192.168.100.173:45455/api/";

        //Seguridad ya sea JWT o ApiKey
        public static string ApiKeyName = "ApiKey";
        public static string ApiKey = "MPGC_ApiKey";
    }
}
