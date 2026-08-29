
using BookingSystem.Shared.Enums;
using BookingSystem.Data.InterfacesRepositories;

namespace BookingSystem.Business;

public class AppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    public AppointmentService(IAppointmentRepository appointmentRepository) {
        _appointmentRepository = appointmentRepository;         
     }
    public async Task ChangeAppointmentStatus(Guid appointmentId, Status newStatus)
    {
        var app = await _appointmentRepository.GetById(appointmentId);
       if(app is null)
        {
            throw new Exception("Appointment was not found!");
        }

       if(app.Status != Status.Pending)
        {
            return;
        }

        app.Status = newStatus;
        await _appointmentRepository.SaveChangesAsync();

    }
}
