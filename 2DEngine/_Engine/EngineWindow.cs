namespace _2DEngine._Engine
{
    class EngineWindow
    {
        public enum WindowType
        {
            NONE,
            STARTUP,
            GAME,
            ANIMATOR,
            LEVEL,
        }

        public WindowType myWindowType = WindowType.NONE;

        private bool myIsStarted = false;
        

        public virtual void Initialize()
        {

        }

        public virtual void LoadContent()
        {

        }

        public virtual void Start()
        {
            myIsStarted = true;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }

        public virtual void Stop()
        {
            myIsStarted = false;
        }

        public bool GetIsStarted()
        {
            return myIsStarted;
        }
    }
}
