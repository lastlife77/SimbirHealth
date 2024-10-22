namespace TimeTable.Domain;

public class Appointment
{
    public int Id { get; set; }

    public DateTime Time { get; set; }

    public int TimeTableId { get; set; }

    public int? UserId { get; set; }
}
