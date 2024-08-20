namespace HospitalManagement.Application.Common.Specifications
{
    public class GenericSpecification<T> where T : class
    {
        public Expression<Func<T, bool>> BuildPredicate<TRequest>(TRequest request)
        {
            var predicate = PredicateBuilder.New<T>(true);

            foreach (var prop in typeof(TRequest).GetProperties())
            {
                var value = prop.GetValue(request);
                if (value == null || (value is string str && string.IsNullOrWhiteSpace(str)))
                    continue;

                var propInfo = typeof(T).GetProperty(prop.Name);
                if (propInfo != null)
                {
                    if (prop.PropertyType == typeof(int))
                    {
                        predicate = BuildIntPredicate(predicate, propInfo, (int)value);
                    }
                    else if (prop.PropertyType == typeof(string))
                    {
                        predicate = predicate.And(CreateStringContainsExpression(propInfo, value.ToString()));
                    }
                    else if (prop.PropertyType == typeof(DateTime))
                    {
                        predicate = BuildDatePredicate(predicate, propInfo, (DateTime)value);
                    }
                    else if (prop.PropertyType == typeof(DateTime?))
                    {
                        predicate = BuildNullableDatePredicate(predicate, propInfo, (DateTime?)value);
                    }
                    else
                    {
                        predicate = predicate.And(CreateEqualsExpression(propInfo, value));
                    }
                }
            }

            return predicate;
        }

        private Expression<Func<T, bool>> BuildIntPredicate(Expression<Func<T, bool>> predicate, PropertyInfo propInfo, int value)
        {
            if (value > 0)
            {
                predicate = predicate.And(CreateGreaterThanExpression(propInfo, value));
            }
            else if (value == 0)
            {
                predicate = predicate.And(CreateEqualsExpression(propInfo, value));
            }
            else if (value < 0)
            {
                predicate = predicate.And(CreateLessThanExpression(propInfo, -value));
            }

            return predicate;
        }

        private Expression<Func<T, bool>> BuildDatePredicate(Expression<Func<T, bool>> predicate, PropertyInfo propInfo, DateTime value)
        {
            // Örneğin: belirli bir tarihte
            predicate = predicate.And(CreateEqualsExpression(propInfo, value));

            // Örneğin: Tarihten büyük
            predicate = predicate.Or(CreateGreaterThanExpression(propInfo, value));

            // Örneğin: Tarihten küçük
            predicate = predicate.Or(CreateLessThanExpression(propInfo, value));

            return predicate;
        }

        private Expression<Func<T, bool>> BuildNullableDatePredicate(Expression<Func<T, bool>> predicate, PropertyInfo propInfo, DateTime? value)
        {
            if (value.HasValue)
            {
                return BuildDatePredicate(predicate, propInfo, value.Value);
            }

            return predicate;
        }

        private Expression<Func<T, bool>> CreateEqualsExpression(PropertyInfo propInfo, object value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var member = Expression.Property(parameter, propInfo);
            var constant = Expression.Constant(value);
            var body = Expression.Equal(member, constant);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        private Expression<Func<T, bool>> CreateNotEqualsExpression(PropertyInfo propInfo, object value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var member = Expression.Property(parameter, propInfo);
            var constant = Expression.Constant(value);
            var body = Expression.NotEqual(member, constant);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        private Expression<Func<T, bool>> CreateGreaterThanExpression(PropertyInfo propInfo, object value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var member = Expression.Property(parameter, propInfo);
            var constant = Expression.Constant(value);
            var body = Expression.GreaterThan(member, constant);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        private Expression<Func<T, bool>> CreateGreaterThanOrEqualExpression(PropertyInfo propInfo, object value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var member = Expression.Property(parameter, propInfo);
            var constant = Expression.Constant(value);
            var body = Expression.GreaterThanOrEqual(member, constant);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        private Expression<Func<T, bool>> CreateLessThanExpression(PropertyInfo propInfo, object value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var member = Expression.Property(parameter, propInfo);
            var constant = Expression.Constant(value);
            var body = Expression.LessThan(member, constant);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        private Expression<Func<T, bool>> CreateLessThanOrEqualExpression(PropertyInfo propInfo, object value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var member = Expression.Property(parameter, propInfo);
            var constant = Expression.Constant(value);
            var body = Expression.LessThanOrEqual(member, constant);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        private Expression<Func<T, bool>> CreateStringContainsExpression(PropertyInfo propInfo, string value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var member = Expression.Property(parameter, propInfo);
            var constant = Expression.Constant(value, typeof(string));
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var body = Expression.Call(member, containsMethod, constant);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
