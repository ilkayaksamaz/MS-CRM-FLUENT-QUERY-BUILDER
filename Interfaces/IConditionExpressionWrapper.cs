using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Querybuilder.Interfaces
{
    public interface IConditionExpressionWrapper : IExecutable
    {
        IConditionExpressionWrapper ToConditionExpression(ConditionExpression Conditions);
        IConditionExpressionWrapper ToConditionExpression(string attrName);
        IConditionExpressionWrapper ToConditionExpression(string attrName, ConditionOperator conditionalOperator);
        IConditionExpressionWrapper ToConditionExpression(string attrName, ConditionOperator conditionalOperator, object value);
        IConditionExpressionWrapper ToConditionExpression(string attrName, ConditionOperator conditionalOperator, params object[] values);

        IConditionExpressionWrapper ToConditionExpression(string attrName, ConditionOperator conditionalOperator, ICollection<object> values);
    }
}
