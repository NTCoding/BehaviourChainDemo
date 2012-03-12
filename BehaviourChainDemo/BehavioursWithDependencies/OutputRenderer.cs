using System;
using BehaviourChainDemo.Services;

namespace BehaviourChainDemo.BehavioursWithDependencies
{
    public class OutputRenderer : Behaviour
    {
        private IRequest _request;

        public OutputRenderer(IRequest request)
        {
            _request = request;
        }

        protected override void BeforeInnerBehaviour()
        {
            Console.WriteLine("I am the output render. Here is the output for this request:");
            Console.WriteLine();
            Console.Write(_request.Output);
        }

        protected override void AfterInnerBehaviour()
        {
        }
    }
}