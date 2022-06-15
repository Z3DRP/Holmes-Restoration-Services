using System;
using System.ComponentModel.DataAnnotations;
using HolmesServices.ErrorMessages;
using HolmesServices.Errors;
using HolmesServices.DataAccess;
using System.Collections.Generic;

namespace HolmesServices.Models
{
    public class Design
    {
        [Required(ErrorMessage = "Design Id required")]
        [Range(0, int.MaxValue, ErrorMessage = "Id must be a positive number")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Customer Id requried")]
        [Range(0, int.MaxValue, ErrorMessage = "Id must be a positive number")]
        public int Customer_Id { get; set; }
        //navigational property - fk
        public Customer Customer { get; set; }


        [Required(ErrorMessage = "Decking Id required")]
        [Range(0, int.MaxValue, ErrorMessage = "Id must be a positive number")]
        public int Decking_Id { get; set; }
        //navigational property - fk
        public Decking Deck { get; set; }


        [Required(ErrorMessage = "Railing Id required")]
        [Range(0, int.MaxValue, ErrorMessage = "Id must be a positive number")]
        public int Railing_Id { get; set; }
        //navigational property - fk
        public Railing Rail { get; set; }


        [Required(ErrorMessage = "Length is requried")]
        [Range(0,1000000,ErrorMessage = "Length must be between 0 - 1000000")]
        public double Length { get; set; }


        [Required(ErrorMessage = "Width is required")]
        public double Width { get; set; }


        [Required(ErrorMessage = "Square feet is required")]
        public double Square_Ft { get => this.Square_Ft; set => CalcSquareFeet(); }


        [Required(ErrorMessage = "Estimate required")]
        public double Estimate { get => this.Estimate; set => CalcEstimate(); }


        [Required(ErrorMessage = "Start date required")]
        public DateTime Start_Date { get; set; }
        // nav property
        public ICollection<Job> Jobs { get; set; }

        private double CalcSquareFeet()
        {
            return this.Length * this.Width;
        }
        private double CalcEstimate()
        {
            double deckPrice = 0;
            double railPrice = 0;
            (double, double) prices = (deckPrice, railPrice);
            double estimate = 0;

            prices = GetPrices();
            estimate = ((prices.Item1 * Square_Ft) + (prices.Item2 * Square_Ft));

            return estimate;
        }
        private (double, double) GetPrices()
        {
            double deckPrice = 0;
            double railPrice = 0;

            deckPrice = DeckingDB.GetDeckPrice_PerSqft(Decking_Id);
            railPrice = RailingDB.GetRailPrice_PerSqft(Railing_Id);

            return (deckPrice, railPrice);
        }
    }
}
