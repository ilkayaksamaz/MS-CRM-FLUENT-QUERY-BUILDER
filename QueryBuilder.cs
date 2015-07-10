using Framework.Querybuilder;
using Framework.Querybuilder.Interfaces;
using Framework.Querybuilder.Operations;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Querybuilder
{
    public sealed class QueryBuilder :
        QeuryContext,
        IQueryExpressionWrapper,
        IExecutable
    {

        //public QueryBuilder(IOrganizationService ServiceInstance)
        //{
        //    Service = ServiceInstance;
        //}


        #region IQueryExpressionWrapper Members

        public IFilterExpressionWrapper ToQueryExpression()
        {
            return new FilterExpressionWrapper(new QueryExpression());
        }

        public IFilterExpressionWrapper ToQueryExpression(string entityName)
        {
            return new FilterExpressionWrapper(new QueryExpression(entityName)
            {
                ColumnSet = new ColumnSet(true)
            });
        }

        public IFilterExpressionWrapper ToQueryExpression(string entityName, params string[] columns)
        {
            return new FilterExpressionWrapper(new QueryExpression(entityName)
            {
                ColumnSet = new ColumnSet(columns)
            });
        }

        #endregion


        #region IQueryExpressionWrapper Members



        #endregion

        public EntityCollection ExecuteMultiple(IOrganizationService service)
        {
            return this.ExecuteQuery(service);
        }

        public IEnumerable<T> ExecuteMultiple<T>(IOrganizationService service, Func<Entity, T> func)
        {
            return this.ExecuteQuery<T>(service, func);
        }
    }
}
