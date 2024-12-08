using ActividadUT2.Domain.DTO;
using ActividadUT2.Domain.Entity;
using ActividadUT2.Domain.Generic;
using AutoMapper;

namespace ActividadUT2.Domain.Service;

public class CatService : IEntityService<Guid, CatDTO>
{
    private readonly IEntityRepository<Guid, Cat> _catRepository;
    private readonly IMapper _mapper;

    public CatService(IEntityRepository<Guid, Cat> catRepository, IMapper mapper)
    {
        _catRepository = catRepository;
        _mapper = mapper;
    }

    public ICollection<CatDTO> Get() =>
        _mapper.Map<ICollection<CatDTO>>(_catRepository.Get().ToList());

    public CatDTO Get(Guid id) => _mapper.Map<CatDTO>(_catRepository.Get(id));

    public CatDTO Create(CatDTO entity) =>
        _mapper.Map<CatDTO>(_catRepository.Create(_mapper.Map<Cat>(entity)));

    public CatDTO Update(CatDTO entity) =>
        _mapper.Map<CatDTO>(_catRepository.Update(_mapper.Map<Cat>(entity)));

    public CatDTO Delete(Guid id) => _mapper.Map<CatDTO>(_catRepository.Delete(id));
}