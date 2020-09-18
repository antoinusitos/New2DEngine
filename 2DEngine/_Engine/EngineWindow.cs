namespace _2DEngine._Engine
{
    public class EngineWindow
    {
        public enum WindowType
        {
            NONE,
            STARTUP,
            GAME,
            ANIMATOR,
            LEVEL,
            OBJECT
        }

        public WindowType myWindowType = WindowType.NONE;
        public bool myOneFrameWindow = false;

        private bool myIsStarted = false;

        protected string myToolName = "";

        protected Engine myEngine = null;

        public EngineWindow(Engine anEngine)
        {
            myEngine = anEngine;
        }

        public virtual void Initialize()
        {

        }

        public virtual void LoadContent()
        {

        }

        public virtual void Awake()
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

        public string GetToolName()
        {
            return myToolName;
        }
    }
}
