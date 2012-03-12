using System;
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
        [Test]
        public void BehaviourChains_101()
        {
            var chain = new BehaviourChain();
            chain.Append(new BehaviourNode(typeof(Nick)));
            chain.Append(new BehaviourNode(typeof(Emily)));
            chain.Prepend(new BehaviourNode(typeof(Paul)));
            chain.Prepend(new BehaviourNode(typeof(Gregzilla)));

            var executor = new SimpleChainExecutor();
            executor.ExecuteBehavioursOf(chain);
        }

        [Test]
        public void Conventional_Configuration()
        {
            var graph = BehaviourGraph.GetPopulatedGraph();

            // all chains that talk to db need a session open and closed
            graph.WrapChainsConditionally<NHiberanteSessionBehavior>(chain => chain.Any(node => node.Type == typeof(RepositoryBehavior)));

            // all chains involving Nick need a error handling behaviour
            graph.WrapChainsConditionally<ErrorHandlingBehaviour>(chain => chain.Any(node => node.Type == typeof(BrokenNode)));

            graph.EnrichChainsConditionally<GregzillaWarning>(chain => chain.Any(node => node.Type == typeof(Gregzilla)));

            // doesn't have to be just type - conventions can apply to anything - e.g. involving namespaces, output types, etc

            var runner = new SimpleChainExecutor();
            Console.WriteLine("About to run chains....");
            Console.WriteLine();
            foreach (var chain in graph.Chains)
            {
                Console.WriteLine("*******************");
                Console.WriteLine( );
                Console.WriteLine( );
                Console.WriteLine("About to execute chain...");
                Console.WriteLine();
                
                runner.ExecuteBehavioursOf(chain);
            }
        }
        
        // Advanced runtime demo - using IoC to build up the chain
            // Show how behaviors need access to certain service

        // Example showing context being passed along the chains - but injected with IoC as per FubuMVC
            // Show conditional logic for behavior executing
            // maybe a real world demo of opening an NHibernate

    }
}
