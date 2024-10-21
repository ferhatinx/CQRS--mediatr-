using MediatR;

namespace Cqrs.CQRS.GetById;

public class GetByIdQuery : IRequest<GetByIdQueryResult>
{
    public GetByIdQuery(int id)
    {
        this.Id = id;
    }
    public int Id { get; set; }
}
