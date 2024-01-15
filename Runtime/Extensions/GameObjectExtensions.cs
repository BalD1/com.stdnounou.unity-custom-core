using UnityEngine;

namespace StdNounou
{
    public static class GameObjectExtensions
    {
        #region Create

        #region Simple
        public static GameObject Create(this GameObject gameObject)
        {
            if (gameObject == null) return null;
            GameObject gO = GameObject.Instantiate(gameObject);
            return gO;
        }
        public static T Create<T>(this GameObject gameObject) where T : Component
        => Create(gameObject).GetComponent<T>();
        public static T Create<T>(this T obj) where T : Component
        => Create<T>(obj.gameObject);
        #endregion

        #region Vec2Position
        public static GameObject Create(this GameObject gameObject, Vector2 position)
        {
            if (gameObject == null) return null;
            GameObject gO = GameObject.Instantiate(gameObject, position, Quaternion.identity);
            return gO;
        }
        public static T Create<T>(this GameObject gameObject, Vector2 position) where T : Component
            => Create(gameObject, position).GetComponent<T>();
        public static T Create<T>(this T obj, Vector2 position) where T : Component
        => Create<T>(obj.gameObject, position);
        #endregion

        #region Vec2Position&Quaternion
        public static GameObject Create(this GameObject gameObject, Vector2 position, Quaternion quaternion)
        {
            if (gameObject == null) return null;
            GameObject gO = GameObject.Instantiate(gameObject, position, quaternion);
            return gO;
        }
        public static T Create<T>(this GameObject gameObject, Vector2 position, Quaternion quaternion) where T : Component
            => Create(gameObject, position, quaternion).GetComponent<T>();
        public static T Create<T>(this T obj, Vector2 position, Quaternion quaternion) where T : Component
            => Create<T>(obj.gameObject, position, quaternion);
        #endregion

        #region Vec3Position
        public static GameObject Create(this GameObject gameObject, Vector3 position)
        {
            if (gameObject == null) return null;
            GameObject gO = GameObject.Instantiate(gameObject, position, Quaternion.identity);
            return gO;
        }
        public static T Create<T>(this GameObject gameObject, Vector3 position) where T : Component
            => Create(gameObject, position).GetComponent<T>();
        public static T Create<T>(this T obj, Vector3 position) where T : Component
            => Create<T>(obj.gameObject, position);
        #endregion

        #region Vec3Position&Quaternion
        public static GameObject Create(this GameObject gameObject, Vector3 position, Quaternion quaternion)
        {
            if (gameObject == null) return null;
            GameObject gO = GameObject.Instantiate(gameObject, position, quaternion);
            return gO;
        }
        public static T Create<T>(this GameObject gameObject, Vector3 position, Quaternion quaternion) where T : Component
            => Create(gameObject, position, quaternion).GetComponent<T>();
        public static T Create<T>(this T obj, Vector3 position, Quaternion quaternion) where T : Component
            => Create<T>(obj.gameObject, position, quaternion);
        #endregion

        #region Parent
        public static GameObject Create(this GameObject gameObject, Transform parent)
        {
            if (gameObject == null) return null;
            GameObject gO = GameObject.Instantiate(gameObject, parent);
            return gO;
        }
        public static T Create<T>(this GameObject gameObject, Transform parent) where T : Component
            => Create(gameObject, parent).GetComponent<T>();
        public static T Create<T>(this T obj, Transform parent) where T : Component
            => Create<T>(obj.gameObject, parent);
        #endregion

        #region RectTransform
        public static GameObject Create(this GameObject gameObject, RectTransform parent)
        {
            if (gameObject == null) return null;
            GameObject gO = GameObject.Instantiate(gameObject, parent);
            return gO;
        }
        public static T Create<T>(this GameObject gameObject, RectTransform parent) where T : Component
            => Create(gameObject, parent).GetComponent<T>();
        public static T Create<T>(this T obj, RectTransform parent) where T : Component
            => Create<T>(obj.gameObject, parent);
        #endregion 

        #endregion
    } 
}
