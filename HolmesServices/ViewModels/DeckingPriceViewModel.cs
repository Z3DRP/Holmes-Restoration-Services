﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.ViewModels
{
    public class DeckingPriceViewModel
    {
        public int Id { get; set; }
        public string Product_Code { get; set; }   
        public string Name { get; set; }
        public double Price_Per_SqFt { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
