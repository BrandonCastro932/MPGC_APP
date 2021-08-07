using MPGC_API.Models;
using System.Collections.ObjectModel;

namespace MPGC_APP.Tools
{
    public static class ObjetosGlobales
    {
        //Rutas de consumo (Producción y pruebas)
        //Ruta API Azure Brandon: https://mpgcapi20210730165803.azurewebsites.net/api/
        //Ruta Local Brandon: http://192.168.159.1:45455/api/

        public static string RutaProduccion = "https://mpgcapi20210730165803.azurewebsites.net/api/";
        public static string RutaPruebas = "https://mpgcapi20210730165803.azurewebsites.net/api/";

        //Seguridad ya sea JWT o ApiKey
        public static string ApiKeyName = "ApiKey";
        public static string ApiKey = "MPGC_ApiKey";

        public static AppShell shell;

        public static User userLog = new User();

        public static ObservableCollection<UserGame> Completed = new ObservableCollection<UserGame>();
        public static ObservableCollection<UserGame> Playing = new ObservableCollection<UserGame>();
        public static ObservableCollection<UserGame> Queue = new ObservableCollection<UserGame>();
        public static ObservableCollection<UserGame> Wishlist = new ObservableCollection<UserGame>();

        public static bool isUserLogged = false;
    }
}
