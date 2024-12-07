using ReflectionsTesting.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ReflectionsTesting
{
    public class CSVGenerator<T>
    {
        private IEnumerable<T> _data;
        private string _filename;
        private Type _type;

        public CSVGenerator(IEnumerable<T> data, string filename)
        {
            _data = data;
            _filename = filename;
            _type = typeof(T);
        }

        public void Generate() 
        {
            var rows = new List<string>();

            rows.Add(CreateHeader());

            foreach (var item in _data) 
            {
                rows.Add(CreateRow(item));
            }

            File.WriteAllLines($"{_filename}.csv", rows, Encoding.UTF8);
        }

        private string CreateHeader ()
        {
            var properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sb = new StringBuilder();

            var idPropery = properties.FirstOrDefault(p => p.Name == "Id");

            if (idPropery != null)
            {
                sb.Append(idPropery.Name).Append(",");
            }

            foreach (var property in properties)
            {
                if (property.Name == "Id")
                {
                    continue;
                }

                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && property.PropertyType != typeof(string))
                {
                    var itemType = property.PropertyType.IsGenericType
                        ? property.PropertyType.GetGenericArguments()[0] 
                        : property.PropertyType.GetElementType();        

                    if (itemType != null)
                    {
                        var nestedProperties = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                        foreach (var nestedProperty in nestedProperties)
                        {
                            sb.Append($"{property.Name}_{nestedProperty.Name},");
                        }
                    }
                }
                else
                {
                    sb.Append(property.Name).Append(",");
                }
            }

            return sb.ToString().TrimEnd(',');
        }


        private string CreateRow (T item)
        {
            ArgumentNullException.ThrowIfNull(item);

            var properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sb = new StringBuilder();

            var idProperty = properties.FirstOrDefault(p => p.Name == "Id");
            if (idProperty != null)
            {
                var idValue = idProperty.GetValue(item);
                sb.Append(CreateItem(idValue)).Append(",");
            }

            foreach (var property in properties.Where(p => p.Name != "Id"))
            {
                var value = property.GetValue(item);
                var nestedType = property.PropertyType.GetGenericArguments().FirstOrDefault();

                if (value is IEnumerable collection && property.PropertyType != typeof(string))
                {
                    var nestedProperties = nestedType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    var nestedValues = new Dictionary<string, List<string>>();

                    foreach (var nestedProperty in nestedProperties)
                    {
                        nestedValues[nestedProperty.Name] = new List<string>();
                    }

                    foreach (var listItem in collection)
                    {
                        foreach (var nestedProperty in nestedProperties)
                        {
                            var nestedValue = nestedProperty.GetValue(listItem);
                            nestedValues[nestedProperty.Name].Add(nestedValue?.ToString() ?? string.Empty);
                        }
                    }

                    foreach (var nestedProperty in nestedProperties)
                    {
                        sb.Append(string.Join("; ", nestedValues[nestedProperty.Name])).Append(",");
                    }
                }
                else if (value != null && !IsSimpleType(property.PropertyType))
                {
                    var nestedProperties = property.PropertyType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                    foreach (var nestedProperty in nestedProperties)
                    {
                        var nestedValue = nestedProperty.GetValue(value);
                        sb.Append(CreateItem(nestedValue)).Append(",");
                    }
                }
                else
                {
                    sb.Append(CreateItem(value)).Append(",");
                }
            }

            return sb.ToString().TrimEnd(',');
        }


        private string CreateItem(object item)
        {
            if (item is int num)
            {
                return num.ToString();
            }
            if (item is string str)
            {
                return str; 
            }
            if (item is DateTime date)
            {
                return date.ToString("yyyy-MM-dd"); 
            }
            if(item is Guid)
            {
                return Guid.NewGuid().ToString();
            }
       
            return item?.ToString() ?? string.Empty; 
        }

        private bool IsSimpleType(Type type)
        {
            return type.IsPrimitive || type.IsEnum || type == typeof(string) || type == typeof(decimal) || type == typeof(DateTime) || type == typeof(Guid);
        }


    }
}
