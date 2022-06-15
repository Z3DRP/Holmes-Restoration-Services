using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HolmesServices.Models
{
    public enum Decktype { Hardwood, Compostie, Wood, Treated };

    public class Deck_Type
    {
        [Required(ErrorMessage = "Id is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Id must be a positive number")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Deck type is required")]
        [MaxLength(100, ErrorMessage = "Deck type must be 100 characters or less")]
        [RegularExpression(@"[0-9]*?[a-zA-Z]*?[0-9]*?[a-zA-Z]*?", ErrorMessage = "Deck type may contain letters and numbers only")]
        public Decktype Type { get; set; }


        [Required(ErrorMessage = "Type code is required")]
        [MaxLength(10, ErrorMessage = "Type code must be 10 characters or less")]
        [RegularExpression(@"[0-9]*?[a-zA-Z]*?[0-9]*?[a-zA-Z]*?", ErrorMessage = "Type code may contain letters and numbers only")]
        public string Type_Code { get; set; }
    }
}
