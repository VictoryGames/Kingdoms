using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HashMap<A, T>
{
    public int Pairs { get; set; }
    public A[] Keys { get; set; }
    public T[] Out { get; set; }

    /// <summary>
    /// Adds a Key(par1) and an output(par2) so whenever the Key(par1) is pluged into 'HashMap.Get()' the output is par2
    /// </summary>
    public void Put(A par1A, T par2T)
    {
        if (Pairs == 0)
        {
            Keys = new A[1000];
            Out = new T[1000];
            Keys[Pairs] = par1A;
            Out[Pairs] = par2T;
        }
        else
        {
            Keys[Pairs] = par1A;
            Out[Pairs] = par2T;
        }
        Pairs += 1;
    }
    /// <summary>
    /// Gets an output value from a key value(par1)
    /// </summary>
    public T Get(A par1A)
    {        
        for (int i = 0; i < Pairs; i++)
        {
            if (Equals(par1A, Keys[i]))
            {
                return Out[i];
            }
        }
        return default(T);
    }
}

