namespace Novus.Api.Test.Helpers
{
    public static class ErrorCode
    {
        public static int LoginDataIncorrect { get; } = 4182;
        public static int PhoneDataInvalid { get; } = 4024;
        public static int InvalidLogInParameterFormat { get; } = 4020;
        public static int Unauthorized { get; } = 4000;

    }
}