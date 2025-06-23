public class CustomerService
{
    private readonly List<Customer> customers = [];

    public CustomerService()
    {
        SeedCustomers();
    }

    public List<Customer> GetAll() => customers;

    public Customer? GetById(int id) => customers.FirstOrDefault(c => c.Id == id);

    public void Add(Customer customer)
    {
        int maxId = customers.Count != 0 ? customers.Max(c => c.Id) : 0;
        customer.Id = maxId + 1;
        customers.Add(customer);
    }

    public void Update(Customer updated)
    {
        var index = customers.FindIndex(c => c.Id == updated.Id);
        if (index != -1)
            customers[index] = updated;
    }

    private void SeedCustomers()
    {
        string[] names = ["Alice Brown", "Bob Smith", "Charlie Johnson", "Diana King", "Ethan Lee",
                          "Fiona Watts", "George Hall", "Hannah Stone", "Isaac Blake", "Julia Young"];

        string[] emails = ["alice@example.com", "bob@example.com", "charlie@example.com", "diana@example.com", "ethan@example.com",
                           "fiona@example.com", "george@example.com", "hannah@example.com", "isaac@example.com", "julia@example.com"];

        string[] services = ["Window Cleaning", "Lawn Mowing", "Dog Walking", "Pool Maintenance", "Housekeeping", "Window Cleaning", "Lawn Mowing", "Dog Walking", "Pool Maintenance", "Housekeeping"];

        string[] notes =
        [
            "Cleaned 2nd floor windows only.",
            "Customer prefers edging done every visit.",
            "Dog is friendly but likes to chase squirrels.",
            "Backyard pool needs extra chlorine.",
            "Focus on kitchen and bathrooms.",
            "North-facing windows are hard to reach.",
            "Mow in diagonal pattern.",
            "Walk between 4-5 PM preferred.",
            "Skimmer basket clogs often.",
            "Requested organic cleaning supplies."
        ];

        var rand = new Random();

        for (int i = 0; i < 10; i++)
        {
            customers.Add(new Customer
            {
                Id = i + 1,
                Name = names[i],
                Email = emails[i],
                Phone = $"{rand.Next(100, 1000)}-{rand.Next(100, 1000)}-{rand.Next(100, 1000)}",
                ServiceType = services[i],
                Notes = notes[i]
            });
        }
    }
}
