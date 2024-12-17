
using HouseManager.Core.Contracts;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HouseManager.Filters
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class ActiveOccupantExists : TypeFilterAttribute
	{
		public ActiveOccupantExists() : base(typeof(ActiveOccupantExistsImpl))
		{

		}

		private class ActiveOccupantExistsImpl(IOccupantService occupantService) : IAsyncActionFilter

		{
			private int occupantId;

			public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
			{
				if (int.TryParse(context.RouteData.Values["id"]?.ToString(), out occupantId) == false)
				{
					context.Result = new BadRequestResult();
					return;
				}

				if (!await occupantService.IsActiveAsync(occupantId))
				{
					context.Result = new NotFoundResult();
					return;
				}

				await next();
			}
		}
	}
}
