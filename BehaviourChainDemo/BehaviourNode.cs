using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BehaviourChainDemo
{
    public class BehaviourNode : IEnumerable<BehaviourNode>
    {
        public BehaviourNode(Type type)
        {
            Type = type;
        }

        public BehaviourChain Chain { get; set; }

        public BehaviourNode Next { get; set; }

        public BehaviourNode Previous { get; set; }

        public Type Type { get; private set; }

        public void Append(BehaviourNode node)
        {
            if (this.Contains(node)) return;

            var last = this.LastOrDefault() ?? this;
            last.Next = node;
        }

        public IEnumerator<BehaviourNode> GetEnumerator()
        {
            if (Next != null)
            {
                yield return Next;

                foreach (BehaviourNode node in Next)
                {
                    yield return node;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}