using System;
using System.Collections.Generic;

namespace WebApplicationOdontoPrev.ViewModels
{
    public class RaioXAnalisesReportViewModel
    {
        public List<RaioXAnalise> raio_x_analises { get; set; } = new();
        public List<string> nr_cpfs { get; set; } = new();

        public class RaioXAnalise
        {
            public string nm_paciente { get; set; } = string.Empty;
            public string nr_cpf { get; set; } = string.Empty;
            public DateTime dt_data_raio_x { get; set; }
            public string ds_raio_x { get; set; } = string.Empty;
            public DateTime dt_analise_raio_x { get; set; }
            public string ds_analise_raio_x { get; set; } = string.Empty;
            public string nm_plano { get; set; } = string.Empty;
            public int nr_total_raio_x_analisados { get; set; }
            public string ds_descricao_analise { get; set; } = string.Empty;
        }
    }
}
