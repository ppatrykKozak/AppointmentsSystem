using Appointments.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Appointments.Application.Features.Patient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
    {
        private readonly IPatientRepository _repository;

        public CreatePatientCommandHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Appointments.Domain.Entities.Patient
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            await _repository.AddAsync(patient);

            return patient.Id;
        }
    }
}
