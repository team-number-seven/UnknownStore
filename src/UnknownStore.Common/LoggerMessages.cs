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

        public static string CommandExecutedSuccessfully(string commandName) =>
            $"{TimeNow}The command {commandName} was executed successfully.";

        public static string QueryExecutedSuccessfully(string queryName) =>
            $"{TimeNow}The query {queryName} was executed successfully.";
    }
}