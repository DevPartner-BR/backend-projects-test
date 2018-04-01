namespace PathMap
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Reflection;

    public class MapeamentoUpdate
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
                if (prop.PropertyType == typeof(string) ||
                    prop.PropertyType == typeof(int) ||
                    prop.PropertyType == typeof(int?) ||
                    prop.PropertyType == typeof(decimal) ||
                    prop.PropertyType == typeof(decimal?) ||
                    prop.PropertyType == typeof(float) ||
                    prop.PropertyType == typeof(float?) ||
                    prop.PropertyType == typeof(double) ||
                    prop.PropertyType == typeof(double?) ||
                    prop.PropertyType == typeof(bool) ||
                    prop.PropertyType == typeof(bool?) ||
                    prop.PropertyType == typeof(DateTime) ||
                    prop.PropertyType == typeof(DateTime?) ||
                    prop.PropertyType == typeof(Boolean) ||
                    prop.PropertyType == typeof(Boolean?))
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
}
