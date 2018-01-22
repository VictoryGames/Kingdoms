using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public enum Direction { Stop, Left, Right, Up, Down};
    public Direction Player_Dur = Direction.Stop;
    public Direction Past_Dur = Direction.Stop;

    public GameTypes.Gametypes OperationalGameType;

    public float Speed;

    public int AttackSpeed;
    private int AttackProg = 0;

    private Collider AttackCollider = default(Collider);

    public Animation Animations;
    public List<Sprite> Walk_Up;
    public List<Sprite> Walk_Down;
    public List<Sprite> Walk_Left;
    public List<Sprite> Walk_Right;
    public List<Sprite> Attack_Up;
    public List<Sprite> Attack_Down;
    public List<Sprite> Attack_Left;
    public List<Sprite> Attack_Right;
    public bool IsAttacking = false;
    


    // Use this for initialization
    void Start ()
    {
        Animations = new Animation(
            new List<List<Sprite>>
            {
                Walk_Up,
                Walk_Down,
                Walk_Left,
                Walk_Right,
                Attack_Up,
                Attack_Down,
                Attack_Left,
                Attack_Right
            });
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Speed = GetComponent<ClassComponent>().SelectedClass.Speed;
        Animations.Sprites = GetComponent<ClassComponent>().SelectedClass.Sprites;


        if (GameTypes.PauseLayer <= 0 && GameTypes.GameTypeIn == OperationalGameType) {

            if (AttackProg <= AttackSpeed && IsAttacking) AttackProg++; else { AttackProg = 0; IsAttacking = false; }
            AttackSpeed = (int)GetComponent<ClassComponent>().SelectedClass.AttackSpeed;
            Index<Collider> EntityColliders = new Index<Collider>();
            foreach (Entity E in EntityHandler.EntityIndex.Array)
            {
                EntityColliders += E.EntityCollider;
            }
            Past_Dur = Player_Dur != Direction.Stop ? Player_Dur : Past_Dur;
            Player_Dur = (Input.GetKey(KeyCode.W) && (Player_Dur == Direction.Stop || Player_Dur == Direction.Up)) ? Direction.Up : 
                         (Input.GetKey(KeyCode.S) && (Player_Dur == Direction.Stop || Player_Dur == Direction.Down)) ? Direction.Down : 
                         (Input.GetKey(KeyCode.D) && (Player_Dur == Direction.Stop || Player_Dur == Direction.Right)) ? Direction.Right :
                         (Input.GetKey(KeyCode.A) && (Player_Dur == Direction.Stop || Player_Dur == Direction.Left)) ? Direction.Left : 
                         Direction.Stop;

            switch (Player_Dur)
            {
                case Direction.Up:
                    GetComponent<Entity>().Move(new Vector2(0, Speed), new Index<Collider>[] { EntityColliders });
                    break;
                case Direction.Down:
                    GetComponent<Entity>().Move(new Vector2(0, -Speed), new Index<Collider>[] { EntityColliders });
                    break;
                case Direction.Left:
                    GetComponent<Entity>().Move(new Vector2(-Speed, 0), new Index<Collider>[] { EntityColliders });
                    break;
                case Direction.Right:
                    GetComponent<Entity>().Move(new Vector2(Speed, 0), new Index<Collider>[] { EntityColliders });
                    break;
            }


            switch (Past_Dur)
            {

                case Direction.Up:
                    if (Player_Dur == Direction.Stop)
                    {
                        GetComponent<SpriteRenderer>().sprite = Animations.Sprites[0][1];
                    }
                    else
                    {
                        Animations.UpdateAnimation(0, 5);
                        GetComponent<SpriteRenderer>().sprite = Animations.GetAnimationChannel(0);
                    }
                    Collider EC = GetComponent<Entity>().EntityCollider;
                    AttackCollider = new Collider(EC.OriginX, EC.OriginY + EC.Height, 0.4F, EC.Width);
                    break;
                case Direction.Down:
                    if (Player_Dur == Direction.Stop)
                    {
                        GetComponent<SpriteRenderer>().sprite = Animations.Sprites[1][1];
                    }
                    else
                    {
                        Animations.UpdateAnimation(1, 5);
                        GetComponent<SpriteRenderer>().sprite = Animations.GetAnimationChannel(1);
                    }
                    break;
                    EC = GetComponent<Entity>().EntityCollider;
                    AttackCollider = new Collider(EC.OriginX, EC.OriginY - 0.4F, 0.4F, EC.Width);
                case Direction.Left:
                    if (Player_Dur == Direction.Stop)
                    {
                        GetComponent<SpriteRenderer>().sprite = Animations.Sprites[2][1];
                    }
                    else
                    {
                        Animations.UpdateAnimation(2, 5);
                        GetComponent<SpriteRenderer>().sprite = Animations.GetAnimationChannel(2);
                    }
                    EC = GetComponent<Entity>().EntityCollider;
                    AttackCollider = new Collider(EC.OriginX - 0.4F, EC.OriginY, EC.Height, 0.4F);
                    break;
                case Direction.Right:
                    if (Player_Dur == Direction.Stop)
                    {
                        GetComponent<SpriteRenderer>().sprite = Animations.Sprites[3][1];
                    }
                    else
                    {
                        Animations.UpdateAnimation(3, 5);
                        GetComponent<SpriteRenderer>().sprite = Animations.GetAnimationChannel(3);
                    }
                    EC = GetComponent<Entity>().EntityCollider;
                    AttackCollider = new Collider(EC.OriginX + EC.Width, EC.OriginY, EC.Height, 0.4F);
                    break;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (!IsAttacking)
                {
                    IsAttacking = true;
                    EntityLivingBase Attacker = GetComponent<EntityLivingBase>();
                    List<EntityLivingBase> Targets = new List<EntityLivingBase>();

                    foreach (EntityLivingBase E in EntityHandler.EntityLivingIndex.Array)
                    {
                        if (Collider.Collided(E.gameObject.GetComponent<Entity>().EntityCollider, AttackCollider))
                        {
                            Targets.Add(E);
                        }
                    }
                    if (Targets != new List<EntityLivingBase>())
                    {
                        foreach (EntityLivingBase En in Targets)
                        {
                            GetComponent<ClassComponent>().SelectedClass.Attack(Attacker, En);
                            print(En);
                        }
                    }
                }
            }

            /*if (Animations.HasFinishedAnimaStream())
            {

            }*/

        }
    }

}
