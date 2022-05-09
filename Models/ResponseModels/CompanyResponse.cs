using System;
namespace spacex_explore.Models.ResponseModels
{ 
    public class Headquarters
    {
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }

    public class Links
    {
        public string website { get; set; }
        public string flickr { get; set; }
        public string twitter { get; set; }
        public string elon_twitter { get; set; }
    }

    public class CompanyResponse
    {
        public Headquarters headquarters { get; set; }
        public Links links { get; set; }
        public string name { get; set; }
        public string founder { get; set; }
        public int founded { get; set; }
        public int employees { get; set; }
        public int vehicles { get; set; }
        public int launch_sites { get; set; }
        public int test_sites { get; set; }
        public string ceo { get; set; }
        public string cto { get; set; }
        public string coo { get; set; }
        public string cto_propulsion { get; set; }
        public long valuation { get; set; }
        public string summary { get; set; }
        public string id { get; set; }

        public CompanyResponse()
        {
            links = new Links();
            headquarters = new Headquarters();
        }
    }


}
