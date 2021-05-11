using System;

namespace AblyGame.Controllers
{
    class ControllerBase
    {
        private Action _up;
        private Action _down;
        private Action _left;
        private Action _right;
        private Action _reset;
        
        public Action Up
        {
            get => _up;
            set => _up = value;
        }

        public Action Down
        {
            get => _down;
            set => _down = value;
        }

        public Action Left
        {
            get => _left;
            set => _left = value;
        }

        public Action Right
        {
            get => _right;
            set => _right = value;
        }

        public Action Reset
        {
            get => _reset;
            set => _reset = value;
        }     
    }
}