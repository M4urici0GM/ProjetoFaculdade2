using System;
using ProjetoFaculdade2.Common;

namespace ProjetoFaculdade2.Entities
{
    public class Movies : BaseEntity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Available { get; set; }
    }
}