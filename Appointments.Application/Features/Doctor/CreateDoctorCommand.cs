using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System;

namespace Appointments.Application.Features.Doctor;

public class CreateDoctorCommand : IRequest<Guid>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Specialty { get; set; } = null!;
}