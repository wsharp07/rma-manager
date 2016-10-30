using AutoMapper;
using RmaManager.ViewModels;
using RmaManager.Models;
using System;
using RmaManager.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RmaManager.Mappings
{
    public class RmaVmToEntity : ITypeConverter<RmaViewModel, Rma>
    {
        public Rma Convert(RmaViewModel src, Rma dest, ResolutionContext context)
        {
            if(src == null)
                return null;
            
            dest.Id = src.Id;
            dest.RmaNumber = src.RmaNumber;
            var options = new DbContextOptions<RmaContext>();
            using(var dbContext = new RmaContext(options))
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