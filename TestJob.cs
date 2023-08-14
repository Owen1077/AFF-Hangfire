namespace AFFHangfire
{
    public class TestJob : ITestJob
    {
        private readonly DataContext _context;
        public TestJob(DataContext context)
        {
            _context = context;
        }
        public void SendWelcomeMessage(string message)
        {
            Console.WriteLine(message);
        }

        public async Task<string> register(string name)
        {
            var req = new Character();
            req.Name = name;
            await _context.AddAsync(req);
            await _context.SaveChangesAsync();

            return "Done";
        }
    }
}
