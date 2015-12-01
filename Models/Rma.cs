using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RmaManager.Data;

namespace RmaManager.Models
{
	[Table("Rmas")]
	public class Rma : EntityModelBase
	{
		public int Id {get;set;}
		[Required]
		[StringLength(50, MinimumLength = 5)]
		public string RmaNumber {get;set;}
		public int? HardwareTypeId {get;set;}
		[ForeignKey("HardwareTypeId")]
		public HardwareType HardwareType { get; set; }
	}
}