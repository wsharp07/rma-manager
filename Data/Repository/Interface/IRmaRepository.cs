using System.Collections.Generic;
using RmaManager.Models;

namespace RmaManager.Data.Repository.Interface
{
	public interface IRmaRepository
	{
		int Upsert(Rma rma);
		IEnumerable<Rma> GetAllRmas();
	}
}