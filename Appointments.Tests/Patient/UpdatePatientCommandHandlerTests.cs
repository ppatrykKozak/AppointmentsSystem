using Appointments.Application.Features.Patient;
using Appointments.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using DomainPatient = Appointments.Domain.Entities.Patient;

namespace Appointments.Tests.Patient;

[TestFixture]
public class UpdatePatientCommandHandlerTests
{
    [Test]
    public async Task Handle_ShouldUpdateExistingPatient()
    {
       
        var mockRepo = new Mock<IPatientRepository>();
        var existingPatient = new DomainPatient
        {
            Id = Guid.NewGuid(),
            FirstName = "Old",
            LastName = "Name"
        };

        mockRepo.Setup(r => r.GetByIdAsync(existingPatient.Id))
                .ReturnsAsync(existingPatient);

        var handler = new UpdatePatientCommandHandler(mockRepo.Object);

        var command = new UpdatePatientCommand
        {
            Id = existingPatient.Id,
            FirstName = "New",
            LastName = "Surname"
        };

        
        await handler.Handle(command, CancellationToken.None);

        
        Assert.That(existingPatient.FirstName, Is.EqualTo("New"));
        Assert.That(existingPatient.LastName, Is.EqualTo("Surname"));
        mockRepo.Verify(r => r.UpdateAsync(existingPatient), Times.Once);
    }
}
