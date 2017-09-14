using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public interface IRepository
    {
	    IEnumerable<GuestResponse> GetAllResponses();

	    bool AddResponse(GuestResponse response);

	    bool EditResponse(GuestResponse response);
    }
}
