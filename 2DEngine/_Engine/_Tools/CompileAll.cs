namespace _2DEngine._Engine._Tools
{
    class CompileAll : Tool
    {
        public CompileAll(Engine anEngine) : base(anEngine)
        {
            myToolName = "Compile all";
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Start()
        {
            base.Start();

            myOneFrameWindow = true;



            Debug.Log("Everything have been Saved !");
        }
    }
}
