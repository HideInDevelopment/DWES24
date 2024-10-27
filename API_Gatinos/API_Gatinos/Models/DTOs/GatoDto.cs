namespace API_Gatinos.Models.DTOs;

#nullable disable
public class GatoDto
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Raza { get; set; }
    public int Peso { get; set; }
    public Guid IdColonia { get; set; }
}
