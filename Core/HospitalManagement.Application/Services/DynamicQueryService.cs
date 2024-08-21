namespace HospitalManagement.Application.Services
{
    public class DynamicQueryService
    {
        public Expression<Func<T, bool>> BuildPredicate<T>(Dictionary<string, string> filters)
        {
            var predicate = PredicateBuilder.New<T>(true);

            foreach (var filter in filters)
            {
                var expression = BuildExpression<T>(filter.Key, filter.Value);
                predicate = predicate.And(expression);
            }

            return predicate;
        }

        private Expression<Func<T, bool>> BuildExpression<T>(string filterKey, string value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");

            // FilterKey: "ItemType==", "dbParameter>=" gibi
            var propertyName = filterKey.TrimEnd('=', '>', '<');
            var property = Expression.Property(parameter, propertyName);

            var constant = Expression.Constant(Convert.ChangeType(value, property.Type));

            // Operatöre göre farklı Expression'lar oluşturun
            if (filterKey.EndsWith("=="))
            {
                return Expression.Lambda<Func<T, bool>>(Expression.Equal(property, constant), parameter);
            }
            if (filterKey.EndsWith(">"))
            {
                return Expression.Lambda<Func<T, bool>>(Expression.GreaterThan(property, constant), parameter);
            }
            if (filterKey.EndsWith(">="))
            {
                return Expression.Lambda<Func<T, bool>>(Expression.GreaterThanOrEqual(property, constant), parameter);
            }
            if (filterKey.EndsWith("<="))
            {
                return Expression.Lambda<Func<T, bool>>(Expression.LessThanOrEqual(property, constant), parameter);
            }
            if (filterKey.EndsWith("<"))
            {
                return Expression.Lambda<Func<T, bool>>(Expression.LessThan(property, constant), parameter);
            }

            // Diğer operatörler için de ekleyin...
            throw new NotSupportedException("Desteklenmeyen operatör");
        }

    }
}
