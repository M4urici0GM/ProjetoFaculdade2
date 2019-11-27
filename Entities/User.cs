using ProjetoFaculdade2.Common;

namespace ProjetoFaculdade2.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}