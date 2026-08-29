namespace BookingSystem.Shared.Filters;

public class ProcedureFilter
{
    public Guid? SalonId { get; set; }
   // public int? Price { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;

}
