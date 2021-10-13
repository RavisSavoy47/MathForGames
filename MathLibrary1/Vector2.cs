using System;

namespace MathLibrary1
{
    public struct Vector2
    {
        public float Y;
        public float X;


        ///Create overloaded fuctions for subtraction with a vector, multiplication with a scalor, division with a scalar.
        ///Create overloads to chek if two are equal to each otther and to check if two vectors are not equal to each other.

        //Add with vector
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2 { X = lhs.X + rhs.X, Y = lhs.Y + rhs.Y };
        }

        //Subtract with vector
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2 { X = lhs.X - rhs.X, Y = lhs.Y - rhs.Y };
        }

        //Multiply with scalor
        public static Vector2 operator *(Vector2 lhs, float rhs)
        {
            return new Vector2 { X = lhs.X * rhs, Y = lhs.Y * rhs };
        }

        //Divide with scalor
        public static Vector2 operator /(Vector2 lhs, float rhs)
        {
            return new Vector2 { X = lhs.X / rhs, Y = lhs.Y / rhs };
        }

        //Checks if their equal 
        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            if (lhs.X == rhs.X && lhs.Y == rhs.Y)
                return true;
            else
                return false;    
        }
        
        //Checks if their not equal
        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            if (lhs.X != rhs.X || lhs.Y != rhs.Y)
                return true;
            else
                return false;
        }
    }


}
