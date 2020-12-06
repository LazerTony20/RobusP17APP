using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Bluetooth;
using Plugin.BLE;
using System.Collections.Generic;

namespace AppTut1
{
    [Activity(Label = "App1Tuto", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView textView2;
        List<object> devicelist = new List<object>();
        

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
            FindViewById<Button>(Resource.Id.buttonLetterC).Click += (o, e) =>
            textView2.Text = "C";
            FindViewById<Button>(Resource.Id.buttonLetterD).Click += (o, e) =>
            textView2.Text = "D";
            FindViewById<Button>(Resource.Id.buttonLetterJ).Click += (o, e) =>
            textView2.Text = "J";
            FindViewById<Button>(Resource.Id.buttonLetterL).Click += (o, e) =>
            textView2.Text = "L";
            FindViewById<Button>(Resource.Id.buttonLetterT).Click += (o, e) =>
            textView2.Text = "T";
            FindViewById<Button>(Resource.Id.buttonLetterV).Click += (o, e) =>
            textView2.Text = "V";
            FindViewById<Button>(Resource.Id.buttonLetterZ).Click += (o, e) =>
            textView2.Text = "Z";
            
            FindViewById<Button>(Resource.Id.buttonStartScan).Click += (o, e) =>
            {
                adapter.StartScanningForDevicesAsync();
            };

            FindViewById<Button>(Resource.Id.buttonStopScan).Click += (o, e) => adapter.StopScanningForDevicesAsync();

            FindViewById<Button>(Resource.Id.buttonBTStatus).Click += (o, e) =>
            {
                System.Diagnostics.Debug.Write($"The bluetooth state changed to {ble.State}");
            };

            FindViewById<Button>(Resource.Id.buttonBTConnect).Click += (o, e) =>
            {
                textView2.Text = "Connecting";
                //adapter.ConnectToDeviceAsync("0000ffe0-0000-1000-8000-00805f9b34fb");
            };

            adapter.DeviceDiscovered += (s, a) => 
            {
                devicelist.Add(a.Device);
                System.Diagnostics.Debug.Write($"{a.Device.Id}");
                if(a.Device.Id.ToString() == "0000ffe0-0000-1000-8000-00805f9b34fb")
                {
                    adapter.ConnectToDeviceAsync(a.Device);
                    textView2.Text = "Connecting";
                    System.Diagnostics.Debug.Write("Connecting");
                    System.Diagnostics.Debug.Write("Connecting");
                    System.Diagnostics.Debug.Write("Connecting");
                    System.Diagnostics.Debug.Write("Connecting");
                }
                System.Diagnostics.Debug.Write("-----------------");
            };

            ble.StateChanged += (s, e) =>
            {
                System.Diagnostics.Debug.WriteLine($"The bluetooth state changed to {e.NewState}");
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }


}