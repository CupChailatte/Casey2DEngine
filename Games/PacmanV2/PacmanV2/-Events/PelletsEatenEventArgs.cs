using System;
using Microsoft.Xna.Framework;

namespace PacmanV2.Events;

// Observer pattern 
//* Denna event ska hantera event vid uppätning av pellets

public class PelletsEatenEventArgs : EventArgs
{
    public int ScoreValue;
    public Point GridPos;

    public PelletsEatenEventArgs(Point gridPos, int scoreValue = 10)
    {
        ScoreValue = scoreValue;
        GridPos = gridPos;
    }
}