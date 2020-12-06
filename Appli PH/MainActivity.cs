using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Plugin.BluetoothLE;
using Android.Bluetooth;


namespace Appli_PH
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView textView2;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //-------------------------------------------------------------------------------------//
            //var ble = CrossBluetoothLE.Current;
            var ble = CrossBleAdapter.Current;
            var adapter = CrossBleAdapter.Current;
            var server = CrossBleAdapter.Current.CreateGattServer();
            //var service = ;
            //var service = server.addService(Guid.NewGuid(), true);
            var characteristic = service.AddCharacteristic(Guid.NewGuid(),CharacteristicProperties.Read | CharacteristicProperties.Write | CharacteristicProperties.WriteNoResponse, GattPermissions.Read | GattPermissions.Write);
            var notifyCharacteristic = service.AddCharacteristic(Guid.NewGuid(), CharacteristicProperties.Indicate | CharacteristicProperties.Notify, GattPermissions.Read | GattPermissions.Write);
            //-------------------------------------------------------------------------------------//
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
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

            /*FindViewById<Button>(Resource.Id.buttonStartScan).Click += (o, e) =>
            {
                scanner.StartScanningForDevicesAsync();
            };
            */
            var scanner = CrossBleAdapter.Current.Scan().Subscribe(scanResult =>
            {
                // do something with it
                // the scanresult contains the device, RSSI, and advertisement packet

            });

            FindViewById<Button>(Resource.Id.buttonStopScan).Click += (o, e) => scanner.Dispose(); // to stop scanning

            FindViewById<Button>(Resource.Id.buttonBTStatus).Click += (o, e) =>
            {
                System.Diagnostics.Debug.Write($"The bluetooth state changed to {ble.State}");
            };

            FindViewById<Button>(Resource.Id.buttonBTConnect).Click += (o, e) =>
            {
                textView2.Text = "Connecting";
                //adapter.ConnectToDeviceAsync("0000ffe0-0000-1000-8000-00805f9b34fb");
            };

            /*adapter.DeviceDiscovered += (s, a) =>
            {
                devicelist.Add(a.Device);
                System.Diagnostics.Debug.Write($"{a.Device.Id}");
                if (a.Device.Id.ToString() == "0000ffe0-0000-1000-8000-00805f9b34fb")
                {
                    adapter.ConnectToDeviceAsync(a.Device);
                    textView2.Text = "Connecting";
                    System.Diagnostics.Debug.Write("Connecting");
                    System.Diagnostics.Debug.Write("Connecting");
                    System.Diagnostics.Debug.Write("Connecting");
                    System.Diagnostics.Debug.Write("Connecting");
                }
                System.Diagnostics.Debug.Write("-----------------");
            };*/

            /*ble.StateChanged += (s, e) =>
            {
                System.Diagnostics.Debug.WriteLine($"The bluetooth state changed to {e.NewState}");
            };
            */

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, CrossBleAdapter.Current.Status.ToString(), Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
