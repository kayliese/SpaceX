using System;
using System.Collections.Generic;

namespace spacex_explore.Models.ResponseModels
{
    public class CrewResponse
    {
        public string name { get; set; }
        public string agency { get; set; }
        public string image { get; set; }
        public string wikipedia { get; set; }
        public List<string> launches { get; set; }
        public string status { get; set; }
        public string id { get; set; }

        public bool isFav { get; set; }

        public CrewResponse()
        {
            launches = new List<string>();
        }
    }
}
