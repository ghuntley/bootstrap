// The following attributes are used to specify the signing key for the assembly,
// if desired. See the Mono documentation for more information about signing.
//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]

using System.Reflection;
using System.Runtime.CompilerServices;

using Android.App;

// Prevent GooglePlay from filtering out devices without WiFi capability.
// https://github.com/jamesmontemagno/Xamarin.Plugins/tree/master/Connectivity#important
[assembly: UsesFeature("android.hardware.wifi", Required = false)]

