﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MathLibrary
{
    /// <summary>
    /// This class defines 4x4 matrices
    /// </summary>
    public struct Matrix4
    {
        /// <summary>
        /// Stores the values of the matrix  
        /// The first number is the row, and the second is the column
        /// </summary>
        public float M00, M01, M02, M03, M10, M11, M12, M13, M20, M21, M22, M23, M30, M31, M32, M33;

        /// <summary>
        /// Assigns the values of the matrix to the input given
        /// </summary>
        public Matrix4(
            float m00, float m01, float m02, float m03,
            float m10, float m11, float m12, float m13,
            float m20, float m21, float m22, float m23,
            float m30, float m31, float m32, float m33)
        {
            M00 = m00; M01 = m01; M02 = m02; M03 = m03;
            M10 = m10; M11 = m11; M12 = m12; M13 = m13;
            M20 = m20; M21 = m21; M22 = m22; M23 = m23;
            M30 = m30; M31 = m31; M32 = m32; M33 = m33;
        }

        /// <summary>
        /// Varaible created to store an identity matrix.
        /// Made static so that it can be accessed easily.
        /// </summary>
        public static Matrix4 Identity
        {
            get
            {
                //returns a new identity matrix
                return new Matrix4(
                    1, 0, 0, 0,
                    0, 1, 0, 0,
                    0, 0, 1, 0,
                    0, 0, 0, 1);
            }
        }

        /// <summary>
        /// Creates a new matrix that has been rotated on this x axis by the given value in radians
        /// </summary>
        /// <param name="radians">The result of the rotation</param>
        public static Matrix4 CreateRotationX(float radians)
        {
            return new Matrix4(
                1, 0, 0, 0,
                0, (float)Math.Cos(radians), -(float)Math.Sin(radians), 0,
                0, (float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 0, 1
                );
        }

        /// <summary>
        /// Creates a new matrix that has been rotated on the Y axis by the given value in radians
        /// </summary>
        /// <param name="radians">The result of the rotation</param>
        public static Matrix4 CreateRotationY(float radians)
        {
            return new Matrix4(
               (float)Math.Cos(radians), 0, (float)Math.Sin(radians), 0, 
               0, 1, 0, 0,
               -(float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0, 
               0, 0 , 0, 1 );
        }

        /// <summary>
        /// Creates a new matrix that has been rotated on the Z axis by the given value in radians
        /// </summary>
        /// <param name="radians">The result of the rotation</param>
        public static Matrix4 CreateRotationZ(float radians)
        {
            return new Matrix4(
                (float)Math.Cos(radians), -(float)Math.Sin(radians), 0, 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1 );
        }

        /// <summary>
        /// Creates a new matrix that has been translated by the given values
        /// </summary>
        /// <param name="translation">The position of the new matrix</param>
        public static Matrix4 CreateTranslation(float x, float y, float z)
        {
            return new Matrix4(
                1, 0, 0, x,
                0, 1, 0, y,
                0, 0, 1, z,
                0, 0, 0, 1
                );
        }


        /// <summary>
        /// Creates a new matrix that has been scaled by the given values
        /// </summary>
        /// <param name="scale">The result of the scale</param>
        public static Matrix4 CreateScale(float x, float y, float z)
        {
            return new Matrix4(
                x, 0, 0, 0,
                0, y, 0, 0,
                0, 0, z, 0,
                0, 0, 0, 1
                );
        }

        /// <summary>
        /// Adds two matrices together
        /// </summary>
        /// <param name="lhs">The left hand side of the operation</param>
        /// <param name="rhs">The right hand side of the operation</param>
        /// <returns>The added matrices</returns>
        public static Matrix4 operator +(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
                (lhs.M00 + rhs.M00), (lhs.M01 + rhs.M01), (lhs.M02 + rhs.M02), (lhs.M03 + rhs.M03),
                (lhs.M10 + rhs.M10), (lhs.M11 + rhs.M11), (lhs.M12 + rhs.M12), (lhs.M13 + rhs.M13),
                (lhs.M20 + rhs.M20), (lhs.M21 + rhs.M21), (lhs.M22 + rhs.M22), (lhs.M23 + rhs.M23),
                (lhs.M30 + rhs.M30), (lhs.M31 + rhs.M31), (lhs.M32 + rhs.M32), (lhs.M33 + rhs.M33)
                );
        }

        /// <summary>
        /// Subtracts one matrix from another
        /// </summary>
        /// <param name="lhs">The left hand side of the operation</param>
        /// <param name="rhs">The right hand side of the operation, and the matrix the lhs will be subtracted by</param>
        /// <returns>The rhs matrix subtracted from the lhs matrix</returns>
        public static Matrix4 operator -(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
                (lhs.M00 - rhs.M00), (lhs.M01 - rhs.M01), (lhs.M02 - rhs.M02), (lhs.M03 - rhs.M03),
                (lhs.M10 - rhs.M10), (lhs.M11 - rhs.M11), (lhs.M12 - rhs.M12), (lhs.M13 - rhs.M13),
                (lhs.M20 - rhs.M20), (lhs.M21 - rhs.M21), (lhs.M22 - rhs.M22), (lhs.M23 - rhs.M23),
                (lhs.M30 - rhs.M30), (lhs.M31 - rhs.M31), (lhs.M32 - rhs.M32), (lhs.M33 - rhs.M33)
                );
        }

        /// <summary>
        /// Multiplies two matrices together
        /// </summary>
        /// <param name="lhs">The left hand side of the operation</param>
        /// <param name="rhs">The right hand side of the operation</param>
        /// <returns>A new matrix that is the result of the two multilied matrices</returns>
        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
                //Row1, Column1
                ((lhs.M00 * rhs.M00) + (lhs.M01 * rhs.M10) + (lhs.M02 * rhs.M20) + (lhs.M03 * rhs.M30)),
                //Row1, Column2
                ((lhs.M00 * rhs.M01) + (lhs.M01 * rhs.M11) + (lhs.M02 * rhs.M21) + (lhs.M03 * rhs.M31)),
                //Row1, Column3
                ((lhs.M00 * rhs.M02) + (lhs.M01 * rhs.M12) + (lhs.M02 * rhs.M22) + (lhs.M03 * rhs.M32)),
                //Row 1, Column4
                ((lhs.M00 * rhs.M03) + (lhs.M01 * rhs.M13) + (lhs.M02 * rhs.M23) + (lhs.M03 * rhs.M33)),

                //Row2, Column1
                ((lhs.M10 * rhs.M00) + (lhs.M11 * rhs.M10) + (lhs.M12 * rhs.M20) + (lhs.M13 * rhs.M30)),
                //Row2, Column2
                ((lhs.M10 * rhs.M01) + (lhs.M11 * rhs.M11) + (lhs.M12 * rhs.M21) + (lhs.M13 * rhs.M31)),
                //Row2, Column3
                ((lhs.M10 * rhs.M02) + (lhs.M11 * rhs.M12) + (lhs.M12 * rhs.M22) + (lhs.M13 * rhs.M32)),
                //Row2, Column4
                ((lhs.M10 * rhs.M03) + (lhs.M11 * rhs.M13) + (lhs.M12 * rhs.M23) + (lhs.M13 * rhs.M33)),

                //Row3, Column1
                ((lhs.M20 * rhs.M00) + (lhs.M21 * rhs.M10) + (lhs.M22 * rhs.M20) + (lhs.M23 * rhs.M30)),
                //Row3, Column2
                ((lhs.M20 * rhs.M01) + (lhs.M21 * rhs.M11) + (lhs.M22 * rhs.M21) + (lhs.M23 * rhs.M31)),
                //Row3, Column3
                ((lhs.M20 * rhs.M02) + (lhs.M21 * rhs.M12) + (lhs.M22 * rhs.M22) + (lhs.M23 * rhs.M32)),
                //Row3, Column4
                ((lhs.M20 * rhs.M03) + (lhs.M21 * rhs.M13) + (lhs.M22 * rhs.M23) + (lhs.M23 * rhs.M33)),

                //Row4, Column1
                ((lhs.M30 * rhs.M00) + (lhs.M31 * rhs.M10) + (lhs.M32 * rhs.M20) + (lhs.M33 * rhs.M30)),
                //Row4, Column2
                ((lhs.M30 * rhs.M01) + (lhs.M31 * rhs.M11) + (lhs.M32 * rhs.M21) + (lhs.M33 * rhs.M31)),
                //Row4, Column3
                ((lhs.M30 * rhs.M02) + (lhs.M31 * rhs.M12) + (lhs.M32 * rhs.M22) + (lhs.M33 * rhs.M32)),
                //Row4, Column4
                ((lhs.M30 * rhs.M03) + (lhs.M31 * rhs.M13) + (lhs.M32 * rhs.M23) + (lhs.M33 * rhs.M33))
                );
        }
    }
}
