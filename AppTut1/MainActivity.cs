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
            FindViewById<Button>(Resource.Id.buttonLetterP).Click += (o, e) =>
            textView2.Text = "P";
            FindViewById<Button>(Resource.Id.buttonLetterA).Click += (o, e) =>
            textView2.Text = "A";
            FindViewById<Button>(Resource.Id.buttonLetterU).Click += (o, e) =>
            textView2.Text = "U";
            FindViewById<Button>(Resource.Id.buttonLetterL).Click += (o, e) =>
            textView2.Text = "L";
            FindViewById<Button>(Resource.Id.buttonLetterH).Click += (o, e) =>
            textView2.Text = "H";
            FindViewById<Button>(Resource.Id.buttonLetterO).Click += (o, e) =>
            textView2.Text = "O";
            FindViewById<Button>(Resource.Id.buttonLetterU2).Click += (o, e) =>
            textView2.Text = "U";
            FindViewById<Button>(Resource.Id.buttonLetterD).Click += (o, e) =>
            textView2.Text = "D";
            FindViewById<Button>(Resource.Id.buttonLetterE).Click += (o, e) =>
            textView2.Text = "E";
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}