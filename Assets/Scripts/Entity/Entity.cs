using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    public float Width;
    public float Height;
    public Collider EntityCollider;
    public int EntityID = 0;

    // Use this for initialization
	void Start ()
    {
        EntityCollider = new Collider(transform.position.x - Width / 2, transform.position.y - Height / 2, Height, Width);
        EntityHandler.EntityIndex += this;
        EntityID = EntityHandler.EntityIndex.Length - 1;
    }

    void Update()
    {
        EntityCollider = new Collider(transform.position.x - Width / 2, transform.position.y - Height / 2, Height,  Width);
    }

    void FixedUpdate()
    {
        EntityHandler.EntityIndex.Array[EntityID] = this;
    }

    public void Move(Vector2 par1Vector2, Index<Collider>[] par2IndexColliderArray)
    {
        Collider NewMoveX = new Collider(EntityCollider.OriginX + par1Vector2.x, EntityCollider.OriginY, EntityCollider.Height, EntityCollider.Width);
        Collider NewMoveY = new Collider(EntityCollider.OriginX, EntityCollider.OriginY + par1Vector2.y, EntityCollider.Height, EntityCollider.Width);
        bool YCanMove = true;
        bool XCanMove = true;
        if (par1Vector2 != new Vector2(0, 0))
        {
            foreach (Index<Collider> I in par2IndexColliderArray)
            {
                foreach (Collider C in I.Array)
                {
                    if (Collider.Collided(C, NewMoveY) && !Equals(C, EntityCollider)) YCanMove = false;
                    if (Collider.Collided(C, NewMoveX) && !Equals(C, EntityCollider)) XCanMove = false;
                }
            }
            if (XCanMove) { transform.position = new Vector3(transform.position.x + par1Vector2.x, transform.position.y, 0); EntityCollider = new Collider(transform.position.x - Width / 2, transform.position.y - Height / 2, Height, Width); }
            if (YCanMove) { transform.position = new Vector3(transform.position.x, transform.position.y + par1Vector2.y, 0); EntityCollider = new Collider(transform.position.x - Width / 2, transform.position.y - Height / 2, Height, Width); }
        }
    }

}
