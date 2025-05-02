using MediatR;
using Appointments.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DoctorEntity = Appointments.Domain.Entities.Doctor;

namespace Appointments.Application.Features.Doctor;

public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, IEnumerable<DoctorEntity>>
{
    private readonly IDoctorRepository _repository;

    public GetAllDoctorsQueryHandler(IDoctorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DoctorEntity>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
