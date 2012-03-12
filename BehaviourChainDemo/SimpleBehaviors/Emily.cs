using System;

namespace BehaviourChainDemo.SimpleBehaviors
{
    public class Emily : Behaviour
    {
        protected override void ExecutePreAction()
        {
            Console.WriteLine("Emily:   Grooooooooooooooooooowwwwwwl");
        }

        protected override void ExecutePostAction()
        {

        }
    }
}