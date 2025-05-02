using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;
using AppointmentEntity = Appointments.Domain.Entities.Appointment;

namespace Appointments.Application.Features.Appointment;

public class GetAllAppointmentsQuery : IRequest<IEnumerable<AppointmentEntity>>
{
}