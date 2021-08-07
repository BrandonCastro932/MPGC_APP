using MPGC_APP.Tools;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MPGC_API.Models
{
    public partial class User
    {
        public User()
        {
            UserGames = new HashSet<UserGame>();
        }

        public int Iduser { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public int IduserStatus { get; set; }

        public virtual UserStatus IduserStatusNavigation { get; set; }
        public virtual ICollection<UserGame> UserGames { get; set; }


        public User LoginUser()
        {
            string Consumo = ObjetosGlobales.RutaPruebas + "users/login";

            var client = new RestClient(Consumo);
            var request = new RestRequest(Method.GET);
            request.AddParameter("username", Username);
            request.AddParameter("password", Password);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKey);

            IRestResponse response = client.Execute(request);

            HttpStatusCode statusCode = response.StatusCode;

            var user = JsonConvert.DeserializeObject<User>(response.Content);

            if (statusCode == HttpStatusCode.OK)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public List<UserGame> GetUserGames()
        {
            string Consumo = string.Format(ObjetosGlobales.RutaPruebas + "users/usergames/{0}", Iduser);

            var client = new RestClient(Consumo);
            var request = new RestRequest(Method.GET);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKey);

            IRestResponse response = client.Execute(request);

            var userGames = JsonConvert.DeserializeObject<List<UserGame>>(response.Content);

            if (userGames != null)
            {
                return userGames;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> RegisterUser()
        {
            string Consumo = ObjetosGlobales.RutaPruebas + "users";

            var client = new RestClient(Consumo);
            var request = new RestRequest(Method.POST);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKey);
            request.AddHeader("Content-type", "application/json");

            string JsonClass = JsonConvert.SerializeObject(this);
            request.AddParameter("application/json", JsonClass, ParameterType.RequestBody);

            IRestResponse response = await client.ExecuteAsync(request);
            HttpStatusCode code = response.StatusCode;

            if (code == HttpStatusCode.Created)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
