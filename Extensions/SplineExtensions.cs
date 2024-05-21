using UnityEngine;
using UnityEngine.Splines;

public static class SplineExtensions{
    
    /// <summary>
    /// Retrieves an array of points from the spline.
    /// </summary>
    /// <param name="spline">The spline to retrieve points from.</param>
    /// <returns>An array of Vector3 points.</returns>
    public static Vector3[] GetPoints(this Spline spline){
        Vector3[] points = new Vector3[spline.Count];

        for(int i = 0; i < spline.Count; i++){
            points[i] = spline[i].Position;
        }
        return points;
    }
}