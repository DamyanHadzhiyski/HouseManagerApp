using static HouseManager.Core.Constants.DataConstants;

namespace HouseManager.Core.Models.Pagination
{
	public class PageViewModel
	{
        public int ElementsPerPage { get; set; } = DefaultElementsOnPage;

        public int CurrentPage { get; set; } = 1;

        public int TotalElements { get; set; } = 0;
    } 
}
