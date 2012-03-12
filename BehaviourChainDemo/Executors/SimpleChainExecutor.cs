using System;

namespace BehaviourChainDemo.Executors
{
    public class SimpleChainExecutor
    {
        public void ExecuteBehavioursOf(BehaviourChain chain)
        {
            var top = (Behaviour)Activator.CreateInstance(chain.Top.Type);

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
                    var inner = (Behaviour) Activator.CreateInstance(node.Type);
                    next.Inner = inner;
                    next = inner;
                }
            }
        }
    }
}