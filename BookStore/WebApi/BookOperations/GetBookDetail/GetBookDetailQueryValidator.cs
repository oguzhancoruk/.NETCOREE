using FluentValidation;
namespace WebApi.BookOperations.GetBooksDetail
{
    public class GetbooksDetailQueryValidator:AbstractValidator<GetbooksDetailQuery>
    {
      public  GetbooksDetailQueryValidator()
      {
RuleFor(query=> query.BookId ).GreaterThan(0);
      }
    }
}