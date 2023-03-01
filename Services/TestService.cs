using DropDownDemoWithAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropDownDemoWithAPI.Services
{
    public class TestService : ITestService
    {

        /// <summary>
        /// https://www.universal-tutorial.com/rest-apis/free-rest-api-for-country-state-city
        /// use above url to get api-token 
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetAccessToken()
        {

            string token = string.Empty;
            using (var client = new HttpClient())
            {
                // api-token
                client.DefaultRequestHeaders.Add("api-token", "T6VPNRfWnLEngl0wvv7-gWvcOJDqOJJmsvh6CNtj9kzugTRbHouuDOSWy7sbbstnmh0");
                //user-email that registered on  https://www.universal-tutorial.com/rest-apis/free-rest-api-for-country-state-city
                client.DefaultRequestHeaders.Add("user-email", "ask@universal-tutorial.com");


                var response = await client.GetAsync($"{App.BaseUrl}/getaccesstoken");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var responseDetails = JsonConvert.DeserializeObject<TokenResponse>(content);

                    if (!string.IsNullOrWhiteSpace(responseDetails.Auth_Token))
                    {
                        token = responseDetails.Auth_Token;
                    }

                }
            }
            return token;
        }

        public async Task<List<CountryModel>> GetCountryList()
        {
            var countryList = new List<CountryModel>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.Token);
                var response = await client.GetAsync($"{App.BaseUrl}/countries");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    countryList = JsonConvert.DeserializeObject<List<CountryModel>>(content);
                }
            }
            return countryList;
        }

        public async Task<List<StateModel>> GetStateListByCountryName(string countryName)
        {
            var stateList = new List<StateModel>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.Token);
                var response = await client.GetAsync($"{App.BaseUrl}/states/{countryName}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    stateList = JsonConvert.DeserializeObject<List<StateModel>>(content);
                }
            }
            return stateList;
        }

        public async Task<List<CityModel>> GetCityListByStateName(string stateName)
        {
            var cityList = new List<CityModel>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.Token);
                var response = await client.GetAsync($"{App.BaseUrl}/cities/{stateName}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    cityList = JsonConvert.DeserializeObject<List<CityModel>>(content);
                }
            }
            return cityList;
        }
    }
}
