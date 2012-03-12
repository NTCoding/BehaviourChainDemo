using BehaviourChainDemo.Services;

namespace BehaviourChainDemo.BehavioursWithDependencies
{
    public class RequiresALogger : Behaviour
    {
        private ILogger _logger;
        private IRequest _request;

        public RequiresALogger(ILogger logger, IRequest request)
        {
            _logger = logger;
            _request = request;
        }

        protected override void BeforeInnerBehaviour()
        {
            _request.AppendToOutput("RequiresALogger:        Got my logger: " + _logger.GetType().FullName);
        }

        protected override void AfterInnerBehaviour()
        {
        }
    }
}