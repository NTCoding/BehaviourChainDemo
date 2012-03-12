using System;

namespace BehaviourChainDemo.SimpleBehaviors
{
    public class BrokenNode : Behaviour
    {
        protected override void ExecutePreAction()
        {
            Console.WriteLine("Broken node: I am about to throw a 404. Love you xx");

            throw new Exception("404: Resource not found");
        }

        protected override void ExecutePostAction()
        {
        }
    }
}