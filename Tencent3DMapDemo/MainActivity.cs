using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Com.Tencent.Tencentmap.Mapsdk.Maps;
using Android.Support.V4.App;
using Android.Locations;

namespace Tencent3DMapDemo
{
    [Activity(Label = "腾讯3D地图", Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        private TencentMap _map;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.mapFragment);
            _map = mapFragment.Map;

        }
    }
    

}