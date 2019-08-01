using System;

namespace DataTransformSystem
{
    public class AccountStandard
    {
        private DateTime _openDate;
        private bool _bOpenDateRequired = false;
        public string AccountCode { get; set; }
        public string Name { get; set; }
        public EType Type { get; set; }
        public DateTime OpenDate
        {
            get => _openDate;
            set
            {
                _openDate = value;
                _bOpenDateRequired = true;
            }
        }

        public ECurrency Currency { get; set; }

        public bool Validation()
        {
            if ( _bOpenDateRequired )
            {
                return !string.IsNullOrEmpty(AccountCode) && !string.IsNullOrEmpty(Name) && Type != EType.Unknown && Currency != ECurrency.Unknown && !OpenDate.Equals(DateTime.MinValue);
            }
            else
            {
                return !string.IsNullOrEmpty(AccountCode) && !string.IsNullOrEmpty(Name) && Type != EType.Unknown && Currency != ECurrency.Unknown;
            }
        }

        public override string ToString()
        {
            var date = OpenDate.Equals(DateTime.MinValue) ? "" : OpenDate.ToString("yyyy-MM-dd");
            return $"{AccountCode},{Name},{Type},{date},{Currency}";
        }

    }
}
