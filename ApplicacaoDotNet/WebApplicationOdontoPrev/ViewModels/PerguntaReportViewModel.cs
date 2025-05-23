namespace WebApplicationOdontoPrev.ViewModels
{
    public class PerguntaReportViewModel
    {
        public string IdPaciente { get; set; } = string.Empty;
        public string NmPaciente { get; set; } = string.Empty;
        public string NrCpf { get; set; } = string.Empty;
        public DateTime DtCheckIn { get; set; }
        public string DsPergunta { get; set; } = string.Empty;
        public string DsResposta { get; set; } = string.Empty;
    }
}
