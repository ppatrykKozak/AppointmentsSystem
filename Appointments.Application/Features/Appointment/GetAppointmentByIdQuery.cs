using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System;
using AppointmentEntity = Appointments.Domain.Entities.Appointment;

namespace Appointments.Application.Features.Appointment;

public class GetAppointmentByIdQuery : IRequest<AppointmentEntity?>
{
    public Guid Id { get; set; }

    public GetAppointmentByIdQuery(Guid id)
    {
        Id = id;
    }
}