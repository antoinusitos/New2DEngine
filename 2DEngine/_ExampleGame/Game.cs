using _2DEngine._Engine;

namespace _2DEngine._ExampleGame
{
    class Game : EngineWindow
    {
        private Scene scene = null;

        private const string sceneToLoad = "test";

        public Game(Engine anEngine) : base(anEngine)
        {
            myToolName = "Game Mode";
        }

        public override void Initialize()
        {
            myWindowType = WindowType.GAME;
        }

        public override void LoadContent()
        {

        }

        public override void Awake()
        {
            base.Awake();

            scene = Resources.LoadScene(sceneToLoad);
            scene.Awake();
        }

        public override void Start()
        {
            base.Start();

            scene.Start();
        }

        public override void Update()
        {
            scene.InternalUpdate();
        }

        public override void Draw()
        {
            scene.InternalDraw();
        }

        public override void Stop()
        {
            base.Stop();

            Entities.GetInstance().CleanEntities();
        }
    }
}
