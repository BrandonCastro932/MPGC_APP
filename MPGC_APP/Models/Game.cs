using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MPGC_APP.Tools;
using RestSharp;
using Newtonsoft.Json;
using System.Net;

namespace MPGC_API.Models
{
    public partial class Game
    {
        public Game()
        {
            GamePlatforms = new HashSet<GamePlatform>();
            GameScreenshots = new HashSet<GameScreenshot>();
            UserGames = new HashSet<UserGame>();
        }

        public int Idgame { get; set; }
        public string Name { get; set; }
        public DateTime Released { get; set; }
        public string BackgroundImage { get; set; }
        public decimal Rating { get; set; }
        public decimal Playtime { get; set; }
        public string Description { get; set; }
        public string UrlMusicTheme { get; set; }
        public int Idgenre { get; set; }

        public virtual Genre IdgenreNavigation { get; set; }
        public virtual ICollection<GamePlatform> GamePlatforms { get; set; }
        public virtual ICollection<GameScreenshot> GameScreenshots { get; set; }
        public virtual ICollection<UserGame> UserGames { get; set; }

        public ObservableCollection<Game> GetAllGames()
        {
            string Consumo = ObjetosGlobales.RutaPruebas + "Games";

            var client = new RestClient(Consumo);
            var request = new RestRequest(Method.GET);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKey);

            IRestResponse response = client.Execute(request);

            HttpStatusCode statusCode = response.StatusCode;
            Console.WriteLine(response);
            var AllGames = JsonConvert.DeserializeObject<ObservableCollection<Game>>(response.Content);

            if(statusCode == HttpStatusCode.OK)
            {
                return AllGames;
            }
            else
            {
                return null;
            }

        }
        public Game GetGameById(int id)
        {
            string Consumo = string.Format(ObjetosGlobales.RutaPruebas + "Games/{0}",id);

            var client = new RestClient(Consumo);
            var request = new RestRequest(Method.GET);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKey);

            IRestResponse response = client.Execute(request);

            HttpStatusCode statusCode = response.StatusCode;

            Game game = (Game)JsonConvert.DeserializeObject(response.Content);

            if (statusCode == HttpStatusCode.OK)
            {
                return game;
            }
            else
            {
                return null;
            }

        }
    }
}
