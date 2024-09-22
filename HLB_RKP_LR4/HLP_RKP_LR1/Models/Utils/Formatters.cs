namespace HLP_RKP_LR3.Models
{
    public class Formatters
    {
        public static string FormatColumnName(string raw)
        {
            string[] name = raw.Trim().Split(' ');
            return string.Join("_", name);
        }
    }
}
