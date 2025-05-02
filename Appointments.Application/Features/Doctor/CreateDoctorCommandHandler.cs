using MediatR;
using Appointments.Domain.Entities;
using Appointments.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using DoctorEntity = Appointments.Domain.Entities.Doctor;

namespace Appointments.Application.Features.Doctor;

public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Guid>
{
    private readonly IDoctorRepository _repository;

    public CreateDoctorCommandHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = new DoctorEntity
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Specialty = request.Specialty
        };

        await _repository.AddAsync(doctor);
        return doctor.Id;
    }
}
