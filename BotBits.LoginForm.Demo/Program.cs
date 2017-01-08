﻿using System.Threading;

namespace BotBits.LoginForm.Demo
{
    internal class Program
    {
        private static readonly BotBitsClient bot = new BotBitsClient();

        private static void Main()
        {
            Login.Of(bot).WithPromptAsync().CreateJoinRoomAsync("PW01");
            Thread.Sleep(-1);
        }
    }
}