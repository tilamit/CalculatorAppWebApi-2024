using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Sprache;

namespace Calculator
{
  public class ExpressionParser : IParser<double>
  {
    public Expression<Func<double>> Parse(string input)
    {
      var result = Syntax.ParseLambda(new Input(input));

      if (!result.WasSuccessful)
      {
        throw new Exception(result.Message);
      }

      return result.Value;
    }
  }
}
