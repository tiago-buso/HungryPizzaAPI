using AutoMapper;
using Flunt.Notifications;
using HungryPizzaAPI.Models.Dominios;
using HungryPizzaAPI.Models.Persistencias;
using HungryPizzaAPI.Repositories;

namespace HungryPizzaAPI.Services
{
    public class SaboresService : ISaboresService
    {
        private readonly ISaborRepository _saborRepository;
        private readonly IMapper _mapper;

        public SaboresService(ISaborRepository saborRepository, IMapper mapper)
        {
            _saborRepository = saborRepository;
            _mapper = mapper;
        }

        public async Task<List<Sabor>> SelecionarSaboresPorIds(List<int> saboresIds)
        {
            List<SaborPersistencia> saboresPersistencias = await _saborRepository.SelecionarSaboresPorIds(saboresIds);

            ValidarSabores(saboresIds, saboresPersistencias);          
           
            return _mapper.Map<List<Sabor>>(saboresPersistencias);                       
        }

        private void ValidarSabores(List<int> saboresIds, List<SaborPersistencia> saboresPersistencias)
        {
            if (saboresIds == null )
            {
                throw new Exception("Não foi passado pelo menos um sabor corretamente");
            }
            else if (saboresPersistencias == null)
            {
                throw new Exception("Não foi encontrado nenhum sabor no banco");
            }
            else if (saboresIds.Count != saboresPersistencias.Count)
            {
                throw new Exception("O número de sabores passado não bate com os encontrados no banco");
            }
        }
    }
}
