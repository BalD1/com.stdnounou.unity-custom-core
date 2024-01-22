using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StdNounou.Core
{
    public class ObjectPool<T> : IDisposable
                  where T : Component
    {
        private Queue<T> pool = new Queue<T>();
        private Func<T> createAction;
        private int maxCapacity = -1;

        private Transform parentContainer;

        public ObjectPool(Func<T> _createAction, Transform _parentContainer, int initialCount = 10, int _maxCapacity = -1)
        {
            createAction = _createAction;
            parentContainer = _parentContainer;
            maxCapacity = _maxCapacity;

            T[] res = GetNextMultiple(initialCount);
            foreach (var item in res)
            {
                item.gameObject.SetActive(false);
            }

            pool = new Queue<T>(res);
            SceneManager.sceneUnloaded += SceneClear;
        }

        public void Dispose()
        {
            SceneManager.sceneUnloaded -= SceneClear;
        }

        /// <summary>
        /// Removes every null objects until the queue reaches a non-null one.
        /// </summary>
        public void CleanUntilNextValid()
        {
            while (pool.Count > 0 && pool.Peek() == null) pool.Dequeue();
        }

        public int Length()
            => pool.Count;

        public bool IsEmpty()
            => pool.Count == 0;

        private void SceneClear(Scene newScene)
        {
            pool.Clear();
        }

        #region

        public bool TryPeekNext(out T result)
        {
            result = null;
            CleanUntilNextValid();

            if (pool.Count <= 0) return false;

            result = pool.Peek();

            return true;
        }

        #endregion

        #region GetNextSingle

        /// <summary>
        /// Gets the next object in pool, and sets it active. Will create a new one if none is found.
        /// </summary>
        /// <returns>"<see cref="T"/>" type Object</returns>
        public T GetNext()
        {
            T obj = null;
            bool isValid = false;

            if (pool.Count > 0)
            {
                do
                {
                    obj = pool.Dequeue();
                }
                while (obj == null && pool.Count > 0);

                isValid = obj != null;
            }

            if (!isValid && (pool.Count <= maxCapacity || maxCapacity < 0))
            {
                obj = createAction?.Invoke();
                obj?.transform.SetParent(parentContainer, true);
            }

            obj?.gameObject.SetActive(true);

            return obj;
        }
        /// <summary>
        /// Gets the next object in pool, sets it active, and gives it a new position. Will create a new one if none is found.
        /// </summary>
        /// <param name="position"></param>
        /// <returns>"<see cref="T"/>" type Object</returns>
        public T GetNext(Vector2 position)
        {
            T obj = GetNext();
            obj.transform.position = position;
            return obj;
        }
        /// <summary>
        /// Gets the next object in pool, sets it active, and gives it a new rotation. Will create a new one if none is found.
        /// </summary>
        /// <param name="position"></param>
        /// <returns>"<see cref="T"/>" type Object</returns>
        public T GetNext(Quaternion rotation)
        {
            T obj = GetNext();
            obj.transform.rotation = rotation;
            return obj;
        }
        /// <summary>
        /// Gets the next object in pool, sets it active, and gives it a new position and rotation. Will create a new one if none is found.
        /// </summary>
        /// <param name="position"></param>
        /// <returns>"<see cref="T"/>" type Object</returns>
        public T GetNext(Vector2 position, Quaternion rotation)
        {
            T obj = GetNext();
            obj.transform.SetPositionAndRotation(position, rotation);
            return obj;
        }
        #endregion

        #region GetNextMultipleNonAlloc

        /// <summary>
        /// Outs the next <paramref name="count"/> objects in pool.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="objs"></param>
        public void GetNextMultiple(int count, out T[] objs)
        {
            objs = new T[count];
            for (int i = 0; i < count; i++)
            {
                objs[i] = GetNext();
            }
        }
        /// <summary>
        /// Outs the next <paramref name="count"/> objects in pool, and gives them a new position.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="objs"></param>
        public void GetNextMultiple(int count, Vector2 position, out T[] objs)
        {
            objs = new T[count];
            for (int i = 0; i < count; i++)
            {
                objs[i] = GetNext();
                objs[i].transform.position = position;
            }
        }
        /// <summary>
        /// Outs the next <paramref name="count"/> objects in pool, and gives them a new rotation.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="objs"></param>
        public void GetNextMultiple(int count, Quaternion rotation, out T[] objs)
        {
            objs = new T[count];
            for (int i = 0; i < count; i++)
            {
                objs[i] = GetNext();
                objs[i].transform.rotation = rotation;
            }
        }
        /// <summary>
        /// Outs the next <paramref name="count"/> objects in pool, and gives them a new position and rotation.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="objs"></param>
        public void GetNextMultiple(int count, Vector2 position, Quaternion rotation, out T[] objs)
        {
            objs = new T[count];
            for (int i = 0; i < count; i++)
            {
                objs[i] = GetNext();
                objs[i].transform.SetPositionAndRotation(position, rotation);
            }
        }
        #endregion

        #region GetNextMultipleAlloc

        /// <summary>
        /// Returns the next <paramref name="count"/> objects in pool.
        /// </summary>
        /// <param name="count"></param>
        public T[] GetNextMultiple(int count)
        {
            T[] objs = new T[count];
            GetNextMultiple(count, out objs);
            return objs;
        }

        /// <summary>
        /// Returns the next <paramref name="count"/> objects in pool, and gives them a new position.
        /// </summary>
        /// <param name="count"></param>
        public T[] GetNextMultiple(int count, Vector2 position)
        {
            T[] objs = new T[count];
            GetNextMultiple(count, out objs);
            foreach (var item in objs)
            {
                item.transform.position = position;
            }
            return objs;
        }
        /// <summary>
        /// Returns the next <paramref name="count"/> objects in pool, and gives them a new rotation.
        /// </summary>
        /// <param name="count"></param>
        public T[] GetNextMultiple(int count, Quaternion rotation)
        {
            T[] objs = new T[count];
            GetNextMultiple(count, rotation, out objs);
            return objs;
        }
        /// <summary>
        /// Returns the next <paramref name="count"/> objects in pool, and gives them a new position and rotation.
        /// </summary>
        /// <param name="count"></param>
        public T[] GetNextMultiple(int count, Vector2 position, Quaternion rotation)
        {
            T[] objs = new T[count];
            GetNextMultiple(count, position, rotation, out objs);
            return objs;
        }
        #endregion

        public void Enqueue(T obj)
        {
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
        public void ResetQueue() => pool.Clear();

        public T[] ToArray() => pool.ToArray();
    } 
}
