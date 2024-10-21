using Cqrs.Data;
using MediatR;

namespace Cqrs.CQRS.Create;

public class CreateCommandHandle : IRequestHandler<CreateCommand>
{
    private readonly StudentContext _context;

    public CreateCommandHandle(StudentContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        
        await _context.Students.AddAsync(new Student{
            Name = request.Name,
            Age = request.Age,
            Number = request.Number,
        });
        await _context.SaveChangesAsync();
        return Unit.Value;
    }

}
