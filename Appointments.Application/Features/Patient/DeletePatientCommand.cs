using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Application.Features.Patient
{

    public class DeletePatientCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeletePatientCommand(Guid id)
        {
            Id = id;
        }
    }
}
