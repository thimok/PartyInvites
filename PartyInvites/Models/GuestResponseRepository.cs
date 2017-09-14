using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PartyInvites.Extensions;

namespace PartyInvites.Models
{
    public class GuestResponseRepository : IRepository
    {
	    private readonly List<GuestResponse> _responses = new List<GuestResponse>();

	    public IEnumerable<GuestResponse> GetAllResponses()
	    {
		    return _responses;
	    }

	    public bool AddResponse(GuestResponse response)
	    {
		    if (_responses.Any(a => a.Email == response.Email))
		    {
			    //A response with this email already exists
			    return false;
		    }
		    else
		    {
				//No response with this email already exists, safe to add it.
			    _responses.Add(response);
			    return true;
		    }
	    }

	    public bool EditResponse(GuestResponse response)
	    {
		    if (_responses.None(a => a.Email == response.Email))
		    {
				//No GuestResponse object found with this given email, so it probably does not exist (or someone messed with the HttpPost data)
			    return false;
		    }

		    GuestResponse original = _responses.Find(r => r.Email == response.Email);
		    if (original == null)
		    {
			    return false;
		    }

//		    original.Name = response.Name;
//		    original.Phone = response.Phone;
//		    original.Address = response.Address;
//		    original.WillAttend = response.WillAttend;

		    _responses.Remove(original);
			_responses.Add(response);

		    return true;
	    }
    }
}
