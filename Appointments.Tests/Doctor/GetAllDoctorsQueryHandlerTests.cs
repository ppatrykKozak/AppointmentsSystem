using Appointments.Application.Features.Doctor;
using Appointments.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DomainDoctor = Appointments.Domain.Entities.Doctor;

namespace Appointments.Tests.Doctor;

[TestFixture]
public class GetAllDoctorsQueryHandlerTests
{
    [Test]
    public async Task Handle_ShouldReturnAllDoctors()
    {
       
        var doctors = new List<DomainDoctor>
        {
            new DomainDoctor { Id = Guid.NewGuid(), FirstName = "Anna", LastName = "Nowak", Specialty = "Dermatolog" },
            new DomainDoctor { Id = Guid.NewGuid(), FirstName = "Piotr", LastName = "Zieliński", Specialty = "Neurolog" }
        };

        var mockRepo = new Mock<IDoctorRepository>();
        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(doctors);

        var handler = new GetAllDoctorsQueryHandler(mockRepo.Object);

       
        var result = await handler.Handle(new GetAllDoctorsQuery(), CancellationToken.None);

       
        Assert.That(result, Is.EqualTo(doctors));
    }
}
