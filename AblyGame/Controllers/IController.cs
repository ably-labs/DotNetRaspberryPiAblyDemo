using System;

namespace AblyGame.Controllers
{
    interface IController
    {
        void ProcessInput();
        
        Action Up { get; set; }

        Action Down { get; set; }

        Action Left { get; set; }

        Action Right { get; set; }
        
        Action Reset { get; set; }
    }
}