using System;

namespace DataTransformSystem
{
    public class Mapping
    {
        public static Action<AccountStandard, string>[] MappingActions =
        {
            Resolver.IdentifierAccountCode,
            Resolver.CustodianCodeAccountCode,
            Resolver.NameName,
            Resolver.TypeType,
            Resolver.OpenedOpenDate,
            Resolver.CurrencyCurrency
        };
    }
}
