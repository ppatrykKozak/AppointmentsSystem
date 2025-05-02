using MediatR;
using Appointments.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AppointmentEntity = Appointments.Domain.Entities.Appointment;

namespace Appointments.Application.Features.Appointment;

public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, IEnumerable<AppointmentEntity>>
{
    private readonly IAppointmentRepository _repository;

    public GetAllAppointmentsQueryHandler(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AppointmentEntity>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
