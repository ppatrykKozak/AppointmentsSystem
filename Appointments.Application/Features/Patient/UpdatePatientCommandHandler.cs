using MediatR;
using Appointments.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using PatientEntity = Appointments.Domain.Entities.Patient;

namespace Appointments.Application.Features.Patient;

public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand>
{
    private readonly IPatientRepository _repository;

    public UpdatePatientCommandHandler(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(request.Id);
        if (existing is null)
            return Unit.Value; 

        existing.FirstName = request.FirstName;
        existing.LastName = request.LastName;

        await _repository.UpdateAsync(existing);
        return Unit.Value;
    }
}
