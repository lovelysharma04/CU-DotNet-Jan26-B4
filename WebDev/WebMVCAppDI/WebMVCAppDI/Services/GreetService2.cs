namespace WebMVCAppDI.Services
{
    public class GreetService2 : IGreet
    {
        public string SayHello(string name)
        {
            return $"Hi, {name}! Welcome to our website.";
        }
    }
}
