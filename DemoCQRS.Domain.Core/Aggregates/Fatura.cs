using System;

namespace DemoCQRS.Domain.Core.Aggregates
{
    public class Fatura
    {
        public string NuFatura { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
