using HouseManager.Core.Contracts;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HouseManager.Filters
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class HouseOrganizationExists : TypeFilterAttribute
	{
		public HouseOrganizationExists(string routeParam) : base(typeof(HouseOrganizationExistsImpl))
		{
			Arguments = [routeParam];
		}

		private class HouseOrganizationExistsImpl(IHouseOrganizationService houseOrgService, string routeParam) : IAsyncActionFilter
		{
			private int houseOrgId;

			public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
			{
				if (int.TryParse(context.RouteData.Values[routeParam]?.ToString(), out houseOrgId) == false)
				{
					context.Result = new BadRequestResult();
					return;
				}

				if (!await houseOrgService.ExistByIdAsync(houseOrgId))
				{
					context.Result = new NotFoundResult();
					return;
				}

				await next();
			}
		}
	}
}
