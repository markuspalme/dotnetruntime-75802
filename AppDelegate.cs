using System;
using Foundation;
using Newtonsoft.Json;

namespace testapp;

public class ProductImage : IEntity
{
	public string ProductNumber { get; set; }

	public Guid Id { get; set; }
}

public interface IEntity
{
	Guid Id { get; set; }
}

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {
	public override UIWindow? Window {
		get;
		set;
	}

	public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
		// create a new window instance based on the screen size
		Window = new UIWindow (UIScreen.MainScreen.Bounds);

		var x = @"{
                ""productNumber"": ""P1"",
                ""id"": ""46c67d7c-fd15-4d89-9fed-991c48c1bacf""
            }";

		var msg = "";

		try
		{
			//var pi = System.Text.Json.JsonSerializer.Deserialize<ProductImage>(x);
			var pi = Newtonsoft.Json.JsonConvert.DeserializeObject<ProductImage>(x);
			msg = pi.ProductNumber + " - " + pi.Id;
		}
		catch (Exception e)
		{
			msg = e.Message + Environment.NewLine + e.StackTrace;
		}

		// create a UIViewController with a single UILabel
		var vc = new UIViewController ();
		vc.View!.AddSubview (new UILabel (Window!.Frame) {
			BackgroundColor = UIColor.SystemBackground,
			TextAlignment = UITextAlignment.Center,
			Text = msg,
			Lines = 0,
			AutoresizingMask = UIViewAutoresizing.All,
		});
		Window.RootViewController = vc;

		// make the window visible
		Window.MakeKeyAndVisible ();

		return true;
	}
}
