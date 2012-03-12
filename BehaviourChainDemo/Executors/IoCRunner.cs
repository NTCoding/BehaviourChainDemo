namespace BehaviourChainDemo.Executors
{
    public class IoCRunner
    {
        public void ExecuteBehavioursOf(BehaviourChain chain)
        {
            var top = (Behaviour)IoC.Container.GetInstance(chain.Top.Type);

            BuildRuntimeChain(chain, top);

            top.Invoke();
        }

        private static void BuildRuntimeChain(BehaviourChain chain, Behaviour top)
        {
            var next = top;
            foreach (var node in chain)
            {
                if (node != chain.Top)
                {
                    var inner = (Behaviour) IoC.Container.GetInstance(node.Type);
                    next.Inner = inner;
                    next = inner;
                }
            }
        }
    }
}