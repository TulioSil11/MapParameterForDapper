using ApiPortalVendedor.Models;
using Dapper.Oracle;
using System;
using System.Collections.Generic;
using System.Data;

namespace ApiPortalVendedor.Repositories
{
    public class mapperParameter
    {

        public OracleDynamicParameters mapperForDictionary(object model)
        {
            Dictionary<string, object> propertyValues = new Dictionary<string, object>();
            Type ObjectType = model.GetType();
            System.Reflection.PropertyInfo[] properties = ObjectType.GetProperties();
            foreach (System.Reflection.PropertyInfo property in properties)
            {
                propertyValues.Add(property.Name, property.GetValue(model, null));
            }

            var parameters = mapperParrameters(propertyValues);

            return parameters;
        }


        public OracleDynamicParameters mapperParrameters (Dictionary<string, object> propertyValues)
        {
            OracleDynamicParameters parameters = new OracleDynamicParameters();

            foreach (KeyValuePair<string, object> ele1 in propertyValues)
            {
                parameters.Add($"{ele1.Key}", ele1.Value);                
            }

            parameters.Add("CUR_OUT", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            return parameters;
        }

    }

}
