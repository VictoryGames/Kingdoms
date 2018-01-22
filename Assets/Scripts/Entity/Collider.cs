using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider {
   

    public enum ColDir {Null, Up, Down, Left, Right}

    public float OriginX { get; set; }
    public float OriginY { get; set; }
    public float Height  { get; set; }
    public float Width   { get; set; }

    public Collider(float par1, float par2, float par3, float par4)
    {
        OriginX = par1;
        OriginY = par2;
        Height = par3;
        Width = par4;
    }

    public static ColDir CollidedDir(Collider Col1, Collider Col2)
    {

        if (Col1.OriginX < (Col2.OriginX + Col2.Width) && (Col1.OriginX + Col1.Width) > Col2.OriginX && Col1.OriginY < (Col2.OriginY + Col2.Height) && (Col1.Height + Col1.OriginY) > Col2.OriginY)
        {
            return                Col1.OriginX < Col2.OriginX
                ? ColDir.Right :  (Col1.OriginX + Col1.Width)  > (Col2.OriginX + Col2.Width)
                ? ColDir.Left  :  Col1.OriginY < Col2.OriginY
                ? ColDir.Down  :  (Col1.Height + Col1.OriginY) > (Col2.OriginY + Col2.Height) 
                ? ColDir.Up    :  ColDir.Null; 



        }
        else
        {
            return ColDir.Null;
        }
     }
    public static bool Collided(Collider Col1, Collider Col2)
    {
        return (Col1.OriginX < (Col2.OriginX + Col2.Width) && (Col1.OriginX + Col1.Width) > Col2.OriginX && Col1.OriginY < (Col2.OriginY + Col2.Height) && (Col1.Height + Col1.OriginY) > Col2.OriginY);    
    }

}
