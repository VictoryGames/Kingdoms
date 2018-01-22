using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Class {

    private int Strength;

    public Archer(int par1ID, string par2name, float par3Health, int par4Strength, float par5AttackSpeed, float par6Speed)
    : base(par1ID, par2name, par3Health, par4Strength, par5AttackSpeed, par6Speed)
    {
        Strength = par4Strength;
    }

    public Archer(int par1ID, string par2name, float par3Health, int par4Strength, float par5AttackSpeed, float par6Speed, List<List<Sprite>> par7Sprites)
    : base(par1ID, par2name, par3Health, par4Strength, par5AttackSpeed, par6Speed, par7Sprites)
    {
        Strength = par4Strength;
    }

    public override void Attack(EntityLivingBase attacker, EntityLivingBase target)
    {
        if (target.gameObject != attacker.gameObject)
        {
            target.Damage(Strength);
            Debug.Log("Hello");
        }
        base.Attack(attacker, target);
    }

}
