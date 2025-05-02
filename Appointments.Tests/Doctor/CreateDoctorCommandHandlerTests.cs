using Appointments.Application.Features.Doctor;
using Appointments.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using DomainDoctor = Appointments.Domain.Entities.Doctor;

namespace Appointments.Tests.Doctor;

[TestFixture]
public class CreateDoctorCommandHandlerTests
{
    [Test]
    public async Task Handle_ShouldReturnNewDoctorId()
    {
        
        var mockRepo = new Mock<IDoctorRepository>();
        var handler = new CreateDoctorCommandHandler(mockRepo.Object);

        var command = new CreateDoctorCommand
        {
            FirstName = "Jan",
            LastName = "Kowalski",
            Specialty = "Kardiolog"
        };

     
        var result = await handler.Handle(command, CancellationToken.None);

        
        Assert.That(result, Is.TypeOf<Guid>());
        Assert.AreNotEqual(Guid.Empty, result);

        mockRepo.Verify(r => r.AddAsync(It.Is<DomainDoctor>(d =>
            d.FirstName == command.FirstName &&
            d.LastName == command.LastName &&
            d.Specialty == command.Specialty
        )), Times.Once);
    }
}
