﻿namespace HouseManager.Infrastructure.Constants
{
	/// <summary>
	/// Constants used for data validation of the data models
	/// </summary>
	public static class EntityConstants
	{
		/// <summary>
		/// Min and Max length of a description field
		/// </summary>
		public const int DescriptionMinLength = 10;
		public const int DescriptionMaxLength = 200;

        /// <summary>
        /// Min and Max length of a House Organization name
        /// </summary>
        public const int HouseOrganizationNameMinLength = 3;
		public const int HouseOrganizationNameMaxLength = 50;

        /// <summary>
        /// Min and Max length of a person names
        /// </summary>
        public const int FullNameMinLength = 10;
        public const int FullNameMaxLength = 100;

        /// <summary>
        /// Min and Max length of an address
        /// </summary>
        public const int AddressMinLength = 10;
		public const int AddressMaxLength = 100;

        /// <summary>
        /// Min and Max length of a name of the town
        /// </summary>
        public const int TownNameMinLength = 2;
		public const int TownNameMaxLength = 40;

        /// <summary>
        /// Min and Max values of a units' common parts
        /// </summary>
        public const string UnitCommonPartsMinArea = "0";
		public const string UnitCommonPartsMaxArea = "100";

        /// <summary>
        /// Requested phone number format
        /// </summary>
		public const string PhoneNumberRegEx = @"^\+359[0-9]{9}$";
	}
}
