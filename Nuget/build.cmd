set locationVersion=7.1.6.1
set 2dMapVersion=1.3.2
set 3dMapVersion=4.2.3

msbuild  ../TencentLocationSdk/TencentLocationSdk.csproj /t:Rebuild /p:Configuration=Release
msbuild  ../TencentMapSDK_Android_3D/TencentMapSDK_Android_3D.csproj /t:Rebuild /p:Configuration=Release
msbuild  ../TencentMapSDK_Android_2D/TencentMapSDK_Android_2D.csproj /t:Rebuild /p:Configuration=Release


nuget pack tencentlocation.xamarin.android.nuspec -Version %locationVersion%
nuget pack tencent2dmap.xamarin.android.nuspec -Version %2dMapVersion%
nuget pack tencent3dmap.xamarin.android.nuspec -Version %3dMapVersion%