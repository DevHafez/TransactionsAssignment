using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TransactionsAssignment.Domain.Entities;
using TransactionsAssignment.Persistence;

namespace TransactionsAssignment.Service.Features.CategoryFeatures.Commands
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public List<Category>  RequestedList { get; set; }
       
        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateCategoryCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                List<Category> categoriesList = new List<Category>();
                foreach (var item in request.RequestedList)
                {
                    Category category = new Category();
                    category.CategoryName = item.CategoryName;
                    category.Description = item.Description;
                    categoriesList.Add(category);
                }

                _context.Categories.AddRange(categoriesList);
                await _context.SaveChangesAsync();
                return categoriesList.Count;
            }
        }
    }
}
