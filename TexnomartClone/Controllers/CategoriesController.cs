using Microsoft.AspNetCore.Mvc;
using TexnomartClone.Application.Interfaces;

namespace TexnomartClone.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

}
