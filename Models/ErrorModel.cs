using System;
using System.Collections.Generic;

namespace spacex_explore.Models
{
    public class ErrorModel
    {
        public ErrorModel()
        {
            error = new List<string>();
        }

        public List<string> error { get; set; }
    }
}
