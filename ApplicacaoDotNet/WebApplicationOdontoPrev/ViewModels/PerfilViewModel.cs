namespace WebApplicationOdontoPrev.ViewModels
{
    public class PerfilViewModel
    {
        public string IdPaciente { get; set; } = string.Empty;
        public string NmPaciente { get; set; } = string.Empty;
        public string NrCpf { get; set; } = string.Empty;
        public string NmPlano { get; set; } = string.Empty;
        public DateTime DtNascimento { get; set; }
        public string DsSexo { get; set; } = string.Empty;
        public string NrTelefone { get; set; } = string.Empty;
        public string DsEmail { get; set; } = string.Empty;
    }
}
