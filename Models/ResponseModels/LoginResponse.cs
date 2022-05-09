using System;
namespace spacex_explore.Models.ResponseModels
{
    public class LoginResponse
    {
        public string token { get; set; }
        public int userId { get; set; }
    }
}
