using BehaviourChainDemo.Services;

namespace BehaviourChainDemo.BehavioursWithDependencies
{
    public class RequestParser : Behaviour
    {
        private IRequest _request;

        public RequestParser(IRequest request)
        {
            _request = request;
        }

        protected override void BeforeInnerBehaviour()
        {
            _request.AppendToOutput("Request parser:        Request has been parsed");
        }

        protected override void AfterInnerBehaviour()
        {
        }
    }
}