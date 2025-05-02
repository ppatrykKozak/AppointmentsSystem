using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System;

namespace Appointments.Application.Features.Doctor;

public class DeleteDoctorCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteDoctorCommand(Guid id)
    {
        Id = id;
    }
}
