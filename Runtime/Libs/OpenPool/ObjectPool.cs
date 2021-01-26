// Copyright (c) 2020 Omid Saadat (@omid3098)
using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : class
{
    private readonly Stack<T> _stack;
    private readonly List<T> _unreleasedObjects;
    private readonly Action<T> _onGet;
    private readonly Action<T> _onRelease;
    private readonly Func<T> _onNew;
    public List<T> ActiveObjects => _unreleasedObjects;

    public ObjectPool(int capacity,
                        Func<T> actionNew,
                        Action<T> actionOnGet = null,
                        Action<T> actionOnRelease = null)
    {
        _stack = new Stack<T>(capacity);
        _unreleasedObjects = new List<T>(capacity);
        _onNew = actionNew ?? throw new ArgumentException("New action can't be null!");
        _onGet = actionOnGet;
        _onRelease = actionOnRelease;
    }


    public void WarmUp(int count)
    {
        for (int i = 0; i < count; i++)
        {
            T element = _onNew();
            _stack.Push(element);
        }
    }

    public T Get()
    {
        if (_stack.Count == 0)
        {
            WarmUp(1);
        }
        T element = _stack.Pop();
        _unreleasedObjects.Add(element);
        _onGet?.Invoke(element);
        return element;
    }

    public void Release(T element)
    {
        if (_stack.Count > 0 && ReferenceEquals(_stack.Peek(), element))
            Debug.LogError("Internal error. Trying to destroy object that is already released to pool.");
        _onRelease?.Invoke(element);
        _stack.Push(element);
        _unreleasedObjects.Remove(element);
    }

    public void ReleaseAll()
    {
        for (int i = 0; i < _unreleasedObjects.Count; i++)
        {
            var element = _unreleasedObjects[i];
            if (_stack.Count > 0 && ReferenceEquals(_stack.Peek(), element))
                Debug.LogError("Internal error. Trying to destroy object that is already released to pool.");
            _onRelease?.Invoke(element);
            _stack.Push(element);
        }
        _unreleasedObjects.Clear();
    }
}
