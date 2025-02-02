﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

namespace Singularity.Expressions
{
    internal sealed class ExpressionContext
    {
        public List<MethodCallExpression> ScopedExpressions { get; }
        public Expression Expression { get; set; }

        public ExpressionContext(Expression expression)
        {
            ScopedExpressions = new List<MethodCallExpression>();
            Expression = expression;
        }

        public ExpressionContext(ReadOnlyExpressionContext context)
        {
            ScopedExpressions = context.ScopedExpressions.ToList();
            Expression = context.Expression;
        }

        public static implicit operator ReadOnlyExpressionContext(ExpressionContext context)
        {
            return new ReadOnlyExpressionContext(context);
        }
    }

    internal sealed class ReadOnlyExpressionContext
    {
        public ReadOnlyCollection<MethodCallExpression> ScopedExpressions { get; }
        public Expression Expression { get; }

        public ReadOnlyExpressionContext(ExpressionContext context)
        {
            ScopedExpressions = new ReadOnlyCollection<MethodCallExpression>(context.ScopedExpressions.ToArray());
            Expression = context.Expression;
        }

        public static explicit operator ExpressionContext(ReadOnlyExpressionContext context)
        {
            return new ExpressionContext(context);
        }
    }
}
