using CompitionProj;

var t = new System.Timers.Timer() { Interval = 100 }; //main game loop
t.Elapsed += (s, e) =>
{

    Wall.Player1.Input(true);
    Wall.Player2.Input(false);
    Ball.b.Update();
    Level.Instance.DisplayLevel();
};

t.Start(); //start the same loop


while (true)
{
    Console.ReadKey(true);  //stops keypresses from being put into the console
}
