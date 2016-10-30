using System;
using System.Collections.Generic;
using RmaManager.Models;

namespace RmaManager.ViewModels
{
	public class RmaViewModel
	{
		public RmaViewModel()
		{
			CreatedAt = DateTime.Now;
			UpdatedAt = DateTime.Now;
		}
		public int Id { get; set; }
		public string RmaNumber { get; set; }
		public string HardwareTypeName { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}