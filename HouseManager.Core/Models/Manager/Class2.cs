using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HouseManager.Core.Models.Manager
{
	public class Class2 : ActiveManagementViewModel
	{
        public Class2()
        {
            ManagerPosition = "Cashier";
        }
    }
}
