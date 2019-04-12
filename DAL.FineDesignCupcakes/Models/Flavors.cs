using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace DAL.FineDesignCupcakes.Models
{

    public class Flavors
    {
        public string FlavorName { get; set; }
        public string Image { get; set; }

        public string Thumbnail { get; set; }

    }
}
