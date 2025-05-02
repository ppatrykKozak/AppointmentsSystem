using MediatR;
using Appointments.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using DoctorEntity = Appointments.Domain.Entities.Doctor;

namespace Appointments.Application.Features.Doctor;

public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand>
{
    private readonly IDoctorRepository _repository;

    public UpdateDoctorCommandHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = await _repository.GetByIdAsync(request.Id);
        if (doctor is null)
            return Unit.Value; 

        doctor.FirstName = request.FirstName;
        doctor.LastName = request.LastName;
        doctor.Specialty = request.Specialty;

        await _repository.UpdateAsync(doctor);
        return Unit.Value;
    }
}
