using System;

namespace BehaviourChainDemo.SimpleBehaviors
{
    public class NHiberanteSessionBehavior : Behaviour
    {
        protected override void BeforeInnerBehaviour()
        {
            Console.WriteLine("**********       Opening an NHiberante Sesssion      ***** ");
        }

        protected override void AfterInnerBehaviour()
        {
            Console.WriteLine("**********       Closing an NHibernate Session     ********");
        }
    }
}