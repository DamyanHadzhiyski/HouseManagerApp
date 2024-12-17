
using HouseManager.Core.Contracts;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HouseManager.Filters
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class HouseOrganizationExistsFilterAttribute : Attribute, IAsyncActionFilter
	{
		private readonly IHouseOrganizationService houseOrgService;
		private int houseOrgId;

        public HouseOrganizationExistsFilterAttribute(IHouseOrganizationService _houseOrgService)
        {
			houseOrgService = _houseOrgService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (int.TryParse(context.RouteData.Values["id"]?.ToString(), out houseOrgId) == false)
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
