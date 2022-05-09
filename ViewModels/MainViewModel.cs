using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers.Commands;
using Newtonsoft.Json;
using spacex_explore.Models;
using spacex_explore.Models.ResponseModels;
using spacex_explore.Services;
using spacex_explore.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace spacex_explore.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        WebService webService;
        public MainViewModel()
        {
            webService = new WebService();

            AddFav = new MvvmHelpers.Commands.Command<string>(async (id) =>
            {
                await MakeFav(id);
            });

            UpdateProfileCommand = new MvvmHelpers.Commands.Command(async () =>
            {
                await UpdateProfile();
            });

            MessagingCenter.Subscribe<string>(this, "RefreshData", async (ex) => {
                _ = GetFav();
            });
        }


        public ICommand AddFav { get; set; }
        public ICommand UpdateProfileCommand { get; set; }

        #region
        private UserProfileResponse _profile { get; set; }
        public UserProfileResponse profile
        {
            get
            {
                return _profile;
            }
            set
            {
                _profile = value;
                OnPropertyChanged();
            }
        }

        public List<FavResponse> MyFavList { get; set; }

        private CompanyResponse _Company { get; set; }
        public CompanyResponse Company
        {
            get
            {
                return _Company;
            }
            set
            {
                _Company = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<HistoryResponse> _History { get; set; }
        public ObservableCollection<HistoryResponse> History
        {
            get
            {
                return _History;
            }
            set
            {
                _History = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<LaunchesResponse> _Launches { get; set; }
        public ObservableCollection<LaunchesResponse> Launches
        {
            get
            {
                return _Launches;
            }
            set
            {
                _Launches = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<RocketsResponse> _Rockets { get; set; }
        public ObservableCollection<RocketsResponse> Rockets
        {
            get
            {
                return _Rockets;
            }
            set
            {
                _Rockets = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ShipsResponse> _Ships { get; set; }
        public ObservableCollection<ShipsResponse> Ships
        {
            get
            {
                return _Ships;
            }
            set
            {
                _Ships = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<DragonResponse> _Dragons { get; set; }
        public ObservableCollection<DragonResponse> Dragons
        {
            get
            {
                return _Dragons;
            }
            set
            {
                _Dragons = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<DragonResponse> _FavDragons { get; set; }
        public ObservableCollection<DragonResponse> FavDragons
        {
            get
            {
                return _FavDragons;
            }
            set
            {
                _FavDragons = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CrewResponse> _Crews { get; set; }
        public ObservableCollection<CrewResponse> Crews
        {
            get
            {
                return _Crews;
            }
            set
            {
                _Crews = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CrewResponse> _FavCrews { get; set; }
        public ObservableCollection<CrewResponse> FavCrews
        {
            get
            {
                return _FavCrews;
            }
            set
            {
                _FavCrews = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<StarlinkResponse> _StartLinks { get; set; }
        public ObservableCollection<StarlinkResponse> StartLinks
        {
            get
            {
                return _StartLinks;
            }
            set
            {
                _StartLinks = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<StarlinkResponse> _FavStartLinks { get; set; }
        public ObservableCollection<StarlinkResponse> FavStartLinks
        {
            get
            {
                return _FavStartLinks;
            }
            set
            {
                _FavStartLinks = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<LaunchesResponse> _FavLaunches { get; set; }
        public ObservableCollection<LaunchesResponse> FavLaunches
        {
            get
            {
                return _FavLaunches;
            }
            set
            {
                _FavLaunches = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<RocketsResponse> _FavRockets { get; set; }
        public ObservableCollection<RocketsResponse> FavRockets
        {
            get
            {
                return _FavRockets;
            }
            set
            {
                _FavRockets = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ShipsResponse> _FavShips { get; set; }
        public ObservableCollection<ShipsResponse> FavShips
        {
            get
            {
                return _FavShips;
            }
            set
            {
                _FavShips = value;
                OnPropertyChanged();
            }
        }

        async internal Task UpdateProfile()
        {
            IsBusy = true;

            if (string.IsNullOrWhiteSpace(profile.fullName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Full name cannot be empty", "OK");
                return;
            }

            var result = await webService.WebRequest("api/Account/UpdateUserProfile", JsonConvert.SerializeObject(profile), "POST");
            var response = JsonConvert.DeserializeObject<UserProfileResponse>(result);

            if (response == null || response.id <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong. Please try again", "OK");
            }


            profile.fullName = response.fullName;
            IsBusy = false;

            await Application.Current.MainPage.DisplayAlert("Success", "Your profile updated", "OK");

            return;
        }

        internal async Task<bool> Register(RegistrationModel user)
        {
            IsBusy = true;
            if (user == null)
            {
                IsBusy = false;
                return false;
            }


            try
            {

                var result = await webService.WebRequest("api/account/register", JsonConvert.SerializeObject(user), "POST");
                var responseObj = JsonConvert.DeserializeObject<RegisterResponse>(result);

                if (responseObj == null || responseObj.id <= 0)
                {
                    IsBusy = false;
                    return false;
                }

                IsBusy = false;
                return true;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                return false;
            }
        }

        async internal Task<bool> Login(LoginModel loginModel)
        {
            IsBusy = true;
            if (loginModel == null)
            {
                IsBusy = false;
                return false;
            }

            try
            {

                var result = await webService.WebRequest("api/account/login", JsonConvert.SerializeObject(loginModel), "POST");
                var response = JsonConvert.DeserializeObject<LoginResponse>(result);

                if (response == null || string.IsNullOrWhiteSpace(response.token))
                {
                    IsBusy = false;
                    return false;
                }

                await SecureStorage.SetAsync("token", response.token);
                await SecureStorage.SetAsync("userId", $"{response.userId}");

                IsBusy = false;
                return true;
            }
            catch (Exception ex)
            {
                IsBusy = false;
                return false;
            }
        }

        internal async Task GetUserProfile()
        {
            IsBusy = true;

            var response = await webService.WebRequest("api/Account/GetUserProfile", JsonConvert.SerializeObject(new { userId = Convert.ToInt32(await SecureStorage.GetAsync("userId")) }), "POST");

            var _profile = JsonConvert.DeserializeObject<UserProfileResponse>(response);

            profile = _profile;

            IsBusy = false;

        }

        internal async Task GetCompany()
        {
            IsBusy = true;

            var response = await webService.WebRequest("api/Space/company", "", "GET");
            var company = JsonConvert.DeserializeObject<CompanyResponse>(response);

            Company = company;

            IsBusy = false;
        }

        internal async Task GetHistory()
        {
            IsBusy = true;

            var response = await webService.WebRequest("api/Space/history", "", "GET");
            var history = JsonConvert.DeserializeObject<ObservableCollection<HistoryResponse>>(response);

            History = new ObservableCollection<HistoryResponse>(history);

            IsBusy = false;
        }

        #endregion

        internal async Task GetLaunches()
        {
            IsBusy = true;

            var response = await webService.WebRequest("api/Space/launches", "", "GET");
            var launches = JsonConvert.DeserializeObject<ObservableCollection<LaunchesResponse>>(response);

            var favlaunches = new List<LaunchesResponse>();

            // Check any launch is in fav and marking it
            foreach (var _fav in MyFavList)
            {
                if (launches.FirstOrDefault(x => x.id == _fav.postId) != null)
                {
                    launches.FirstOrDefault(x => x.id == _fav.postId).isFav = true;
                    favlaunches.Add(launches.FirstOrDefault(x => x.id == _fav.postId));
                }
            }

            // Reverse the list for order list to latest to top
            var _las = new List<LaunchesResponse>(launches);
            _las.Reverse();

            Launches = new ObservableCollection<LaunchesResponse>(_las);

            favlaunches.Reverse();
            FavLaunches = new ObservableCollection<LaunchesResponse>(favlaunches);

            IsBusy = false;
        }

        internal async Task GetExplore()
        {
            IsBusy = true;

            // Getting ships
            var response = await webService.WebRequest("api/Space/ships", "", "GET");
            var ships = JsonConvert.DeserializeObject<ObservableCollection<ShipsResponse>>(response);

            var favships = new List<ShipsResponse>();

            foreach (var _fav in MyFavList)
            {
                if (ships.FirstOrDefault(x => x.id == _fav.postId) != null)
                {
                    ships.FirstOrDefault(x => x.id == _fav.postId).isFav = true;
                    favships.Add(ships.FirstOrDefault(x => x.id == _fav.postId));
                }
            }

            Ships = new ObservableCollection<ShipsResponse>(ships);
            FavShips = new ObservableCollection<ShipsResponse>(favships);

            // Getting rockets
            var rocketResponse = await webService.WebRequest("api/Space/rockets", "", "GET");
            var rockets = JsonConvert.DeserializeObject<ObservableCollection<RocketsResponse>>(rocketResponse);
            var favrockets = new List<RocketsResponse>();

            foreach (var _fav in MyFavList)
            {
                if (rockets.FirstOrDefault(x => x.id == _fav.postId) != null)
                {
                    var rock = rockets.FirstOrDefault(x => x.id == _fav.postId);
                    rock.isFav = true;

                    favrockets.Add(rock);
                }
            }

            Rockets = new ObservableCollection<RocketsResponse>(rockets);
            FavRockets = new ObservableCollection<RocketsResponse>(favrockets);

            // Getting dragons
            var dragonResponse = await webService.WebRequest("api/Space/dragons", "", "GET");
            var dragons = JsonConvert.DeserializeObject<ObservableCollection<DragonResponse>>(dragonResponse);
            var favdragons = new List<DragonResponse>();

            foreach (var _fav in MyFavList)
            {
                if (dragons.FirstOrDefault(x => x.id == _fav.postId) != null)
                {
                    var dragon = dragons.FirstOrDefault(x => x.id == _fav.postId);
                    dragon.isFav = true;

                    favdragons.Add(dragon);
                }
            }

            Dragons = new ObservableCollection<DragonResponse>(dragons);
            FavDragons = new ObservableCollection<DragonResponse>(favdragons);

            // Getting crew
            var crewResponse = await webService.WebRequest("api/Space/crew", "", "GET");
            var crews = JsonConvert.DeserializeObject<ObservableCollection<CrewResponse>>(crewResponse);
            var favcrew = new List<CrewResponse>();

            foreach (var _fav in MyFavList)
            {
                if (crews.FirstOrDefault(x => x.id == _fav.postId) != null)
                {
                    var crew = crews.FirstOrDefault(x => x.id == _fav.postId);
                    crew.isFav = true;

                    favcrew.Add(crew);
                }
            }

            Crews = new ObservableCollection<CrewResponse>(crews);
            FavCrews = new ObservableCollection<CrewResponse>(favcrew);

            // Getting starLink
            var starResponse = await webService.WebRequest("api/Space/starlink", "", "GET");
            var stars = JsonConvert.DeserializeObject<ObservableCollection<StarlinkResponse>>(starResponse);
            var favstarts = new List<StarlinkResponse>();

            //foreach (var _fav in MyFavList)
            //{
            //    if (crews.FirstOrDefault(x => x.id == _fav.postId) != null)
            //    {
            //        var crew = crews.FirstOrDefault(x => x.id == _fav.postId);
            //        crew.isFav = true;

            //        favcrew.Add(crew);
            //    }
            //}

            StartLinks = new ObservableCollection<StarlinkResponse>(stars);
            FavStartLinks = new ObservableCollection<StarlinkResponse>(favstarts);


            IsBusy = false;
        }

        internal async Task<bool> GetFav()
        {
            IsBusy = true;

            var response = await webService.WebRequest("api/Account/GetFavorites", JsonConvert.SerializeObject(new { userId = await SecureStorage.GetAsync("userId") }), "POST");
            if (response == null)
                return false;

            var result = JsonConvert.DeserializeObject<List<FavResponse>>(response);           

            MyFavList = new List<FavResponse>(result);

            await GetCompany();
            await GetHistory();
            await GetUserProfile();

            // Call apis after the fav becasue its check with fav response
            await GetExplore();
            await GetLaunches();

            IsBusy = false;
            return true;
        }

        internal async Task MakeFav(string id)
        {
            IsBusy = true;

            // Check already fav then do removing
            if (MyFavList.FirstOrDefault(x => x.postId == id) != null)
            {
                await RemoveFav(id);
                return;
            }

            var response = await webService.WebRequest("api/Account/PostFavorites", JsonConvert.SerializeObject(new { postId = id, userId = await SecureStorage.GetAsync("userId") }), "POST");

            // Adding to fav list
            var fav = new FavResponse
            {
                id = MyFavList.Count + 1,
                postId = id,
                userId = await SecureStorage.GetAsync("userId")
            };

            MyFavList.Add(fav);
            RefreshData();

            //IsBusy = false;
        }

        internal async Task RemoveFav(string id)
        {
            IsBusy = true;

            var response = await webService.WebRequest("api/Account/DeleteFavorites", JsonConvert.SerializeObject(new { postId = id, userId = await SecureStorage.GetAsync("userId") }), "POST");

            var rem = MyFavList.FirstOrDefault(x => x.postId == id);
            if (rem == null)
                return;

            MyFavList.Remove(rem);
            RefreshData();

            //IsBusy = false;
        }

        

        internal async void RefreshData()
        {
            await GetExplore();
            await GetLaunches();
        }
    }
}
