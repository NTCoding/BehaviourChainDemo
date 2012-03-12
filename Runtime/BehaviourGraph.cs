using System;
using System.Collections.Generic;
using BehaviourChainDemo;
using BehaviourChainDemo.SimpleBehaviors;

namespace Runtime
{
    public class BehaviourGraph
    {
        public static BehaviourGraph GetPopulatedGraph()
        {
            var graph = new BehaviourGraph();

            var noGregZilla = new BehaviourChain();
            noGregZilla.Append(new BehaviourNode(typeof(Nick)));
            noGregZilla.Append(new BehaviourNode(typeof(Emily)));
            noGregZilla.Append(new BehaviourNode(typeof(Paul)));

            graph.Add(noGregZilla);

            var database = new BehaviourChain();
            database.Append(new BehaviourNode(typeof(RepositoryBehavior)));
            database.Append(new BehaviourNode(typeof(Emily)));

            graph.Add(database);

            var noNick = new BehaviourChain();
            noNick.Append(new BehaviourNode(typeof(Nick)));
            noNick.Append(new BehaviourNode(typeof(Emily)));
            noNick.Prepend(new BehaviourNode(typeof(Paul)));
            noNick.Prepend(new BehaviourNode(typeof(Gregzilla)));

            graph.Add(noNick);

            return graph;
        }

        private List<BehaviourChain> chains;

        public BehaviourGraph()
        {
            chains = new List<BehaviourChain>();
        }

        private void Add(BehaviourChain behaviourChain)
        {
            this.chains.Add(behaviourChain);
        }

        public void WrapChainsConditionally<T>(Func<BehaviourChain, bool> predicate)
        {
            foreach (var chain in Chains)
            {
                if (predicate(chain))
                {
                    chain.Prepend(new BehaviourNode(typeof(T)));
                }
            }
        }

        public void EnrichChainsConditionally<T>(Func<BehaviourChain, bool> predicate)
        {
            foreach (var chain in Chains)
            {
                if (predicate(chain))
                {
                    chain.Append(new BehaviourNode(typeof(T)));
                }
            }
        }

        public IEnumerable<BehaviourChain> Chains 
        {
            get { return chains; }
        }
    }
}