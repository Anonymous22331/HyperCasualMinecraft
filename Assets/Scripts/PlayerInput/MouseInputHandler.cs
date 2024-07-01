using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TestTHC
{
    public class MouseInputHandler : InputHandler
    {
        public override void Handle()
        {
            var touchPos = Input.mousePosition;
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                var pointerEventData = new PointerEventData(EventSystem.current) { position = touchPos };
                var raycastResults = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerEventData, raycastResults);

                if (raycastResults.Count > 0)
                {
                    foreach (var result in raycastResults)
                    {
                        if (result.gameObject.tag.Equals("Block"))
                        {
                            var block = result.gameObject.GetComponent<Block>();
                            if (block != null)
                            {
                                SendBlockClicked(block);
                            }

                            break;
                        }
                    }
                }
            }
        }
    }
}