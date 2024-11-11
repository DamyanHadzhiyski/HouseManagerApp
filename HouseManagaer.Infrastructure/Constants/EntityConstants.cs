namespace HouseManager.Infrastructure.Constants
{
	public static class EntityConstants
	{
		public const int DescriptionMinLength = 10;
		public const int DescriptionMaxLength = 200;

		public const int HouseOrganizationNameMinLength = 3;
		public const int HouseOrganizationNameMaxLength = 20;

        public const int BoardMemberFullNameMinLength = 10;
        public const int BoardMemberFullNameMaxLength = 100;

        public const int AddressMinLength = 10;
		public const int AddressMaxLength = 100;

		public const int TownNameMinLength = 3;
		public const int TownNameMaxLength = 20;

		public const int UnitTypeNameMinLength = 3;
		public const int UnitTypeNameMaxLength = 20;

        public const int OccupantFullNameMinLength = 10;
        public const int OccupantFullNameMaxLength = 100;

        public const string UnitCommonPartsMinArea = "0";
		public const string UnitCommonPartsMaxArea = "100";

		public const string PhoneNumberRegEx = @"^\+[0-9 ]{8,}$";
	}
}
