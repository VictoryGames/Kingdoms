using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTypes : InitBase {
    public enum Gametypes
    {
        TitleScreen = 0,
        Singleplayer = 1,
        Dungeon = 2,
        Training = 3,
        Shop = 4
    }
    public static Gametypes GameTypeIn = 0;
    public static int PauseLayer = 1;

    public override void SingleplayerStart()
    {
        GameTypeIn = Gametypes.Singleplayer;
        base.SingleplayerStart();
    }
    public override void DungeonStart()
    {
        GameTypeIn = Gametypes.Dungeon;
        base.DungeonStart();
    }
    public override void TrainingStart()
    {
        GameTypeIn = Gametypes.Training;
        base.TrainingStart();
    }
    public override void ShopStart()
    {
        GameTypeIn = Gametypes.Shop;
        base.ShopStart();
    }
}
