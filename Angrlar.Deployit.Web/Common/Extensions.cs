namespace Angrlar.Deployit.Web.Common
{
    public static class Extensions
    {
        public static T? ToNullable<T>(this object input) where T : struct
        {
            if (input == null) return default(T?);

            if (input is T?) return (T?)input;

            int temp;
            if (int.TryParse(input.ToString(), out temp))
            {
                return temp as T?;
            }

            return default(T?);
        }
    }
}