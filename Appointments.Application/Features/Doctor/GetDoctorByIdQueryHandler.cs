using MediatR;
using Appointments.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using DoctorEntity = Appointments.Domain.Entities.Doctor;

namespace Appointments.Application.Features.Doctor;

public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, DoctorEntity?>
{
    private readonly IDoctorRepository _repository;

    public GetDoctorByIdQueryHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<DoctorEntity?> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}
