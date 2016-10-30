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
			HardwareType defaultHardwareType = HardwareTypeSeeds();
			RmaSeeds(defaultHardwareType);
		}
		
		private HardwareType HardwareTypeSeeds()
		{
			HardwareType result = null;
			if(_context.HardwareTypes.Any() == false)
			{
				var hardwareType = new HardwareType(); 
				hardwareType.Name = "Impinj";
				
				_context.HardwareTypes.Add(hardwareType);
				_context.SaveChanges();
				result = hardwareType;
			}
			else
			{
				result = _context.HardwareTypes.First();
			}
			return result;
		}
		
		private void RmaSeeds(HardwareType hardwareType)
		{
			if(_context.Rmas.Any() == false)
			{
				var rma1 = new Rma(); 
				rma1.RmaNumber = "RMA-2015-001";
				rma1.HardwareType = hardwareType;
				
				var rma2 = new Rma();
				rma2.RmaNumber = "RMA-2015-002";
				rma2.HardwareType = hardwareType;
				
				var rma3 = new Rma();
				rma3.RmaNumber = "RMA-2015-003";
                               				
                                var rma4 = new Rma();
				rma4.RmaNumber = "RMA-2015-004";
				
				var rma5 = new Rma();
				rma5.RmaNumber = "RMA-2015-005";

                                var rma6 = new Rma();
				rma6.RmaNumber = "RMA-2015-006";
				
				var rma7 = new Rma();
				rma7.RmaNumber = "RMA-2015-007";                  
                                
                                var rma8 = new Rma();
				rma8.RmaNumber = "RMA-2015-008";
				
				var rma9 = new Rma();
				rma9.RmaNumber = "RMA-2015-009";
                                    
                                var rma10 = new Rma();
				rma10.RmaNumber = "RMA-2015-010";
                                   
				_context.Rmas.Add(rma1);
				_context.Rmas.Add(rma2);
				_context.Rmas.Add(rma3);
				_context.Rmas.Add(rma4);
                                _context.Rmas.Add(rma5); 
                                _context.Rmas.Add(rma6);
                                _context.Rmas.Add(rma7);
                                _context.Rmas.Add(rma8);
                                _context.Rmas.Add(rma9);
                                _context.Rmas.Add(rma10);

				_context.SaveChanges();
			}
		}
	}
}