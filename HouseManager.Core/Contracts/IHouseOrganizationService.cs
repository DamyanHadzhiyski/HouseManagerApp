using HouseManager.Core.Models.HouseOrganization;
using HouseManager.Infrastructure.Data.Models;

namespace HouseManager.Core.Contracts
{
	/// <summary>
	/// Interface that will be added into the IoC and used for 
	/// retrieval and manipulation of data from the HouseOrganizations table
	/// </summary>
	public interface IHouseOrganizationService
    {
        /// <summary>
        /// Method to add HouseOrganization to the database with the data provided
        /// </summary>
        /// <param name="houseOrg">HouseOrganization data</param>
        /// <returns></returns>
        Task<int> AddAsync(HouseOrganizationFormModel houseOrg);

		/// <summary>
		/// Method to change House Organization existing in the database
		/// </summary>
		/// <param name="houseOrg">HouseOrganization data</param>
		/// <returns></returns>
		Task EditAsync(HouseOrganizationFormModel houseOrg);

        /// <summary>
        /// Method that returns readonly information for all House Organization as a view model
        /// </summary>
        /// <returns></returns>
        IQueryable<HouseOrganizationViewModel> GetAllReadOnly();

		/// <summary>
		///  Method that returns readonly detailed information for specific House Organization as a view model
		/// </summary>
		/// <param name="houseOrgId"></param>
		/// <returns></returns>
		IQueryable<HouseOrganizationDetailViewModel> GetDetailsByIdReadOnly(int houseOrgId);

		/// <summary>
		/// Method that returns readonly information for specific House Organization
		/// </summary>
		/// <param name="houseOrgId">House Organization Id</param>
		/// <returns></returns>
		IQueryable<HouseOrganizationFormModel> GetByIdReadOnly(int houseOrgId);

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
		IQueryable<HouseOrganization?> GetByIdAsync(int houseOrgId);

		/// <summary>
		/// Method that returns all house organizations managed by specified manager
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		IQueryable<HouseOrganizationViewModel> GetAllManagedByAsync(List<int> id);

		/// <summary>
		/// Method that returns all house organization to which the user is joined
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		IQueryable<HouseOrganizationViewModel> GetAllOccupiedByAsync(List<int> id);

		/// <summary>
		/// Method that returns all created by specific user house organization
		/// </summary>
		/// <param name="creatorId"></param>
		/// <returns></returns>
		IQueryable<HouseOrganizationViewModel> GetAllByCreatorIdAsync(string creatorId);

		/// <summary>
		/// Method that returns the name of a specified house organization
		/// </summary>
		/// <param name="houseOrgId"></param>
		/// <returns></returns>
		Task<string> GetNameByIdAsync(int houseOrgId);
	}
}
