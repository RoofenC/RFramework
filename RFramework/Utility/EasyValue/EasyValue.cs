#region

using System;
using UnityEngine.Events;

#endregion

namespace RFramework
{
	public class EasyValue<T> where T : IComparable<T>
	{
        private T value;
        private T maxValue;
        private T minValue;

        public T Value
        {
            get => value;
            set
            {
                if (typeof(T) == typeof(bool))
                {
                    this.value = value;
                    OnValueChanged?.Invoke(this.value);
                }
                else
                {
                    if (value.CompareTo(minValue) < 0)
                    {
                        this.value = minValue;
                        OnValueChanged?.Invoke(this.value);
                        OnValueTooLow?.Invoke(this.value);
                    }
                    else if (value.CompareTo(maxValue) > 0)
                    {
                        this.value = maxValue;
                        OnValueChanged?.Invoke(this.value);
                        OnValueOverflow?.Invoke(this.value);
                    }
                    else
                    {
                        this.value = value;
                        OnValueChanged?.Invoke(this.value);
                    }
                }
            }
        }

        public T MaxValue
        {
            get => maxValue;
            set
            {
                if (typeof(T) != typeof(bool) && value.CompareTo(minValue) < 0)
                    throw new ArgumentException("MaxValue cannot be less than MinValue.");
                maxValue = value;
            }
        }

        public T MinValue
        {
            get => minValue;
            set
            {
                if (typeof(T) != typeof(bool) && value.CompareTo(maxValue) > 0)
                    throw new ArgumentException("MinValue cannot be greater than MaxValue.");
                minValue = value;
            }
        }

        public event UnityAction<T> OnValueChanged;
        public event UnityAction<T> OnValueOverflow;
        public event UnityAction<T> OnValueTooLow;

        public EasyValue(T minValue, T maxValue, T initialValue)
        {
            if (typeof(T) == typeof(bool))
            {
                this.minValue = default;
                this.maxValue = default;
                Value = initialValue; // This will trigger the value set logic
            }
            else
            {
                if (minValue.CompareTo(maxValue) > 0)
                    throw new ArgumentException("MinValue cannot be greater than MaxValue.");

                this.minValue = minValue;
                this.maxValue = maxValue;
                Value = initialValue; // This will trigger the value set logic
            }
        }
	}

}
