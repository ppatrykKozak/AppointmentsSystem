using Appointments.Domain.Repositories;
using Grpc.Core;
using Appointments.gRPC;
using static Appointments.gRPC.AppointmentService;

namespace Appointments.gRPC.Services;

public class AppointmentGrpcService : AppointmentService.AppointmentServiceBase
{
    private readonly IAppointmentRepository _repository;

    public AppointmentGrpcService(IAppointmentRepository repository)
    {
        _repository = repository;
    }

    public override async Task<AppointmentResponse> GetAppointmentById(AppointmentRequest request, ServerCallContext context)
    {
        var appointment = await _repository.GetByIdAsync(Guid.Parse(request.Id));

        if (appointment == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "Appointment not found"));
        }

        return new AppointmentResponse
        {
            Id = appointment.Id.ToString(),
            Date = appointment.Date.ToString("yyyy-MM-dd HH:mm"),
            Notes = appointment.Notes ?? "",
            PatientFirstName = appointment.Patient?.FirstName ?? "",
            DoctorLastName = appointment.Doctor?.LastName ?? ""
        };
    }
}
