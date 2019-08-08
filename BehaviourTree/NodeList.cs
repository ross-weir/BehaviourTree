using System;
using System.Collections;
using System.Collections.Generic;

namespace BT
{
    internal class NodeList<T> : IEnumerable<T>
    {
        private readonly T[] nodes_;

        public NodeList(T[] nodes)
        {
            nodes_ = nodes;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new NodeEnumerator(nodes_);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class NodeEnumerator : IEnumerator<T>
        {
            private readonly T[] nodes_;
            private int index_ = -1;

            public NodeEnumerator(T[] nodes)
            {
                nodes_ = nodes;
            }

            public T Current => nodes_[index_];

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
