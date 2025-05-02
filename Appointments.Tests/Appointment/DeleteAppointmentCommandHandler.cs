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
public class DeleteAppointmentCommandHandlerTests
{
    [Test]
    public async Task Handle_ShouldCallDeleteAsyncOnce()
    {
        var mockRepo = new Mock<IAppointmentRepository>();
        var id = Guid.NewGuid();

        mockRepo.Setup(r => r.GetByIdAsync(id))
                .ReturnsAsync(new AppointmentEntity { Id = id });

        var handler = new DeleteAppointmentCommandHandler(mockRepo.Object);
        var command = new DeleteAppointmentCommand(id);

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.That(result, Is.True);
        mockRepo.Verify(r => r.DeleteAsync(id), Times.Once);
    }
}
