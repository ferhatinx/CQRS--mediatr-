using MediatR;

namespace Cqrs.CQRS.Create;

public class CreateCommand : IRequest
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Number { get; set; }
}
