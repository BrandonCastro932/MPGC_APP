﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MPGC_APP.Tools
{
    public static class ObjetosGlobales
    {
        //Rutas de consumo (Producción y pruebas)
        //Ruta API Azure Brandon: https://mpgcapi20210730165803.azurewebsites.net/api/
        //Ruta Local Brandon: http://192.168.159.1:45455/api/

        public static string RutaProduccion = "http://192.168.159.1:45455/api/";
        public static string RutaPruebas = "http://192.168.159.1:45455/api/";

        //Seguridad ya sea JWT o ApiKey
        public static string ApiKeyName = "ApiKey";
        public static string ApiKey = "MPGC_ApiKey";
    }
}
