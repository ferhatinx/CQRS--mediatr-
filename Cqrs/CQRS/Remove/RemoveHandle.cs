using Cqrs.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.CQRS.Remove;

public class RemoveHandle : IRequestHandler<RemoveCommand>
{
    private readonly StudentContext _context;

    public RemoveHandle(StudentContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(RemoveCommand request, CancellationToken cancellationToken)
    {
         var deletedEntitiy =await _context.Students.FirstOrDefaultAsync(x=>x.Id ==request.Id);
        _context.Students.Remove(deletedEntitiy);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }

}
