using System;

namespace BehaviourChainDemo.SimpleBehaviors
{
    public class Gregzilla : Behaviour
    {
        protected override void BeforeInnerBehaviour()
        {
            Console.WriteLine("Gregzilla:     Raaaaaaaaaaaaaaaaaaaaaaaaaaa!!!!");
        }

        protected override void AfterInnerBehaviour()
        {
            Console.WriteLine("Gregzilla:  Om Nom Nommmmmmmmmm!!!");
        }
    }
}