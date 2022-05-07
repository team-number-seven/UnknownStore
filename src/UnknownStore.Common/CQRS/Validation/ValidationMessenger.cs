namespace UnknownStore.Common.CQRS.Validation
{
    public static class ValidationMessenger
    {
        public static string PropertyCannotBeNullOrEmpty(string name)
        {
            return $"{name} cannot be null or empty";
        }

        public static string NotFoundEntity(string name)
        {
            return $"{name} not fount";
        }

        public static string InvalidFormat(string name, string value)
        {
            return $"Invalid {name} format({value})";
        }

        public static string InvalidValue(string name, string value)
        {
            return $"Invalid{name} value({value})";
        }
    }
}