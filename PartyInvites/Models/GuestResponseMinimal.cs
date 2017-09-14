using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class GuestResponseMinimal
    {
	    [Required(ErrorMessage = "Please enter your email adress")]
	    [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
	    public string Email { get; set; }
	}
}
