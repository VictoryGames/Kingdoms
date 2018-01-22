using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityLivingBase : InitBase {

    public int Health;
    public int MaxHealth;
    public float Resistance;
    public static Color ColorGoal = new Color(1, 0, 1, 0.001F);
    public GameTypes.Gametypes gametype;
    public int HurtAnimationTime;
    private int HurtAnimationProg = 0;
    

    public bool isBeingDamaged;

    
    public int IndexID = 0;
    private bool wasSet = false;

    // Use this for initialization
    public override void SingleplayerStart()
    {
        if (gametype == GameTypes.Gametypes.Singleplayer)
        {
            EntityHandler.EntityLivingIndex += this;
            IndexID = EntityHandler.EntityLivingIndex.Length - 1;
            wasSet = true;
        }
        base.SingleplayerStart();
    }
    public override void ShopStart()
    {
        if (gametype == GameTypes.Gametypes.Shop)
        {
            EntityHandler.EntityLivingIndex += this;
            IndexID = EntityHandler.EntityLivingIndex.Length - 1;
            wasSet = true;
        }
        base.ShopStart();
    }

    public override void DungeonStart()
    {
        if (gametype == GameTypes.Gametypes.Dungeon)
        {
            EntityHandler.EntityLivingIndex += this;
            IndexID = EntityHandler.EntityLivingIndex.Length - 1;
            wasSet = true;
        }
        base.DungeonStart();
    }

    public override void TrainingStart()
    {
        if (gametype == GameTypes.Gametypes.Training)
        {
            EntityHandler.EntityLivingIndex += this;
            IndexID = EntityHandler.EntityLivingIndex.Length - 1;
            wasSet = true;
        }
        base.TrainingStart();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (gametype == GameTypes.GameTypeIn && wasSet)
        {
            if (IsDead())
            {
                EntityHandler.EntityIndex.Array[GetComponent<Entity>().EntityID].EntityCollider = new Collider(0,0,-1,-1);
                gameObject.SetActive(false);
            }
            if (isBeingDamaged)
            {
                HurtAnimationProg++;
                //  int r
                //  int g
                //  int b
                //  Color32 c = new Color32();
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
            if (HurtAnimationProg > HurtAnimationTime)
            {
                isBeingDamaged = false;
                HurtAnimationProg = 0;
            }
            UpdateIndex();
        }
    }

    public bool IsDead()
    {
        return (Health <= 0);
    }

    public void Heal(int par1Health)
    {
        Health = (Health + par1Health < MaxHealth) ? par1Health + Health : MaxHealth;
        UpdateIndex();
    }

    public void Damage(int par1Damage)
    {
        int Ran = new System.Random().Next(0, 100);
        float damage = par1Damage;
        if (Health - ((Ran < Resistance) ? damage -  damage * (Resistance / 200) : damage) > 0)
        {
            Health -= (int)((isBeingDamaged) ? 0 : (Ran < Resistance) ? damage - damage * (Resistance / 200) : damage);
            isBeingDamaged = true;
        }
        else
        {
            Health = 0;
        }
        UpdateIndex();
    }

    private void UpdateIndex()
    {
        EntityHandler.EntityLivingIndex.Array[IndexID] = this;
    }

}
