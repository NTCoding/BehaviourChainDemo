using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourChainDemo;
using BehaviourChainDemo.BehavioursWithDependencies;
using BehaviourChainDemo.Executors;
using BehaviourChainDemo.Services;
using BehaviourChainDemo.SimpleBehaviors;
using NUnit.Framework;
using StructureMap;

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

            // Will take control of the chain and execute how it likes to
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
        
        // Demonstrate how context is passed through the chain using IoC - which also passes in dependencies
        // this is a benefit of letting the controller instantiate the object and separating configuration
        // from the runtime
        [Test]
        public void IoC_With_Context()
        {
            IoC.Container = new Container();
            IoC.Container.Configure(x =>
                                        {
                                            x.For<IRepository>().Use<BlahRepository>();
                                            x.For<ILogger>().Use<BlahLogger>();
                                            x.For<IRequest>().Use(new SillyRequest()); // equivalent to Http scoped
                                        });

            var chain = new BehaviourChain();
            chain.Append(new BehaviourNode(typeof(RequestParser)));
            chain.Append(new BehaviourNode(typeof(RequiresARepository)));
            chain.Append(new BehaviourNode(typeof(RequiresALogger)));
            chain.Append(new BehaviourNode(typeof(OutputRenderer)));

            var runner = new IoCRunner();
            runner.ExecuteBehavioursOf(chain);
        }
    }
}
