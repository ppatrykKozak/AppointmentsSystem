using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System;

namespace Appointments.Application.Features.Appointment;

public class DeleteAppointmentCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteAppointmentCommand(Guid id)
    {
        Id = id;
    }
}
