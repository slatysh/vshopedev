namespace Vshope.Common.Exception
{
    public static class ExceptionCodes
    {
        public const string COMMON_INVALID_ARGUMENTS = "COMMON_INVALID_ARGUMENTS";
        public const string COMMON_NOT_EXIST = "COMMON_NOT_EXIST";
        public const string COMMON_ALREADY_EXISTS = "ALREADY_EXISTS";
        public const string DB_RELATED_ENTITY_EXISTS = "DB_RELATED_ENTITY_EXISTS";
        public const string DISABLED_FUNCTIONALITY = "DISABLED_FUNCTIONALITY";
        public const string FILE_IS_TOO_BIG = "FILE_IS_TOO_BIG";
        public const string READONLY_FIELD = "READONLY_FIELD";
        public const string FORBIDDEN = "FORBIDDEN";

        public const string BL_CODE_ORDER_BY_KEY_NOT_DEFINED = "BL_CODE_ORDER_BY_KEY_NOT_DEFINED";
        public const string BL_CODE_USER_ALREADY_EXIST = "BL_CODE_USER_ALREADY_EXIST";
        public const string BL_CODE_USER_NOT_CONFIRMED = "BL_CODE_USER_NOT_CONFIRMED";

        public const string AUTH_JWT_INCORRECT = "AUTH_JWT_INCORRECT";
        public const string AUTH_CODE_INCORRECT = "AUTH_CODE_INCORRECT";
        public const string AUTH_REFRESH_TOKEN_INCORRECT = "AUTH_REFRESH_TOKEN_INCORRECT";

        public const string VK_AUTH_TOKEN_INCORRECT = "VK_AUTH_TOKEN_INCORRECT";
        public const string VK_ID_INVALID = "VK_ID_INVALID";

        public const string CONTROLLER_CANT_GET_CURRENT_USER_COMPANY_ID = "CONTROLLER_CANT_GET_CURRENT_USER_COMPANY_ID ";
        public const string CONTROLLER_CANT_GET_CURRENT_USER_ID = "CONTROLLER_CANT_GET_CURRENT_USER_ID ";
    }
}
