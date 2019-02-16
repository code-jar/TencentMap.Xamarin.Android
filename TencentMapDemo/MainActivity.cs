using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Com.Tencent.Map.Geolocation;
using Com.Tencent.Tencentmap.Mapsdk.Map;
using Com.Tencent.Mapsdk.Raster.Model;
using Android.Content.PM;
using System.Collections.Generic;

namespace TencentMapDemo
{
    [Activity(Label = "腾讯地图", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private MapView mapView = null;
        private ITencentLocationListener locationListener = null;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            RequestPermissions();

            mapView = FindViewById<MapView>(Resource.Id.mapview);
            mapView.OnCreate(savedInstanceState);

            var locationManager = TencentLocationManager.GetInstance(this);
            var locationRequest = TencentLocationRequest.Create();
            locationListener = new LocationListener(this, mapView, locationManager, locationListener);
            var locationButton = FindViewById<ImageButton>(Resource.Id.locationButton);

            locationButton.Click += (sender, args) =>
            {
                int error = locationManager.RequestLocationUpdates(locationRequest, locationListener);
            };

        }

        protected override void OnDestroy()
        {
            mapView.OnDestroy();
            base.OnDestroy();
        }
        protected override void OnPause()
        {
            mapView.OnPause();
            base.OnPause();
        }
        protected override void OnResume()
        {
            mapView.OnResume();
            base.OnResume();
        }
        protected override void OnStop()
        {
            mapView.OnStop();
            base.OnStop();
        }
        protected override void OnRestart()
        {
            mapView.OnRestart();
            base.OnRestart();
        }

        private void RequestPermissions()
        {
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                string[] permissions = { Android.Manifest.Permission.AccessCoarseLocation, Android.Manifest.Permission.ReadPhoneState, Android.Manifest.Permission.WriteExternalStorage };

                if (CheckSelfPermission(permissions[0]) != Permission.Granted)
                {
                    RequestPermissions(permissions, 0);
                }

            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }


    public class LocationListener : Java.Lang.Object, ITencentLocationListener
    {
        private readonly Android.Content.Context _ctx;
        private readonly MapView _mapView;
        private readonly TencentLocationManager _locationManager;
        private readonly ITencentLocationListener _locationListener;

        public LocationListener(Android.Content.Context ctx, MapView view, TencentLocationManager manager, ITencentLocationListener listener)
        {
            _ctx = ctx;
            _mapView = view;
            _locationManager = manager;
            _locationListener = listener;
        }

        private Marker LocationMarker = null;

        public void OnLocationChanged(ITencentLocation location, int error, string reason)
        {
            if (TencentLocation.ErrorOk == error)
            {
                if (LocationMarker != null)
                {
                    LocationMarker.Remove();
                }

                var markerOption = new MarkerOptions();

                var latlng = new LatLng(location.Latitude, location.Longitude);
                markerOption.InvokePosition(latlng);
                markerOption.InvokeTitle(location.Name);
                markerOption.Anchor(0.5f, 0.5f);
                markerOption.InvokeIcon(BitmapDescriptorFactory.DefaultMarker());
                LocationMarker = _mapView.AddMarker(markerOption);
                LocationMarker.ShowInfoWindow();
                _mapView.Map.SetZoom(16);
                _mapView.Map.SetCenter(latlng);
                // 定位成功
                Toast.MakeText(_ctx, $"定位成功:{location.Address}", ToastLength.Long).Show();
            }
            else
            {
                // 定位失败
                Toast.MakeText(_ctx, $"定位失败:error:{error},reason:{reason}", ToastLength.Long).Show();
            }
            _locationManager.RemoveUpdates(_locationListener);
        }

        public void OnStatusUpdate(string p0, int p1, string p2)
        {
            //throw new NotImplementedException();
        }
    }

    public class EasyPermisssionCallbacks : Java.Lang.Object, Pub.Devrel.Easypermissions.EasyPermissions.IPermissionCallbacks
    {
        public void OnPermissionsDenied(int p0, IList<string> p1)
        {
            throw new System.NotImplementedException();
        }

        public void OnPermissionsGranted(int p0, IList<string> p1)
        {
            throw new System.NotImplementedException();
        }

        public void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            throw new System.NotImplementedException();
        }
    }
}