using System;

[Serializable]
public class Game
{
    public int score;
    public int debris;
    public int starDust;

    public Game(int score, int debris, int starDust)
    {
        this.score = score;
        this.debris = debris;
        this.starDust = starDust;
    }
}