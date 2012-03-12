using System;

namespace BehaviourChainDemo.SimpleBehaviors
{
    public class Paul : Behaviour
    {
        protected override void ExecutePreAction()
        {
            Console.WriteLine("Paul:   Zzuuuuuuuuuumbaaaaaaaaaaa");
        }

        protected override void ExecutePostAction()
        {
            Console.WriteLine("Paul: Oi oiiiiiiiiii !!!!");
        }
    }
}