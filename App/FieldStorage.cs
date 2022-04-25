namespace ADBMailer
{
    internal sealed class FieldStorage
    {
        public enum Kind
        {
            ExcelFields,
            WordFields,
        }

        private static readonly Dictionary<Kind, KeyValuePair<string, object>> LastStates = new();

        public static object? GetLastMapping(Kind kind, string filename)
        {
            return GetLastMapping(kind, filename, "");
        }

        public static object? GetLastMapping(Kind kind, string filename, string additionalKey)
        {
            if (!LastStates.ContainsKey(kind))
            {
                return null;
            }
            var fileKey = GetFileKey(filename, additionalKey);
            if (fileKey.Length == 0)
            {
                return null;
            }
            return LastStates[kind].Key == fileKey ? LastStates[kind].Value : null;
        }

        public static void SetLastMapping(Kind kind, string filename, object value)
        {
            SetLastMapping(kind, filename, value, "");
        }

        public static void SetLastMapping(Kind kind, string filename, object value, string additionalKey)
        {
            var fileKey = GetFileKey(filename, additionalKey);
            if (fileKey.Length == 0)
            {
                return;
            }
            if (LastStates.ContainsKey(kind))
            {
                LastStates[kind] = new KeyValuePair<string, object>(fileKey, value);
            }
            else
            {
                LastStates[kind] = new KeyValuePair<string, object>(fileKey, value);
            }
        }

        private static string GetFileKey(string filename, string additionalKey)
        {
            try
            {
                var fi = new FileInfo(filename);
                if (!fi.Exists)
                {
                    return "";
                }
                var size = fi.Length;
                if (size <= 0)
                {
                    return "";
                }
                var timestamp = fi.LastWriteTimeUtc.Ticks;
                if (timestamp <= 0)
                {
                    return "";
                }
                return $"{filename}:{size}@{timestamp}+{additionalKey}";
            }
            catch
            {
                return "";
            }
        }
    }
}