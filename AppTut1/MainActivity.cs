using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace AppTut1
{
    [Activity(Label = "App1Tuto", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView textView2;
        int number;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            textView2 = FindViewById<TextView>(Resource.Id.textView2);
            FindViewById<Button>(Resource.Id.buttonIncrement).Click += (o, e) =>
            textView2.Text = (++number).ToString();
            FindViewById<Button>(Resource.Id.buttonDecrement).Click += (o, e) =>
            textView2.Text = (--number).ToString();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}