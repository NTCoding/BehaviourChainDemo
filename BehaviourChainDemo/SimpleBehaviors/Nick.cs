using System;

namespace BehaviourChainDemo.SimpleBehaviors
{
    public class Nick : Behaviour
    {
        protected override void BeforeInnerBehaviour()
        {
            Console.WriteLine("Nick:   Wooooooooooof" );
        }

        protected override void AfterInnerBehaviour()
        {
           
        }
    }
}