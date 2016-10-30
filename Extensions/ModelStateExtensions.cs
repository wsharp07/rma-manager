using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RmaManager.Extensions
{
	public static class ModelStateExtensions
	{
		public static string ToErrorString(this ModelStateDictionary me)
		{
			string result = string.Join(" , ", me.Values
								.SelectMany(v => v.Errors)
								.Select(e => e.ErrorMessage));
								
			return result;			
		}
	}
}