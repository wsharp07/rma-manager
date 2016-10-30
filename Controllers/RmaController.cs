using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RmaManager.Data;
using RmaManager.Data.Repository;
using RmaManager.Data.Repository.Interface;
using RmaManager.ViewModels;
using AutoMapper;

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
			IEnumerable<RmaViewModel> results = null;
			var query = _rmaRepo.GetAllRmas().ToList();
			results = Mapper.Map<IEnumerable<RmaViewModel>>(query);
			return View(results);
		}
	}
}