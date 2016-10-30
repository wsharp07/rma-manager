using AutoMapper;
using RmaManager.ViewModels;
using RmaManager.Models;
using System;
using RmaManager.Data;
using System.Linq;

namespace RmaManager.Mappings
{
    public class RmaVmToEntity : ITypeConverter<RmaViewModel, Rma>
    {
        public Rma Convert(ResolutionContext context)
        {
            if(context.IsSourceValueNull)
                return null;
                
            var src = (RmaViewModel)context.SourceValue;
            var dest = new Rma();
            
            dest.Id = src.Id;
            dest.RmaNumber = src.RmaNumber;
            
            using(var dbContext = new RmaContext())
            {
                var hardwareType = dbContext.HardwareTypes
                                .FirstOrDefault(x => x.Name.Equals(src.HardwareTypeName));
                                
                if(hardwareType != null)
                {
                    dest.HardwareTypeId = hardwareType.Id;
                }
            }
            
            
            return dest;
        }
    }
}