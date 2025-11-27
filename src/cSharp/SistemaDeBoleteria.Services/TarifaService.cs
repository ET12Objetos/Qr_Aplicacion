using SistemaDeBoleteria.Core.Interfaces.IServices;
using SistemaDeBoleteria.Core.Interfaces.IRepositories;
using SistemaDeBoleteria.Core.DTOs;
using SistemaDeBoleteria.Core.Models;
using SistemaDeBoleteria.Core.Exceptions;
using Mapster;
using System.Data.SqlTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeBoleteria.Services
{
    public class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository tarifaRepository;
        private readonly IFuncionRepository funcionRepository;
        private readonly IEventoRepository eventoRepository;
        public TarifaService(ITarifaRepository tarifaRepository, IFuncionRepository funcionRepository, IEventoRepository eventoRepository)
        {
            this.tarifaRepository = tarifaRepository;
            this.funcionRepository = funcionRepository;
            this.eventoRepository = eventoRepository;
        }
        public IEnumerable<MostrarTarifaDTO> GetAllByFuncionId(int IdFuncion)
        => tarifaRepository
                .SelectAllByFuncionId(IdFuncion)
                .Adapt<IEnumerable<MostrarTarifaDTO>>();

        public MostrarTarifaDTO? Get(int IdTarifa)
        => tarifaRepository
                .Select(IdTarifa)
                .Adapt<MostrarTarifaDTO>();

        public MostrarTarifaDTO Post(CrearTarifaDTO tarifa)
        {
			if(!funcionRepository.Exists(tarifa.IdFuncion))
				throw new NotFoundException("No se encontró la función especificada.");
            
            return tarifaRepository
                    .Insert(tarifa.Adapt<Tarifa>())
                    .Adapt<MostrarTarifaDTO>();
        }
        public MostrarTarifaDTO Put(ActualizarTarifaDTO tarifa, int IdTarifa)
        {
            if (!tarifaRepository.Exists(IdTarifa))
                throw new NotFoundException("No se encontró la tarifa especificada.");
            if (!tarifaRepository.Update(tarifa.Adapt<Tarifa>(), IdTarifa))
                throw new DataBaseException("No se pudo actualizar la tarifa especificada.");

            return tarifaRepository
                    .Select(IdTarifa)!
                    .Adapt<MostrarTarifaDTO>();
        }
        public void ActivarTarifas(int idEvento)
        {
            if (!eventoRepository.Exists(idEvento))
                throw new NotFoundException("No se encontró el evento especificado.");
            if (!tarifaRepository.ActivarTarifasByIdEvento(idEvento))
                throw new DataBaseException("No se pudieron activar las tarifas del evento especificado.");
        }
    }
}
