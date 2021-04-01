namespace DweepConstcoh.Game.Entities
{
    public enum EntityType
    {
        None = 0,

        Ground = 1,
        Wall = 2,
        Finish = 3,

        Player = 4,

        PlayerMover = 5,
        ToolsetSelector = 6,

        Lazer = 7,
        LazerTop = 8,
        LazerLeft = 9,
        LazerDown = 10,
        LazerRight = 11,
        LazerRay = 12,
        Mirror = 13,
        MirrorMainDiagonal = 14,
        MirrorSideDiagonal = 15,

        Bomb = 16,
        Fire = 17,
        Torch = 18,

        RotateToLeft = 19,
        RotateToRight = 20,

        ToolOnMap = 21
    }
}
