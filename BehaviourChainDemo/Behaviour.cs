namespace BehaviourChainDemo
{
    public abstract class Behaviour
    {
        public void Invoke()
        {
            ExecutePreAction();

            if (!IsEndOfChain()) Inner.Invoke();

            ExecutePostAction();
        }

        private bool IsEndOfChain()
        {
            return Inner == null;
        }

        public Behaviour Inner { get; set; }

        protected abstract void ExecutePreAction();

        protected abstract void ExecutePostAction();
    }
}