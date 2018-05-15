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
    class Words
    {

        public static char[] WordGuess { get; set; }

        public static char[] Word { get; set; }

        public string word { get; set; }

        public string wordguess { get; set; }

        public int Level { get; set; }
    }


}