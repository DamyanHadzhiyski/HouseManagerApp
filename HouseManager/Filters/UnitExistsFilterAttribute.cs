
using HouseManager.Core.Contracts;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HouseManager.Filters
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class UnitExistsFilterAttribute : Attribute, IAsyncActionFilter
	{
		private readonly IUnitService unitService;
		private int unitId;

        public UnitExistsFilterAttribute(IUnitService _unitService)
        {
			unitService = _unitService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (int.TryParse(context.RouteData.Values["id"]?.ToString(), out unitId) == false)
			{
				context.Result = new BadRequestResult();
				return;
			}

			if (!await unitService.ExistsByIdAsync(unitId))
			{
				context.Result = new NotFoundResult();
				return;
			}

			await next();
		}
	}
}
