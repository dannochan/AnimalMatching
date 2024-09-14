namespace AnimalMatching;

public partial class MainPage : ContentPage
{
	List<string> selectedEmoji = new List<string>(2);
	Boolean isRunning; 
	Boolean isMatch; 
	int matchCount;


	public MainPage()
	{
		InitializeComponent();
		isRunning = false; 
		isMatch = false;
		matchCount = 0;
	}


	private void PlayAgainButton_Clicked(object sender, EventArgs e)
	{
		isRunning = true;
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


	}
	private void Button_Clicked(object sender, EventArgs e)
	{
		// get the first button clicked
			Button button = (Button)sender;
			button.BackgroundColor = Colors.Red;
			selectedEmoji.Add(button.Text);

		if(selectedEmoji.Count >= 2){
			if(selectedEmoji[0] == selectedEmoji[1]){
				// if the text of the buttons are the same, then they are a match
				// remove the emoji from the list
				isMatch = true;
				matchCount += 1;
				ReplaceMatchedButtons(selectedEmoji[0]);
				CheckMatchFound();
				selectedEmoji.Clear();
			}else {
				// if the text of the buttons are not the same, then they are not a match
				// reset the color of the buttons
				isMatch = false;
				selectedEmoji.Clear();
			}
		}

	}

	private void ReplaceMatchedButtons(string emoji){
		foreach (var button in AnimalButtons.Children.OfType<Button>()){
			if(button.Text == emoji){
				button.Text = "";
				button.BackgroundColor = Colors.White;
			}
		}
	}

	private void CheckMatchFound(){
		if(matchCount == 8){
			AnimalButtons.IsVisible = false;
			PlayAgainButton.IsVisible = true;
			isRunning = false;
			matchCount = 0;
		}
	}
}

