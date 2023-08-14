namespace AFFHangfire
{
    public interface ITestJob
    {
         void SendWelcomeMessage(string message);
         Task<string> register(string name);

    }
}
