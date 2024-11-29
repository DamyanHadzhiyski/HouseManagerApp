using HouseManager.Core.Models.Manager;

using Microsoft.AspNetCore.Mvc;

namespace HouseManager.ViewComponents
{
	public class ActiveManagerViewComponent() : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync(ActiveManagementViewModel model, string position)
		{
			if (model == null)
			{
				var emptyModel = new ActiveManagementFormModel();

				emptyModel.ManagerPosition = position;

				return View("_ActiveManagerFormPartial", emptyModel);
			}
			else
			{
				return View("_ActiveManagerViewPartial",model);
			}

		}
	}
}
