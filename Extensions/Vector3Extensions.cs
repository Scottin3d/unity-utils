using UnityEngine;

namespace Utilities.Extensions
{
    public static class Vector3Extensions
    {
        /// <summary>
        /// Sets any x y z values of a Vector3
        /// </summary>
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
        }

        /// <summary>
        /// Adds to any x y z values of a Vector3
        /// </summary>
        public static Vector3 Add(this Vector3 vector, float x = 0, float y = 0, float z = 0)
        {
            return new Vector3(vector.x + x, vector.y + y, vector.z + z);
        }

        /// <summary>
        /// Returns a Boolean indicating whether the current Vector3 is in a given range from another Vector3
        /// </summary>
        /// <param name="current">The current Vector3 position</param>
        /// <param name="target">The Vector3 position to compare against</param>
        /// <param name="range">The range value to compare against</param>
        /// <returns>True if the current Vector3 is in the given range from the target Vector3, false otherwise</returns>
        public static bool InRangeOf(this Vector3 current, Vector3 target, float range)
        {
            return (current - target).sqrMagnitude <= range * range;
        }

        /// <summary>
        /// Divides two Vector3 objects component-wise.
        /// </summary>
        /// <remarks>
        /// For each component in v0 (x, y, z), it is divided by the corresponding component in v1 if the component in v1 is not zero. 
        /// Otherwise, the component in v0 remains unchanged.
        /// </remarks>
        /// <example>
        /// Use 'ComponentDivide' to scale a game object proportionally:
        /// <code>
        /// myObject.transform.localScale = originalScale.ComponentDivide(targetDimensions);
        /// </code>
        /// This scales the object size to fit within the target dimensions while maintaining its original proportions.
        ///</example>
        /// <param name="v0">The Vector3 object that this method extends.</param>
        /// <param name="v1">The Vector3 object by which v0 is divided.</param>
        /// <returns>A new Vector3 object resulting from the component-wise division.</returns>
        public static Vector3 ComponentDivide(this Vector3 v0, Vector3 v1)
        {
            return new Vector3(
                v1.x != 0 ? v0.x / v1.x : v0.x,
                v1.y != 0 ? v0.y / v1.y : v0.y,
                v1.z != 0 ? v0.z / v1.z : v0.z);
        }

        /// <summary>
        /// Combines two arrays of Vector3 into a single array.
        /// </summary>
        /// <param name="v0">The first array of Vector3.</param>
        /// <param name="v1">The second array of Vector3.</param>
        /// /// <returns>A new array that contains all the elements from both input arrays.</returns>
        public static Vector3[] CombineWith(this Vector3[] v0, Vector3[] v1)
        {
            // combine the two lists
            Vector3[] combined = new Vector3[v0.Length + v1.Length];
            v0.CopyTo(combined, 0);
            v1.CopyTo(combined, v0.Length);
            return combined;
        }

        /// <summary>
        /// Rotates an array of Vector3 objects by a specified angle around the Y-axis.
        /// </summary>
        /// <param name="v">The array of Vector3 objects to rotate.</param>
        /// /// <param name="angle">The angle (in degrees) by which to rotate the Vector3 objects.</param>
        public static void Rotate(this Vector3[] v, float angle)
        {
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = Quaternion.Euler(0, angle, 0) * v[i];
            }
        }


        /// <summary>
        /// Translates an array of Vector3 by a given translation vector.
        /// </summary>
        /// <param name="v">The array of Vector3 to be translated.</param>
        /// /// <param name="translation">The translation vector.</param>
        public static void Translate(this Vector3[] v, Vector3 translation)
        {
            for (int i = 0; i < v.Length; i++)
            {
                v[i] += translation;
            }
        }

        /// <summary>
        /// Inverts the order of elements in the given array of Vector3.
        /// </summary>
        /// /// <param name="v">The array of Vector3 to invert.</param>
        public static void Invert(this Vector3[] v)
        {
            Vector3[] inverted = new Vector3[v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                inverted[i] = v[^i];
            }
            v = inverted;
        }

        /// <summary>
        /// Flips the z-coordinate of given Vector3.
        /// </summary>
        /// /// <param name="v">The Vector3 to modify.</param>
        public static void FlipZ(this Vector3 v)
        {
            v = new Vector3(v.x, v.y, -v.z);
        }

        /// <summary>
        /// Flips the Y and Z components of the given Vector3.
        /// </summary>
        /// /// <param name="v">The Vector3 to flip.</param>
        public static void FlipYZ(this Vector3 v)
        {
            v = new Vector3(v.x, -v.y, v.z);
        }

        /// <summary>
        /// Flips the X and Z components of the given vector.
        /// </summary>
        /// /// <param name="v">The vector to flip.</param>
        public static void FlipXZ(this Vector3 v)
        {
            v = new Vector3(-v.x, v.y, -v.z);
        }

    }
}
