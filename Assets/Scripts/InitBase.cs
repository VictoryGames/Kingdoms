using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBase : MonoBehaviour {

    public static Index<InitBase> InitBases = new Index<InitBase>();

    void Start()
    {
        InitBases += this;
    }

    public virtual void SingleplayerStart() { }
    public virtual void DungeonStart() { }
    public virtual void TrainingStart() { }
    public virtual void ShopStart() { }
}
