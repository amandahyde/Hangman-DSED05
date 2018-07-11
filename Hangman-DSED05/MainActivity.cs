using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using Android.Views;
using System.IO;

namespace Hangman_DSED05
{
    [Activity(Label = "Hangman_DSED05", MainLauncher = true,  Icon = "@drawable/noose", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        private Button btnNext;
        private TextView txtName;





        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);



            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Startup();
        }





        private void Startup()
        {

            //bind the variables to layout controls
            txtName = FindViewById<TextView>(Resource.Id.etEnterName);
            btnNext = FindViewById<Button>(Resource.Id.btnNext);



            btnNext.Click += onNext_Click;




        }

        private void onNext_Click(object sender, EventArgs e)
        {

            //toast check to see its working
            Toast.MakeText(this, "Your name is " + txtName.Text, ToastLength.Long).Show();

            //create an intent to move data to the other activity.
            var gameActivity = new Intent(this, typeof(HangmanGame));
            gameActivity.PutExtra("Name", txtName.Text);

            //start game activity
            StartActivity(gameActivity);
        }

       
        }

    }



