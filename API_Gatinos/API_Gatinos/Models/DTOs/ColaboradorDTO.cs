namespace API_Gatinos.Models.DTOs;

#nullable disable
public class ColaboradorDTO
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public int Telefono { get; set; }
    public string Email { get; set; }
    public ICollection<ColoniaDTO> Colonias { get; set; }
}
