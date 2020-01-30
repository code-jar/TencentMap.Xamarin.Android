set locationVersion=7.2.4 
set oneVersion=1.3.4.1 
set twoVersion=4.3.1 

msbuild  ../TencentLocationSdk/TencentLocationSdk.csproj /t:Rebuild /p:Configuration=Release
msbuild  ../TencentMapSDK_Android_3D/TencentMapSDK_Android_3D.csproj /t:Rebuild /p:Configuration=Release
msbuild  ../TencentMapSDK_Android_2D/TencentMapSDK_Android_2D.csproj /t:Rebuild /p:Configuration=Release


nuget pack tencentlocation.xamarin.android.nuspec -Version %locationVersion%
nuget pack tencent2dmap.xamarin.android.nuspec -Version %oneVersion%
nuget pack tencent3dmap.xamarin.android.nuspec -Version %twoVersion%