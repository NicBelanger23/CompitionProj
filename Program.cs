// See https://aka.ms/new-console-template for more information

using CompitionProj;


Console.WriteLine("Hello, World!");

Level.Instance.DisplayLevel();


var t = new System.Timers.Timer() { Interval = 100 };
t.Elapsed += (s, e) =>
{

    Wall.Player1.Input(true);
    Wall.Player2.Input(false);
    Ball.b.Update();
    Level.Instance.DisplayLevel();
};

t.Start();


while (true)
{
    Console.ReadKey(true);

}
