using System;

namespace BehaviourChainDemo.Services
{
    public class SillyRequest : IRequest
    {
        public void AppendToOutput(string message)
        {
            Output += message + Environment.NewLine;
        }

        public string Output { get; set; }
    }
}