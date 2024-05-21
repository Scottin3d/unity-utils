using UnityEngine;
using UnityEngine.Splines;

public static class SplineContainerExtensions{
    /// <summary>
    /// Adds an array of splines to the <see cref="SplineContainer"/>.
    /// </summary>
    /// <param name="splineContainer">The <see cref="SplineContainer"/> to add the splines to.</param>
    /// <param name="splines">The array of splines to add.</param>
    /// <returns>The updated <see cref="SplineContainer"/> with the added splines.</returns>
    public static SplineContainer AddSplines(this SplineContainer splineContainer, Spline[] splines){
        foreach(Spline spline in splines){
            splineContainer.AddSpline(spline);
        }

        return splineContainer;
    }

    /// <summary>
    /// Removes an array of splines from the <see cref="SplineContainer"/>.
    /// </summary>
    /// <param name="splineContainer">The <see cref="SplineContainer"/> to remove the splines from.</param>
    /// <param name="splines">The array of splines to remove.</param>
    /// <returns>The updated <see cref="SplineContainer"/> with the removed splines.</returns>
    public static SplineContainer RemoveSplines(this SplineContainer splineContainer, Spline[] splines){
        foreach(Spline spline in splines){
            splineContainer.RemoveSpline(spline);
        }

        return splineContainer;
    }

    /// <summary>
    /// Removes all splines from the <see cref="SplineContainer"/>.
    /// </summary>
    /// <param name="splineContainer">The <see cref="SplineContainer"/> to remove the splines from.</param>
    /// <returns>The updated <see cref="SplineContainer"/> with all splines removed.</returns>s
    public static SplineContainer RemoveSplines(this SplineContainer splineContainer){
        foreach(Spline spline in splineContainer.Splines){
            splineContainer.RemoveSpline(spline);
        }
        return splineContainer;
    }
}