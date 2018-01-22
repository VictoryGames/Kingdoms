using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Index<T>
{
    public T[] Array { get; set; }
    public int Length;

    public void Clear()
    {
        Length = 0;
        Array = new T[Length];
    }

    public static Index<T> operator +(Index<T> par1Index, T par2T)
    {
        Index<T> t = par1Index;
        if (t.Length == 0)
        {
            t.Length += 1;
            t.Array = new T[t.Length];
            t.Array[t.Length - 1] = par2T;
            return t;
        }
        else
        {
            t.Length += 1;
            t.Array = new T[t.Length];
            for (int i = 0; i < par1Index.Length; i++)
                t.Array[i] = par1Index.Array[i];
            t.Array[t.Length - 1] = par2T;
            return t;
        }
    }
}
