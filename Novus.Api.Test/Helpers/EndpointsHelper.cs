using System;

namespace Novus.Api.Test.Helpers
{
    public static class EndpointsHelper
    {
        public static Uri UserLogIn { get; } = new Uri("user/login/", UriKind.Relative);
        public static Uri UserInfo { get; } = new Uri("user/profile/", UriKind.Relative);
        public static Uri UserPersonalInfo { get; } = new Uri("user/profile/personal_info/", UriKind.Relative);

    }
}