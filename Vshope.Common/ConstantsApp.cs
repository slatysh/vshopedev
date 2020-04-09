using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Vshope.Common
{
    public static class ConstantsApp
    {
        public const string AUTH_PASSWORD_PRIVATE_HASH = "tXdiBrIlf3tTsvJKvRvl";
        public const string AUTH_JWT_SYMMETRIC_KEY = "qYlQWfGDsheVR8ZLdk1m";
        public const string AUTH_CODE_SYMMETRIC_KEY = "l1stYzJzOavLYsyeye0b";
        public const string AUTH_REFRESH_TOKEN_KEY = "1EaeWenPt6jCmoWV4C4j";
        public const int AUTH_JWT_LIFETIME = 10080; // минут (60*24*7)
        public const int AUTH_CODE_LIFETIME = 1440; // минут (60*24*1)
        public const int AUTH_REFRESH_TOKEN_LIFETIME = 14400; // минут (60*24*10)

        public const int VALIDATION_MIN_LENGTH_PASSWORD = 6;
        public const int VALIDATION_MAX_LENGTH_SMALL = 256;
        public const int VALIDATION_MAX_LENGTH_NORMAL = 1024;
        public const int VALIDATION_MAX_LENGTH_BIG = 4096;
        public const float VALIDATION_MAX_VALUE_HUNDRED = 100;
        public const float VALIDATION_MAX_VALUE_SMALL = 1000;
        public const float VALIDATION_MAX_VALUE_SMALLNORMAL = 100000;
        public const float VALIDATION_MAX_VALUE_NORMAL = 10000000000;
        public const float VALIDATION_MAX_FILE_LENGTH = 5 * 1024 * 1024;
        public const float VALIDATION_MIN_LATITUDE = -90;
        public const float VALIDATION_MAX_LATITUDE = 90;
        public const float VALIDATION_MIN_LONGITUDE = -180;
        public const float VALIDATION_MAX_LONGITUDE = 180;
        public static string AUTH_ISSUER = "";
        public static string AUTH_AUDIENCE = "";

        public static string CLIENT_DOMAIN = "";
        public static string SERVER_VERSION = "";

        public static string ADMIN_EMAIL = "";

        public static int REQUEST_LIST_MAX_COUNT = 1000;

        public const int VK_API_MARKET_GET_PRODUCT_PER_STEP = 5;
        public const int VK_API_MARKET_GET_PRODUCT_MAX_COUNT = 5000;

        public const string VK_API_VERSION = "5.103";
        public const string VK_API_OAUTH_HOST = "oauth.vk.com";
        public const string VK_API_OAUTH_TOKEN_ENDPOINT = "https://oauth.vk.com/access_token";

        public static SymmetricSecurityKey GetAuthCodeSymmetricKeyBytes()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AUTH_CODE_SYMMETRIC_KEY));
        }

        public static SymmetricSecurityKey GetAuthJwtSymmetricKeyBytes()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AUTH_JWT_SYMMETRIC_KEY));
        }

        public static SymmetricSecurityKey GetAuthRefreshTokenSymmetricKeyBytes()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AUTH_REFRESH_TOKEN_KEY));
        }

        public static void InitializeByConfig(IConfiguration config)
        {
            var appSettingsConfig = config.GetSection("AppSettings");
            AUTH_ISSUER = appSettingsConfig["BackAppName"];
            AUTH_AUDIENCE = appSettingsConfig["FrontAppName"];
            CLIENT_DOMAIN = appSettingsConfig["ClientDomain"];
            SERVER_VERSION = appSettingsConfig["Version"];
            ADMIN_EMAIL = appSettingsConfig["adminEmail"];
        }
    }
}
