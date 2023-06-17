using AutoMapper;
using RecipeApp.API.Models.Update;
using RecipeApp.Application.ViewModel;
using RecipeApp.Application.ViewModel.CategoryViewModel;
using RecipeApp.Application.ViewModel.IngredientViewModel;
using RecipeApp.Application.ViewModel.RecipeViewModel;
using RecipeApp.Domain.Entities;

namespace RecipeApp.API.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryViewModel>();
        CreateMap<CategoryViewModel, Category>();
        CreateMap<UpdateCategoryViewModel, Category>();
        CreateMap<Category, UpdateCategoryViewModel>();
        CreateMap<CreateCategoryViewModel, Category>();
        CreateMap<Category, CreateCategoryViewModel>();
        CreateMap<UpdateCategoryViewModel, CategoryViewModel>();
        CreateMap<CategoryViewModel, UpdateCategoryViewModel>();
        CreateMap<CreateCategoryViewModel, CategoryViewModel>();
        CreateMap<CategoryViewModel, CreateCategoryViewModel>();
        CreateMap<UpdateCategoryViewModel, Category>();
        CreateMap<UpdateCategoryViewModel, UpdateCategoryModel>();
        CreateMap<UpdateCategoryModel, UpdateCategoryViewModel>();

        CreateMap<Ingredient, IngredientViewModel>();
        CreateMap<IngredientViewModel, Ingredient>();
        CreateMap<UpdateIngredientViewModel, Ingredient>();
        CreateMap<Ingredient, UpdateIngredientViewModel>();
        CreateMap<CreateIngredientViewModel, Ingredient>();
        CreateMap<Ingredient, CreateIngredientViewModel>();
        CreateMap<UpdateIngredientViewModel, IngredientViewModel>();
        CreateMap<IngredientViewModel, UpdateIngredientViewModel>();
        CreateMap<CreateIngredientViewModel, IngredientViewModel>();
        CreateMap<IngredientViewModel, CreateIngredientViewModel>();
        CreateMap<UpdateIngredientViewModel, UpdateIngredientModel>();
        CreateMap<UpdateIngredientModel, UpdateIngredientViewModel>();
        
        CreateMap<Recipe, RecipeViewModel>();
        CreateMap<RecipeViewModel, Recipe>();
        CreateMap<UpdateRecipeViewModel, Recipe>();
        CreateMap<Recipe, UpdateRecipeViewModel>();
        CreateMap<CreateRecipeViewModel, Recipe>();
        CreateMap<Recipe, CreateRecipeViewModel>();
        CreateMap<UpdateRecipeViewModel, RecipeViewModel>();
        CreateMap<RecipeViewModel, UpdateRecipeViewModel>();
        CreateMap<CreateRecipeViewModel, RecipeViewModel>();
        CreateMap<RecipeViewModel, CreateRecipeViewModel>();
        CreateMap<UpdateRecipeViewModel, UpdateRecipeModel>();
        CreateMap<UpdateRecipeModel, UpdateRecipeViewModel>();
    }
}