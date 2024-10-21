using MediatR;

namespace Cqrs.CQRS.GetAll;

public class GetAllQuery : IRequest<List<GetAllQueryResult>>
{

}
