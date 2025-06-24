public class ServiceTypeService
{
    private readonly List<ServiceType> serviceTypes = [];

    public ServiceTypeService()
    {
        SeedServices();
    }

    public List<ServiceType> GetAll() => serviceTypes;

    public ServiceType? GetById(int id) =>
        serviceTypes.FirstOrDefault(s => s.Id == id);

    public void Add(ServiceType service)
    {
        int maxId = serviceTypes.Count > 0 ? serviceTypes.Max(s => s.Id) : 0;
        service.Id = maxId + 1;
        serviceTypes.Add(service);
    }

    public void Delete(string name)
    {
        var service = serviceTypes.FirstOrDefault(s => s.Name == name);
        if (service != null)
        {
            serviceTypes.Remove(service);
        }
    }

    private void SeedServices()
    {
        string[] defaultNames = [
            "Window Cleaning",
            "Lawn Mowing",
            "Dog Walking",
            "Pool Maintenance",
            "Housekeeping"
        ];

        for (int i = 0; i < defaultNames.Length; i++)
        {
            serviceTypes.Add(new ServiceType
            {
                Id = i + 1,
                Name = defaultNames[i]
            });
        }
    }
}
