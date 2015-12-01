using System;
using RmaManager.Data.Interfaces;

namespace RmaManager.Data
{
	public class EntityModelBase : IEntityTimeStamps
	{
		public DateTime CreatedAt { get; set; } = DateTime.Now;
		public DateTime UpdatedAt { get; set; } = DateTime.Now;
	}
}