using MediatR;
using Appointments.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using AppointmentEntity = Appointments.Domain.Entities.Appointment;

namespace Appointments.Application.Features.Appointment;

public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, AppointmentEntity?>
{
    private readonly IAppointmentRepository _repository;

    public GetAppointmentByIdQueryHandler(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<AppointmentEntity?> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}
