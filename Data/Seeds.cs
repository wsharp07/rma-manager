using System.Linq;
using RmaManager.Models;

namespace RmaManager.Data
{
	public class Seeds
	{
		private RmaContext _context;
		public Seeds(RmaContext context)
		{
			_context = context;
			
		}
		public void EnsureSeedData()
		{
			if(_context.Rmas.Any() == false)
			{
				var rma1 = new Rma(); 
				rma1.RmaNumber = "RMA-2015-001";
				
				var rma2 = new Rma();
				rma2.RmaNumber = "RMA-2015-002";
				
				var rma3 = new Rma();
				rma3.RmaNumber = "RMA-2015-003";
				
				_context.Rmas.Add(rma1);
				_context.Rmas.Add(rma2);
				_context.Rmas.Add(rma3);
				
				_context.SaveChanges();
			}
		}
	}
}