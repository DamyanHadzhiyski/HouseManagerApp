
using HouseManager.Core.Contracts;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HouseManager.Filters
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class ActiveManagerExists : TypeFilterAttribute
	{
        public ActiveManagerExists() : base(typeof(ActiveManagerExistsImpl))
        {
        }

		private class ActiveManagerExistsImpl(IManagementService managementService) : IAsyncActionFilter
		{
			private int managerId;

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
}
