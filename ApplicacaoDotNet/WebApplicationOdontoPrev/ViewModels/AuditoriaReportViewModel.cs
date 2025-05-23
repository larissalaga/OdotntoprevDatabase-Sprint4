namespace WebApplicationOdontoPrev.ViewModels
{
    public class AuditoriaReportViewModel
    {
        public List<AuditoriaItem> Auditorias { get; set; } = new List<AuditoriaItem>();
        public List<string> Tabelas { get; set; } = new List<string>();
        public List<string> Operacoes { get; set; } = new List<string>();
        public List<string> Usuarios { get; set; } = new List<string>();
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public class AuditoriaItem
        {
            public string IdAuditoria { get; set; } = string.Empty;
            public string NmTabela { get; set; } = string.Empty;
            public string DsOperacao { get; set; } = string.Empty;
            public DateTime DtOperacao { get; set; }
            public string IdUsuario { get; set; } = string.Empty;
            public string NmValoresAnteriores { get; set; } = string.Empty;
        }
    }
}
