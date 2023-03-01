using CommunityToolkit.Mvvm.ComponentModel;
using DropDownDemoWithAPI.Models;
using DropDownDemoWithAPI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropDownDemoWithAPI.ViewModels
{
    public partial class DropDownDetailPageViewModel : ObservableObject
    {
        private CountryModel _selectedCountry;
        public CountryModel SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                IsStateSelectionEnable = true;
                OnPropertyChanged(nameof(IsStateSelectionEnable));
                GetStateListByCountryID();
            }
        }

        private int _selectedIndex = -1;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => SetProperty(ref _selectedIndex, value);
        }

        private StateModel _selectedState;
        public StateModel SelectedState
        {
            get => _selectedState;
            set
            {
                _selectedState = value;
                IsCitySelectionEnable = true;
                OnPropertyChanged(nameof(IsCitySelectionEnable));
                GetCityListByStateID();
            }
        }


        public bool IsStateSelectionEnable { get; set; }
        public bool IsCitySelectionEnable { get; set; }


        [ObservableProperty]
        private bool _isCountryLoading;

        [ObservableProperty]
        private bool _isStateLoading;

        [ObservableProperty]
        private bool _isCityLoading;

        public ObservableCollection<CountryModel> CountryList { get; set; } = new ObservableCollection<CountryModel>();
        public ObservableCollection<StateModel> StateList { get; set; } = new ObservableCollection<StateModel>();
        public ObservableCollection<CityModel> CityList { get; set; } = new ObservableCollection<CityModel>();



        private readonly ITestService _testService;
        public DropDownDetailPageViewModel(ITestService testService)
        {
            _testService = testService;
            GetCountryList();
        }

        private async void GetCountryList()
        {

            IsCountryLoading = true;

            App.Token = await _testService.GetAccessToken();

            if (string.IsNullOrWhiteSpace(App.Token))
            {
                await App.Current.MainPage.DisplayAlert("Oops", "token not available", "OK");
            }

            var response = await _testService.GetCountryList();
            if (response?.Count > 0)
            {
                foreach (var country in response)
                {
                    CountryList.Add(country);
                }
            }

            SelectedIndex = 0; // display item available at index 0  as default item.
            IsCountryLoading = false;
        }

        private async void GetStateListByCountryID()
        {
            if (SelectedCountry != null)
            {
                StateList.Clear();
                IsStateLoading = true;
                var response = await _testService.GetStateListByCountryName(SelectedCountry.Country_Name);
                if (response?.Count > 0)
                {
                    foreach (var state in response)
                    {
                        StateList.Add(state);
                    }
                }
                IsStateLoading = false;
            }

        }

        private async void GetCityListByStateID()
        {
            if (SelectedState != null)
            {
                CityList.Clear();
                IsCityLoading = true;
                var response = await _testService.GetCityListByStateName(SelectedState.State_Name);
                if (response?.Count > 0)
                {
                    foreach (var city in response)
                    {
                        CityList.Add(city);
                    }
                }
                IsCityLoading = false;
            }

        }
    }
}
