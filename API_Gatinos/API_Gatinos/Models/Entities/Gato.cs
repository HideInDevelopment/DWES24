using API_Gatinos.Models.Repositories.GenericDBConnection.Models;

namespace API_Gatinos.Models.Entities;

#nullable disable
public class Gato : Entity<Guid>
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Raza { get; set; }
    public int Peso { get; set; }
    public Guid IdColonia { get; set; }
}
