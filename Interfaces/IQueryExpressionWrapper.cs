using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Querybuilder.Interfaces
{
    public interface IQueryExpressionWrapper
    {
        /// <summary>
        /// Create Qeury Expression
        /// </summary>
        /// <returns></returns>
        IFilterExpressionWrapper ToQueryExpression();
        /// <summary>
        /// Create Qeury Expression
        /// </summary>
        /// <param name="entityName">Entity Name</param>
        /// <returns></returns>
        IFilterExpressionWrapper ToQueryExpression(string entityName);
        /// <summary>
        /// Create Qeury Expression
        /// </summary>
        /// <param name="entityName">Entity Name</param>
        /// <param name="columns">Entity Columns</param>
        /// <returns></returns>
        IFilterExpressionWrapper ToQueryExpression(string entityName, params string[] columns);
       
    }
}
