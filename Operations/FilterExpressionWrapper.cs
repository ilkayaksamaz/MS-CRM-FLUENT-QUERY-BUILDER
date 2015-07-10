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
    internal class FilterExpressionWrapper : QeuryContext, IFilterExpressionWrapper
    {

        public FilterExpressionWrapper(QueryExpression eueryExp)
        {
            Query = eueryExp;
        }

        #region IFilterExpressionWrapper Members

        public IConditionExpressionWrapper ToFilterExpression()
        {
            return new ConditionExpressionWrapper(new FilterExpression(), Query);
        }

        public IConditionExpressionWrapper ToFilterExpression(Microsoft.Xrm.Sdk.Query.LogicalOperator filteropterator)
        {
            return new ConditionExpressionWrapper(new FilterExpression(filteropterator), Query);
        }


        public IConditionExpressionWrapper ToFilterExpression(FilterExpression Expression)
        {
            return new ConditionExpressionWrapper(Expression, Query);
        }

        public IFilterExpressionWrapper LinkEntity(string linkToEntityName, string linkFromAttributeName, string linkToAttributeName)
        {

            if (Query == null)
                throw new ArgumentNullException("QeuryExpression", "Create first Query Expression with ToExpression method");
            Query.AddLink(linkToEntityName, linkFromAttributeName, linkToAttributeName);
            return new FilterExpressionWrapper(Query);
        }

        public IFilterExpressionWrapper LinkEntity(string linkToEntityName, string linkFromAttributeName, string linkToAttributeName, JoinOperator joinOperator)
        {

            if (Query == null)
                throw new ArgumentNullException("QeuryExpression", "Create first Query Expression with ToExpression method");
            Query.AddLink(linkToEntityName, linkFromAttributeName, linkToAttributeName);
            return new FilterExpressionWrapper(Query);
        }

        #endregion

        #region IExecutable Members

        public EntityCollection ExecuteMultiple(IOrganizationService service)
        {
            return this.ExecuteQuery(service);
        }

        #endregion



        #region IExecutable Members


        public IEnumerable<T> ExecuteMultiple<T>(IOrganizationService service, Func<Entity, T> func)
        {
            return this.ExecuteQuery<T>(service, func);
        }

        #endregion




    }
}
