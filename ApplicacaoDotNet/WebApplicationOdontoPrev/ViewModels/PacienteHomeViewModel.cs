namespace WebApplicationOdontoPrev.ViewModels
{
    public class PacienteHomeViewModel
    {
        public string id { get; set; } = string.Empty;
        public string nm_paciente { get; set; } = string.Empty;
        public string nr_cpf { get; set; } = string.Empty;
        public string nm_plano { get; set; } = string.Empty;
        public int total_pontos { get; set; }
    }
}
