using UnityEngine;

namespace StdNounou
{
    public static class TransformExtensions
    {
        #region Set World Position

        public static void SetPositionX(this Transform transform, float newPosX)
        {
            Vector3 pos = transform.position;
            pos.x = newPosX;
            transform.position = pos;
        }

        public static void SetPositionY(this Transform transform, float newPosY)
        {
            Vector3 pos = transform.position;
            pos.y = newPosY;
            transform.position = pos;
        }

        public static void SetPositionZ(this Transform transform, float newPosZ)
        {
            Vector3 pos = transform.position;
            pos.z = newPosZ;
            transform.position = pos;
        }

        #endregion

        #region Set Local Position

        public static void SetLocalPositionX(this Transform transform, float newPosX)
        {
            Vector3 pos = transform.localPosition;
            pos.x = newPosX;
            transform.localPosition = pos;
        }

        public static void SetLocalPositionY(this Transform transform, float newPosY)
        {
            Vector3 pos = transform.localPosition;
            pos.y = newPosY;
            transform.localPosition = pos;
        }

        public static void SetLocalPositionZ(this Transform transform, float newPosZ)
        {
            Vector3 pos = transform.localPosition;
            pos.z = newPosZ;
            transform.localPosition = pos;
        }

        #endregion

        #region Add To World Position

        public static void AddToPositionX(this Transform transform, float x)
        {
            Vector3 pos = transform.position;
            pos.x += x;
            transform.position = pos;
        }

        public static void AddToPositionY(this Transform transform, float y)
        {
            Vector3 pos = transform.position;
            pos.y += y;
            transform.position = pos;
        }

        public static void AddToPositionZ(this Transform transform, float z)
        {
            Vector3 pos = transform.position;
            pos.z += z;
            transform.position = pos;
        }

        #endregion

        #region Add To Local Position

        public static void AddToLocalPositionX(this Transform transform, float x)
        {
            Vector3 pos = transform.localPosition;
            pos.x += x;
            transform.localPosition = pos;
        }

        public static void AddToLocalPositionY(this Transform transform, float y)
        {
            Vector3 pos = transform.localPosition;
            pos.y += y;
            transform.localPosition = pos;
        }

        public static void AddToLocalPositionZ(this Transform transform, float z)
        {
            Vector3 pos = transform.localPosition;
            pos.z += z;
            transform.localPosition = pos;
        } 

        #endregion

        public static void SetScale(this Transform transform, Vector3 scale)
        {
            transform.localScale = scale;
        }
    } 
}
