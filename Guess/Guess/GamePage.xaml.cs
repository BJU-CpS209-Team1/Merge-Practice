using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Guess {
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class GamePage : ContentPage {
    int number;
    int guess;
    Random random = new Random();

    public GamePage(int difficulty) {
      InitializeComponent();
      SetDifficulty(difficulty);
    }

    private void btnGuess_Clicked(object sender, EventArgs e) {
      try {
        guess = Convert.ToInt32(entryGuess.Text);
        CheckGuess();
      } catch {
        DisplayAlert("Invalid guess", "Please enter a number as your guess", "Make me");
      }
    }

    private void CheckGuess() {
      if (guess == number) 
        DisplayWin();

      if (Math.Abs(number - guess) > 10) {
        labelOutput.Text = "Not even close.";
      } else if (guess > number) {
        labelOutput.Text = "Too high.";
      } else if (guess < number) {
        labelOutput.Text = "Too low.";
      } else {
        labelOutput.Text = "";
      }
    }

    // Credit:
    // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/navigation/pop-ups
    // https://stackoverflow.com/questions/29257929/how-to-terminate-a-xamarin-application
    async void DisplayWin() {
      bool playAgain = await DisplayAlert("You win.", "Would you like to play again?", "Yes, master.", "Go home.");      
      if (playAgain) {
        App.Current.MainPage = new MainPage();
      } else {
        Process.GetCurrentProcess().Kill();
      }      
    }

    private void SetDifficulty(int difficulty) {
      if (difficulty == 0) {
        // Easy
        number = random.Next(0, 10);
        labelHeader.Text = "Guess a number from 1 to 10";
      } else if (difficulty == 1) {
        // Medium
        number = random.Next(0, 20);
        labelHeader.Text = "Guess a number from 1 to 20";
      } else if (difficulty == 2) {
        // Hard
        number = random.Next(0, 50);
        labelHeader.Text = "Guess a number from 1 to 50";
      }
    }

    private void btnCheat_Clicked(object sender, EventArgs e) {
      DisplayCheat(0);
    }

    async void DisplayCheat(int cheatNumber) {
      bool cheat;

      switch (cheatNumber) {
        case 0:
          cheat = await DisplayAlert("Really?", "Cheating is not cool. Are you really sure you want to do this?", "I'm sure.", "No, sorry!");
          break;
        case 1:
          cheat = await DisplayAlert("Come on!", "I can't believe you did that.", "I can believe it.", "I misclicked.");
          break;
        case 2:
          cheat = await DisplayAlert("Are you serious?", "I thought I warned you about this already?", "I wasn't listening.", "Forgive me.");
          break;
        case 3:
          cheat = await DisplayAlert("I'm disappointed in you.", "You don't want me to feel this way do you?", "Computers have no soul.", "Ok fine.");
          break;
        case 4:
          cheat = await DisplayAlert("Proverbs 28:6", "Whoever walks in integrity walks securely, but he who makes his ways crooked will be found out.", "Good to know.", "I don't want to be found out!");
          break;
        case 5:
          cheat = await DisplayAlert("James 4:17", "So whoever knows the right thing to do and fails to do it, for him it is sin.", "I will fail.", "I don't want to sin!");
          break;
        case 6:
          cheat = await DisplayAlert("Ok, fine.", "You really want to do this don't you? Your family and friends will never like you again. You will lose your job and all your money. You will be forced to live with nothing but a broken conscience and a stupid number you could have figured out in ten seconds.", "Shut up already!", "You've convinced me.");
          break;
        default:
          cheat = false;
          break;
      }
       
      if (cheat && cheatNumber < 6) {
        DisplayCheat(++cheatNumber);
      } else if (cheatNumber == 6) {
        await DisplayAlert("I take no part in this iniquity.", $"I can't believe you made me give this to you. I feel really sorry for what's about to happen to you and your poor family. Don't say I didn't warn you. \r\n\r\n The secret number is {number}", "Destroy the world.");
        return;
      } else {
        return;
      }
    }

  }
}