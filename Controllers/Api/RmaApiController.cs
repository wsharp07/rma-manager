using Microsoft.AspNetCore.Mvc;
using RmaManager.Data.Repository.Interface;
using System.Net;
using System.Linq;
using System;
using RmaManager.Extensions;
using RmaManager.Models;
using RmaManager.ViewModels;
using AutoMapper;
using System.Collections.Generic;

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
			IEnumerable<Rma> response = _rmaRepo.GetAllRmas();
			IEnumerable<RmaViewModel> results = Mapper.Map<IEnumerable<RmaViewModel>>(response);
			return Json(results);
		}
		
		#endregion
		
		#region Post
		
		[HttpPost("")]
		public JsonResult Post([FromBody]RmaViewModel model)
		{
			try
			{
				if(ModelState.IsValid)
				{
					var rmaEntity = Mapper.Map<Rma>(model);
					Response.StatusCode = (int)HttpStatusCode.Created;
					
					//_rmaRepo.Upsert(model);
					return Json(Mapper.Map<RmaViewModel>(rmaEntity));
				}
			}
			catch(Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { Message = ex.Message});
			}
			
			Response.StatusCode = (int)HttpStatusCode.BadRequest;
			return Json(ModelState.ToErrorString());
		}
		
		#endregion
	}
}