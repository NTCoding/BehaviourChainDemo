using System;

namespace BehaviourChainDemo.Executors
{
    public class Converter
    {
        public Behaviour ConvertBehaviourChainToBehaviours(BehaviourChain chain)
        {
            var top = (Behaviour)Activator.CreateInstance(chain.Top.Type);

            PopulateBehaviours(chain, top);

            return top;
        }

        private static void PopulateBehaviours(BehaviourChain chain, Behaviour top)
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