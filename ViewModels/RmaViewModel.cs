using System.Collections.Generic;
using RmaManager.Models;

namespace RmaManager.ViewModels
{
	public class RmaViewModel
	{
		public string JsonObj {get;set;}
		public IEnumerable<Rma> Rmas { get; set; }
	}
}