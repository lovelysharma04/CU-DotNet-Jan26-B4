namespace WebMVCAppDI.Services
{
    public class GreetService : IGreet
    {
        public string SayHello(string name)
        {
            return $"Hello, {name}!";
        }
    }
}
