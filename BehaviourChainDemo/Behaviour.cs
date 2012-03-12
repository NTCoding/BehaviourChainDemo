namespace BehaviourChainDemo
{
    public abstract class Behaviour
    {
        public void Invoke()
        {
            BeforeInnerBehaviour();

            if (!IsEndOfChain()) Inner.Invoke();

            AfterInnerBehaviour();
        }

        private bool IsEndOfChain()
        {
            return Inner == null;
        }

        public Behaviour Inner { get; set; }

        protected abstract void BeforeInnerBehaviour();

        protected abstract void AfterInnerBehaviour();
    }
}