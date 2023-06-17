using AutoMapper;
using RecipeApp.Application.Interfaces;
using RecipeApp.Application.ViewModel.CategoryViewModel;
using RecipeApp.Domain.Entities;
using RecipeApp.Domain.Interfaces;

namespace RecipeApp.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryViewModel?> GetAsync(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id);
            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task<IEnumerable<CategoryViewModel?>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }

        public async Task<CategoryViewModel> AddAsync(CreateCategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            await _categoryRepository.AddAsync(category);
            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task<CategoryViewModel> UpdateAsync(UpdateCategoryViewModel categoryViewModel)
        {
            var category = await _categoryRepository.GetAsync(categoryViewModel.Id);

            if (category == null)
            {
                throw new InvalidOperationException("Category not found");
            }

            _mapper.Map(categoryViewModel, category);
            await _categoryRepository.UpdateAsync(category);
            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task DeleteAsync(CategoryViewModel categoryViewModel)
        {
            var category = await _categoryRepository.GetAsync(categoryViewModel.Id);

            if (category == null)
            {
                throw new InvalidOperationException("Category not found");
            }

            await _categoryRepository.DeleteAsync(category);
        }
    }
}
