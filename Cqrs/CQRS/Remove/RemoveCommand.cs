using MediatR;

namespace Cqrs.CQRS.Remove;

public class RemoveCommand : IRequest
{
    public RemoveCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
