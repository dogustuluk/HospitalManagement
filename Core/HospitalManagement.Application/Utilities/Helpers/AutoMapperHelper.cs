namespace HospitalManagement.Application.Utilities.Helpers
{
    public class AutoMapperHelper
    {
        public static void ConfigureAutoMappings(IMapperConfigurationExpression cfg, Assembly[] assemblies)
        {
            // Entity'leri al
            var entityTypes = assemblies
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => typeof(BaseEntity).IsAssignableFrom(t) && !t.IsAbstract)
                .ToArray();

            // DTO'ları ve attribute'ları al
            var dtoTypes = assemblies
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => !t.GetCustomAttributes(false).Any(attr => attr is CommandRequestMappingAttribute || attr is CommandResponseMappingAttribute || attr is QueryRequestMappingAttribute || attr is QueryResponseMappingAttribute))
                .ToArray();

            var requestTypes = assemblies
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => t.GetCustomAttribute<CommandRequestMappingAttribute>() != null ||
                            t.GetCustomAttribute<QueryRequestMappingAttribute>() != null)
                .ToArray();

            var responseTypes = assemblies
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => t.GetCustomAttribute<CommandResponseMappingAttribute>() != null ||
                            t.GetCustomAttribute<QueryResponseMappingAttribute>() != null)
                .ToArray();

            // Mapping kuralları
            var mappingRules = new (Type[] SourceTypes, Type[] DestinationTypes, Func<Type, Type, bool> IsMatchingPair)[]
            {
            (entityTypes, dtoTypes, IsEntityToDtoPair),
            (dtoTypes, requestTypes, IsDtoToRequestPair),
            (dtoTypes, responseTypes, IsDtoToResponsePair)
            };

            foreach (var rule in mappingRules)
            {
                var pairs = rule.SourceTypes.SelectMany(
                    t1 => rule.DestinationTypes.Where(t2 => rule.IsMatchingPair(t1, t2)),
                    (t1, t2) => (SourceType: t1, DestinationType: t2)
                );

                foreach (var pair in pairs)
                {
                    cfg.CreateMap(pair.SourceType, pair.DestinationType);
                    cfg.CreateMap(pair.DestinationType, pair.SourceType);
                }
            }
        }

        private static bool IsEntityToDtoPair(Type entityType, Type dtoType)
        {
            // Entity ve DTO adlarının eşleşmesini sağlayan mantık
            var entityName = entityType.Name;
            var dtoNameWithoutSuffix = dtoType.Name.Replace("_Dto", string.Empty);
            return dtoNameWithoutSuffix == entityName && entityType != dtoType;
        }

        private static bool IsDtoToRequestPair(Type dtoType, Type requestType)
        {
            // DTO ve Request attribute'larını kontrol et
            var isRequest = requestType.GetCustomAttribute<CommandRequestMappingAttribute>() != null ||
                            requestType.GetCustomAttribute<QueryRequestMappingAttribute>() != null;

            if (isRequest)
            {
                var dtoName = dtoType.Name;
                var requestNameWithoutSuffix = requestType.Name.Replace("Request", string.Empty);
                return dtoName == requestNameWithoutSuffix && dtoType != requestType;
            }

            return false;
        }

        private static bool IsDtoToResponsePair(Type dtoType, Type responseType)
        {
            // DTO ve Response attribute'larını kontrol et
            var isResponse = responseType.GetCustomAttribute<CommandResponseMappingAttribute>() != null ||
                             responseType.GetCustomAttribute<QueryResponseMappingAttribute>() != null;

            if (isResponse)
            {
                var dtoName = dtoType.Name;
                var responseNameWithoutSuffix = responseType.Name.Replace("Response", string.Empty);
                return dtoName == responseNameWithoutSuffix && dtoType != responseType;
            }

            return false;
        }
    }


}
