using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PangoCalculator.Models
{
    public class MathExercise
    {
        public double num1 { get; set; }
        public double num2 { get; set; }
        public CalcOperator op { get; set; }
        public ResultType queryType { get; set; }
    }
}