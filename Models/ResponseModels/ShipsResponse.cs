using System;
using System.Collections.Generic;

namespace spacex_explore.Models.ResponseModels
{
    public class ShipsResponse
    {
        public object last_ais_update { get; set; }
        public string legacy_id { get; set; }
        public string model { get; set; }
        public string type { get; set; }
        public List<string> roles { get; set; }
        public int? imo { get; set; }
        public int? mmsi { get; set; }
        public int? abs { get; set; }
        public int? @class { get; set; }
        public int? mass_kg { get; set; }
        public int? mass_lbs { get; set; }
        public int? year_built { get; set; }
        public string home_port { get; set; }
        public string status { get; set; }
        public object speed_kn { get; set; }
        public object course_deg { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        public string link { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public List<string> launches { get; set; }
        public string id { get; set; }

        public bool isFav { get; set; } = false;

        public ShipsResponse()
        {
            roles = new List<string>();
            launches = new List<string>();
        }
    }
}
