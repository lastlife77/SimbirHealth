namespace Document.Domain;

public class History
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int PatientId { get; set; }

    public int HospitalId { get; set; }

    public int DoctorId { get; set; }

    public int RoomId { get; set; }

    public string Data { get; set; }

}
