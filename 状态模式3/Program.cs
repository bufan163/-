using System;

namespace 状态模式3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MarioStateMachine mario = new MarioStateMachine();
            mario.obtainMushRoom();
            int score = mario.getScore();
            StateEnum state = mario.getCurrentState();
            Console.WriteLine("mario score: " + score + "; state: " + state);
            mario.obtainCape();
            int score2 = mario.getScore();
            StateEnum state2 = mario.getCurrentState();
            Console.WriteLine("mario score: " + score2 + "; state: " + state2);
            Console.ReadKey();
        }
    }
}
