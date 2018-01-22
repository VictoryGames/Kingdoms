using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class
{
    public string Name;
    public int ID;
    public float Health;
    public float Strength;
    public float AttackSpeed;
    public float Speed;
    public List<List<Sprite>> Sprites;

    public Class(int par1ID, string par2name, float par3Health, float par4Strength, float par5AttackSpeed, float par6Speed)
    {
        ID = par1ID;
        Health = par3Health;
        Strength = par4Strength;
        AttackSpeed = par5AttackSpeed;
        Speed = par6Speed;
        Name = par2name;
        Sprites = new List<List<Sprite>>();
    }

    public Class(int par1ID, string par2name, float par3Health, int par4Strength, float par5AttackSpeed, float par6Speed, List<List<Sprite>> par7Sprites)
    {
        ID = par1ID;
        Health = par3Health;
        Strength = par4Strength;
        AttackSpeed = par5AttackSpeed;
        Speed = par6Speed;
        Name = par2name;
        Sprites = par7Sprites;
    }

    public virtual void Attack(EntityLivingBase attacker, EntityLivingBase target) { }

    public static void Regester(Class par1Class)
    {
        Classes.classes[par1Class.ID] = par1Class;
    }

    public static Class GetClass(int par1ID)
    {
        return Classes.classes[par1ID];
    }

}

public class Classes : MonoBehaviour {

    public static Class[] classes = new Class[1000];
    public enum enumClasses
    {
        Default,
        Warrior,
        Archer
    }

    //=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-//
    public static Class Default;
    public static Class Warrior;
    public static Class archer;

    public List<Sprite> Warrior_Up_1;
    public List<Sprite> Warrior_Down_1;
    public List<Sprite> Warrior_Left_1;
    public List<Sprite> Warrior_Right_1;
    public List<Sprite> Warrior_Attack_Up_1;
    public List<Sprite> Warrior_Attack_Down_1;
    public List<Sprite> Warrior_Attack_Left_1;
    public List<Sprite> Warrior_Attack_Right_1;


    //=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-//
    void Start()
    {

        //=-=-=-=-==-=-=-=-=Class=Declaration=-=-=-=-=-=-=-=-=-//

        Default = new Class(0, "Default", 1000, 1, 100, 0.05F);
        Class.Regester(Default);

        List<List<Sprite>> WarriorSprites = new List<List<Sprite>>()
        {
            Warrior_Up_1,
            Warrior_Down_1,
            Warrior_Left_1,
            Warrior_Right_1,
            Warrior_Attack_Up_1,
            Warrior_Attack_Down_1,
            Warrior_Attack_Left_1,
            Warrior_Attack_Right_1
        };
        Warrior = new Class(1, "Noble Warrior Andrew", 795, 38, 20, 0.07F, WarriorSprites);
        Class.Regester(Warrior);

        archer = new Archer(2, "Archer", 500, 5, 15, 0.1F, WarriorSprites);
        Class.Regester(archer);

        //=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-//
    }
}
