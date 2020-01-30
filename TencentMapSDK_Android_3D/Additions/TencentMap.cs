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

namespace Com.Tencent.Tencentmap.Mapsdk.Maps
{
    public partial class TencentMap : global::Com.Tencent.Tencentmap.Mapsdk.Maps.BaseMap, global::Com.Tencent.Map.Core.Interfaces.IMap
    {
        public override void SetMapStyle(int p0)
        {
            this.MapStyle = p0;
        }
    }
}