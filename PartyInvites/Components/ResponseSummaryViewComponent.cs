using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Components
{
    public class ResponseSummaryViewComponent : ViewComponent
    {
	    private IRepository _repository;

	    public ResponseSummaryViewComponent(IRepository repository)
	    {
		    _repository = repository;
	    }

	    public IViewComponentResult Invoke()
	    {
		    return View(_repository);
	    }
    }
}
