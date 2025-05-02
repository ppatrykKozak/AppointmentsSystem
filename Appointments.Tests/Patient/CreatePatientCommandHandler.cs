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
public class CreatePatientCommandHandlerTests
{
    [Test]
    public async Task Handle_ShouldReturnNewPatientId()
    {
        // Arrange
        var repositoryMock = new Mock<IPatientRepository>();
        var handler = new CreatePatientCommandHandler(repositoryMock.Object);

        var command = new CreatePatientCommand
        {
            FirstName = "Test",
            LastName = "Patient"
        };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.That(result, Is.TypeOf<Guid>());
        Assert.AreNotEqual(Guid.Empty, result);

        repositoryMock.Verify(r => r.AddAsync(It.Is<DomainPatient>(p =>
            p.FirstName == command.FirstName && p.LastName == command.LastName
        )), Times.Once);
    }
}
