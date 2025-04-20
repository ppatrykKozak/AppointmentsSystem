using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointments.Domain.Entities;
using Appointments.Domain.Repositories;
using MediatR;
using PatientEntity = Appointments.Domain.Entities.Patient;

namespace Appointments.Application.Features.Patients;

public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, IEnumerable<PatientEntity>>
{
    private readonly IPatientRepository _repository;

    public GetAllPatientsQueryHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PatientEntity>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
