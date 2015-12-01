using Microsoft.AspNet.Mvc;
using RmaManager.Data.Repository.Interface;
using System.Net;
using System.Linq;
using System;
using RmaManager.Extensions;
using RmaManager.Models;

namespace RmaManager.Controllers.Api
{
	[Route("api/rmas")]
	public class RmaApiController : Controller
	{
		private IRmaRepository _rmaRepo;
		
		public RmaApiController(IRmaRepository rmaRepo)
		{
			_rmaRepo = rmaRepo;
		}
		
		#region Get
		
		[HttpGet("")]
		public JsonResult Get()
		{
			var results = _rmaRepo.GetAllRmas();
			return Json(results);
		}
		
		#endregion
		
		#region Post
		
		[HttpPost("")]
		public JsonResult Post([FromBody]Rma model)
		{
			if(ModelState.IsValid)
			{
				Response.StatusCode = (int)HttpStatusCode.Created;
				//_rmaRepo.Upsert(model);
				return Json(model);
			}
			
			Response.StatusCode = (int)HttpStatusCode.BadRequest;
			return Json(ModelState.ToErrorString());
		}
		
		#endregion
	}
}