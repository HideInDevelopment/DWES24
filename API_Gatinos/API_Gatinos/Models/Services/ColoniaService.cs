using API_Gatinos.Models.DTOs;
using API_Gatinos.Models.Entities;
using API_Gatinos.Models.Repositories.Interfaces;
using AutoMapper;

namespace API_Gatinos.Models.Services;

public class ColoniaService : IEntityService<Guid, ColoniaDTO>
{
    private readonly IEntityRepository<Guid, Colonia> _coloniaRepository;
    private readonly IMapper _mapper;

    public ColoniaService(IEntityRepository<Guid, Colonia> coloniaRepository, IMapper mapper)
    {
        _coloniaRepository = coloniaRepository;
        _mapper = mapper;
    }

    public ICollection<ColoniaDTO> Get() =>
        _mapper.Map<ICollection<ColoniaDTO>>(_coloniaRepository.Get().ToList());

    public ColoniaDTO Get(Guid id) => _mapper.Map<ColoniaDTO>(_coloniaRepository.Get(id));

    public ColoniaDTO Create(ColoniaDTO entity) =>
        _mapper.Map<ColoniaDTO>(_coloniaRepository.Create(_mapper.Map<Colonia>(entity)));

    public ColoniaDTO Update(ColoniaDTO entity) =>
        _mapper.Map<ColoniaDTO>(_coloniaRepository.Update(_mapper.Map<Colonia>(entity)));

    public ColoniaDTO Delete(Guid id) => _mapper.Map<ColoniaDTO>(_coloniaRepository.Delete(id));
}
