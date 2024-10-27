using API_Gatinos.Models.Entities;

namespace API_Gatinos.Models.DTOs;

#nullable disable
public class ResponsableDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public int Telefono { get; set; }
    public string Email { get; set; }
    public ICollection<ColoniaDto> Colonias { get; set; }
}
