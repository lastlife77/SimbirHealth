namespace Timetable.Domain;

public class Timetable
{
    public int Id { get; set; }

    public int HospitalId { get; set; }

    public int DoctorId { get; set; }

    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public int RoomId { get; set; }
}
