using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using System.Collections.Generic;
using DoctorEntity = Appointments.Domain.Entities.Doctor;

namespace Appointments.Application.Features.Doctor;

public class GetAllDoctorsQuery : IRequest<IEnumerable<DoctorEntity>>
{
}