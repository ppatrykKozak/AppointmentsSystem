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
public class UpdateDoctorCommandHandlerTests
{
    [Test]
    public async Task Handle_ShouldUpdateDoctorFields()
    {
        
        var existingDoctor = new DomainDoctor
        {
            Id = Guid.NewGuid(),
            FirstName = "Old",
            LastName = "Name",
            Specialty = "OldSpecialty"
        };

        var mockRepo = new Mock<IDoctorRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(existingDoctor.Id))
                .ReturnsAsync(existingDoctor);

        var handler = new UpdateDoctorCommandHandler(mockRepo.Object);

        var command = new UpdateDoctorCommand
        {
            Id = existingDoctor.Id,
            FirstName = "New",
            LastName = "Doctor",
            Specialty = "NewSpecialty"
        };

       
        await handler.Handle(command, CancellationToken.None);

        
        Assert.That(existingDoctor.FirstName, Is.EqualTo("New"));
        Assert.That(existingDoctor.LastName, Is.EqualTo("Doctor"));
        Assert.That(existingDoctor.Specialty, Is.EqualTo("NewSpecialty"));

        mockRepo.Verify(r => r.UpdateAsync(existingDoctor), Times.Once);
    }
}
