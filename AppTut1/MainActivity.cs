using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Bluetooth;
using Plugin.BLE;

namespace AppTut1
{
    [Activity(Label = "App1Tuto", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView textView2;
        int number = 0;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            var ble = CrossBluetoothLE.Current;
            var adapter = CrossBluetoothLE.Current.Adapter;
            var state = ble.State;
            ble.StateChanged += (s, e) =>
            {
                System.Diagnostics.Debug.Write($"The bluetooth state changed to {e.NewState}");
            };
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
            
            FindViewById<Button>(Resource.Id.buttonStartScan).Click += (o, e) =>
            {
                adapter.StartScanningForDevicesAsync();
            };

            FindViewById<Button>(Resource.Id.buttonStopScan).Click += (o, e) =>
            {
                adapter.StopScanningForDevicesAsync();
            };

            FindViewById<Button>(Resource.Id.buttonBTStatus).Click += (o, e) =>
            {
                System.Diagnostics.Debug.Write($"The bluetooth state changed to {ble.State}");
            };

            FindViewById<Button>(Resource.Id.buttonBTConnect).Click += (o, e) =>
            {
                textView2.Text = "Connecting";
            };

            adapter.DeviceDiscovered += (s, a) => 
            {
                System.Diagnostics.Debug.Write($"Device Found: {a.Device.Id}");
                System.Diagnostics.Debug.Write("-----------------");
            };

            

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }


}