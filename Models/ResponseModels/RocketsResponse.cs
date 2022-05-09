using System;
using System.Collections.Generic;

namespace spacex_explore.Models.ResponseModels
{
    public class Height
    {
        public double? meters { get; set; }
        public double? feet { get; set; }
    }

    //public class Diameter
    //{
    //    public double? meters { get; set; }
    //    public double? feet { get; set; }
    //}

    public class Mass
    {
        public int kg { get; set; }
        public int lb { get; set; }
    }

    public class ThrustSeaLevel
    {
        public int kN { get; set; }
        public int lbf { get; set; }
    }

    public class ThrustVacuum
    {
        public int kN { get; set; }
        public int lbf { get; set; }
    }

    public class FirstStage
    {
        public ThrustSeaLevel thrust_sea_level { get; set; }
        public ThrustVacuum thrust_vacuum { get; set; }
        public bool reusable { get; set; }
        public int engines { get; set; }
        public double fuel_amount_tons { get; set; }
        public int? burn_time_sec { get; set; }
    }

    //public class Thrust
    //{
    //    public int kN { get; set; }
    //    public int lbf { get; set; }
    //}

    public class CompositeFairing
    {
        public Height height { get; set; }
        public Diameter diameter { get; set; }
    }

    public class Payloads
    {
        public CompositeFairing composite_fairing { get; set; }
        public string option_1 { get; set; }
    }

    public class SecondStage
    {
        //public Thrust thrust { get; set; }
        public Payloads payloads { get; set; }
        public bool reusable { get; set; }
        public int engines { get; set; }
        public double fuel_amount_tons { get; set; }
        public int? burn_time_sec { get; set; }
    }

    public class Isp
    {
        public int sea_level { get; set; }
        public int vacuum { get; set; }
    }

    public class Engines
    {
        public Isp isp { get; set; }
        public ThrustSeaLevel thrust_sea_level { get; set; }
        public ThrustVacuum thrust_vacuum { get; set; }
        public int number { get; set; }
        public string type { get; set; }
        public string version { get; set; }
        public string layout { get; set; }
        public int? engine_loss_max { get; set; }
        public string propellant_1 { get; set; }
        public string propellant_2 { get; set; }
        public double thrust_to_weight { get; set; }
    }

    public class LandingLegs
    {
        public int number { get; set; }
        public string material { get; set; }
    }

    public class PayloadWeight
    {
        public string id { get; set; }
        public string name { get; set; }
        public int kg { get; set; }
        public int lb { get; set; }
    }

    public class RocketsResponse
    {
        public Height height { get; set; }
        //public Diameter diameter { get; set; }
        public Mass mass { get; set; }
        public FirstStage first_stage { get; set; }
        //public SecondStage second_stage { get; set; }
        public Engines engines { get; set; }
        public LandingLegs landing_legs { get; set; }
        public List<PayloadWeight> payload_weights { get; set; }
        public List<string> flickr_images { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public bool active { get; set; }
        public int stages { get; set; }
        public int boosters { get; set; }
        public int cost_per_launch { get; set; }
        public int success_rate_pct { get; set; }
        public string first_flight { get; set; }
        public string country { get; set; }
        public string company { get; set; }
        public string wikipedia { get; set; }
        public string description { get; set; }
        public string id { get; set; }

        public bool isFav { get; set; } = false;

        public RocketsResponse()
        {
            payload_weights = new List<PayloadWeight>();
            flickr_images = new List<string>();
        }
    }
}
