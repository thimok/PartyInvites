using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class EFGuestResponseRepository : IRepository
    {
	    private ResponseContext _responses;

	    public EFGuestResponseRepository(ResponseContext response)
	    {
		    _responses = response;
	    }

	    public IEnumerable<GuestResponse> GetAllResponses() => _responses.Responses;

	    public bool AddResponse(GuestResponse response)
	    {
			//Check if an entry with this email already exists
		    if (_responses.Responses.Any(a => a.Email == response.Email))
		    {
			    return false;
		    }

		    _responses.Responses.Add(response);
		    _responses.SaveChanges();

			return true;
	    }

	    public bool EditResponse(GuestResponse response)
	    {
		    if (_responses.Responses.Any(a => a.Email == response.Email))
		    {
			    //Found a match, now let's fetch it
			    GuestResponse res = _responses.Responses.First(a => a.Email == response.Email);
			    res.Name = response.Name;
			    res.Phone = response.Phone;
			    res.Address = response.Address;
			    res.WillAttend = response.WillAttend;

			    _responses.Responses.Update(res);
			    _responses.SaveChanges();

			    return true;
		    }

		    return false;
	    }
    }
}
