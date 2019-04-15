using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.FineDesignCupcakes.Models
{
    public class Frostings
    {

        [Key]
        public int FrostingId { get; set; }
        public string FrostingName { get; set; }
        public string Image { get; set; }

        public string Thumbnail { get; set; }

    }
}
