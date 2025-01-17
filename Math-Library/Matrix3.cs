﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    /// <summary>
    /// The class that defines 3x3 Matrices
    /// </summary>
    public struct Matrix3
    {
        /// <summary>s
        /// Variables that store the values of the matrix
        /// The first number is the row, and the second is the column
        /// </summary>
        public float M00, M01, M02, M10, M11, M12, M20, M21, M22;

        /// <summary>
        /// Assigns the values of the matrix to the input given
        /// </summary>
        public Matrix3(
            float m00, float m01, float m02,
            float m10, float m11, float m12,
            float m20, float m21, float m22)
        {
            M00 = m00; M01 = m01; M02 = m02;
            M10 = m10; M11 = m11; M12 = m12;
            M20 = m20; M21 = m21; M22 = m22;
        }

        /// <summary>
        /// Varaible created to store an identity matrix.
        /// Made static so that it can be accessed easily.
        /// </summary>
        public static Matrix3 Identity
        {
            get {
                //returns a new identity matrix
                return new Matrix3(
                    1, 0, 0,
                    0, 1, 0,
                    0, 0, 1);
                 }
        }

        /// <summary>
        /// Creates a new matrix that has been rotated by the given value in radians
        /// </summary>
        /// <param name="radians">The result of the rotation</param>
        public static Matrix3 CreateRotation(float radians)
        {
            return new Matrix3(
                (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                -(float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 1
                );
        }

        /// <summary>
        /// Creates a new matrix that has been translated by the given value
        /// </summary>
        /// <param name="translation">The position of the new matrix</param>
        public static Matrix3 CreateTranslation(float x, float y)
        {
            return new Matrix3(
                1, 0, x,
                0, 1, y,
                0, 0, 1
                );
        }



        /// <summary>
        /// Creates a new matrix that has been translated by the given value
        /// </summary>
        /// <param name="translation">The position of the new matrix</param>
        public static Matrix3 CreateTranslation(Vector2 translation)
        {
            return new Matrix3(
                1, 0, translation.X,
                0, 1, translation.Y,
                0, 0, 1
                );
        }
        /// <summary>
        /// Creates a new matrix that has been scaled by the given value
        /// </summary>
        /// <param name="scale">The result of the scale</param>
        public static Matrix3 CreateScale(float x, float y)
        {
            return new Matrix3(
                x, 0, 0,
                0, y, 0,
                0, 0, 1
                );
        }

        /// <summary>
        /// Adds two matrices together
        /// </summary>
        /// <param name="lhs">The left hand side of the operation</param>
        /// <param name="rhs">The right hand side of the operation</param>
        /// <returns>The result of the two added matrices</returns>
        public static Matrix3 operator +(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
                (lhs.M00 + rhs.M00), (lhs.M01 + rhs.M01), (lhs.M02 + rhs.M02),
                (lhs.M10 + rhs.M10), (lhs.M11 + rhs.M11), (lhs.M12 + rhs.M12),
                (lhs.M20 + rhs.M20), (lhs.M21 + rhs.M21), (lhs.M22 + rhs.M22)
                );
        }

        /// <summary>
        /// Subtracts one matrix from another
        /// </summary>
        /// <param name="lhs">The left hand matrix</param>
        /// <param name="rhs">The right hand matrix, and the matrix the lhs will be subtracted by</param>
        /// <returns>The rhs matrix subtracted from the lhs matrix</returns>
        public static Matrix3 operator -(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
                (lhs.M00 - rhs.M00), (lhs.M01 - rhs.M01), (lhs.M02 - rhs.M02),
                (lhs.M10 - rhs.M10), (lhs.M11 - rhs.M11), (lhs.M12 - rhs.M12),
                (lhs.M20 - rhs.M20), (lhs.M21 - rhs.M21), (lhs.M22 - rhs.M22)
                );
        }

        /// <summary>
        /// Multiplies two matrices together
        /// </summary>
        /// <param name="lhs">The left hand side of the operation</param>
        /// <param name="rhs">The right hand side of the operation</param>
        /// <returns>The result of the two matrices multiplied</returns>
        public static Matrix3 operator *(Matrix3 lhs, Matrix3 rhs)
        {
            return new Matrix3(
                //Row1, Column1
                ((lhs.M00 * rhs.M00) + (lhs.M01 * rhs.M10) + (lhs.M02 * rhs.M20)),
                //Row1, Column2
                ((lhs.M00 * rhs.M01) + (lhs.M01 * rhs.M11) + (lhs.M02 * rhs.M21)),
                //Row1, Column3
                ((lhs.M00 * rhs.M02) + (lhs.M01 * rhs.M12) + (lhs.M02 * rhs.M22)),

                //Row2, Column1
                ((lhs.M10 * rhs.M00) + (lhs.M11 * rhs.M10) + (lhs.M12 * rhs.M20)),
                //Row2, Column2
                ((lhs.M10 * rhs.M01) + (lhs.M11 * rhs.M11) + (lhs.M12 * rhs.M21)),
                //Row2, Column3
                ((lhs.M10 * rhs.M02) + (lhs.M11 * rhs.M12) + (lhs.M12 * rhs.M22)),

                //Row3, Column1
                ((lhs.M20 * rhs.M00) + (lhs.M21 * rhs.M10) + (lhs.M22 * rhs.M20)),
                //Row3, Column2
                ((lhs.M20 * rhs.M01) + (lhs.M21 * rhs.M11) + (lhs.M22 * rhs.M21)),
                //Row3, Column3
                ((lhs.M20 * rhs.M02) + (lhs.M21 * rhs.M12) + (lhs.M22 * rhs.M22))
                );
        }
    }
}
