using Appointments.Application.Features.Appointment;
using Appointments.Domain.Entities;
using Appointments.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appointments.Tests.Appointment;

[TestFixture]
public class CreateAppointmentCommandHandlerTests
{
    [Test]
    public async Task Handle_ShouldReturnNewAppointmentId()
    {
       
        var mockRepo = new Mock<IAppointmentRepository>();
        mockRepo.Setup(r => r.IsDoctorAvailableAsync(It.IsAny<Guid>(), It.IsAny<DateTime>()))
                .ReturnsAsync(true);

        var handler = new CreateAppointmentCommandHandler(mockRepo.Object);

        var command = new CreateAppointmentCommand
        {
            PatientId = Guid.NewGuid(),
            DoctorId = Guid.NewGuid(),
            Date = DateTime.UtcNow.AddDays(1),
            Notes = "Test apoitments"
        };

        
        var result = await handler.Handle(command, CancellationToken.None);

       
        Assert.That(result, Is.TypeOf<Guid>());
        Assert.AreNotEqual(Guid.Empty, result);

        mockRepo.Verify(r => r.AddAsync(It.Is<Domain.Entities.Appointment>(a =>
            a.PatientId == command.PatientId &&
            a.DoctorId == command.DoctorId &&
            a.Notes == command.Notes
        )), Times.Once);
    }
}
