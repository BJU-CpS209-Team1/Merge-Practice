using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Guess {
  public partial class MainPage : ContentPage {
    public MainPage() {
      InitializeComponent();

      pickDifficulty.Items.Add("Easy");
      pickDifficulty.Items.Add("Medium");
      pickDifficulty.Items.Add("Hard");

      // Defaut to Easy
      pickDifficulty.SelectedIndex = 1;
            // hi isaac
            // hi again
    }

    private void btnStart_Clicked(object sender, EventArgs e) {
      App.Current.MainPage = new GamePage(pickDifficulty.SelectedIndex);
    }
  }
}
