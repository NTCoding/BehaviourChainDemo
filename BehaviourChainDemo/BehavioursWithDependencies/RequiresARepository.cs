using BehaviourChainDemo.Services;

namespace BehaviourChainDemo.BehavioursWithDependencies
{
    public class RequiresARepository : Behaviour
    {
        private IRepository _repository;
        private readonly IRequest _request;

        public RequiresARepository(IRepository repository, IRequest request)
        {
            this._repository = repository;
            _request = request;
        }

        protected override void BeforeInnerBehaviour()
        {
            _request.AppendToOutput("Requires a repository:        Got My repository: " + _repository.GetType().FullName);
        }

        protected override void AfterInnerBehaviour()
        {
        }
    }
}