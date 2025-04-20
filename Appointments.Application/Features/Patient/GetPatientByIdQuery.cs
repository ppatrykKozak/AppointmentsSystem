using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientEntity = Appointments.Domain.Entities.Patient;

namespace Appointments.Application.Features.Patient
{

  
    public class GetPatientByIdQuery : IRequest<PatientEntity>
    {
        public Guid Id { get; set; }

        public GetPatientByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
