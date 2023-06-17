namespace RecipeApp.Application.Interfaces
{
    public interface IService<TViewModel, TCreateDto, TUpdateDto> 
    {
        Task<TViewModel?> GetAsync(Guid id);
        Task<IEnumerable<TViewModel?>> GetAllAsync();
        Task<TViewModel> AddAsync(TCreateDto entity);
        Task<TViewModel> UpdateAsync(TUpdateDto entity);
        Task DeleteAsync(TViewModel entity);
    }
    
        public interface IViewModelService<TViewModel> where TViewModel : IViewModel
    {
        Task<TViewModel?> GetAsync(Guid id);
        Task<IEnumerable<TViewModel?>> GetAllAsync();
        Task DeleteAsync(TViewModel entity);
    }
}