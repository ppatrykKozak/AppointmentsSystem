using Appointments.Application.Features.Patient;
using Appointments.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Appointments.Tests.Patient;

[TestFixture]
public class DeletePatientCommandHandlerTests
{
    [Test]
    public async Task Handle_ShouldCallDeleteAsyncOnce()
    {
       
        var mockRepo = new Mock<IPatientRepository>();
        var handler = new DeletePatientCommandHandler(mockRepo.Object);
        var patientId = Guid.NewGuid();

        var command = new DeletePatientCommand(patientId);

        
        await handler.Handle(command, CancellationToken.None);

      
        mockRepo.Verify(r => r.DeleteAsync(patientId), Times.Once);
    }
}
