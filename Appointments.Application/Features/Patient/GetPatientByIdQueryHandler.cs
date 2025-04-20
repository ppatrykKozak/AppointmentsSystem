using MediatR;
using Appointments.Domain.Entities;
using Appointments.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using PatientEntity = Appointments.Domain.Entities.Patient;


namespace Appointments.Application.Features.Patient;

public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientEntity?>
{
    private readonly IPatientRepository _repository;

    public GetPatientByIdQueryHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<PatientEntity?> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}
