using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourChainDemo
{
    public class BehaviourChain : IEnumerable<BehaviourNode>
    {
        public BehaviourNode Top { get; protected set; }

        // TODO - methods specific to the domain ??

        public void Prepend(BehaviourNode node)
        {
            var next = Top;
            SetTop(node);

            if (next != null)
            {
                Top.Next = next;
            }
        }

        internal void SetTop(BehaviourNode node)
        {
            node.Previous = null;

            if (Top != null)
            {
                Top.Chain = null;
            }

            Top = node;
            node.Chain = this;
        }

        public void Append(BehaviourNode node)
        {
            if (Top == null)
            {
                SetTop(node);
                return;
            }

            Top.Append(node);
        }

        public IEnumerator<BehaviourNode> GetEnumerator()
        {
            if (Top == null) yield break;

            yield return Top;

            foreach (var node in Top)
            {
                yield return node;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
