using AblyGame.Controllers;
using AblyGame.Displays;
using AblyGame.Surfaces;

namespace AblyGame
{
    class Game
    {
        private const uint Mask = 0x00000000;
        
        private readonly IDisplay _display;
        private readonly IController _controller;
        
        private readonly Surface _background;
        private readonly Surface _foreground;

        private readonly Surface _first;
        private readonly Surface _second;

        private Surface _active;
        private Surface _previous;

        private readonly Sprite[] _sprites;
        private readonly Sprite _ship;
        
        private Wave _wave;
        
        private enum Event
        {
            None,
            Up,
            Down,
            Left,
            Right,
            Quit
        }

        private Event _event;
        
        public Game(IDisplay display, IController controller)
        {
            _display = display;
            
            _controller = controller;
            SetupController();

            _background = new Surface();
            Backgrounds.CreateDefaultBackground(_background);

            _foreground = new Surface();

            _first = new Surface();
            _second = new Surface();
        
            _active = _first;
            _previous = _second;

            _sprites = new Sprite[]
            {
                new Ship(_foreground),
                new Rock(_foreground),
                new Rock(_foreground)
            };
            _ship = _sprites[0];
            
            _wave = new Wave(1);
            
            _event = Event.None;

            IsRunning = true;
        }

        public bool IsRunning { get; set; }
        
        public void Update()
        {
            ProcessEvent(GetEvent());
            
            foreach (var s in _sprites)
            {
                s.Update();    
            }

            if (_ship.Y != _sprites[1].Y)
            {
                return;
            }

            if (_ship.X == _sprites[1].X || _ship.X == _sprites[2].X)
            {
                Backgrounds.CreateFrownBackground(_background);
                _ship.Reset();
                return;
            }

            if (_wave.Next())
            {
                return;
            }

            _ship.MoveDown();
            if (_ship.Y == 0)
            {
                Backgrounds.CreateSmileBackground(_background);
                _ship.Reset();
            }
        }

        public void Draw()
        {
            _foreground.Fill(Mask);
            foreach (var s in _sprites)
            {  
                s.Draw();
            }

            SurfaceTools.Compose(_active, _background, _foreground, Mask);
            SwapOutputSurfaces();
            _active.Diff(_previous, _display.Draw);
        }
        
        private void SetupController()
        {
            _controller.Up = () => _event = Event.Up;
            _controller.Down = () => _event = Event.Down;
            _controller.Left = () => _event = Event.Left;
            _controller.Right = () => _event = Event.Right;
            _controller.Reset = () => _event = Event.Quit;
        }

        private Event GetEvent()
        {
            Event e = _event;
            _event = Event.None;
            return e;
        }

        private void ProcessEvent(Event e)
        {
            switch (e)
            {
                case Event.Quit:
                    _display.Clear();
                    IsRunning = false;
                    break;
                case Event.Left:
                    _ship.MoveLeft();
                    break;
                case Event.Right:
                    _ship.MoveRight();
                    break;
            }
        }

        private void SwapOutputSurfaces()
        {
            if (_active == _first)
            {
                _active = _second;
                _previous = _first;
            }
            else
            {
                _active = _first;
                _previous = _second;
            }
        }
        
        class Wave
        {
            private int _waves;
            private int _current;

            public Wave(int waves)
            {
                Reset(waves);
            }

            public bool Next()
            {
                ++_current;
                if (_current == _waves)
                {
                    Reset(_waves);
                    return false;
                }
                return true;
            }

            private void Reset(int waves)
            {
                _waves = waves;
                _current = 0;
            }
        }
    }
}