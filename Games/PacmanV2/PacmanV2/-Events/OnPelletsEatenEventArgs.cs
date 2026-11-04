using System;
using Microsoft.Xna.Framework;

namespace PacmanV2.Events;

// Observer pattern 
//* Denna event ska hantera event vid uppätning av pellets

public class OnPelletsEatenEventArgs : EventArgs
{
    public int ScoreValue;
    public Point GridPos;

    public OnPelletsEatenEventArgs(Point gridPos, int scoreValue = 10)
    {
        ScoreValue = scoreValue;
        GridPos = gridPos;
    }
}