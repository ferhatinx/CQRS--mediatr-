using MediatR;

namespace Cqrs.CQRS.Update;

public class UpdateCommand : IRequest
{
     public int Id { get; set; }

    public string Name { get; set; }
    public int Age { get; set; }
    public int Number { get; set; }
}
