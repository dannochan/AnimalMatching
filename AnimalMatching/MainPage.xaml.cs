namespace AnimalMatching;

public partial class MainPage : ContentPage
{
	Button lastClickedButton; 
	bool findingMatch = false; 
	int matchesFound; 
	int tenthOfSecondsElapsed = 0;

	public MainPage()
	{
		InitializeComponent();
	}


	private void PlayAgainButton_Clicked(object sender, EventArgs e)
	{
		AnimalButtons.IsVisible = true; // show the buttons
		PlayAgainButton.IsVisible = false; // Hide the play again button

		List<string> animalEmoji = [
			"🫏" , "🫏" , 
			"🐒", "🐒", 
			"🐅" , "🐅",
			"🐘", "🐘",
			"🦬", "🦬",
			"🦏", "🦏",
			"🐊", "🐊",
			"🐫", "🐫",	
		]; 

		foreach (var button in AnimalButtons.Children.OfType<Button>()){
			int index = Random.Shared.Next(animalEmoji.Count);
			string nextEmoji = animalEmoji[index]; 
			button.Text = nextEmoji; 
			animalEmoji.RemoveAt(index);
		}
		Dispatcher.StartTimer(TimeSpan.FromSeconds(1), TimerTick);

	}

    private bool TimerTick()
    {
		

        if(!this.IsLoaded)
			return false;
		

		tenthOfSecondsElapsed++; 

		TimeElapsed.Text = "Time elapsed: " + (tenthOfSecondsElapsed / 10F).ToString("0.0s"); 

		if(PlayAgainButton.IsVisible){
			tenthOfSecondsElapsed =0; 
			return false; 
		}

		return true; 
    }

    private void Button_Clicked(object sender, EventArgs e)
	{
		if( sender is Button buttonClicked){
			if(!string.IsNullOrWhiteSpace(buttonClicked.Text) && (findingMatch == false)){
				buttonClicked.BackgroundColor = Colors.Red; 
				lastClickedButton = buttonClicked;
				findingMatch = true;

			}else {
			if(buttonClicked != lastClickedButton && buttonClicked.Text == lastClickedButton.Text && 
			!string.IsNullOrEmpty(buttonClicked.Text)) {
				matchesFound++; 
				lastClickedButton.Text = ""; 
				buttonClicked.Text = "";
			}
			lastClickedButton.BackgroundColor = Colors.LightBlue;
			buttonClicked.BackgroundColor = Colors.LightBlue;
			findingMatch = false;
		} 
		}

		if(matchesFound == 8){
			matchesFound = 0; 
			AnimalButtons.IsVisible = false;
			PlayAgainButton.IsVisible = true; 
		}

	}

}

