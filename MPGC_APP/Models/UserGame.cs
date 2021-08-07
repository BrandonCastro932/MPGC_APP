using MPGC_APP.Tools;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MPGC_API.Models
{
    public partial class UserGame
    {
        public int IduserGame { get; set; }
        public int IdgameState { get; set; }
        public int Idgame { get; set; }
        public int Iduser { get; set; }

        public virtual Game IdgameNavigation { get; set; }
        public virtual GameState IdgameStateNavigation { get; set; }
        public virtual User IduserNavigation { get; set; }

        public async Task<bool> RegisterGame()
        {
            string Consumo = ObjetosGlobales.RutaPruebas + "usergames";

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

            return false;
        }
        public async Task<bool> DeleteGame()
        {
            string Consumo = ObjetosGlobales.RutaPruebas + "usergames";

            var client = new RestClient(Consumo);
            var request = new RestRequest(Method.DELETE);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKey);
            request.AddHeader("Content-type", "application/json");

            string JsonClass = JsonConvert.SerializeObject(this);
            request.AddParameter("application/json", JsonClass, ParameterType.RequestBody);

            IRestResponse response = await client.ExecuteAsync(request);
            HttpStatusCode code = response.StatusCode;

            if (code == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }
    }
}
