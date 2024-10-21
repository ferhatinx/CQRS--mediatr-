using Cqrs.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.CQRS.GetAll;

public class GetAllQueryHandle : IRequestHandler<GetAllQuery,List<GetAllQueryResult>>
{
    private readonly StudentContext _context;

    public GetAllQueryHandle(StudentContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllQueryResult>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
       return await _context.Students.Select(x=>new GetAllQueryResult{
            Id = x.Id,
            Age = x.Age, 
            Name = x.Name, 
            Number = x.Number}).AsNoTracking().ToListAsync();
    }
    // public List<GetAllQueryResult> Handle(GetAllQuery query)
    // {
    //    return _context.Students.Select(x=>new GetAllQueryResult{
    //         Id = x.Id,
    //         Age = x.Age, 
    //         Name = x.Name, 
    //         Number = x.Number}).AsNoTracking().ToList();

    // }



}
