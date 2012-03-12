using System;
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
            // create a behaviour graph - call it a list of actions to imply action methods
            var graph = BehaviourGraph.GetPopulatedGraph();

            // apply conventions to some chains
                // All chains ending with the word secure have a security convention applied to them
                // All chains with a type of Nick must have a cowboy convention applied

            // invoke all the chains

            // display the output
                // name
        }
        
        // Advanced runtime demo - using IoC to build up the chain
            // Show how behaviors need access to certain service

        // Example showing context being passed along the chains - but injected with IoC as per FubuMVC
            // Show conditional logic for behavior executing
            // maybe a real world demo of opening an NHibernate

    }

    public class BehaviourGraph
    {
        public static void GetPopulatedGraph()
        {
            // Create 5 chains - some with nick - some without
            var graph = new BehaviourGraph();

            // this will be the unaffected chain
            var noGregZilla = new BehaviourChain();
            noGregZilla.Append(new BehaviourNode(typeof(Nick)));
            noGregZilla.Append(new BehaviourNode(typeof(Emily)));
            noGregZilla.Append(new BehaviourNode(typeof(Paul)));

            graph.Add(noGregZilla);

            var dbConnection

            // Database connection, wrapped by NHibernate

            // No nick so we'll expect exceptions and wrap just his nodes
        }
    }

    public class NHiberanteSessionBehavior : Behaviour
    {
        protected override void ExecutePreAction()
        {
            Console.WriteLine("**********       Opening and ");
        }

        protected override void ExecutePostAction()
        {
            throw new System.NotImplementedException();
        }
    }
}
