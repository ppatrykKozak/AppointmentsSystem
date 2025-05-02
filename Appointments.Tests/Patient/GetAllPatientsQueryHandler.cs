using Appointments.Application.Features.Patient;
using Appointments.Application.Features.Patients;
using Appointments.Domain.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DomainPatient = Appointments.Domain.Entities.Patient;

namespace Appointments.Tests.Patient;

[TestFixture]
public class GetAllPatientsQueryHandlerTests
{
    [Test]
    public async Task Handle_ShouldReturnAllPatients()
    {
        
        var mockRepo = new Mock<IPatientRepository>();
        var expectedPatients = new List<DomainPatient>
        {
            new DomainPatient { FirstName = "Jan", LastName = "Kowalski" },
            new DomainPatient { FirstName = "Anna", LastName = "Nowak" }
        };

        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(expectedPatients);

        var handler = new GetAllPatientsQueryHandler(mockRepo.Object);

        
        var result = await handler.Handle(new GetAllPatientsQuery(), CancellationToken.None);

        Assert.That(result.Count(), Is.EqualTo(2));
        CollectionAssert.AreEquivalent(expectedPatients, result);
    }
}
