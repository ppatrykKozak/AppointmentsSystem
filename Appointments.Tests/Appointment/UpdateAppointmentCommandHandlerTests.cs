using Appointments.Application.Features.Appointment;
using Appointments.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using AppointmentEntity = Appointments.Domain.Entities.Appointment;

namespace Appointments.Tests.Appointment;

[TestFixture]
public class UpdateAppointmentCommandHandlerTests
{
    [Test]
    public async Task Handle_ShouldUpdateAppointment()
    {
        
        var appointmentId = Guid.NewGuid();
        var existingAppointment = new AppointmentEntity
        {
            Id = appointmentId,
            PatientId = Guid.NewGuid(),
            DoctorId = Guid.NewGuid(),
            Date = DateTime.UtcNow.AddDays(-1),
            Notes = "Old notes"
        };

        var mockRepo = new Mock<IAppointmentRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(appointmentId))
                .ReturnsAsync(existingAppointment);

        var handler = new UpdateAppointmentCommandHandler(mockRepo.Object);

        var command = new UpdateAppointmentCommand
        {
            Id = appointmentId,
            PatientId = Guid.NewGuid(),
            DoctorId = Guid.NewGuid(),
            Date = DateTime.UtcNow.AddDays(1),
            Notes = "Updated notes"
        };

        
        var result = await handler.Handle(command, CancellationToken.None);

        
        Assert.That(result, Is.EqualTo(true));

        mockRepo.Verify(r => r.UpdateAsync(It.Is<AppointmentEntity>(a =>
            a.Id == appointmentId &&
            a.PatientId == command.PatientId &&
            a.DoctorId == command.DoctorId &&
            a.Date == command.Date &&
            a.Notes == command.Notes
        )), Times.Once);
    }
}
