using UnityEngine;

namespace StdNounou.Core
{
    public static class VectorUtils
    {
        public static Vector2 ClampVector2(Vector2 vector, float min, float max)
        {
            vector.x = Mathf.Clamp(vector.x, min, max);
            vector.y = Mathf.Clamp(vector.y, min, max);
            return vector;
        }

        public static Vector2 ClampVector2(Vector2 vector, Vector2 min, Vector2 max)
        {
            vector.x = Mathf.Clamp(vector.x, min.x, max.x);
            vector.y = Mathf.Clamp(vector.y, min.y, max.y);
            return vector;
        }

        public static Vector3 ClampVector3(Vector3 vector, float min, float max)
        {
            float vecZ = vector.z;
            vector = ClampVector2(vector, min, max);
            vector.z = Mathf.Clamp(vecZ, min, max);
            return vector;
        }

        public static Vector3 ClampVector3(Vector3 vector, Vector3 min, Vector3 max)
        {
            float vecZ = vector.z;
            vector = ClampVector2(vector, min, max);
            vector.z = Mathf.Clamp(vecZ, min.z, max.z);
            return vector;
        }

        public static bool Vector2ApproximatlyEquals(Vector2 a, Vector2 b, float approx = .1f)
        {
            if (b.x <= a.x + approx && b.y <= a.y + approx &&
                b.y >= a.y - approx && b.y >= a.y - approx) return true;

            return false;
        }

        public static Vector2 Truncate(Vector2 original, float max)
        {
            if (original.magnitude > max)
            {
                original.Normalize();

                original *= max;

            }

            return original;
        }
        public static void Truncate(ref Vector2 original, float max)
        {
            if (original.magnitude > max)
            {
                original.Normalize();

                original *= max;
            }
        }

        public static Vector3 AddVec2(this Vector3 vector3, Vector2 vector2)
        {
            vector3.x += vector2.x;
            vector3.y += vector2.y;
            return vector3;
        }

        public static Vector2 AddVec3(this Vector2 vector2, Vector3 vector3)
        {
            vector2.x += vector3.x;
            vector2.y += vector3.y;
            return vector2;
        }

        public static Vector3 SubVec2(this Vector3 vector3, Vector2 vector2)
        {
            vector3.x -= vector2.x;
            vector3.y -= vector2.y;
            return vector3;
        }

        public static Vector2 SubVec3(this Vector2 vector2, Vector3 vector3)
        {
            vector2.x -= vector3.x;
            vector2.y -= vector3.y;
            return vector2;
        }
    }

}