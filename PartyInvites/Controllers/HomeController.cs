using System;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace PartyInvites.Controllers
{
	public class HomeController : Controller
	{
		private IRepository _repository;

		public HomeController(IRepository repo)
		{
			_repository = repo;
		}

		public ViewResult Index()
		{
			return View("MyView");
		}

		[HttpGet]
		public ViewResult RsvpForm()
		{
			return View();
		}

		[HttpPost]
		public ViewResult RsvpForm(GuestResponse guestResponse)
		{
			if (ModelState.IsValid)
			{
				//Check if the response is added succesfully
				if (_repository.AddResponse(guestResponse))
				{
					return View("Thanks", guestResponse);
				}
				else
				{
					return View("Duplicate");
				}
				
			}
			else
			{
				return View();
			}
		}
		
		[Authorize]
		public ViewResult ListResponses()
		{
			//Sort responses based on their attendance status
			return View(_repository.GetAllResponses().OrderByDescending(r => r.WillAttend));
		}

		[HttpGet]
		public ViewResult EditData()
		{
			//First page: enter email
			return View("EditDataFirst");
		}

		[HttpPost]
		public ViewResult EditData(GuestResponseMinimal response)
		{
			//Second page: email has been submitted with a GuestResponseMinimal object
			if (ModelState.IsValid)
			{
				GuestResponse responseObject = _repository.GetAllResponses().FirstOrDefault(e => e.Email == response.Email);
				if (responseObject != null)
				{
					return View(responseObject);
				}
				else
				{
					return View("EditDataFirst");
				}
			}
			else
			{
				return View("EditDataFirst");
			}
		}

		[HttpPost]
		public ViewResult EditDataSubmit(GuestResponse response)
		{
			//Third page: changed data has been submitted with a GuestResponse object
			if (ModelState.IsValid)
			{
				//Check if edit worked
				if (_repository.EditResponse(response))
				{
					return View("Thanks", response);
				}
				else
				{
					return View("EditFailed");
				}
			}
			else
			{
				return View("EditData");
			}
		}
	}
}
