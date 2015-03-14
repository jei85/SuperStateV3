// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace SuperState01
{
	[Register ("SuperState01ViewController")]
	partial class SuperState01ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton buttonDone { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UINavigationBar myNavBar { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView myTextView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tblView { get; set; }

		[Action ("buttonDone_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void buttonDone_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (buttonDone != null) {
				buttonDone.Dispose ();
				buttonDone = null;
			}
			if (myNavBar != null) {
				myNavBar.Dispose ();
				myNavBar = null;
			}
			if (myTextView != null) {
				myTextView.Dispose ();
				myTextView = null;
			}
			if (tblView != null) {
				tblView.Dispose ();
				tblView = null;
			}
		}
	}
}
