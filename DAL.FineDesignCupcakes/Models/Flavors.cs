﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.FineDesignCupcakes.Models
{

    public class Flavors
    {

        [Key]
        public int FlavorId { get; set; }
        public string FlavorName { get; set; }
        public string Image { get; set; }

        public string Thumbnail { get; set; }

    }

   
}
