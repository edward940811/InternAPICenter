using System;
using System.ComponentModel;

namespace ESHClouds.ApiCenter.Enums
{
    /// <summary>
    /// 法規雲角色
    /// </summary>
    public static class LegalRoleEnum
    {
        public static string 主管 { get; set; } = "manager3";
        public static string 執行者 { get; set; } = "user3";
        public static string 計畫者 { get; set; } = "planer3";
        public static string 管理員 { get; set; } = "admin3";
        public static string Lite管理員 { get; set; } = "lite";

        public static int[] Run()
        {
            return new int[]{1,2};
        }
    }

    /// <summary>
    /// 化學雲角色
    /// </summary>
    public static class ChemicalEnum
    {

        public static string 使用者 { get; set; } = "lite";
        public static string 供應商 { get; set; } = "lite";
        public static string 系統管理者 { get; set; } = "lite";
        public static string 廠區管理者 { get; set; } = "lite";
    }
}