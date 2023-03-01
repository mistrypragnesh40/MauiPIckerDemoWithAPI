using DropDownDemoWithAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropDownDemoWithAPI.Services
{
    public interface ITestService
    {
        Task<string> GetAccessToken();
        Task<List<CountryModel>> GetCountryList();
        Task<List<StateModel>> GetStateListByCountryName(string countryName);
        Task<List<CityModel>> GetCityListByStateName(string stateName);
    }
}
