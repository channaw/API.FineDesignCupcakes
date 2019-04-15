using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.FineDesignCupcakes.Models
{
    public class Toppings
    {

        [Key]
        public int ToppingId { get; set; }
        public string ToppingName { get; set; }
        public string Image { get; set; }
        public string Thumbnail { get; set; }

    }
}
