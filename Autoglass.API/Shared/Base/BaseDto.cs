using AutoMapper;

namespace Autoglass.API.Shared.Base;

public abstract class BaseDto<TDto, TEntity>
    where TDto : class
    where TEntity : class
{
    protected IMapper _mapper;

    public BaseDto()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TDto, TEntity>().ReverseMap();
        });

        _mapper = config.CreateMapper();
    }

    public TDto MapToDto(TEntity entity)
    {
        return _mapper.Map<TDto>(entity);
    }

    public TEntity MapToEntity(TDto dto)
    {
        return _mapper.Map<TEntity>(dto);
    }
}