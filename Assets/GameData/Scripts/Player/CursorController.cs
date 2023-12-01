using UnityEngine;
namespace Game.Player
{
    public class CursorController
    {
        public static void LockCursor(bool locked)
        {
            Cursor.visible = !locked;

            if (locked)
                Cursor.lockState = CursorLockMode.Locked;
            else
                Cursor.lockState = CursorLockMode.None;
        }
    }
}