namespace HouseManager.Core.Models.Manager
{
	/// <summary>
	/// Model of a president used in the top level layers of the app
	/// </summary>
	public class CashierViewModel : ActiveManagementViewModel
    {
        public CashierViewModel()
        {
            ManagerPosition = "Cashier";
        }
    }
}