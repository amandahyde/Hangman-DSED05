using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Hangman_DSED05
{
    [Activity(Label = "HangmanGame")]
    public class HangmanGame : Activity
    {
        private TextView txtMessage;
        private String Name;
        private Button A;
        private Button B;
        private Button C;
        private Button D;
        private Button E;
        private Button F;
        private Button G;
        private Button H;
        private Button I;
        private Button J;
        private Button K;
        private Button L;
        private Button M;
        private Button N;
        private Button O;
        private Button P;
        private Button Q;
        private Button R;
        private Button S;
        private Button T;
        private Button U;
        private Button V;
        private Button W;
        private Button X;
        private Button Y;
        private Button Z;

        private ImageView imgDoom;

        private TextView ShowWord;

       

        public int Level = 0;
    
        public int Count = 0;

        List<string> WordList = new List<string>();


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Game);
            // Create your application here

            Name = Intent.GetStringExtra("Name");

            txtMessage = FindViewById<TextView>(Resource.Id.txtMessage);
            //txtMessage.Text = "Welcome to the game " + Name;
            //Toast.MakeText(this, "You are " + Name, ToastLength.Long).Show();

            ShowWord = FindViewById<TextView>(Resource.Id.lblShowWord);

            A = FindViewById<Button>(Resource.Id.btnA);
            B = FindViewById<Button>(Resource.Id.btnB);
            C = FindViewById<Button>(Resource.Id.btnC);
            D = FindViewById<Button>(Resource.Id.btnD);
            E = FindViewById<Button>(Resource.Id.btnE);
            F = FindViewById<Button>(Resource.Id.btnF);
            G = FindViewById<Button>(Resource.Id.btnG);
            H = FindViewById<Button>(Resource.Id.btnH);
            I = FindViewById<Button>(Resource.Id.btnI);
            J = FindViewById<Button>(Resource.Id.btnJ);
            K = FindViewById<Button>(Resource.Id.btnK);
            L = FindViewById<Button>(Resource.Id.btnL);
            M = FindViewById<Button>(Resource.Id.btnM);
            N = FindViewById<Button>(Resource.Id.btnN);
            O = FindViewById<Button>(Resource.Id.btnO);
            P = FindViewById<Button>(Resource.Id.btnP);
            Q = FindViewById<Button>(Resource.Id.btnQ);
            R = FindViewById<Button>(Resource.Id.btnR);
            S = FindViewById<Button>(Resource.Id.btnS);
            T = FindViewById<Button>(Resource.Id.btnT);
            U = FindViewById<Button>(Resource.Id.btnU);
            V = FindViewById<Button>(Resource.Id.btnV);
            W = FindViewById<Button>(Resource.Id.btnW);
            X = FindViewById<Button>(Resource.Id.btnX);
            Y = FindViewById<Button>(Resource.Id.btnY);
            Z = FindViewById<Button>(Resource.Id.btnZ);

            imgDoom = FindViewById<ImageView>(Resource.Id.ImgDoom);

            AlphabetLetters();
            LoadWords();
        }

        private void AlphabetLetters()
        {
            A.Click += letter_Click;
            B.Click += letter_Click;
            C.Click += letter_Click;
            D.Click += letter_Click;
            E.Click += letter_Click;
            F.Click += letter_Click;
            G.Click += letter_Click;
            H.Click += letter_Click;
            I.Click += letter_Click;
            J.Click += letter_Click;
            K.Click += letter_Click;
            L.Click += letter_Click;
            M.Click += letter_Click;
            N.Click += letter_Click;
            O.Click += letter_Click;
            P.Click += letter_Click;
            Q.Click += letter_Click;
            R.Click += letter_Click;
            S.Click += letter_Click;
            T.Click += letter_Click;
            U.Click += letter_Click;
            V.Click += letter_Click;
            W.Click += letter_Click;
            X.Click += letter_Click;
            Y.Click += letter_Click;
            Z.Click += letter_Click;

        }

        public void letter_Click(object sender, EventArgs e)
        {
            bool IsNoMatchedLetter = true;
            //make a fake button
            Button fakeBtn = (Button)sender;

            if (fakeBtn.Clickable)
            {
                //letter exists 
                for (int i = 0; i < Words.Word.Length; i++)
                {
                    var Letter = Words.Word[i];
                    
                    if (Letter.ToString().ToUpper() == fakeBtn.Text.ToUpper().ToString())
                    {
                        Words.WordGuess[i] = (char)Letter;
                        IsNoMatchedLetter = false;
                        Words.Letter = Words.Letter - 1;

                   
                        
                    }

                    
                   

                                 

                    WordToGuess();
                    //Toast.MakeText(this, Words.Word.ToString(), ToastLength.Long).Show(); 

                    //if (Letter.ToString().ToUpper() != fakeBtn.Text.ToUpper().ToString())
                    //{
                    //    Level++;

                    //}


                }


                if (IsNoMatchedLetter == true)
                {
                    Level++;
                    ChangeImage();
                }
                fakeBtn.Enabled = false;

                //if (Words.Letter == 0)

                //{
                //    Words.Wins++;
                //    FinishGame();
                //}


            }



            //if (fakeBtn.Text == copycurrentword)
            //{ Toast.MakeText(this, "!!! " + Name, ToastLength.Long).Show(); }
        }


      


    private void ChangeImage()
        {



            if (Level == 1)

            {
                imgDoom.SetImageResource(Resource.Drawable.hangmanstart);
            }

            else if (Level == 2)


            {
                imgDoom.SetImageResource(Resource.Drawable.hangman2);
            }

            else if (Level == 3)
            {
                imgDoom.SetImageResource(Resource.Drawable.hangman3);
            }

            else if (Level == 4)
            {
                imgDoom.SetImageResource(Resource.Drawable.hangman4);
            }

            else if (Level == 5)
            {
                imgDoom.SetImageResource(Resource.Drawable.hangman5);
            }
            else if (Level == 6)
            {
                imgDoom.SetImageResource(Resource.Drawable.hangman6);
            }
            else if (Level == 7)
            {
                imgDoom.SetImageResource(Resource.Drawable.hangmanend);
                Words.Losses++;
                Toast.MakeText(this, "You Lose", ToastLength.Long).Show();
           
               

                txtMessage.Text = Words.Losses.ToString();

                FinishGame();
            }

       
        }

        private void FinishGame()
        {

            //create an intent to move data to the other activity.
            var mainActivity = new Intent(this, typeof(MainActivity));
       

            //start game activity
            StartActivity(mainActivity);
        }

      

        private void LoadWords()
        {

            var assets = Assets;

            using (var sr = new StreamReader(assets.Open("hangmanwords.txt")))
            {
                while (!sr.EndOfStream)
                {
                    var text = sr.ReadLine();


                    if (text != string.Empty && text.Length > 4) //ignore empty lines or words less than 4 letters
                    {
                        text = text.Trim();



                        var word = text;

                        word = word.Trim();

                        //cut out the stuff you don't want

                        if (!WordList.Contains(word))
                        {

                            WordList.Add(word);
                        }
                    }


                }

                Random rand = new Random();


                int RndNumber = rand.Next(1, WordList.Count);


                Words.TheWord = WordList[RndNumber];



                char[] WordArray = new char[Words.TheWord.Length];




                WordArray = Words.TheWord.ToArray();

                Words.Word = WordArray;



                char[] WordGuessArray;

                string copycurrentword = "";

                foreach (char letter in Words.Word)

                {
                    copycurrentword += "_";
                    Words.Letter++;
                }

                //Toast.MakeText(this, , ToastLength.Long).Show();

                WordGuessArray = copycurrentword.ToArray();

                Words.WordGuess = WordGuessArray;

                WordToGuess();

            }


        }


        private void WordToGuess()

        {
            ShowWord.Text = new string(Words.WordGuess);
            //Toast.MakeText(this, Words.Word.ToString(), ToastLength.Long).Show();
        }

        private void ReplaceWithLetters()


        {




        }



    }

}