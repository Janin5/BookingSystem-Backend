using BookingSystem.Data.InterfacesRepositories;

namespace BookingSystem.Business;

public class AvailabilityService
{
    private readonly IStylistRepository _stylistRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IProcedureRepository _procedureRepository;

    private static readonly TimeSpan SlotStep = TimeSpan.FromMinutes(30);

    public AvailabilityService(IStylistRepository stylistRepository, IAppointmentRepository appointmentRepository, IProcedureRepository procedureRepository)
    {
        _stylistRepository = stylistRepository;
        _appointmentRepository = appointmentRepository;
        _procedureRepository = procedureRepository;
    }

    public async Task<List<TimeOnly>> GetFreeSlots(Guid stylistId, DateOnly date, Guid procedureId)
    {
        var freeSlots = new List<TimeOnly>();

        var schedule = await _stylistRepository.GetScheduleAsync(stylistId, date.DayOfWeek);
        if (schedule is null)
        {
            return freeSlots;
        }

        var procedure = await _procedureRepository.GetByIdAsync(procedureId);
        if (procedure is null)
        {
            return freeSlots;
        }
        var duration = procedure.Duration;

        var activeAppointments = await _appointmentRepository.GetConfirmedAppointmentsByDateAsync(stylistId, date);

        var today = DateOnly.FromDateTime(DateTime.Now);
        var now = TimeOnly.FromDateTime(DateTime.Now);

        var slotStart = schedule.Start;
        while (slotStart.Add(duration) <= schedule.End)
        {
            var slotEnd = slotStart.Add(duration);

            bool overlaps = activeAppointments.Any(a =>
            {
                var appointmentStart = TimeOnly.FromDateTime(a.AppointmentDate);
                var appointmentEnd = appointmentStart.Add(a.Procedure.Duration);
                return slotStart < appointmentEnd && slotEnd > appointmentStart;
            });

            bool inThePast = (date == today) && (slotStart <= now);

            if (!overlaps && !inThePast)
            {
                freeSlots.Add(slotStart);
            }

            slotStart = slotStart.Add(SlotStep);
        }

        return freeSlots;
    }
}
