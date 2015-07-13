# MS.CRM.FLUENT.QUERY.BUILDER
Microsoft CRM Dynamics fluent query builder for RetriveMultiple...

## SAMPLE USAGE
```
var entities = new QueryBuilder()
        .ToQueryExpression("entity_name")
        .ToFilterExpression(LogicalOperator.And)
        .ToConditionExpression("attr_name", ConditionOperator.Equal, "object_value")
         .ToConditionExpression("attr_name", ConditionOperator.Equal, "object_value")
        .ExecuteMultiple(IOrganiztionService, p => new CustomClass()
        {
            Propery = p["attr_name"],
        }).ToList(); 
```
