using System;
using System.ComponentModel.DataAnnotations;
using WebApplicationOdontoPrev.Dtos;

namespace WebApplicationOdontoPrev.Dtos
{
    public class AuditoriaDtos
    {
        [Required]
        [MaxLength(50)]
        public string nm_tabela { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string ds_operacao { get; set; } = string.Empty;

        public DateTime dt_operacao { get; set; }

        [MaxLength(100)]
        public string id_usuario { get; set; } = string.Empty;

        public string nm_valores_anteriores { get; set; } = string.Empty;
    }
}
