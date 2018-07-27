﻿namespace _03___Gen._Swap_Method_String
{
    using System;

    public class Box<T> : IComparable<Box<T>>
        where T : IComparable
    {
        public Box()
        {
            this.Value = default(T);
        }

        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public int CompareTo(Box<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }

        public override string ToString()
        {
            return $"{this.Value.GetType().FullName}: {this.Value}";
        }
    }

}
