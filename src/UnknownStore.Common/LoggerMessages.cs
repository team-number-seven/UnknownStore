using System;

namespace UnknownStore.Common
{
    public static class LoggerMessages
    {
        public static string TimeNow => $"[{DateTime.Now:G}]";

        public static string ObjectPropertyIsNullOrEmptyMessage(string name)
        {
            return $"The {name} cannot be null";
        }
    }
}