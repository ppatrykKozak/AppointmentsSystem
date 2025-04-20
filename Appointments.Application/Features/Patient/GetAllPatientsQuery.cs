using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointments.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using PatientEntity = Appointments.Domain.Entities.Patient;

namespace Appointments.Application.Features.Patients;

public class GetAllPatientsQuery : IRequest<IEnumerable<PatientEntity>>
{
}