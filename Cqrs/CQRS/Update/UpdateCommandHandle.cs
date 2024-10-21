using Cqrs.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.CQRS.Update;

public class UpdateCommandHandle : IRequestHandler<UpdateCommand>
{
    private readonly StudentContext _context;

    public UpdateCommandHandle(StudentContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
         var unchanged = await _context.Students.FirstOrDefaultAsync(x=>x.Id == request.Id);
        unchanged.Number = request.Number;
        unchanged.Name = request.Name;
        unchanged.Age = request.Age;
        await _context.SaveChangesAsync();
        return Unit.Value;
    }

}
