namespace Medical_record.Helper
{
    public class StringHelper
    {
        public static string TruncateAddress(string address, int maxLength = 50)
        {
            if (string.IsNullOrEmpty(address))
                return string.Empty;

            if (address.Length <= maxLength)
                return address;

            return address.Substring(0, maxLength) + "...";
        }
    }
}
