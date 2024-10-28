using API_Gatinos.Models.Entities;

namespace API_Gatinos.Models.DTOs;

#nullable disable
public class ColoniaDTO
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Ubicacion { get; set; }
    public int Telefono { get; set; }
    public int Movil { get; set; }
    public string Descripcion { get; set; }
    public string Imagen { get; set; }
    public ICollection<GatoDTO> Gatos { get; set; }
    public ICollection<ColaboradorDTO> Colaboradores { get; set; }
}
