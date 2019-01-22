using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UIFaces.NET.Models;
using Newtonsoft.Json;

namespace UIFaces.NET.Services
{
    public partial class UIFacesService
    {
        readonly string APIKey;


        public UIFacesService(string APIKey)
        {
            if (string.IsNullOrWhiteSpace(APIKey))
            {
                throw new ArgumentException("API-key cannot be empty.");
            }
            this.APIKey = APIKey;
        }

        /// <summary>
        /// Get persons
        /// </summary>
        /// <param name="Limit">Limit the number of results.</param>
        /// <param name="Offset">Offset where to start the sequence from.</param>
        /// <param name="Gender">Specify the gender: male or female.</param>
        /// <param name="Random">Show random instead of popular avatars.</param>
        /// <param name="FromAge">Minimum age of people in avatars.</param>
        ///<param name="ToAge">Maximum age of people in avatars.</param>
        ///<param name="Haircolor">Hair color of people in avatars.</param>
        ///<param name="Emotion">Emotion of people in avatars.</param>
        /// <returns>A list of Persons (inc. Name, Email, Profession and URL of the picture).</returns>
        /// 
        public async Task<List<Person>> GetFaces(int Limit = 10, int Offset = 10, List<Gender> Genders = null, bool Random = true, int FromAge = 18, int ToAge = 40, List<string> Haircolors = null, List<string> Emotions = null)
        {
            string URL = RequestURL(Limit, Offset, Genders, Random, FromAge, ToAge, Haircolors, Emotions);


            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Add("X-API-KEY", APIKey);
            HttpResponseMessage Response = await Client.GetAsync(URL);

            if (Response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Person>>(await Response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("UI Faces API request failed: " + Response.StatusCode + " - " + Response.ReasonPhrase);
            }
        }

        string RequestURL(int Limit, int Offset, List<Gender> Genders, bool Random, int FromAge, int ToAge, List<string> Haircolors, List<string> Emotions)
        {
            var queryString = new StringBuilder("https://uifaces.co/api");

            queryString.Append("?limit=" + Limit.ToString());
            queryString.Append("&offset=" + Offset.ToString());
            queryString.Append("&random=" + Random.ToString());
            queryString.Append("&from_age=" + FromAge.ToString());
            queryString.Append("&to_age=" + ToAge.ToString());

            if (Genders != null)
            {
                foreach (Gender Gender in Genders)
                {
                    queryString.Append("&gender[]=" + Gender.ToString());
                }
            }

            if (Haircolors != null)
            {
                foreach (string Color in Haircolors)
                {
                    queryString.Append("&hairColor[]=" + Color);
                }
            }

            if (Emotions != null)
            {
                foreach (string Emotion in Emotions)
                {
                    queryString.Append("&emotion[]=" + Emotion);
                }
            }

            System.Diagnostics.Debug.WriteLine(queryString);
            return queryString.ToString().ToLower();
        }
    }
}