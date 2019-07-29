using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;

namespace AbpWcfDemo {
    /// <summary>
    /// Derive your application services with crud from this class.
    /// </summary>
    public abstract class WcfAppServiceBaseWithCrud<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey> {

        protected WcfAppServiceBaseWithCrud(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository) {
            LocalizationSourceName = WcfConsts.LocalizationSourceName;
        }

    }
}