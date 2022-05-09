using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using spacex_explore.Helpers;
using spacex_explore.Models;
using spacex_explore.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace spacex_explore.Services
{
    public class WebService
    {
        public async Task<string> WebRequest(string url, object requestBody, string type)
        {
            try
            {
                if (string.IsNullOrEmpty(url) || requestBody == null)
                {
                    var result = new
                    {
                        Code = 1,
                        Status = "Fail",
                        Message = "URL or Request body cannot be empty",
                        Data = ""
                    };

                    var json = JsonConvert.SerializeObject(result);
                    return json;
                }


                using (var httpClient = new HttpClient())
                {
                    var authHeader = new AuthenticationHeaderValue("bearer", await SecureStorage.GetAsync("token"));
                    httpClient.BaseAddress = new Uri(AppConstants.BaseUrl);
                    httpClient.DefaultRequestHeaders.Authorization = authHeader;

                    HttpResponseMessage result;
                    switch (type)
                    {
                        case "POST":
                            var content = new StringContent((string)requestBody, Encoding.UTF8, "application/json");
                            result = await httpClient.PostAsync(url, content);
                            if (result.StatusCode == HttpStatusCode.Unauthorized)
                            {
                                await Application.Current.MainPage.DisplayAlert("Message",
                                    "Login session has expired 😬. Please login again", "OK");
                                SecureStorage.RemoveAll();
                                Application.Current.MainPage = new NavigationPage(new LoginPage());
                                return null;
                            }
                            break;

                        case "GET":
                            result = await httpClient.GetAsync(url);
                            if (result.StatusCode == HttpStatusCode.Unauthorized)
                            {
                                await Application.Current.MainPage.DisplayAlert("Message",
                                    "Login session has expired 😬. Please login again", "OK");
                                SecureStorage.RemoveAll();
                                Application.Current.MainPage = new NavigationPage(new LoginPage());
                                return null;
                            }
                            break;

                        case "FORM":
                            result = await httpClient.PostAsync(url, (MultipartFormDataContent)requestBody);
                            break;

                        default:
                            var obj = new
                            {
                                Code = 1,
                                Status = "Fail",
                                Message = "Invalid Method type. POST or GET allowed.",
                                Data = ""
                            };

                            var er = JsonConvert.SerializeObject(obj);
                            return er;
                            break;
                    }

                    var response = await result.Content.ReadAsStringAsync();

                    if (result.IsSuccessStatusCode && result.StatusCode == HttpStatusCode.OK)
                    {
                        return response;
                    }
                    else if (result.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        var page = App.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
                        if (page != null && page.Title != "Login")
                        {
                            SecureStorage.RemoveAll();
                            Application.Current.MainPage = new NavigationPage(new LoginPage());
                        }
                    }
                    else if (result.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var erros = JsonConvert.DeserializeObject<ErrorModel>(response);
                        var errorMessage = "";

                        foreach (var er in erros.error)
                        {
                            errorMessage = errorMessage + $"\n{er}";
                        }

                        await Application.Current.MainPage.DisplayAlert("Error", errorMessage, "OK");
                    }

                    var error = new
                    {
                        Code = 1,
                        Status = "Fail",
                        Message = "Something went wrong. Please try again later!",
                        Data = ""
                    };

                    var json = JsonConvert.SerializeObject(error);
                    return json;
                }

            }
            catch (Exception ex)
            {
                var result = new
                {
                    Code = 1,
                    Status = "Fail",
                    Message = ex.InnerException?.Message ?? ex.Message,
                    Data = ""
                };

                var json = JsonConvert.SerializeObject(result);
                return json;
            }
        }

    }
}
