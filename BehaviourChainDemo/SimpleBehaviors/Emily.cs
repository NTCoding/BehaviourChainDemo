using System;

namespace BehaviourChainDemo.SimpleBehaviors
{
    public class Emily : Behaviour
    {
        protected override void BeforeInnerBehaviour()
        {
            Console.WriteLine("Emily:   Grooooooooooooooooooowwwwwwl");
        }

        protected override void AfterInnerBehaviour()
        {

        }
    }
}