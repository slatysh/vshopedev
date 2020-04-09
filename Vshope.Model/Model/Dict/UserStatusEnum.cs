namespace Vshope.Model.Model.Dict
{
    public enum UserStatusEnum
    {
        Created = 1,
        Confirmed = 2
    }

    public static class UserStatusEnumHelper
    {
        public static string ToString(UserStatusEnum val)
        {
            switch (val)
            {
                case UserStatusEnum.Created:
                {
                    return "userStatus.created";
                }
                case UserStatusEnum.Confirmed:
                {
                    return "userStatus.confirmed";
                }
                default:
                {
                    return null;
                }
            }
        }
    }
}
