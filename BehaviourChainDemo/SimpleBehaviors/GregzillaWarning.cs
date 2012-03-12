using System;

namespace BehaviourChainDemo.SimpleBehaviors
{
    public class GregzillaWarning : Behaviour
    {
        protected override void BeforeInnerBehaviour()
        {
            Console.WriteLine("Gregzilla on the loooooooooooooose");
        }

        protected override void AfterInnerBehaviour()
        {
        }
    }
}