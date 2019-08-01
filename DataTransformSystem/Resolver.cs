using System;

namespace DataTransformSystem
{
    public static class Resolver
    {
        // Currency: CD->CAD US->USD
        public static void CurrencyCurrency(AccountStandard account, string currency)
        {
            var inCurrency = currency?.Trim().ToUpper();
            switch (inCurrency)
            {
                case "CD":
                case "C":
                    account.Currency = ECurrency.CAD;
                    break;
                case "US":
                case "U":
                    account.Currency = ECurrency.USD;
                    break;
                default:
                    account.Currency = ECurrency.Unknown;
                    break;
            }
        }

        public static void TypeType(AccountStandard account, string type)
        {
            Enum.TryParse(type, true, out EType eType);
            if (eType < EType.Unknown || eType >= EType.Max)
                eType = EType.Unknown;
            account.Type = eType;
        }

        // Identifier -> AccountCode
        public static void IdentifierAccountCode(AccountStandard account, string identifier)
        {
            account.AccountCode = null;
            if (identifier != null)
            {
                var pos = identifier.IndexOf('|');
                if (pos >= 0)
                {
                    account.AccountCode = identifier.Substring(pos + 1);
                }
            }
        }

        // Identifier -> AccountCode
        public static void OpenedOpenDate(AccountStandard account, string date)
        {
            account.OpenDate = Convert.ToDateTime(date);
        }

        public static void NameName(AccountStandard account, string name)
        {
            account.Name = name;
        }

        public static void CustodianCodeAccountCode(AccountStandard account, string code)
        {
            account.AccountCode = code;
        }


    }
}
