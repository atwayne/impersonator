using CommandLine;

namespace WayneLabs.Impersonator
{
    public class Options
    {
        [Option("domain", Required = true)]
        public string Domain { get; set; }

        [Option("username", Required = true)]
        public string Username { get; set; }

        [Option("password", Required = true)]
        public string Password { get; set; }

        [Option("command", Required = true)]
        public string Command { get; set; }

        [Option("arguments", Required = false)]
        public string Arguments { get; set; }
    }
}
