﻿using System.CodeDom;
using System.Threading;
using BotBits.Events;

namespace BotBits.LoginForm.Demo
{
    class Program
    {
        static BotBitsClient bot = new BotBitsClient();

        private static void Main()
        {
            Login.Of(bot).WithPromptAsync().CreateJoinRoomAsync("PW01");
            Thread.Sleep(-1);
        }
    }
}
