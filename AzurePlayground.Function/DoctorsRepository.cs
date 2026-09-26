namespace AzurePlayground.Function;

public class DoctorsRepository
{
    private List<DoctorModel> Doctors =
    [
        new(1, "Dr. John Smith", "Cardiology"),
        new(2, "Dr. Emily Johnson", "Dermatology"),
        new(3, "Dr. Michael Brown", "Neurology"),
        new(4, "Dr. Sarah Davis", "Pediatrics"),
        new(5, "Dr. David Wilson", "Orthopedics")
    ];

    public List<DoctorModel> GetDoctors(int limit)
    {
        return Doctors.Take(limit).ToList();
    }
}
