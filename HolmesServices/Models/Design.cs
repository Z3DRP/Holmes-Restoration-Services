using System;
using System.ComponentModel.DataAnnotations;
using HolmesServices.ErrorMessages;
using HolmesServices.Errors;
using HolmesServices.DataAccess;

namespace HolmesServices.Models
{
    public class Design
    {
        [Required(ErrorMessage = "Design Id required")]
        public int? Id
        {
            get => Id.Value;
            set
            {
                if (value > 0 && value <= int.MaxValue)
                    this.Id = value;
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("greaterZero", "Id"));
            }
        }
        [Required(ErrorMessage = "Customer Id requried")]
        public int? Customer_Id
        {
            get => Customer_Id.Value;
            set
            {
                if (value > 0 && value <= int.MaxValue)
                    this.Customer_Id = value;
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("greaterZero", "Id"));
            }
        }
        //navigation property / foreign key
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Decking Id required")]
        public int? Decking_Id
        {
            get => Decking_Id.Value;
            set
            {
                if (value > 0 && value <= int.MaxValue)
                    this.Decking_Id = value;
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("greaterZero", "Id"));
            }
        }
        //navigation property / foreign key
        public Decking Deck { get; set; }   

        [Required(ErrorMessage = "Railing Id required")]
        public int? Railing_Id
        {
            get => Railing_Id.Value;
            set
            {
                if (value > 0 && value <= int.MaxValue)
                    this.Railing_Id = value;
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("greaterZero", "Id"));
            }
        }
        //navigation property / foreign key
        public Railing Rail { get; set; }

        [Required(ErrorMessage = "Length is requried")]
        public double? Length
        {
            get => Length.Value;
            set
            {
                if (value > 0 && value <= double.MaxValue)
                    this.Length = value;

                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("greaterZero", "Id"));
            }
        }
        [Required(ErrorMessage = "Width is required")]
        public double? Width
        {
            get => Width.Value;
            set
            {
                if (value > 0 && value <= double.MaxValue)
                    this.Width = value;
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("greaterZero", "Id"));
            }
        }
        [Required(ErrorMessage = "Square feet is required")]
        public double? Square_Ft
        {
            get => Square_Ft.Value;
            set
            {
                if (Width.HasValue && Length.HasValue)
                {
                    this.Square_Ft = CalcSquareFeet(Length.Value, Width.Value);
                }
                else
                    Except.ThrowExcept(ErrorDict.GetHardError("needBoth"));
            }
        }
        [Required(ErrorMessage = "Estimate required")]
        public double? Estimate
        {
            get => Estimate.Value;
            set
            {
                if (Square_Ft.HasValue && Square_Ft > 0)
                {
                    this.Estimate = CalcEstimate();
                }
                else
                    Except.ThrowExcept(ErrorDict.GetGeneralError("greaterZero", "Estimate"));
            }
        }
        [Required(ErrorMessage = "Start date required")]
        public DateTime? Start_Date
        {
            get => Start_Date.Value;
            set
            {
                if (value > DateTime.Today && value <= DateTime.Today.AddMonths(4))
                {
                    this.Start_Date = value;
                }
                else
                    Except.ThrowExcept(ErrorDict.GetHardError("betweenDate"));
            }
        }

        private double CalcSquareFeet(double len, double wid)
        {
            return 0.0;
        }
        private double CalcEstimate()
        {
            double deckPrice = 0;
            double railPrice = 0;
            (double, double) prices = (deckPrice, railPrice);
            double estimate = 0;

            if (Square_Ft.HasValue && Decking_Id.HasValue && Railing_Id.HasValue)
            {
                prices = GetPrices();
                estimate = ((prices.Item1 * Square_Ft.Value) + (prices.Item2 * Square_Ft.Value));
            }

            return estimate;
        }
        private (double, double) GetPrices()
        {
            double deckPrice = 0;
            double railPrice = 0;
            try
            {
                deckPrice = DeckingDB.GetDeckPrice_perSqft(Decking_Id.Value);
                railPrice = RailingDB.GetRailPrice_perSqFt(Railing_Id.Value);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return (deckPrice, railPrice);
        }
    }
}
