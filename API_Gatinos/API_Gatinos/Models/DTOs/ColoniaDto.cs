using API_Gatinos.Models.Entities;

namespace API_Gatinos.Models.DTOs;

#nullable disable
public class ColoniaDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Ubicacion { get; set; }
    public int Telefono { get; set; }
    public int Movil { get; set; }
    public string Descripcion { get; set; }
    public string Imagen { get; set; }
    public ICollection<GatoDto> Gatos { get; set; }
    public ICollection<ResponsableDto> Responsables { get; set; }
}
