namespace API_Gatinos.Models.DTOs;

using API_Gatinos.Models.Enums;

#nullable disable
public class GatoDTO
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Raza { get; set; }
    public int Peso { get; set; }
    public EstadoSalud EstadoSalud { get; set; }
    public Guid IdColonia { get; set; }
}
