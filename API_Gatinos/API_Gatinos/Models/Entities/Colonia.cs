using API_Gatinos.Models.Repositories.GenericDBConnection.Models;

namespace API_Gatinos.Models.Entities;

#nullable disable
public class Colonia : Entity<Guid>
{
    public string Nombre { get; set; }
    public string Ubicacion { get; set; }
    public int Telefono { get; set; }
    public int Movil { get; set; }
    public string Descripcion { get; set; }
    public string Imagen { get; set; }
    public virtual ICollection<Gato> Gatos { get; set; }
    public virtual ICollection<Colaborador> Colaboradores { get; set; }
}
