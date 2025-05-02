using MediatR;
using Appointments.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Appointments.Application.Features.Appointment;

public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, bool>
{
    private readonly IAppointmentRepository _repository;

    public DeleteAppointmentCommandHandler(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _repository.GetByIdAsync(request.Id);
        if (appointment == null)
            return false;

        await _repository.DeleteAsync(request.Id);
        return true;
    }
}
