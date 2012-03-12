using System;

namespace BehaviourChainDemo.SimpleBehaviors
{
    public class ErrorHandlingBehaviour : Behaviour
    {
        protected override void BeforeInnerBehaviour()
        {
            // we will take control of this chain now
            Console.WriteLine("Error Handler:             I've got this action covered");
            try
            {
                Inner.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Handler:          There was an error - " + ex.Message);

                Inner = null; // Handling this ourself now
            }
        }

        protected override void AfterInnerBehaviour()
        {
        }
    }
}