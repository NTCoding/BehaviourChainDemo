using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourChainDemo;
using BehaviourChainDemo.Executors;
using BehaviourChainDemo.SimpleBehaviors;
using NUnit.Framework;

namespace Runtime
{
    [TestFixture]
    public class Runtime
    {
        // Simple chains demo
        [Test]
        public void Chains_for_dummies_demo()
        {
            var chain = new BehaviourChain();
            chain.Append(new BehaviourNode(typeof(Nick)));
            chain.Append(new BehaviourNode(typeof(Emily)));
            chain.Prepend(new BehaviourNode(typeof(Paul)));
            chain.Prepend(new BehaviourNode(typeof(Gregzilla)));

            var executor = new SimpleChainExecutor();
            executor.ExecuteBehavioursOf(chain);
        }

        // Advanced configuration demo - conditionals etc
        
        // Advanced runtime demo - using IoC to build up the chain

        // Advanced example showing a graph of chains
    }
}
