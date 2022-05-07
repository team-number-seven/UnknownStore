namespace UnknownStore.Common.CQRS.Validation
{
    public static class ValidationMessenger
    {
        public static string PropertyCannotBeNullOrEmpty(string name) => $"{name} cannot be null or empty";
    }
}
