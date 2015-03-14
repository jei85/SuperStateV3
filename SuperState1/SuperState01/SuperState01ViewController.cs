using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.AVFoundation;
using MonoTouch.MediaPlayer;

namespace SuperState01
{


	public class TableSource : UITableViewSource{
		#region implemented abstract members of UITableViewSource

		string footertxt = "";

		private SuperState01ViewController parentController;

		public bool isPlaying = false;
		public List<int> removedItems = new List<int>();
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{

			int rowIndex = indexPath.Row;
			UITableViewCell cell = tableView.DequeueReusableCell (this.cellID);
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, this.cellID);

			// TODO: populate the cell with the appropriate data based on the indexPath
			cell.TextLabel.Text = this.tableData[rowIndex];

			return cell;
		}

		public override int NumberOfSections (UITableView tableView)
		{
			// TODO: return the actual number of sections
			return 1;
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			// TODO: return the actual number of items in the section
			return this.tableData.Count;

		}

		public override string TitleForHeader (UITableView tableView, int section)
		{
			return "Dagens økt:";
		}

		bool IsAudioFinished (object sender, AVStatusEventArgs e) 
		{
			return e.Status;
		}
		void HandleAudioFinished (object sender, AVStatusEventArgs e) 
		{
			KillAudioPlayer(); // killing audio player from here causes app to crash
		}

		void PlayAudio (string fileName)
		{

			isPlaying = true;
			bool IDoNotExist = false;
			if (!System.IO.File.Exists (fileName)) {
				//enter
				IDoNotExist = true;
			}
			else{
				var url = NSUrl.FromFilename(fileName);
				//AVAudioPlayer player = AVAudioPlayer.FromUrl(url);  


				parentController.player = AVAudioPlayer.FromUrl(url);    
				parentController.player.FinishedPlaying += HandleAudioFinished; 
				//(sender, e) => { player.Dispose(); };
				parentController.player.Play();

			}}

		void KillAudioPlayer ()
		{
			if (parentController.player != null)
			{
				BeginInvokeOnMainThread(() => {
					parentController.player.Stop();
					parentController.player.FinishedPlaying -= HandleAudioFinished;
					parentController.player.Dispose();
					parentController.player = null;
				} );
			}
			isPlaying = false;
		}


		/*
		public override string TitleForFooter2 (UITableView tableView, int section)
		{
			return "";
		}
		*/
		public override string TitleForFooter (UITableView tableView, int section)
		{
			return "";
		}

		public override UITableViewCellEditingStyle EditingStyleForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return UITableViewCellEditingStyle.None;
			// NOTE: Don't call the base implementation on a Model class
			// see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events
			//throw new NotImplementedException ();
		}

		public override string TitleForDeleteConfirmation (UITableView tableView, NSIndexPath indexPath)
		{   // Optional - default text is 'Delete'
			int noOfDeletedItems = removedItems.Count;
			return "Fullfør (" + noOfDeletedItems + " fullførte øvelser)";
		}

		public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editStyle, NSIndexPath indexPath)
		{
			if (editStyle == UITableViewCellEditingStyle.Delete)
			{
				this.tableData.RemoveAt (indexPath.Row);


				tableView.DeleteRows (new NSIndexPath[] {
					indexPath
				}
					, UITableViewRowAnimation.Automatic);

				//det legges i viewet, men viewet oppdateres ikke

				removedItems.Add (1);
			}

			//inserte i det andre viewet
			//CommonItems ci = new CommonItems ();
			//ci.UpdateData (indexPath.Row.ToString ());

			//var frame = new RectangleF(10, 10, 300, 30);
			var frame = new Rectangle();
			var label1 = new UILabel(frame);
			tableView.AddSubview (label1);
			//label1.Text = "skippet " + indexPath.Row.ToString ();
			footertxt = "skippet " + indexPath.Row.ToString ();
		}

		#endregion

		public readonly string cellID;
		//public Dictionary<int, String> tableData;
		public List<string> tableData { get; private set;} 
		string exerciseSelected;
		/*
		public TableSource () // : UITableViewSource
		{

			this.cellID = "cellIdentifier";
			//this.tableData = new Dictionary<int, String> ()
			//0, "Music"
			this.tableData = new List<string> ();
			tableData.Add ("Knebøy");
			tableData.Add ("Pushups");
			tableData.Add ("Situps");
			this.exerciseSelected = this.tableData[1];
		}
*/
		public TableSource (SuperState01ViewController controller) // : UITableViewSource
		{

			this.cellID = "cellIdentifier";
			//this.tableData = new Dictionary<int, String> ()
			//0, "Music"
			this.tableData = new List<string> ();
			tableData.Add ("Oppvarming");
			tableData.Add ("Knebøy");
			tableData.Add ("Push-up");
			tableData.Add ("Sit-up");
			tableData.Add ("Crunches");
			tableData.Add ("Benkpress");
			this.exerciseSelected = this.tableData[1];
			this.parentController = controller; 
		}
	
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{



				//KillAudioPlayer ();
				if (indexPath.ToString() ==  "0")
				{
					if (isPlaying) //!IsAudioFinished(parentController.player, AVStatusEventArgs.Empty))
					{
						KillAudioPlayer ();
					}
				PlayAudio ("mvp002.mp3");
				}
				if (indexPath.ToString() ==  "1")
				{
					if (isPlaying) //!IsAudioFinished(parentController.player, AVStatusEventArgs.Empty))
					{
						KillAudioPlayer ();
					}
					PlayAudio ("mvp002.mp3");
				}
				if (indexPath.ToString() ==  "2")
				{
					if (isPlaying) //!IsAudioFinished(parentController.player, AVStatusEventArgs.Empty))
					{
						KillAudioPlayer ();
					}
					PlayAudio ("mvp002.mp3");
				}
				if (indexPath.ToString() ==  "3")
				{
					if (isPlaying) //!IsAudioFinished(parentController.player, AVStatusEventArgs.Empty))
					{
						KillAudioPlayer ();
					}
					PlayAudio ("mvp002.mp3");
				}
					//new UIAlertView("Row Selected", tableView[indexPath.Row], null, "OK", null).Show();
				//tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight



		
		}
	}





	public class ExerciseItem
	{
		public int exerciseID {
			get;
			set;
		}
		public int kilos {
			get;
			set;
		}
		public int noOfSet {
			get;
			set;
		}
		public List<string> songsOfExerCise { get; private set;}  

	}

	public partial class SuperState01ViewController : UIViewController
	{

		/*
[[UINavigationBar appearance] setBackIndicatorImage:[UIImage imageNamed:@"back_btn.png"]];
    [[UINavigationBar appearance] setBackIndicatorTransitionMaskImage:[UIImage imageNamed:@"back_btn.png"]];

		*/

	
		private MPMusicPlayerController musicPlayer;
		private MPMediaPickerController mediaPicker;
		public AVAudioPlayer player;

		public SuperState01ViewController (IntPtr handle) : base (handle)
		{
		}



		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//myNavBar.SetBackgroundImage (UIImage.FromBundle ("superstate.jpg"), UIBarMetrics.Default); 
			//myNavBar.SetBackgroundImage (UIImage.FromBundle ("superstate.jpg"), UIBarMetrics.CompactPrompt); 
			myNavBar.SetBackgroundImage (UIImage.FromBundle ("superstateiconreDraw.jpg"), UIBarMetrics.CompactPrompt); 

			//[[UINavigationBar appearance] setBackgroundImage:[UIImage imageNamed:@"btn-title-bar.png"] forBarMetrics:UIBarMetricsDefault];

			//myNavBar.BackIndicatorImage = new UIImage(UIImage.FromFile("icon.png"));

			//myNavBar.BackIndicatorImage = new UIImage(NSData.FromFile("icon.png"));

			// Perform any additional setup after loading the view, typically from a nib.
			this.tblView.Source = new TableSource (this);
			//this.tblRemoved.Source = new CommonItems (this);
			//this.tblRemoved.Source =
		
		}

	

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		//musical stuff
		/*
		bool IDoNotExist = false;
		if (!System.IO.File.Exists (fileName)) {
			//enter
			IDoNotExist = true;
		}
		else{
			var url = NSUrl.FromFilename(fileName);
			//AVAudioPlayer player = AVAudioPlayer.FromUrl(url);	
			player = AVAudioPlayer.FromUrl(url);	
			player.FinishedPlaying += HandleAudioFinished; 
			//(sender, e) => { player.Dispose(); };
			player.Play();
		}}
*/
		public void SendComment(string text)
		{
			//base.ViewDidDisappear (animated);
		}

		partial void buttonDone_TouchUpInside (UIButton sender)
		{
			//throw new NotImplementedException ();
			/*
			UIAlertController alert = UIAlertController.Create ("Add Comments", "", UIAlertControllerStyle.Alert);

			alert.AddAction (UIAlertAction.Create ("Save", UIAlertActionStyle.Default, action => {
				SendComment(alert.TextFields[0].Text);
			}));

			alert.AddAction (UIAlertAction.Create ("Cancel", UIAlertActionStyle.Cancel, null));
			alert.AddTextField ((field) => {
				field.Placeholder = "Your Comment";
			});

*/

			UIAlertView alert = new UIAlertView();
			alert.Title = "Hvordan gikk økten?";
			alert.AddButton("Submit");
			alert.Message = "Beskriv progresjon:";
			alert.AlertViewStyle = UIAlertViewStyle.PlainTextInput;
			alert.Clicked += (object s, UIButtonEventArgs ev) => {
				// handle click event here
				// user input will be in alert.GetTextField(0).Text;
			};

			alert.Show();
		}
		#endregion
	}
}

