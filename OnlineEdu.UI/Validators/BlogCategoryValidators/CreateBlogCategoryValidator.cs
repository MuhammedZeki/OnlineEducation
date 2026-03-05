using FluentValidation;
using OnlineEdu.UI.DTOs.BlogCategoryDTOs;

namespace OnlineEdu.UI.Validators.BlogCategoryValidators
{
    public class CreateBlogCategoryValidator:AbstractValidator<CreateBlogCategoryDto>
    {
        public CreateBlogCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Kategori ismi maksimum 30 karakter olmak zorunda.");
        }
    }
}
