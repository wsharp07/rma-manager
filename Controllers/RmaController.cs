using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using RmaManager.Data;
using RmaManager.Data.Repository;
using RmaManager.Data.Repository.Interface;
using RmaManager.ViewModels;

namespace RmaManager.Controllers
{
	public class RmaController : Controller 
	{
		private IRmaRepository _rmaRepo;
		public RmaController(IRmaRepository rmaRepo)
		{
			_rmaRepo = rmaRepo;
		}
		public IActionResult Index()
		{
			RmaViewModel model = new RmaViewModel();
			model.Rmas = _rmaRepo.GetAllRmas();
			
			model.JsonObj = JsonConvert.SerializeObject(model.Rmas);
			return View(model);
		}
	}
}