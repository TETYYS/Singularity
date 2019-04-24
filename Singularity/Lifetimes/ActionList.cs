﻿using System;
using System.Threading;
using Singularity.Collections;

namespace Singularity
{
    internal class ActionList<T>
        where T : class
    {
        private Action<T> Action { get; }
        private SinglyLinkedListNode<T> _root;

        public ActionList(Action<T> action)
        {
            Action = action;
        }

        public void Invoke()
        {
            SinglyLinkedListNode<T>? root = _root;
            while (root != null)
            {
                Action(root.Value!);
                root = root.Next!;
            }
        }

        public void Add(T obj)
        {
            SinglyLinkedListNode<T>? initialValue, computedValue;
            do
            {
                initialValue = _root;
                computedValue = new SinglyLinkedListNode<T>(_root, obj);
            }
            while (initialValue != Interlocked.CompareExchange(ref _root, computedValue, initialValue));
        }
    }
}