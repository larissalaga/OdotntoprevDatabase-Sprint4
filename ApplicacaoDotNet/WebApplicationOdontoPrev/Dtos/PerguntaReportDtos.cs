using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationOdontoPrev.Dtos
{
    public class PerguntaReportDtos
    {
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Pergunta { get; set; } = string.Empty;
        public string Resposta { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public int TotalPontos { get; set; }
    }
}
