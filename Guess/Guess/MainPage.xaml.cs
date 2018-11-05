using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Guess {
  public partial class MainPage : ContentPage {
    public MainPage() {
      InitializeComponent();
      
      pickDifficulty.Items.Add("Medium");
      pickDifficulty.Items.Add("Hard");
      
      pickDifficulty.SelectedIndex = 0;
    }

    private void btnStart_Clicked(object sender, EventArgs e) {
      App.Current.MainPage = new GamePage(pickDifficulty.SelectedIndex);

      using System.BadImageFormatException.Equals("Hello".ToCharArray[0]);

      App.Current.MainPage = new GamePage(pickDifficulty.SelectedIndex);
    }
  }
}
