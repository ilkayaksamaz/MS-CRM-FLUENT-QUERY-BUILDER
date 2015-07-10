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
    public class QeuryContext
    {
        internal QueryExpression Query { get; set; }

        internal EntityCollection ExecuteQuery(IOrganizationService service)
        {
            if (service == null)
                throw new ArgumentNullException("IOrganiztionService", "Service parameter cannot be null");

            return service.RetrieveMultiple(Query);
        }

        internal IEnumerable<T> ExecuteQuery<T>(IOrganizationService service, Func<Entity, T> func)
        {
            if (service == null)
                throw new ArgumentNullException("IOrganiztionService", "Service parameter cannot be null");

            var entities = service.RetrieveMultiple(Query).Entities;
            var list = new List<T>();
            if (entities != null)
            {
                var a = entities.Select<Entity, T>(func).ToList();
                list.AddRange(a);
            }
            return list;
        }
    }
}
