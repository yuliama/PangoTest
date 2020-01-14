using EnumsNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;

namespace PangoCalculator.Models
{
    public class Result : IResult
    {
        public string ResultNumber { get; set; }
        public string css { get; set; }
        public string Calculate(MathExercise exercise)
        {
            string result = string.Empty;

            try
            {
                switch (exercise.op)
                {
                    case CalcOperator.Plus:
                        result = (exercise.num1 + exercise.num2).ToString();
                        break;
                    case CalcOperator.Minus:
                        result = (exercise.num1 - exercise.num2).ToString();
                        break;
                    case CalcOperator.Multiply:
                        result = (exercise.num1 * exercise.num2).ToString();
                        break;
                    case CalcOperator.Divide:
                        result = exercise.num2 != 0 ? (exercise.num1 / exercise.num2).ToString() : "You can't divide by Zero!";
                        break;
                    case CalcOperator.Modulu:
                        result = (exercise.num1 % exercise.num2).ToString();
                        break;
                }

                switch (exercise.queryType)
                {
                    case ResultType.ValueAndColor:
                        {
                            return new JavaScriptSerializer().Serialize(new { result, style = "blue" });
                        }
                    case ResultType.ValueAndDiffColorEvenAndOddRes:
                        {
                            string addStyle = double.Parse(result) % 2 == 0 ? "green" : "red";
                            return new JavaScriptSerializer().Serialize(new { result, style = addStyle });
                        }
                    case ResultType.Value:
                    default:
                        {
                            return new JavaScriptSerializer().Serialize(new { result});
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetOperators()
        {
            List<Tuple<string, string>> operators = new List<Tuple<string, string>>();

            foreach (CalcOperator op in Enum.GetValues(typeof(CalcOperator)))
            {
                FieldInfo fi = op.GetType().GetField(op.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                operators.Add(new Tuple<string, string>( op.ToString(), attributes.First().Description ));
            }
            return new JavaScriptSerializer().Serialize(new { operators });
        }
    }
}