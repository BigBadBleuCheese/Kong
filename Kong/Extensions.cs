namespace Kong
{
    public static class Extensions
    {
        public static float? CoerceToFloat(this string str)
        {
            float tryParse;
            if (float.TryParse(str, out tryParse))
                return tryParse;
            return null;
        }

        public static int? CoerceToInteger(this string str)
        {
            int tryParse;
            if (int.TryParse(str, out tryParse))
                return tryParse;
            return null;
        }

        public static bool IsTruthy(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static string NullIfFalsy(this string str)
        {
            return string.IsNullOrEmpty(str) ? null : str;
        }
    }
}
