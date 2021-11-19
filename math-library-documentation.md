**Devin Broussard**  
s218014  
[Github Repository](https://github.com/devinbroussard/Math-For-Games-Assessment)

# I. Requirements 

1.  **Description of a Problem**   
    **Name:**  
    Math Library  

    **Problem Statement:**  
    Create maths classes implementing Vector and Matrix objects for use in real-time applications.
      
    **Problem Specifications:**  
    * Submitted redistributable classes that implement:
      * Vector classes for 3D vectors, including homogeneous 3D vectors
        * Classes implement methods for, in all instances, translation, scale, magnitude, normalisation, cross product and dot product
      * Matrix classes for 3D matrices, including homogeneous 4D matrices
        * Classes implement methods for multiplication, vectors transformation, and transpose
        * Classes implement methods for setting up as rotation matrices
      * As part of the Colour class, functions for manipulating a bitfield implemented using bit shift operations
    * Code suitably commented to an industry standard as specified by your teacher
# II. Design
1.  ***System Architecture*** 
    There are seperate files that represent different version of math concepts like matrices and vectors. For example, there is the Matrix3 and Vector3 files, which represent a matrix with three rows and three columns, and a three dimensional vector, respectively. These files can then be used by projects with the same namespace.

2. ***Object Information***  
    * **FILE:** Matrix3.cs
        * *Name:* M00, M01, M02, M10, M11, M12, M20, M21, M22(float)
            * *Description:* holds the matrix's values
            * *Visibility:* public  
        * *Name:* Matrix3(constructor)
            * *Description:* Assigns the values of the matrix to the input given
            * *Visibility:* public
            * *Arguments:* float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22 
        * *Name:* Identity(Matrix3)
            * *Description:* Stores an identity matrix
            * *Visibility:* public static  
        * *Name:* CreateRotation(Matrix3)
            * *Description:* Creates a new matrix that has been rotated by the given value in radians
            * *Visibility:* public static 
            * *Arguments:* float radians    
        * *Name:* CreateTranslation(Matrix3)
            * *Description:* Creates a new matrix that has been translated by the given value
            * *Visibility:* public static 
            * *Arguments:* float x, float y
        * *Name:* CreateTranslation(Matrix3)
            * *Description:* Creates a new matrix that has been rotated by the given value in radians
            * *Visibility:* public static 
            * *Arguments:* Vector2 translation 
        * *Name:* CreateScale(Matrix3)
            * *Description:* Creates a new matrix that has been scaled by the given values
            * *Visibility:* public static 
            * *Arguments:* float x, float y     
        * *Name:* + (Matrix3)
            * *Description:* Adds two matrices together
            * *Visibility:* public static 
            * *Arguments:* Matrix3 lhs, Matrix3 rhs
        * *Name:* -(Matrix3)
            * *Description:* Subtracts one matrix from another
            * *Visibility:* public static 
            * *Arguments:* Matrix3 lhs, Matrix3 rhs
        * *Name:* *(Matrix3)
            * *Description:* Multiplies two matrices together
            * *Visibility:* public static 
            * *Arguments:* Matrix3 lhs, Matrix3 rhs       
        * *Name:* M00, M01, M02, M03, M10, M11, M12, M13, M20, M21, M22, M23, M30, M31, M32, M33(float)
            * *Description:* Stores the values of the matrix
            * *Visibility:* public     
        * *Name:* Matrix4(constructor)
            * *Description:* Assigns the values of the matrix to the input given
            * *Visibility:* public 
            * *Arguments:* float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33   
        * *Name:* Identity(Matrix4)
            * *Description:* Variable created to store an identity matrix
            * *Visibility:* public static 
        * *Name:* CreateRotationX(Matrix4)
            * *Description:* creates a new matrix that has been rotated on the x axis by the given value in radians
            * *Visibility:* public static 
            * *Arguments:* float radians    
        * *Name:* CreateRotationY(Matrix4)
            * *Description:* creates a new matrix that has been rotated on the Y axis by the given value in radians
            * *Visibility:* public static
            * *Arguments:* float radians     
        * *Name:* CreateRotationZ(Matrix4)
            * *Description:* creates a new matrix that has been rotated on the Z axis by the given value in radians
            * *Visibility:* public static
            * *Arguments:* float radians          
        * *Name:* CreateTranslation(Matrix4)
            * *Description:* Creates a new matrix that has been translated by the given values
            * *Visibility:* public static
            * *Arguments:* float x, float y, float z     
        * *Name:* CreateScale(Matrix4)
            * *Description:* Creates a new matrix that has been scaled by the given values
            * *Visibility:* public static
            * *Arguments:* float x, float y, float z
        * *Name:* +(Matrix4)
            * *Description:* adds two matrices
            * *Visibility:* public static
            * *Arguments:* matrix lhs, matrix rhs
        * *Name:* -(Matrix4)
            * *Description:* subtracts one matrix from another
            * *Visibility:* public static
            * *Arguments:* Matrix4 lhs, Matrix4 rhs
    * **FILE:** Vector2
        * *Name:* x(float)
            * *Description:* stores the x value of the vector
            * *Visibility:* public   
        * *Name:* y(float)
            * *Description:* stores the y value of the vector
            * *Visibility:* public   
        * *Name:* Vector2(constructor)
            * *Description:* sets the x and y values of the vector
            * *Visibility:* public 
            * *Arguments:* float x, float y  
        * *Name:* Magnitude(float)
            * *Description:* Gets the length of the vector
            * *Visibility:* public   
        * *Name:* Normalized(Vector2)
            * *Description:* property that returns the normalized value of the vector2
            * *Visibility:* public   
         * *Name:* Normalize(Vector2)
            * *Description:* changes this vector to have a magnitude of one
            * *Visibility:* public 
            * *Arguments:* none     
        * *Name:* GetDotProduct(float)
            * *Description:* returns the dot product of the first vector onto the second
            * *Visibility:* public static
            * *Arguments:* vector2 lhs, vector2 rhs     
        * *Name:* GetDistance(float)
            * *Description:* gets the distance between two vectors
            * *Visibility:* public static 
            * *Arguments:* vector2 lhs, vector2 rhs
        * *Name:* +(Vector2)
            * *Description:* adds two vectors
            * *Visibility:* public static
            * *Arguments:* vector2 lhs, vector2 rhs
        * *Name:* -(Vector2)
            * *Description:* subtracts the the rhs vector from the lhs vector
            * *Visibility:* public static
            * *Arguments:* vector2 lhs, vector2 rhs    
        * *Name:* /(vector2)
            * *Description:* divides a vector by a scalar
            * *Visibility:* public static
            * *Arguments:* vector2 vec2, float scalar              
        * *Name:* ==(bool)
            * *Description:* checks to see if two vectors are equal to each other
            * *Visibility:* public static
            * *Arguments:* vector2 lhs, vector2 rhs
        * *Name:* != (bool)
            * *Description:* Checks to see if two vectors are not equal to each other
            * *Visibility:* public static
            * *Arguments:* vector2 lhs, vector2 rhs         
    * **FILE:** Vector3
        * *Name:* X, Y, Z(float)
            * *Description:* The values of the vector
            * *Visibility:* public 
        * *Name:* Vector3(constructor)
            * *Description:* Sets the values of the vector
            * *Visibility:* public 
            * *Arguments:*  float x, float y, float z
        * *Name:* Magnitude(float)
            * *Description:* Gets the length of the vector
            * *Visibility:* public     
        * *Name:* Normalized(Vector3)
            * *Description:* returns the normalized value of the vector2
            * *Visibility:* public      
        * *Name:* Normalize(Vector3)
            * *Description:* changes this vector to have a magnitude that is equal to one
            * *Visibility:* public 
            * *Arguments:* none    
        * *Name:* DotProduct(float)
            * *Description:* returns the dot product of this first vector onto the second
            * *Visibility:* public static
            * *Arguments:* (vector3 lhs, vector3 rhs)    
        * *Name:* CrossProduct(vector3)
            * *Description:* stores the x value of the vector
            * *Visibility:* public static
            * *Arguments:* Vector3 lhs, vector3 rhs
        * *Name:* GetDistance(float)
            * *Description:* returns the distance between two vectors
            * *Visibility:* public static
            * *Arguments:* vector3 lhs, vector3 rhs
        * *Name:* +(vector3)
            * *Description:* adds two vectors
            * *Visibility:* public static
            * *Arguments:* Vector3 lhs, vector3 rhs       
        * *Name:* -(Vector3)
            * *Description:* subtracts one vector from another
            * *Visibility:* public static
            * *Arguments:* vector3 lhs, vector3 rhs         
        * *Name:* *(vector3)
            * *Description:* multilies the vector's x and y values by the scalar
            * *Visibility:* public static
            * *Arguments:* vector3 vec3, float scalar
        * *Name:* *(float)
            * *Description:* multilies the vector's x and y values by the scalar
            * *Visibility:* public static
            * *Arguments:* float scalar, vector3 vec3   
        * *Name:* /(float)
            * *Description:* divides the vector's x and y values by the scalar
            * *Visibility:* public static
            * *Arguments:* vector3 vec3, float scalar
        * *Name:* /(float)
            * *Description:* divides the vector by the scalar
            * *Visibility:* public static
            * *Arguments:* float scalar, vector3 vec3      
    * **FILE:** Vector4.cs
        * *Name:* X, Y, Z, W(float)
            * *Description:* The values of the matrix
            * *Visibility:* public
        * *Name:* Vector4(constructor)
            * *Description:* sets the vector's values
            * *Visibility:* public
            * *Arguments:* float x, float y, float z, float w
        * *Name:* Magnitude(float)
            * *Description:* gets the length of the vector
            * *Visibility:* public
        * *Name:* Normalized(Vector4)
            * *Description:* property that returns the normalized value of the vector2
            * *Visibility:* public
        * *Name:* Normalize(Vector4)
            * *Description:* changes this vector to have a magnitude that is equal to one
            * *Visibility:* public
            * *Arguments:* none
        * *Name:* CrossProduct(Vector4)
            * *Description:* gets the cross product of one vector onto another
            * *Visibility:* public static
            * *Arguments:* Vector4 lhs, Vector4 rhs
        * *Name:* DotProduct(float)
            * *Description:* returns the dot product of the first vector onto the second
            * *Visibility:* public static
            * *Arguments:* vector4 lhs, vector4 rhs
        * *Name:* GetDistance(Vector4 lhs, Vector4 rhs)
            * *Description:* returns the distance between two vectors
            * *Visibility:* public static
            * *Arguments:* Vector4 lhs, Vector4 rhs
        * *Name:* +(Vector4)
            * *Description:* adds the x and y vlaues of the second vector onto the first
            * *Visibility:* public static
            * *Arguments:* Vector4 lhs, vector4 rhs     
        * *Name:* -(Vector4)
            * *Description:* subtracts one vector from another
            * *Visibility:* public static
            * *Arguments:* Vector4 lhs, vector4 rhs   
        * *Name:* *(Vector4)
            * *Description:* multiplies the vector by the scalar
            * *Visibility:* public static
            * *Arguments:* Vector4 lhs, float scalar
        * *Name:* *(Vector4)
            * *Description:* multiplies the vector by the scalar
            * *Visibility:* public static
            * *Arguments:* float scalar, vector4 rhs   
        * *Name:* *(Vector4)
            * *Description:* multiplies the vector4 by the matrix4
            * *Visibility:* public static
            * *Arguments:* vector4 lhs, Matrix4 mat4  
        * *Name:* *-*(Vector4)
            * *Description:* multiplies the vector4 by the matrix4
            * *Visibility:* public static
            * *Arguments:* Matrix4 mat4, Vector4 rhs 
        * *Name:* /(Vector4)
            * *Description:* divides a vector by a scalar
            * *Visibility:* public static
            * *Arguments:* vector4 vec4, float scalar   
        *  *Name:* /(Vector4)
            * *Description:* divides a vector by a scalar
            * *Visibility:* public static
            * *Arguments:* float scalar, vector4 vec4 
        *  *Name:* ==(bool)
            * *Description:* checks to see if two vectors are equal to each other
            * *Visibility:* public static
            * *Arguments:* vector4 vec4, vector4 vec4 
        *  *Name:* !=(bool)
            * *Description:* checks to see if two vectors are not equal to eachother
            * *Visibility:* public static
            * *Arguments:* vector4 vec4, vector4 vec4       