using UnityEngine;

namespace StdNounou
{
    public static class RandomExtensions
    {
        public static Vector2 Range(Vector2 min, Vector2 max)
        {
            Vector2 res = new Vector2();

            res.x = Random.Range(min.x, max.x);
            res.y = Random.Range(min.y, max.y);

            return res;
        }

        public static bool OneOutOfTwo() => Random.Range(0, 2) == 0;
        public static bool OneOutOf(int maxExclusive) => Random.Range(0, maxExclusive) == 0;
        public static bool PercentageChance(int chances) => Random.Range(0, 100) < chances;
        public static bool PercentageChance(float chances) => Random.Range(0, 100) < chances;

        #region Fluctuate

        /// <summary>
        /// <para> Fluctuates <paramref name="vector"/> by <b>10%</b>,</para>
        /// <para> Adding him a random number within <b>10%</b> of himself.</para>
        /// </summary>
        /// <param name="vector"></param>
        public static Vector2 Fluctuate(this Vector2 vector) => Fluctuate(vector, .1f);
        /// <summary>
        /// <para> Fluctuates <paramref name="vector"/> by <b>[100 * <paramref name="rangePercentage"/>]%</b>,</para>
        /// <para> Adding him a random number within <b>[100 * <paramref name="rangePercentage"/>]%</b> of himself.</para>
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="rangePercentage"></param>
        public static Vector2 Fluctuate(this Vector2 vector, float rangePercentage) => Fluctuate(vector, 1 - rangePercentage, 1 + rangePercentage);
        /// <summary>
        /// <para> Fluctuates <paramref name="vector"/> by <b>[100 * <paramref name="minRangePercentage"/>% ~ 100 * <paramref name="maxRangePercentage"/>%]</b>,</para>
        /// <para> Adding him a random number within <b>[100 * <paramref name="minRangePercentage"/>% ~ 100 * <paramref name="maxRangePercentage"/>%]</b> of himself. </para>
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="minRangePercentage"></param>
        /// <param name="maxRangePercentage"></param>
        public static Vector2 Fluctuate(this Vector2 vector, float minRangePercentage, float maxRangePercentage)
        {
            vector.x = Random.Range(vector.x * minRangePercentage, vector.x * maxRangePercentage);
            vector.y = Random.Range(vector.y * minRangePercentage, vector.y * maxRangePercentage);

            return vector;
        }

        /// <summary>
        /// <para> Fluctuates <paramref name="i"/> by <b>10%</b>, </para>
        /// <para> Adding him a random number within <b>10%</b> of himself.</para>
        /// </summary>
        /// <param name="i"></param>
        public static int Fluctuate(this int i) => Fluctuate(i, .1f);
        /// <summary>
        /// <para> Fluctuates <paramref name="i"/> by <b>[100 * <paramref name="rangePercentage"/>]%</b>,</para>
        /// <para> Adding him a random number within <b>[100 * <paramref name="rangePercentage"/>]%</b> of himself.</para>
        /// </summary>
        /// <param name="i"></param>
        /// <param name="rangePercentage"></param>
        public static int Fluctuate(this int i, float rangePercentage) => Fluctuate(i, 1 - rangePercentage, 1 + rangePercentage);
        /// <summary>
        /// <para> Fluctuates <paramref name="i"/> by <b>[100 * <paramref name="minRangePercentage"/>% ~ 100 * <paramref name="maxRangePercentage"/>%]</b>,</para>
        /// <para> Adding him a random number within <b>[100 * <paramref name="minRangePercentage"/>% ~ 100 * <paramref name="maxRangePercentage"/>%]</b> of himself. </para>
        /// </summary>
        /// <param name="i"></param>
        /// <param name="minRangePercentage"></param>
        /// <param name="maxRangePercentage"></param>
        public static int Fluctuate(this int i, float minRangePercentage, float maxRangePercentage)
        {
            return i = Mathf.CeilToInt(Random.Range(i * minRangePercentage, i * maxRangePercentage));
        }

        /// <summary>
        /// <para> Fluctuates <paramref name="f"/> by <b>10%</b>,</para>
        /// <para> Adding him a random number within <b>10%</b> of himself.</para>
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float Fluctuate(this float f) => Fluctuate(f, .1f);
        /// <summary>
        /// <para> Fluctuates <paramref name="f"/> by <b>[100 * <paramref name="rangePercentage"/>]%</b>,</para>
        /// <para> Adding him a random number within <b>[100 * <paramref name="rangePercentage"/>]%</b> of himself.</para>
        /// </summary>
        /// <param name="f"></param>
        /// <param name="rangePercentage"></param>
        /// <returns></returns>
        public static float Fluctuate(this float f, float rangePercentage) => Fluctuate(f, 1 - rangePercentage, 1 + rangePercentage);
        /// <summary>
        /// <para> Fluctuates <paramref name="f"/> by <b>[100 * <paramref name="minRangePercentage"/>% ~ 100 * <paramref name="maxRangePercentage"/>%]</b>,</para>
        /// <para> Adding him a random number within <b>[100 * <paramref name="minRangePercentage"/>% ~ 100 * <paramref name="maxRangePercentage"/>%]</b> of himself. </para>
        /// </summary>
        /// <param name="f"></param>
        /// <param name="minRangePercentage"></param>
        /// <param name="maxRangePercentage"></param>
        /// <returns></returns>
        public static float Fluctuate(this float f, float minRangePercentage, float maxRangePercentage)
        {
            return f = Random.Range(f * minRangePercentage, f * maxRangePercentage);
        }
        #endregion
    } 
}
