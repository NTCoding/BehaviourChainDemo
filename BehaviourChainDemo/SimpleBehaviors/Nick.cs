using System;

namespace BehaviourChainDemo.SimpleBehaviors
{
    public class Nick : Behaviour
    {
        protected override void ExecutePreAction()
        {
            Console.WriteLine("Nick:   Wooooooooooof" );
        }

        protected override void ExecutePostAction()
        {
           
        }
    }
}