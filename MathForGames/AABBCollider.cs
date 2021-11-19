﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class AABBCollider : Collider
    {
        private float _width;
        private float _height;

        /// <summary>
        /// The size of thsi collider on the x axis
        /// </summary>
        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Teh size of this collider pn the y axis
        /// </summary>
        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// The farthest left x position of this collider
        /// </summary>
        public float Left
        {
            get
            {
                return Owner.LocalPosition.X - Width / 2;
            }
        }

        /// <summary>
        /// The farthest right x position of this collider
        /// </summary>
        public float Right
        {
            get
            {
                return Owner.LocalPosition.X + Width / 2;
            }
        }

        /// <summary>
        /// The farthest position upwards
        /// </summary>
        public float Top
        {
            get
            {
                return Owner.LocalPosition.Y - Height / 2;
            }
        }

        /// <summary>
        /// The farthest posituion downwards
        /// </summary>
        public float Bottom
        {
            get
            {
                return Owner.LocalPosition.Y + Height / 2;
            }
        }

        public AABBCollider(float width, float height, Actor owner) : base(owner, ColliderType.AABB)
        {
            _width = width;
            _height = height;
        }

        public override bool CheckCollisionAABB(AABBCollider other)
        {
            //Return false if this owner is checking for a collision against itself
            if (other.Owner == Owner)
                return false;

            //Return true if there is an overlap between boxes
            if(other.Left <= Right &&
               other.Top <= Bottom &&
               Left <= other.Right &&
               Top <= other.Bottom)
            {
                return true;
            }

            //Return false if there is no overlap
            return false;
        }

        public override bool CheckCollisionCircle(SphereCollider other)
        {
            return other.CheckCollisionAABB(this);
        }

        public override void Draw()
        {
            Raylib.DrawRectangleLines((int)Left, (int)Top, (int)Width, (int)Height, Color.BLACK);
        }
    }
}