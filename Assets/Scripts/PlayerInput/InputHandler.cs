using System;

namespace TestTHC
{
    public abstract class InputHandler
    {
        public event Action<Block> BlockClicked;
        public abstract void Handle();

        protected void SendBlockClicked(Block block)
        {
            BlockClicked?.Invoke(block);
        }
    }
}