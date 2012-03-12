using System;

namespace BehaviourChainDemo.SimpleBehaviors
{
    public class NHiberanteSessionBehavior : Behaviour
    {
        protected override void ExecutePreAction()
        {
            Console.WriteLine("**********       Opening an NHiberante Sesssion      ***** ");
        }

        protected override void ExecutePostAction()
        {
            Console.WriteLine("**********       Closing an NHibernate Session     ********");
        }
    }
}