
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using static HouseManager.Infrastructure.Constants.UserRoles;

namespace HouseManager.Filters
{
	/// <summary>
	/// Custom filter that allows access only for users with roles Admin
	/// </summary>
	public class NewUserFilterAttribute : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			if (!IsNewUser(context.HttpContext.User))
			{
				context.Result = new RedirectToActionResult("Details", "Units", new { id = 45 });
			}

		}

		private bool IsNewUser(ClaimsPrincipal user) 
		{
			if (user.IsInRole(AdminRole))
			{ 
				return true;
			}

			return false;
		}
	}
}
