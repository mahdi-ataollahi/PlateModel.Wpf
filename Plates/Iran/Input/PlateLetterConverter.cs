using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PlateModel.Wpf.Plates.Iran.Input
{
    public static class PlateLetterConverter
    {
        public const string None = "";
        public const string EA = "A";
        public const string EB = "B";
        public const string EP = "P";
        public const string EX = "X";
        public const string EJ = "J";
        public const string ED = "D";
        public const string EC = "C";
        public const string ES = "S";
        public const string ET = "T";
        public const string EE = "E";
        public const string EG = "G";
        public const string EK = "K";
        public const string EL = "L";
        public const string EM = "M";
        public const string EN = "N";
        public const string EV = "V";
        public const string EH = "H";
        public const string EY = "Y";
        public const string EZ = "Z";
        public const string EF = "F";

        public const string PA = "الف";
        public const string PB = "ب";
        public const string PP = "پ";
        public const string PX = "ت";
        public const string PJ = "ج";
        public const string PD = "د";
        public const string PC = "س";
        public const string PS = "ص";
        public const string PT = "ط";
        public const string PE = "ع";
        public const string PG = "ق";
        public const string PK = "ک";
        public const string PL = "ل";
        public const string PM = "م";
        public const string PN = "ن";
        public const string PV = "و";
        public const string PH = "هـ";
        public const string PY = "ی";
        public const string PZ = "چ";
        public const string PF = "ف";

        public static string ConvertToPersian(string s)
        {
            switch (s.ToUpper())
            {
                case EA:
                    return PA;
                case EB:
                    return PB;
                case EC:
                    return PC;
                case ED:
                    return PD;
                case EE:
                    return PE;
                case EG:
                    return PG;
                case EH:
                    return PH;
                case EJ:
                    return PJ;
                case EK:
                    return PK;
                case EL:
                    return PL;
                case EM:
                    return PM;
                case EN:
                    return PN;
                case EP:
                    return PP;
                case ES:
                    return PS;
                case ET:
                    return PT;
                case EV:
                    return PV;
                case EX:
                    return PX;
                case EY:
                    return PY;
                case EZ:
                    return PZ;
                case None:
                default:
                    return None;
            }
        }

        public static string ConvertToEnglish(string s)
        {
            switch (s)
            {
                case PA:
                    return EA;
                case PB:
                    return EB;
                case PC:
                    return EC;
                case PD:
                    return ED;
                case PE:
                    return EE;
                case PG:
                    return EG;
                case PH:
                    return EH;
                case PJ:
                    return EJ;
                case PK:
                    return EK;
                case PL:
                    return EL;
                case PM:
                    return EM;
                case PN:
                    return EN;
                case PP:
                    return EP;
                case PS:
                    return ES;
                case PT:
                    return ET;
                case PV:
                    return EV;
                case PX:
                    return EX;
                case PY:
                    return EY;
                case PZ:
                    return EZ;
                case None:
                default:
                    return None;
            }
        }
    }
}
