﻿using HouseManager.Core.Models.Managers;
using HouseManager.Infrastructure.Enums;

namespace HouseManager.Core.Models.Pagination
{
	public class InactiveCashiersPageViewModel : PageViewModel
	{
        public ManagerPosition Position { get; set; } = ManagerPosition.Cashier;

		public List<InactiveManagerViewModel> Collection { get; set; } = [];
    }
}