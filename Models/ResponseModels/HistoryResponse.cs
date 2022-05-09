using System;
namespace spacex_explore.Models.ResponseModels
{
    public class HistoryLinks
    {
        public string article { get; set; }
    }

    public class HistoryResponse
    {
        public HistoryLinks links { get; set; }
        public string title { get; set; }
        public DateTime event_date_utc { get; set; }
        public int event_date_unix { get; set; }
        public string details { get; set; }
        public string id { get; set; }

        public HistoryResponse()
        {
            links = new HistoryLinks();
        }
    }

}
