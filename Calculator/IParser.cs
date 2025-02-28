﻿using System;
using System.Linq.Expressions;

namespace Calculator
{
    public interface IParser<TResult>
    {
        Expression<Func<TResult>> Parse(string input);
    }
}