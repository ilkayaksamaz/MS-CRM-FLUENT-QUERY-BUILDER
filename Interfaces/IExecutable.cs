using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Querybuilder.Interfaces
{
    public interface IExecutable
    {
        EntityCollection ExecuteMultiple(IOrganizationService service);
        IEnumerable<T> ExecuteMultiple<T>(IOrganizationService service, Func<Entity, T> func);
    }
}
