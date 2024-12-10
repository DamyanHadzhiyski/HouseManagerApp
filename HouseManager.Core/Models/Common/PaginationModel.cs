namespace HouseManager.Core.Models.Common
{
	public class PaginationModel
	{
        public int ElementsOnPage { get; set; }

        public int CurrentPage { get; set; }

        public int MaxPages { get; set; }
    }
}
