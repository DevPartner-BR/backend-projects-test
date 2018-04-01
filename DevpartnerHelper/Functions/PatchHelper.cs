using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevpartnerHelper.Functions
{
    public class PatchHelper
    {
        private static ConcurrentDictionary<Type, PropertyInfo[]> TypePropertiesCache =
        new ConcurrentDictionary<Type, PropertyInfo[]>();

        public static void Patch<TPatch, TEntity>(TPatch patch, TEntity entity)
            where TPatch : class
            where TEntity : class
        {
            PropertyInfo[] properties = TypePropertiesCache.GetOrAdd(
                patch.GetType(),
                (type) => type.GetProperties(BindingFlags.Instance | BindingFlags.Public));

            foreach (PropertyInfo prop in properties)
            {
                PropertyInfo orjProp = entity.GetType().GetProperty(prop.Name);
                object value = prop.GetValue(patch);
                if (value != null)
                {
                    orjProp.SetValue(entity, value);
                }
            }
        }
    }
}
