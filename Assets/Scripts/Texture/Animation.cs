using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Animation
{
    public List<List<Sprite>> Sprites;
    public int[] FrameProgress;
    public int[] SpriteProgress;
    public bool[] FinishedAnimation;
    public Animation(List<List<Sprite>> par1Sprites)
    {
        Sprites = par1Sprites;
        SpriteProgress = new int[Sprites.ToArray().Length];
        FrameProgress = new int[Sprites.ToArray().Length];
        FinishedAnimation = new bool[Sprites.ToArray().Length];
    }

    public void UpdateAnimation(int par1ID, int par2FrameTime)
    {
        FinishedAnimation[par1ID] = false;
        FrameProgress[par1ID]++;
        if (FrameProgress[par1ID] > par2FrameTime)
        {
            FrameProgress[par1ID] = 0;
            SpriteProgress[par1ID]++;
        }
        if (SpriteProgress[par1ID] >= Sprites[par1ID].ToArray().Length)
        {
            SpriteProgress[par1ID] = 0;
            FinishedAnimation[par1ID] = true;
        }    
    }
    public Sprite GetAnimationChannel(int par1ID)
    {
        return Sprites[par1ID][SpriteProgress[par1ID]];
    }

    public bool HasFinishedAnimaStream(int par1ID)
    {
        return FinishedAnimation[par1ID];
    }
}
