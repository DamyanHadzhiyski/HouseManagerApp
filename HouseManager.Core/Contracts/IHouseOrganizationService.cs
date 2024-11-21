using HouseManager.Core.Models.HouseOrganization;
using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Contracts
{
    /// <summary>
    /// Interface that will be added into the IoC for and 
    /// used for retrieval and manipulation of data from the HouseOrganizations table
    /// </summary>
	public interface IHouseOrganizationService
    {
        /// <summary>
        /// Method to add HouseOrganization to the database with the data provided
        /// </summary>
        /// <param name="houseOrg">HouseOrganization data</param>
        /// <returns></returns>
        Task AddHouseOrganizationAsync(HouseOrganizationFormModel houseOrg);

		/// <summary>
		/// Method to change House Organization existing in the database
		/// </summary>
		/// <param name="houseOrg">HouseOrganization data</param>
		/// <returns></returns>
		Task EditHouseOrganizationAsync(HouseOrganizationFormModel houseOrg);

        /// <summary>
        /// Method that returns readonly information for all House Organization
        /// </summary>
        /// <returns></returns>
        IQueryable<HouseOrganization> GetAllReadOnly();

		/// <summary>
		/// Method that returns readonly information for specific House Organization
		/// </summary>
		/// <param name="houseOrgId">House Organization Id</param>
		/// <returns></returns>
		IQueryable<HouseOrganization> GetByIdReadOnly(int houseOrgId);

        /// <summary>
        /// Method that checks, if House Organization with this Id exist in the database
        /// </summary>
        /// <param name="houseOrgId">House Organization Id</param>
        /// <returns></returns>
        Task<bool> ExistByIdAsync(int houseOrgId);

		/// <summary>
		/// Method that returns specific House Organization in order it's data to be editable
		/// </summary>
		/// <param name="houseOrgId">House Organization Id</param>
		/// <returns></returns>
		Task<HouseOrganization?> GetHouseOrganizationById(int houseOrgId);
	}
}
