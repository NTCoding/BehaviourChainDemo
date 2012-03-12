using System;

namespace BehaviourChainDemo.SimpleBehaviors
{
    public class Gregzilla : Behaviour
    {
        protected override void ExecutePreAction()
        {
            Console.WriteLine("Gregzilla:     Raaaaaaaaaaaaaaaaaaaaaaaaaaa!!!!");
        }

        protected override void ExecutePostAction()
        {
            Console.WriteLine("Gregzilla:  Om Nom Nommmmmmmmmm!!!");
        }
    }
}