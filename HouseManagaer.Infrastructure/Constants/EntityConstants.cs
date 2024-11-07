namespace HouseManager.Infrastructure.Constants
{
	public static class EntityConstants
	{
		public const int DescriptionMinLength = 10;
		public const int DescriptionMaxLength = 200;

		public const int HomeOrganizationNameMinLength = 3;
		public const int HomeOrganizationNameMaxLength = 20;

		public const int AddressMinLength = 10;
		public const int AddressMaxLength = 100;

		public const int TownNameMinLength = 3;
		public const int TownNameMaxLength = 20;

		public const int UnitTypeNameMinLength = 3;
		public const int UnitTypeNameMaxLength = 20;

		public const int FirstNameMinLength = 2;
		public const int FirstNameMaxLength = 20;
		
		public const int MiddleNameMinLength = 2;
		public const int MiddleNameMaxLength = 30;
		
		public const int LastNameMinLength = 2;
		public const int LastNameMaxLength = 50;

		public const string UnitCommonPartsMinArea = "0";
		public const string UnitCommonPartsMaxArea = "100";

		public const string PhoneNumberRegEx = @"^\+[0-9 ]{8,}$";
	}
}
