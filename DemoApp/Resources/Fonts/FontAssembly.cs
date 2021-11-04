using System;
using System.ComponentModel;

namespace DemoApp.Resources.Fonts
{
    public static class FontAssembly
    {
        public static string NunitoRegular = "Nunito-Regular";
        public static string NunitoSemiBold = "Nunito-SemiBold";
        public static string NunitoSemiBoldItalic = "Nunito-SemiBoldItalic";
        public static string LightStyle = "fa-light-300";
        public static string RegularStyle = "fa-regular-400";
        public static string SolidStyle = "fa-solid-900";
        public static string DuotoneStyle = "fa-duotone-900";
    }

    public class FontAwesomeIcon
    {
        public class Icon
        {
            public const string Plus = "\uf067";
            public const string ChevronLeft = "\uf053";
            public const string ChevronRight = "\uf054";
            public const string PlusCircle = "\uf055";
            public const string MinusCircle = "\uf056";
            public const string Edit = "\uf044";
            public const string Trash = "\uf1f8";
            public const string ChartBar = "\uf080";
            public const string Save = "\uf0c7";
            public const string Cancel = "\uf05e";
            public const string File = "\uf15b";// Hình Nội dung
            public const string User = "\uf007";
            public const string UserTag = "\uf507";
            public const string Calendar = "\uf133";
            public const string Calendar_Alt = "\uf073";
            public const string Flag = "\uf024";
            public const string AngleRight = "\uf105";
            public const string Paperclip = "\uf0c6";
            public const string Number = "\uf0cb";
            public const string ChevronUp = "\uf077";
            public const string ChevronDown = "\uf078";
            public const string GroupUser = "\uf0c0";
            public const string UserPlus = "\uf234";
            public const string InfoCircle = "\uf05a";
            public const string History = "\uf1da";
            public const string Comment = "\uf075";
            public const string Comment_Alt_Exclamation = "\uf4a5";
            public const string Comments = "\uf086";
            public const string Comment_Dot = "\uf4ad";
            public const string Appstore = "\uf36f";
            public const string Find = "\uf002";
            public const string Send = "\uf1d8";
            public const string Delete = "\uf00d";
            public const string Play = "\uf04b";
            public const string Check = "\uf00c";
            public const string Eye = "\uf06e";
            public const string EyeSlash = "\uf070";
            public const string TimescircleX = "\uf057";
            public const string Copy = "\uf0c5";
            public const string Home_Lg_Alt = "\uf80c";
            public const string Megaphone = "\uf675";
            public const string Address_Card = "\uf2bb";
            public const string Window = "\uf40e";
            public const string Coins = "\uf51e";
            public const string Ticket = "\uf145";
            public const string BallotCheck = "\uf733";
            public const string FileInvoice = "\uf570";
            public const string Ellipsis_H_Alt = "\uf39b";
            public const string QRCode = "\uf029";
            public const string SignOut = "\uf08b";
            public const string TimeX = "\uf00d";
            public const string Refresh = "\uf2f1";
            public const string Circlecheck = "\uf058";
            public const string Circle = "\uf111";
            public const string Bell = "\uf0f3";
            public const string Landmark = "\uf66f";
            public const string Ellipsis_v = "\uf142";
            public const string Heart = "\uf004";
            public const string ShareAlt = "\uf1e0";
            public const string Search = "\uf002";
            public const string ShopingBag = "\uf290";
            public const string Clock = "\uf017";
            public const string Minus = "\uf068";
            public const string Book = "\uf02d";
            public const string Pen = "\uf304";
            public const string Lightbulb = "\uf0eb";
            public const string LightbulbSlash = "\uf673";
            public const string ID_Card_Alt = "\uf47f";
            public const string BriefCase = "\uf0b1";
            public const string ID_Badge = "\uf2c1";
            public const string Building = "\uf1ad";
            public const string Phone_Square = "\uf098";
            public const string Key = "\uf084";
            public const string Envelope = "\uf0e0";
            public const string Arrowright = "\uf061";
            public const string House = "\uf00d";
            public const string Mapmarkeralt = "\uf3c5";
            public const string Images = "\uf302";
            public const string Filter = "\uf0b0";
            public const string Store = "\uf54e";
            public const string Lockalt = "\uf30d";
            public const string Creditcardfront = "\uf38a";
            public const string Mail = "\uf0e0";
            public const string User_Cog = "\uf4fe";
            public const string User_Circle = "\uf2bd";
            public const string Cogs = "\uf085";
            public const string VenusMars = "\uf228";
            public const string CaretDown = "\uf0d7";
            public const string PlusSquare = "\uf0fe";
            public const string ChevronDoubleDown = "\uf322";
            public const string HomeAlt = "\uf80a";
            public const string PhoneAlt = "\uf879";
            public const string IDCard = "\uf2c2";
            public const string FileDownload = "\uf56d";
        }

        public enum EnumIcon
        {
            [Description("\uf56d")]
            FileDownload,
            [Description("\uf2c2")]
            IDCard,
            [Description("\uf879")]
            PhoneAlt,
            [Description("\uf80a")]
            HomeAlt,
            [Description("\uf0fe")]
            PlusSquare,
            [Description("\uf0d7")]
            CaretDown,
            [Description("\uf228")]
            VenusMars,
            [Description("\uf067")]
            Plus,
            [Description("\uf053")]
            ChevronLeft,
            [Description("\uf054")]
            ChevronRight,
            [Description("\uf055")]
            PlusCircle,
            [Description("\uf056")]
            MinusCircle,
            [Description("\uf044")]
            Edit,
            [Description("\uf1f8")]
            Trash,
            [Description("\uf080")]
            ChartBar,
            [Description("\uf0c7")]
            Save,
            [Description("\uf05e;")]
            Cancel,
            [Description("\uf15b")]
            File,// Hình Nội dung
            [Description("\uf007")]
            User,
            [Description("\uf507")]
            UserTag,
            [Description("\uf133")]
            Calendar,
            [Description("\uf073")]
            Calendar_Alt,
            [Description("\uf024")]
            Flag,
            [Description("\uf105")]
            AngleRight,
            [Description("\uf0c6")]
            Paperclip,
            [Description("\uf0cb")]
            Number,
            [Description("\uf078")]
            ChevronDown,
            [Description("\uf077")]
            ChevronUp,
            [Description("\uf0c0")]
            GroupUser,
            [Description("\uf234")]
            UserPlus,
            [Description("\uf05a")]
            InfoCircle,
            [Description("\uf1da")]
            History,
            [Description("\uf075")]
            Comment,
            [Description("\uf4a5")]
            Comment_Alt_Exclamation,
            [Description("\uf086")]
            Comments,
            [Description("\uf4ad")]
            Comment_Dot,
            [Description("\uf36f")]
            Appstore,
            [Description("\uf002")]
            Find,
            [Description("\uf1d8")]
            Send,
            [Description("\uf00d")]
            Delete,
            [Description("\uf04b")]
            Play,
            [Description("\uf00c")]
            Check,
            [Description("\uf06e")]
            Eye,
            [Description("\uf070")]
            EyeSlash,
            [Description("\uf057")]
            TimescircleX,
            [Description("\uf0c5")]
            Copy,
            [Description("\uf80c")]
            Home_Lg_Alt,
            [Description("\uf675")]
            Megaphone,
            [Description("\uf2bb")]
            Address_Card,
            [Description("\uf40e")]
            Window,
            [Description("\uf51e")]
            Coins,
            [Description("\uf145")]
            Ticket,
            [Description("\uf733")]
            BallotCheck,
            [Description("\uf570")]
            FileInvoice,
            [Description("\uf39b")]
            Ellipsis_H_Alt,
            [Description("\uf029")]
            QRCode,
            [Description("\uf08b")]
            SignOut,
            [Description("\uf00d")]
            TimeX,
            [Description("\uf2f1")]
            Refresh,
            [Description("\uf058")]
            Circlecheck,
            [Description("\uf111")]
            Circle,
            [Description("\uf0f3")]
            Bell,
            [Description("\uf66f")]
            Landmark,
            [Description("\uf142")]
            Ellipsis_v,
            [Description("\uf004")]
            Heart,
            [Description("\uf1e0")]
            ShareAlt,
            [Description("\uf002")]
            Search,
            [Description("\uf290")]
            ShopingBag,
            [Description("\uf017")]
            Clock,
            [Description("\uf068")]
            Minus,
            [Description("\uf02d")]
            Book,
            [Description("\uf304")]
            Pen,
            [Description("\uf4ff")]
            UserEdit,
            [Description("\uf10b")]
            Mobile,
            [Description("\uf1cb")]
            CodePen,
            [Description("\uf24e")]
            BalanceScale,
            [Description("\uf07a")]
            ShopingCard,
            [Description("\uf217")]
            ShopingCardPlus,
            [Description("\uf013")]
            Cog,
            [Description("\uf0eb")]
            Lightbulb,
            [Description("\uf673")]
            LightbulbSlash,
            [Description("\uf030")]
            Camera,
            [Description("\uf47f")]
            ID_Card_Alt,
            [Description("\uf0b1")]
            BriefCase,
            [Description("\uf2c1")]
            ID_Badge,
            [Description("\uf1ad")]
            Building,
            [Description("\uf098")]
            Phone_Square,
            [Description("\uf084")]
            Key,
            [Description("\uf0e0")]
            Envelope,
            [Description("\uf061")]
            Arrowright,
            [Description("\uf00d")]
            House,
            [Description("\uf3c5")]
            Mapmarkeralt,
            [Description("\uf302")]
            Images,
            [Description("\uf0b0")]
            Filter,
            [Description("\uf54e")]
            Store,
            [Description("\uf30d")]
            LockAlt,
            [Description("\uf38a")]
            Creditcardfront,
            [Description("\uf0e0")]
            Mail,
            [Description("\uf4fe")]
            USer_Cog,
            [Description("\uf085")]
            Cogs,
            [Description("\uf2bd")]
            USer_Circle,
            [Description("\uf325")]
            ChevronDoubleUp,
        }

    }

}
