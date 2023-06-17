using AutoMapper;
using RecipeApp.Application.Interfaces;
using RecipeApp.Domain.Interfaces;

namespace RecipeApp.Application.Services
{
    public class Service<TViewModel, TCreateDto, TUpdateDto> : IService<TViewModel, TCreateDto, TUpdateDto> 
        where TViewModel : class, IViewModel
        where TCreateDto : class
        where TUpdateDto : class
    {
        private readonly IRepository<TViewModel> _repository;
        private readonly IMapper _mapper;

        protected Service(IRepository<TViewModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TViewModel?> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<TViewModel?>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TViewModel> AddAsync(TCreateDto entity)
        {
            var viewModel = _mapper.Map<TViewModel>(entity);
            await _repository.AddAsync(viewModel);
            return viewModel;
        }

        public async Task<TViewModel> UpdateAsync(TUpdateDto entity)
        {
            var viewModel = _mapper.Map<TViewModel>(entity);
            await _repository.UpdateAsync(viewModel);
            return viewModel;
        }

        public async Task DeleteAsync(TViewModel entity)
        {
            await _repository.DeleteAsync(entity);
        }
    }
}