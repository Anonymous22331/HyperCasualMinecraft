using UnityEngine;

namespace TestTHC
{
    public class KeyboardInputHandler : InputHandler
    {
        public override void Handle()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                var block = GameObject.FindObjectOfType<Block>();
                if (block != null)
                {
                    SendBlockClicked(block);
                }
            }
        }
    }
}