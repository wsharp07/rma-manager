using System;

namespace RmaManager.Data.Interfaces
{
	public interface IEntityTimeStamps
	{
		DateTime CreatedAt { get; set;}
		DateTime UpdatedAt { get; set; }
	}
}