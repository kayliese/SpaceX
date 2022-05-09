using System;
namespace spacex_explore.Models.ResponseModels
{
    public class UserProfileResponse
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
    }
}
