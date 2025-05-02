using Appointments.Application.Features.Doctor;
using Appointments.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appointments.Tests.Doctor;

[TestFixture]
public class DeleteDoctorCommandHandlerTests
{
    [Test]
    public async Task Handle_ShouldCallDeleteAsyncOnce()
    {
        
        var mockRepo = new Mock<IDoctorRepository>();
        var handler = new DeleteDoctorCommandHandler(mockRepo.Object);
        var doctorId = Guid.NewGuid();

        var command = new DeleteDoctorCommand(doctorId);

        
        await handler.Handle(command, CancellationToken.None);

        
        mockRepo.Verify(r => r.DeleteAsync(doctorId), Times.Once);
    }
}
