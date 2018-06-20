using System;
using System.Collections.Generic;
using System.Text;

namespace Risk.Model.Enums
{
    public static class ExceptionCode
    {
        /// <summary>
        /// 系統發生嚴重錯誤
        /// </summary>
        public static string InvalidRequest = "Invalid_Request";

        /// <summary>
        /// 此專案所開發的反射框架出錯
        /// </summary>
        public static string AssemblyLauncherError = "Assembly_Launcher_Error";

        /// <summary>
        /// 用於ViewModel驗證錯誤
        /// </summary>
        public static string InvalidModel = "Invalid_Model";

        /// <summary>
        /// 所要求的ID不存在
        /// </summary>
        public static string IdNotExist = "ID_Not_Exist";

        /// <summary>
        /// 存在相同的編號
        /// </summary>
        public static string DuplicateSericalNumber = "Duplicate_Serical_Number";

        /// <summary>
        /// 匯出範本不存在
        /// </summary>
        public static string TemplateNotExists = "Template_Not_Exists";

        /// <summary>
        /// 使用者未加入任何組織
        /// </summary>
        public static string UserOrganizationIsEmpty = "User_Organization_Is_Empty";

        /// <summary>
        /// 匯入範本格式不正確
        /// </summary>
        public static string TemplateFormatError = "Template_Format_Error";
        /// <summary>
        /// 參數錯誤
        /// </summary>
        public static string ParameterIsWrong = "Parameter_Is_Wrong";
       
    } 
}
