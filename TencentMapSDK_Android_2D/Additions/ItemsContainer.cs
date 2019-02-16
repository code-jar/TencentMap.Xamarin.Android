using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace Com.Tencent.Tencentmap.Mapsdk.Map
{
    public abstract partial class ItemizedOverlay : global::Com.Tencent.Tencentmap.Mapsdk.Map.Overlay
    {
        public partial class ItemsContainer : global::Java.Lang.Object, global::Java.Util.IComparator
        {
            int IComparator.Compare(Java.Lang.Object o1, Java.Lang.Object o2)
            {
                //   Com.Tencent.Tencentmap.Mapsdk.Map.IOnMarkerPressListener
                return this.Compare((Java.Lang.Integer)01, (Java.Lang.Integer)o2);
            }

            //bool IComparator.Equals(Java.Lang.Object obj)
            //{
            //    throw new NotImplementedException();
            //}
        }
    }

}