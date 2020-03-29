using System;
namespace BlazorGameEngine.Models.Common
{
    public class Pose
    {
        /// <summary>
        /// X Coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y Coorindate
        /// </summary>
        public int Y { get; set; }

        public Pose(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static Pose operator -(Pose pose0, Pose pose1)
        {
            return new Pose(pose0.X - pose1.X, pose0.Y - pose1.Y);
        }

        public static Pose operator +(Pose pose0, Pose pose1)
        {
            return new Pose(pose0.X + pose1.X, pose0.Y + pose1.Y);
        }
    }
}
