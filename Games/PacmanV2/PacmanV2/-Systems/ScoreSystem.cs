
using Microsoft.Xna.Framework;
using PacmanV2.Events;
using System;

namespace PacmanV2.Systems;

public class ScoreSystem : IUpdateSystem
{
    public int TotalScore = 0;

    public ScoreSystem()
    {
        CollisionSystem.OnPelletEaten += HandlePelletEatenEvent; // Subscribar tíll eventet 
        //! NOTE TO SELF: subscribar inte events i update! 
    }

    public void Update(GameTime gameTime)
    {

    }
    public void HandlePelletEatenEvent(object sender, PelletsEatenEventArgs e)
    {
        TotalScore += e.ScoreValue;
        Console.WriteLine(TotalScore);
    }

    //! GLÖM INTE DETTA I GAMESTATE - när man ändrar till t,ex menu, ska detta köras eller om spelet startas om
    //! FÖREBYGGA MEMORY LEAKS
    public void UnsubscribeEvent()
    {
        CollisionSystem.OnPelletEaten -= HandlePelletEatenEvent;
        Console.WriteLine("ScoreSystem unsubscribed event: OnPelletEaten");
    }

}