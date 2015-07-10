using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Querybuilder.Interfaces
{
    public interface IFilterExpressionWrapper : IExecutable
    {
        /// <summary>
        /// Create Filter Expression
        /// </summary>
        /// <returns></returns>
        IConditionExpressionWrapper ToFilterExpression();
        /// <summary>
        /// Create Filter Expression
        /// </summary>
        /// <param name="filteropterator">Logical Operator</param>
        /// <returns></returns>
        IConditionExpressionWrapper ToFilterExpression(LogicalOperator filteropterator);


        /// <summary>
        /// Create Filter Expression with custom object
        /// </summary>
        /// <param name="filteropterator">Logical Operator</param>
        /// <returns></returns>
        IConditionExpressionWrapper ToFilterExpression(FilterExpression Expression);

        /// <summary>
        /// Join Entity
        /// </summary>
        /// <param name="linkToEntityName"></param>
        /// <param name="linkFromAttributeName"></param>
        /// <param name="linkToAttributeName"></param>
        /// <returns></returns>
        IFilterExpressionWrapper LinkEntity(string linkToEntityName, string linkFromAttributeName, string linkToAttributeName);

        /// <summary>
        /// Join Entity
        /// </summary>
        /// <param name="linkToEntityName"></param>
        /// <param name="linkFromAttributeName"></param>
        /// <param name="linkToAttributeName"></param>
        /// <param name="joinOperator"></param>
        /// <returns></returns>
        IFilterExpressionWrapper LinkEntity(string linkToEntityName, string linkFromAttributeName, string linkToAttributeName, JoinOperator joinOperator);

    }
}
