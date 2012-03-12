namespace BehaviourChainDemo.Executors
{
    public class IoCRunner
    {
        public Behaviour ConvertBehaviourChainsToBehaviours(BehaviourChain chain)
        {
            var top = (Behaviour)IoC.Container.GetInstance(chain.Top.Type);

            BuildBehaviours(chain, top);

            return top;
        }

        private static void BuildBehaviours(BehaviourChain chain, Behaviour top)
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