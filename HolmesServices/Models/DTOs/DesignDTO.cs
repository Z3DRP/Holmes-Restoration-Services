﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.Models.DTOs
{
    public class DesignDTO
    {
        public int DesignId { get; set; }
        public int DeckId { get; set; }
        public int RailId { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Estimate { get; set; }

        public void Load(Design design)
        {
            DesignId = design.Id;
            DeckId = design.Decking_Id;
            RailId = design.Railing_Id;
            Length = design.Length;
            Width = design.Width;
            Estimate = design.Estimate;
        }
    }
}
