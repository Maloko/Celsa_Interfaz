using System;
namespace InterfazMTTO.iSBO_BE
{
    public class BEORTT
    {
        private DateTime rateDate;
        private string currency;
        private decimal rate;

        public DateTime RateDate { get => rateDate; set => rateDate = value; }
        public string Currency { get => currency; set => currency = value; }
        public decimal Rate { get => rate; set => rate = value; }
    }
}
