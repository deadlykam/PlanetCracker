using System;
using UnityEngine;

namespace PlanetCracker.ScriptableObjects.Variables
{
    public class BaseVariableChange2<T> : ScriptableObject
    {
        private Action<T, T> _observers;
        private T _value1;
        private T _value2;

        public void SetValues(T value1, T value2)
        {
            _value1 = value1;
            _value2 = value2;
            Notify();
        }

        public void Notify() => _observers?.Invoke(_value1, _value2);
        public void Subscribe(Action<T, T> observer) => _observers += observer;
        public void Unsubscribe(Action<T, T> observer) => _observers -= observer;
        public T GetValue1() => _value1;
        public T GetValue2() => _value2;
    }
}