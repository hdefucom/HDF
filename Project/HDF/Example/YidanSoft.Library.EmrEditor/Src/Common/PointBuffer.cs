using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YidanSoft.Library.EmrEditor.Src.Common
{
    /// <summary>
    /// 点结构体对象的集合,追加数据将导致缓冲区的变大
    /// </summary>
    public class PointBuffer
    {
        private System.Drawing.Point[] myPoints = new System.Drawing.Point[16];
        private int intPointCount = 0;
        /// <summary>
        /// 对象已经包含的点结构体的个数
        /// </summary>
        public int Count
        {
            get { return intPointCount; }
        }
        /// <summary>
        /// 获得指定序号的点坐标数据
        /// </summary>
        public System.Drawing.Point this[int index]
        {
            get { return myPoints[index]; }
            set { myPoints[index] = value; }
        }

        /// <summary>
        /// 对象中最后一个点结构体
        /// </summary>
        public System.Drawing.Point LastPoint
        {
            get
            {
                if (intPointCount > 0)
                    return myPoints[intPointCount - 1];
                else
                    return System.Drawing.Point.Empty;
            }
        }
        /// <summary>
        /// 获得最大的X值
        /// </summary>
        public int MaxX
        {
            get
            {
                int intValue = myPoints[0].X;
                for (int iCount = 1; iCount < intPointCount; iCount++)
                {

                    if (myPoints[iCount].X > intValue)
                        intValue = myPoints[iCount].X;
                }
                return intValue;
            }
        }
        /// <summary>
        /// 获得最小的X值
        /// </summary>
        public int MinX
        {
            get
            {
                int intValue = myPoints[0].X;
                for (int iCount = 1; iCount < intPointCount; iCount++)
                {

                    if (myPoints[iCount].X < intValue)
                        intValue = myPoints[iCount].X;
                }
                return intValue;
            }
        }
        /// <summary>
        /// 获得最大的X值
        /// </summary>
        public int MaxY
        {
            get
            {
                int intValue = myPoints[0].Y;
                for (int iCount = 1; iCount < intPointCount; iCount++)
                {

                    if (myPoints[iCount].Y > intValue)
                        intValue = myPoints[iCount].Y;
                }
                return intValue;
            }
        }
        /// <summary>
        /// 获得最小的Y值
        /// </summary>
        public int MinY
        {
            get
            {
                int intValue = myPoints[0].Y;
                for (int iCount = 1; iCount < intPointCount; iCount++)
                {

                    if (myPoints[iCount].Y < intValue)
                        intValue = myPoints[iCount].Y;
                }
                return intValue;
            }
        }

        /// <summary>
        /// 添加一个点结构体数据
        /// </summary>
        /// <param name="p">点结构体</param>
        public void Add(System.Drawing.Point p)
        {
            lock (this)
            {
                if (intPointCount >= myPoints.Length)
                {
                    System.Drawing.Point[] ps = new System.Drawing.Point[(int)(myPoints.Length * 1.5)];
                    for (int iCount = 0; iCount < intPointCount; iCount++)
                        ps[iCount] = myPoints[iCount];
                    myPoints = ps;
                }
                myPoints[intPointCount] = p;
                intPointCount++;
            }
        }
        /// <summary>
        /// 移动所有的点
        /// </summary>
        /// <param name="dx">横向移动距离</param>
        /// <param name="dy">纵向移动距离</param>
        public void Offset(int dx, int dy)
        {
            for (int iCount = 0; iCount < intPointCount; iCount++)
            {
                myPoints[iCount].Offset(dx, dy);
            }
        }
        /// <summary>
        /// 移动指定的点
        /// </summary>
        /// <param name="index">点序号</param>
        /// <param name="dx">横向移动距离</param>
        /// <param name="dy">纵向移动距离</param>
        public void Offset(int index, int dx, int dy)
        {
            if (index >= 0 && index < intPointCount)
            {
                myPoints[index].Offset(dx, dy);
            }
        }

        /// <summary>
        /// 返回该缓冲区中所有点的数组
        /// </summary>
        /// <returns>点结构体数组</returns>
        public System.Drawing.Point[] ToPointArray()
        {
            System.Drawing.Point[] ps = null;
            if (intPointCount > 0)
            {
                lock (this)
                {
                    ps = new System.Drawing.Point[intPointCount];
                    for (int iCount = 0; iCount < intPointCount; iCount++)
                    {
                        ps[iCount] = myPoints[iCount];
                    }
                }
            }
            return ps;
        }
        /// <summary>
        /// 返回该缓冲区中所有点的数组，并保证这这些点组成的多边形是封闭的（第一个点和最后一个点重复）
        /// </summary>
        /// <returns>点结构体数组</returns>
        public System.Drawing.Point[] ToClosedPointArray()
        {
            System.Drawing.Point[] ps = null;
            if (intPointCount > 0)
            {
                lock (this)
                {
                    bool bolAdd = (myPoints[0] != myPoints[intPointCount - 1]);
                    ps = new System.Drawing.Point[bolAdd ? intPointCount + 1 : intPointCount];
                    for (int iCount = 0; iCount < intPointCount; iCount++)
                    {
                        ps[iCount] = myPoints[iCount];
                    }
                    if (bolAdd)
                    {
                        ps[intPointCount] = myPoints[0];
                    }
                }
            }
            return ps;
        }//public System.Drawing.Point[] ToClosedPointArray()

        /// <summary>
        /// 清空缓冲区
        /// </summary>
        public void Clear()
        {
            lock (this)
            {
                intPointCount = 0;
                myPoints = new System.Drawing.Point[16];
            }
        }

        /// <summary>
        /// 返回保存所有点的方框对象
        /// </summary>
        /// <returns>方框对象</returns>
        public System.Drawing.Rectangle Bounds
        {
            get
            {
                return GetBounds(this.ToPointArray());
            }
        }

        /// <summary>
        /// 返回包含指定的点集合的方框对象
        /// </summary>
        /// <param name="ps">点坐标数组</param>
        /// <returns>包含所有点的方框对象,若没有数据则返回空方框对象</returns>
        public static System.Drawing.Rectangle GetBounds(System.Drawing.Point[] ps)
        {
            if (ps != null && ps.Length > 1)
            {
                int XMax = ps[0].X;
                int XMin = ps[0].X;
                int YMax = ps[0].Y;
                int YMin = ps[0].Y;
                for (int iCount = 0; iCount < ps.Length; iCount++)
                {
                    if (XMax < ps[iCount].X)
                        XMax = ps[iCount].X;
                    if (XMin > ps[iCount].X)
                        XMin = ps[iCount].X;

                    if (YMax < ps[iCount].Y)
                        YMax = ps[iCount].Y;
                    if (YMin > ps[iCount].Y)
                        YMin = ps[iCount].Y;
                }
                return new System.Drawing.Rectangle(XMin, YMin, XMax - XMin, YMax - YMin);
            }
            return System.Drawing.Rectangle.Empty;
        }//public static System.Drawing.Rectangle GetBounds( System.Drawing.Point[] ps)

        /// <summary>
        /// 返回包含指定的点集合的方框对象
        /// </summary>
        /// <param name="ps">点坐标数组</param>
        /// <returns>包含所有点的方框对象,若没有数据则返回空方框对象</returns>
        public static System.Drawing.RectangleF GetBounds(System.Drawing.PointF[] ps)
        {
            if (ps != null && ps.Length > 1)
            {
                float XMax = ps[0].X;
                float XMin = ps[0].X;
                float YMax = ps[0].Y;
                float YMin = ps[0].Y;
                for (int iCount = 0; iCount < ps.Length; iCount++)
                {
                    if (XMax < ps[iCount].X)
                        XMax = ps[iCount].X;
                    if (XMin > ps[iCount].X)
                        XMin = ps[iCount].X;

                    if (YMax < ps[iCount].Y)
                        YMax = ps[iCount].Y;
                    if (YMin > ps[iCount].Y)
                        YMin = ps[iCount].Y;
                }
                return new System.Drawing.RectangleF(XMin, YMin, XMax - XMin, YMax - YMin);
            }
            return System.Drawing.RectangleF.Empty;
        }//public static System.Drawing.Rectangle GetBounds( System.Drawing.Point[] ps)

    }//public class PointBuffer
}
