using API_Gatinos.Models.Repositories.GenericDBConnection.Models;

namespace API_Gatinos.Models.Entities;

#nullable disable
public class Colaborador : Entity<Guid>
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public int Telefono { get; set; }
    public string Email { get; set; }
    public virtual ICollection<Colonia> Colonias { get; set; }
}
