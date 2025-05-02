using MediatR;
using Appointments.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Appointments.Application.Features.Doctor;

public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
{
    private readonly IDoctorRepository _repository;

    public DeleteDoctorCommandHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
