using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationOdontoPrev.Dtos
{
    public class PacienteDtos
    {
        public string Id { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string nm_paciente { get; set; } = string.Empty;

        [Required]
        [MaxLength(11)]
        public string nr_cpf { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime dt_nascimento { get; set; }

        [Required]
        [MaxLength(1)]
        public string ds_sexo { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(70)]
        public string ds_email { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string nr_telefone { get; set; } = string.Empty;

        [Required]
        public PlanoDto PLANO { get; set; } = new();

        public List<CheckInDto> CHECK_IN { get; set; } = new();
        public List<RaioXDto> RAIO_X { get; set; } = new();
        public List<ExtratoPontosDto> EXTRATO_PONTOS { get; set; } = new();
        public List<DentistaResumoDto> DENTISTA { get; set; } = new();

        public class PlanoDto
        {
            public string ds_codigo_plano { get; set; } = string.Empty;
            public string nm_plano { get; set; } = string.Empty;
        }

        public class CheckInDto
        {
            public DateTime data { get; set; }
            public string pergunta { get; set; } = string.Empty;
            public string resposta { get; set; } = string.Empty;
        }

        public class RaioXDto
        {
            public string ds_raio_x { get; set; } = string.Empty;
            public string im_raio_x { get; set; } = string.Empty;
            public DateTime dt_data_raio_x { get; set; }

            public AnaliseRaioXDto analise { get; set; } = new();

            public class AnaliseRaioXDto
            {
                public string ds_analise_raio_x { get; set; } = string.Empty;
                public DateTime dt_analise_raio_x { get; set; }
            }
        }

        public class ExtratoPontosDto
        {
            public DateTime dt_extrato { get; set; }
            public string ds_movimentacao { get; set; } = string.Empty;
            public int nr_numero_pontos { get; set; }
        }

        public class DentistaResumoDto
        {
            public string nm_dentista { get; set; } = string.Empty;
            public string ds_cro { get; set; } = string.Empty;
        }
    }
}
