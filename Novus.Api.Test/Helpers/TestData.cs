using System.Diagnostics.Contracts;

namespace Novus.Api.Test.Helpers
{
    public static class TestData
    {
        public static string BaseUrl { get; } = "https://stores-api.zakaz.ua/";
        public static string Email { get; } = "test@gmail.com";
        public static string Phone { get; } = "380936535906";
        public static string Passwords { get; } = "537178";
        public static string Name { get; } = "Вікторія";
        public static string UserId { get; } = "2412569";
        public static string Birthday { get; } = null;
        public static string Novus { get; } = "novus";

    }
}