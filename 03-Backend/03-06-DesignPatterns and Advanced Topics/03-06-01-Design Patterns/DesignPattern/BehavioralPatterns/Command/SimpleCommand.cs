using System;

namespace DesignPattern.BehavioralPatterns.Command
{
    class SimpleCommand : Command
    {
        string _payLoad = string.Empty;

        public SimpleCommand(string payLoad)
        {
            _payLoad = payLoad;
        }

        public override void Execute()
        {
            Console.Write($"SimpleCommand: See, I can do simple things like printing ({_payLoad})\n");
        }
    }
}