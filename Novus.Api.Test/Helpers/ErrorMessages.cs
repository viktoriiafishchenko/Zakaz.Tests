namespace Novus.Api.Test.Helpers
{
    public static class ErrorMessages
    {
        public static string LoginDataIncorrect { get; } = "Login or password is incorrect.";
        public static string PhoneDataInvalid { get; } = "Invalid parameter format, phone.";
        public static string InvalidPhoneParameterFormat { get; } = "Invalid parameter format. Length must be between 3 and 128.";
        public static string InvalidPasswordParameterFormat { get; } = "Invalid parameter format. Length must be between 1 and 128.";
        public static string BadRequest { get; } = "Bad request.";
        public static string InvalidEmailParameterFormat { get; } = "Invalid parameter format, email.";
        public static string InvalidBirthdateParameterFormat { get; } = "Invalid parameter format.";
    }
}