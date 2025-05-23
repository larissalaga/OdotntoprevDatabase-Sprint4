using AutoMapper;
using WebApplicationOdontoPrev.Dtos;
using WebApplicationOdontoPrev.Models;
using static WebApplicationOdontoPrev.ViewModels.GerenciarPacientesViewModel;

namespace WebApplicationOdontoPrev.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Paciente, PacienteDtos>().ReverseMap();
            CreateMap<Dentista, DentistaDtos>().ReverseMap();
        }
    }
}
