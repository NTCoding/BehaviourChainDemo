using System;

namespace BehaviourChainDemo.SimpleBehaviors
{
    public class Paul : Behaviour
    {
        protected override void BeforeInnerBehaviour()
        {
            Console.WriteLine("Paul:   Zzuuuuuuuuuumbaaaaaaaaaaa");
        }

        protected override void AfterInnerBehaviour()
        {
            Console.WriteLine("Paul: Oi oiiiiiiiiii !!!!");
        }
    }
}