using MediatR;
using System;
using DoctorEntity = Appointments.Domain.Entities.Doctor;

namespace Appointments.Application.Features.Doctor;

public class GetDoctorByIdQuery : IRequest<DoctorEntity?>
{
    public Guid Id { get; set; }

    public GetDoctorByIdQuery(Guid id)
    {
        Id = id;
    }
}
