using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHandler : MonoBehaviour
{
    public static Index<Entity> EntityIndex = new Index<Entity>();
    public static Index<EntityLivingBase> EntityLivingIndex = new Index<EntityLivingBase>();
}
