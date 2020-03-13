﻿using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using FFImageLoading.Forms.Platform;
using Xamarin.Essentials;
using Acr.UserDialogs;

namespace EduCATS.Droid
{
	[Activity(Label = "EduCATS", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		internal static MainActivity Instance { get; private set; }

		protected override void OnCreate(Bundle savedInstanceState)
		{
			Instance = this;
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;
			base.OnCreate(savedInstanceState);
			initPackages(savedInstanceState);
			LoadApplication(new App());
		}

		void initPackages(Bundle savedInstanceState)
		{
			Platform.Init(this, savedInstanceState);
			Xamarin.Forms.Forms.Init(this, savedInstanceState);
			CachedImageRenderer.Init(enableFastRenderer: true);
			UserDialogs.Init(this);
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
		{
			Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}
	}
}