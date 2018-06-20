using System;
using System.ComponentModel;

namespace ESHClouds.ApiCenter.Enums
{
    /// <summary>
    /// 法規雲角色
    /// </summary>
    [Flags]
    public enum LegalRoleEnum 
    {
        
        主管 = 0,
        執行者 = 1,
        計畫者 = 2,
        管理員 = 4,
    }

    /// <summary>
    /// 化學雲角色
    /// </summary>
    [Flags]
    public enum ChemicalEnum
    {
       
       
        使用者 = 0,
        供應商 = 1,
        系統管理者 = 2,
        廠區管理者 = 4,
    }
}