using Framework.Querybuilder;
using Framework.Querybuilder.Interfaces;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Querybuilder.Operations
{
    internal class ConditionExpressionWrapper : QeuryContext, IConditionExpressionWrapper
    {

        public ConditionExpressionWrapper(FilterExpression filterExp, QueryExpression query)
        {
            Query = query;
            Query.Criteria = filterExp;
        }

        public ConditionExpressionWrapper(ConditionExpression conditionExp, QueryExpression query)
        {
            Query = query;
            Query.Criteria.AddCondition(conditionExp);
        }
        #region IConditionExpressionWrapper Members

        public IConditionExpressionWrapper ToConditionExpression(ConditionExpression Conditions)
        {
            return new ConditionExpressionWrapper(Conditions, Query);
        }

        public IConditionExpressionWrapper ToConditionExpression(string attrName)
        {
            return new ConditionExpressionWrapper(new ConditionExpression() { AttributeName = attrName }, Query);
        }

        public IConditionExpressionWrapper ToConditionExpression(string attrName, Microsoft.Xrm.Sdk.Query.ConditionOperator conditionalOperator)
        {
            return new ConditionExpressionWrapper(new ConditionExpression(attrName, conditionalOperator), Query);
        }

        public IConditionExpressionWrapper ToConditionExpression(string attrName, Microsoft.Xrm.Sdk.Query.ConditionOperator conditionalOperator, object value)
        {
            return new ConditionExpressionWrapper(new ConditionExpression(attrName, conditionalOperator, value), Query);

        }

        public IConditionExpressionWrapper ToConditionExpression(string attrName, Microsoft.Xrm.Sdk.Query.ConditionOperator conditionalOperator, params object[] values)
        {
            return new ConditionExpressionWrapper(new ConditionExpression(attrName, conditionalOperator, values), Query);

        }

        public IConditionExpressionWrapper ToConditionExpression(string attrName, Microsoft.Xrm.Sdk.Query.ConditionOperator conditionalOperator, ICollection<object> values)
        {
            return new ConditionExpressionWrapper(new ConditionExpression(attrName, conditionalOperator, values), Query);
        }

        #endregion




        public EntityCollection ExecuteMultiple(IOrganizationService service)
        {
            return this.ExecuteQuery(service);
        }

        public IEnumerable<T> ExecuteMultiple<T>(IOrganizationService service, Func<Entity, T> func)
        {
            return this.ExecuteQuery<T>(service,func);

        }

        
    }
}
