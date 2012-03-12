using System;

namespace BehaviourChainDemo.SimpleBehaviors
{
    public class RepositoryBehavior : Behaviour
    {
        protected override void ExecutePreAction()
        {
            Console.WriteLine("Repository: Doing some repository stuff before the action has completed");
        }

        protected override void ExecutePostAction()
        {
        }
    }
}