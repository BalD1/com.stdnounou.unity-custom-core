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
    }

}