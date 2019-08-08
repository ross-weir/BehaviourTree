using System;
using System.Collections;
using System.Collections.Generic;

namespace BT
{
    public class NodeList<T> : IEnumerable<Node<T>>
    {
        private readonly NodeEnumerator enumerator_;

        public NodeList(Node<T>[] nodes)
        {
            enumerator_ = new NodeEnumerator(nodes);
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            while(enumerator_.MoveNext())
            {
                yield return enumerator_.Current;
            }

            enumerator_.Reset();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class NodeEnumerator : IEnumerator<Node<T>>
        {
            private readonly Node<T>[] nodes_;
            private int index_ = -1;

            public NodeEnumerator(Node<T>[] nodes)
            {
                nodes_ = nodes;
            }

            public Node<T> Current => nodes_[index_];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                index_ = -1;
                GC.SuppressFinalize(this);
            }

            public bool MoveNext()
            {
                index_++;
                return index_ < nodes_.Length;
            }

            public void Reset()
            {
                index_ = -1;
            }
        }
    }
    }
