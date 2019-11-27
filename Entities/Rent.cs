using System;
using ProjetoFaculdade2.Common;

namespace ProjetoFaculdade2.Entities
{
    public class Rent : BaseEntity
    {
        public DateTime Withdraw { get; set; }
        public DateTime Devolution { get; set; }
        public bool? IsReturned { get; set; }
    }
}