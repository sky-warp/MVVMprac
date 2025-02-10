using System;

namespace _Project.Scripts.Infrastructure
{
    public class ReactProp<T>
    {
        public Action<T> OnValueChanged;
        
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }
    }
}
