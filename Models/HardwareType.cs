using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RmaManager.Data;

namespace RmaManager.Models
{
	[Table("HardwareTypes")]
	public class HardwareType : EntityModelBase
	{
		public int Id {get;set;}
		[Required]
		[StringLength(50, MinimumLength = 3)]
		public string Name {get;set;}
		public ICollection<Rma> Rmas { get; set;}
	}
}