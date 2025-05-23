using WebApplicationOdontoPrev.Models;
using System.Collections.Generic;

namespace WebApplicationOdontoPrev.ViewModels
{
    public class GerenciarPacientesViewModel
    {
        public class PacienteDados
        {
            public Paciente Paciente { get; set; } = new Paciente();

            public Plano Plano { get; set; } = new Plano();

            public List<Dentista> Dentistas { get; set; } = new List<Dentista>();
        }

        public List<PacienteDados> Pacientes { get; set; } = new List<PacienteDados>();
    }
}
