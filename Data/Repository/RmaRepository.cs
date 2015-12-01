using System;
using System.Collections.Generic;
using System.Linq;
using RmaManager.Data.Repository.Interface;
using RmaManager.Models;

namespace RmaManager.Data.Repository
{
	public class RmaRepository : IRmaRepository
	{
		private RmaContext _context;
		public RmaRepository(RmaContext context)
		{
			_context = context;
		}
		
		public IEnumerable<Rma> GetAllRmas()
        {
            return _context.Rmas.OrderBy(x => x.RmaNumber).ToList();
        }
		
		public int Upsert(Rma rma)
		{
			// Insert
			if(rma.Id <= 0)
			{
				_context.Rmas.Add(rma);
			}
			// Update
			else
			{
				var dbObj = _context.Rmas.Single(x => x.Id == rma.Id || x.RmaNumber.Equals(rma.RmaNumber));
				dbObj.RmaNumber = rma.RmaNumber;
				dbObj.UpdatedAt = rma.UpdatedAt;
			}
			
			_context.SaveChanges();
			
			return rma.Id;
		}
    }
}