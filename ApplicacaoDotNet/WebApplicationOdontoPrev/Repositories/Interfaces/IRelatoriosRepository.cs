using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.ViewModels;

namespace WebApplicationOdontoPrev.Repositories.Interfaces
{
    public interface IRelatoriosRepository
    {
        /// <summary>
        /// Retorna o hist�rico de perguntas e respostas de um paciente a partir do CPF.
        /// </summary>
        /// <param name="cpf">CPF do paciente</param>
        Task<List<PerguntaReportDtos>> GetHistoricoRespostas(string cpf);

        /// <summary>
        /// Retorna as an�lises de raio-x feitas para um paciente a partir do CPF.
        /// </summary>
        /// <param name="cpf">CPF do paciente</param>
        Task<List<RaioXAnalisesReportViewModel.RaioXAnalise>> GetRaioXAnalises(string cpf);
    }
}
