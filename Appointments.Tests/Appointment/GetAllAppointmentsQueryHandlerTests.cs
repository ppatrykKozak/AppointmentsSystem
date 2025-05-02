using Appointments.Application.Features.Appointment;
using Appointments.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DomainAppointment = Appointments.Domain.Entities.Appointment;

namespace Appointments.Tests.Appointment;

[TestFixture]
public class GetAllAppointmentsQueryHandlerTests
{
    [Test]
    public async Task Handle_ShouldReturnAllAppointments()
    {
        // Arrange
        var appointments = new List<DomainAppointment>
        {
            new DomainAppointment { Id = Guid.NewGuid(), Notes = "Appoitment 1" },
            new DomainAppointment { Id = Guid.NewGuid(), Notes = "Appoitment 2" }
        };

        var mockRepo = new Mock<IAppointmentRepository>();
        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(appointments);

        var handler = new GetAllAppointmentsQueryHandler(mockRepo.Object);

        // Act
        var result = await handler.Handle(new GetAllAppointmentsQuery(), CancellationToken.None);

        // Assert
        Assert.That(result, Is.EqualTo(appointments));
    }
}
