using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inlog.Desafio.Backend.Domain.Models;

public class Veiculo : BaseModel
{
    [MinLength(2)]
    [MaxLength(50)]
    public string Chassi { get; set; }

    public TipoVeiculo TipoVeiculo { get; set; }

    [MinLength(2)]
    [MaxLength(20)]
    public string Cor { get; set; }

    [MinLength(2)]
    [MaxLength(30)]
    public string Descricao { get; set; }

    [MinLength(2)]
    [MaxLength(10)]
    public string Placa { get; set; }

    public int CoordenadasId { get; set; }

    [NotMapped]
    public Coordenadas Coordenadas { get; set; } = null!;
}