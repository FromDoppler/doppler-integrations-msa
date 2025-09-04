namespace DopplerIntegrationsCore
{
    public class Utils
    {
        public static string FormatDateTimeAsString(DateTime? date, string culture = "")
        {
            return date == null
                ? ""
                : culture == "es" ? string.Format("{0:dd/MM/yyyy hh:mm tt}", date) : string.Format("{0:MM/dd/yyyy hh:mm tt}", date);
        }

        public static string GetCurrentLanguage(int idLanguage)
        {
            return idLanguage == 1 ? "es" : "en";
        }
    }
}
