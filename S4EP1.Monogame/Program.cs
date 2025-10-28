using System;
using Microsoft.Xna.Framework;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        using (var game = new Sonic4Ep1())
        {
            game.Run();
        }
    }
}