using UnityEngine;

namespace StdNounou.Core
{
    public static class MouseUtils
    {
        public static Vector3 GetMouseWorldPosition()
        {
            Vector3 pos = GetMouseWorldPositionWithZ();
            pos.z = 0;
            return pos;
        }
        public static Vector3 GetMouseWorldPosition(Camera cam)
        {
            Vector3 pos = GetMouseWorldPositionWithZ(cam);
            pos.z = 0;
            return pos;
        }
        public static void GetMouseWorldPosition(out Vector3 vector)
        {
            Vector3 pos;
            GetMouseWorldPositionWithZ(out pos);
            pos.z = 0;
            vector = pos;
        }
        public static void GetMouseWorldPosition(out Vector3 vector, Camera cam)
        {
            Vector3 pos;
            GetMouseWorldPositionWithZ(out pos, cam);
            pos.z = 0;
            vector = pos;
        }

        public static Vector3 GetMouseWorldPositionWithZ()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        public static Vector3 GetMouseWorldPositionWithZ(Camera cam)
        {
            return cam.ScreenToWorldPoint(Input.mousePosition);
        }
        public static void GetMouseWorldPositionWithZ(out Vector3 vector)
        {
            vector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        public static void GetMouseWorldPositionWithZ(out Vector3 vector, Camera cam)
        {
            vector = cam.ScreenToWorldPoint(Input.mousePosition);
        }
    } 
}

