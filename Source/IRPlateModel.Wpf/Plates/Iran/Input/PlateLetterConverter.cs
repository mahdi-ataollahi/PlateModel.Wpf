using System.Linq;

namespace IRPlateModel.Wpf.Plates.Iran.Input
{
    public static class PlateLetterConverter
    {
        public static string ConvertToDisplayLetter(char ch)
        {
            switch (ch)
            {
                case 'ا':
                    return "الف";
                case 'ه':
                    return "هـ";
                default:
                    return ch.ToString();
            }
        }

        public static char ConvertToStandardLetter(string s)
        {
            switch (s)
            {
                case "الف":
                case "آ":
                    return 'ا';
                case "ك":
                    return 'ک';
                case "هـ":
                    return 'ه';
                case "ي":
                    return 'ی';
                default:
                    return s.FirstOrDefault();
            }
        }
    }
}
