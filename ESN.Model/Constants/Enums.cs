using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Model.Constants
{   

    public enum OperatorType
    {
        [Esn(Code = "Like", Description = "Like Operator Condition", UserDefine = "")]
        Like,

        [Esn(Code = "=", Description = "Equal Operator Condition")]
        Equal,

        [Esn(Code = "<>", Description = "Not Equal Operator Condition")]
        NotEqual,

        [Esn(Code = ">=", Description = "Greater and Equal Operator Condition")]
        GreaterEqual,

        [Esn(Code = "<=", Description = "Less and Equal Operator Condition (if date time concat 23:59:59)")]
        LessEqual,

        [Esn(Code = "<=", Description = "Less than or Equal Operator Condition with own time")]
        LessOrEqualWithOwnTime,

        [Esn(Code = " IN ", Description = "In Condition")]
        In,

        [Esn(Code = "NOT IN ", Description = "Not In Condition")]
        NotIn,

        [Esn(Code = "IS ", Description = "Is null or not null")]
        Is,

        [Esn(Code = ">", Description = "Greater Than Operator Condition")]
        GreaterThan,

        [Esn(Code = "<", Description = "Less Than Operator Condition")]
        LessThan
    }

    public enum JoinerType
    {
        [Esn(Code = " And ", Description = "And Condition")]
        And,

        [Esn(Code = " Or ", Description = "Or Condition")]
        Or,

        [Esn(Code = " NOT ", Description = "Not Condition")]
        Not
    }

    public enum LikePositionType
    {
        [Esn(Code = "%{0}", Description = "Begin Words")]
        BeginWords,

        [Esn(Code = "{0}%", Description = "End Words")]
        EndWords,

        [Esn(Code = "%{0}%", Description = "Around Words")]
        AroundWords,

        [Esn(Code = "%%", Description = "All Words")]
        AllWords,
    }

    #region Attribute Function

    public class EsnAttribute : Attribute
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string UserDefine { get; set; }
    }

    public static class ESNEnums
    {
        public static string GetAttrCode<T>(this T value)
        {
            string output = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            EsnAttribute[] attrs = fi.GetCustomAttributes(typeof(EsnAttribute), false) as EsnAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Code;
            }
            return output;
        }

        public static string GetAttrDesc<T>(this T value)
        {
            string output = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            EsnAttribute[] attrs = fi.GetCustomAttributes(typeof(EsnAttribute), false) as EsnAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Description;
            }
            return output;
        }

        public static string GetAttrUserDef(this Enum value)
        {
            string output = null;
            Type type = value.GetType();
            FieldInfo fi = type.GetField(value.ToString());
            EsnAttribute[] attrs = fi.GetCustomAttributes(typeof(EsnAttribute), false) as EsnAttribute[];
            if (attrs.Length > 0)
            {
                output = attrs[0].UserDefine;
            }
            //output = output.Replace("@","@"+Environment.NewLine);
            return output;
        }

    }

    #endregion

}
