using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PangoCalculator.Models
{
    public enum ResultType
    {
        Value = 0,
        ValueAndColor,
        ValueAndDiffColorEvenAndOddRes
    }

    public enum CalcOperator
    {
        [Description("+")]
        Plus = 0,
        [Description("-")]
        Minus,
        [Description("*")]
        Multiply,
        [Description("/")]
        Divide,
        [Description("%")]
        Modulu
    }
}