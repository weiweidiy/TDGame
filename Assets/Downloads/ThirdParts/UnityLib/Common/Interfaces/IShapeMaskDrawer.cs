using System;
using UnityEngine;

namespace Game.Common
{
    //public interface IShapeMaskTargetable<T>
    //{
    //    T GetTarget();

    //    void SetTarget(T target);

    //    void ShowShapeMask();
    //}

   
    public interface IShapeMaskDrawer
    {
        void ShowShapeMask(Rect rt);

        void RefreshShape();
    }
}