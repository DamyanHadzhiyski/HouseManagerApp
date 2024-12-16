
using HouseManager.Core.Contracts;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HouseManager.Filters
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class ActiveManagerExistsFilterAttribute : Attribute, IAsyncActionFilter
	{
		private readonly IManagementService managementService;
		private int managerId;

        public ActiveManagerExistsFilterAttribute(IManagementService _managementService)
        {
			managementService = _managementService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (int.TryParse(context.RouteData.Values["id"]?.ToString(), out managerId) == false)
			{
				context.Result = new BadRequestResult();
				return;
			}

			if (!await managementService.IsActiveAsync(managerId))
			{
				context.Result = new NotFoundResult();
				return;
			}

			await next();
		}
	}
}
