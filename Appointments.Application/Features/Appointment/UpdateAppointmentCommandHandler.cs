using MediatR;
using Appointments.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using AppointmentEntity = Appointments.Domain.Entities.Appointment;

namespace Appointments.Application.Features.Appointment;

public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, bool> 
{
    private readonly IAppointmentRepository _repository;

    public UpdateAppointmentCommandHandler(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var appointment = await _repository.GetByIdAsync(request.Id);
        if (appointment == null)
            return false;

        appointment.PatientId = request.PatientId;
        appointment.DoctorId = request.DoctorId;
        appointment.Date = request.Date;
        appointment.Notes = request.Notes;

        await _repository.UpdateAsync(appointment);
        return true;
    }
}
