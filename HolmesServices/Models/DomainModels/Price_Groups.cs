using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HolmesServices.Models.DomainModels
{
    public class Price_Groups
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        [MaxLength(2, ErrorMessage = "Group name can only be 2 characters or less")]
        public string Group_Name { get; set; }

        // for now decks or rails can be empty
        public IEnumerable<Decking> Decks { get; set; }
        public IEnumerable<Railing> Rails { get; set; }
    }
}
