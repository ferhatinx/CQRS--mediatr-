using Cqrs.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.CQRS.GetById;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdQueryResult>
{
    private readonly StudentContext _context;

    public GetByIdQueryHandler(StudentContext context)
    {
        _context = context;
    }


    public async Task<GetByIdQueryResult> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        
        var data =await _context.Students.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (data != null)
        {
            return new GetByIdQueryResult
            {
                Age = data.Age,
                Name = data.Name,
                Number = data.Number,
            };
        }
        return null;
    }
    // public GetByIdQueryResult Handle(GetByIdQuery query)
    // {
    //     var data = _context.Students.FirstOrDefault(x => x.Id == query.Id);
    //     if (data != null)
    //     {
    //         return new GetByIdQueryResult
    //         {
    //             Age = data.Age,
    //             Name = data.Name,
    //             Number = data.Number,
    //         };
    //     }
    //     return null;

    // }
}
