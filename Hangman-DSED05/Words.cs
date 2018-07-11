using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Hangman_DSED05
{
 public static  class Words
    {

        public static char[] WordGuess { get; set; }

        public static char[] Word { get; set; }

        public static string word { get; set; }

        public static string wordguess { get; set; }

        public static int Level { get; set; }

        public static string TheWord { get; set; }

        public static int Losses { get; set; }
        
        public static int Wins { get; set; }

        public static int Letter { get; set; }

    }


}