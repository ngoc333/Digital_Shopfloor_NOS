using System;
using System.Data;
using System.Drawing;
using System.Data.OracleClient;


namespace FORM.ClassLib
{
	/// <summary>
	/// ComVar�� ���� ��� �����Դϴ�.
	/// </summary>
	public class ComVar : COM.ComVar 
	{
		public ComVar()
		{
			//
			// TODO: ���⿡ ������ ���� �߰��մϴ�.
			//
		}
        public static string This_Computer = "";
        public static string This_Action;
        public static string This_Win_ID;
        public static string This_PGM = "MOLD";
        public static string This_Packages;

        public static string This_Title = "";
        public static int This_Screen = 1;
        public static string This_Wh = "";
        public static string This_Mline = "";

        public static bool This_Status = false;

        //public static string This_User = "admin";
        // ������
        public const string Insert = "I";
        public const string Update = "U";
        public const string Delete = "D";

	}
}
