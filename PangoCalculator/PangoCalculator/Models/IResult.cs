using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangoCalculator.Models
{
    interface IResult
    {
        string Calculate(MathExercise exercise);
    }
}
