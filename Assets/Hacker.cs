using UnityEngine;

public class Hacker : MonoBehaviour
{
    const string menupoint = "You may type menu at any time.";
    string[] level1password = { "gear", "clutch", "seatbelt", "door", "bumper" };
    string[] level2password = { "port", "starboard", "stern", "transom", "draft" };
    string[] level3password = { "jetengine", "elevator", "fuselage", "cockpit", "rudder" };
    int level;
    enum Screen { MainMenu, Password, WinScreen };
    Screen CurrentScreen;
    string password;

    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        CurrentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello,You are a hacker and you have to reach your destination asap!");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Select your Option: ");
        Terminal.WriteLine("Press 1 for the Car Showroom");
        Terminal.WriteLine("Press 2 for the Ship");
        Terminal.WriteLine("Press 3 for the Airlines");
        Terminal.WriteLine("Enter your selection.");
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab.");
            Application.Quit();
        }
        else if (CurrentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (CurrentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else
        {
            ShowMainMenu();
        }
    }


    void RunMainMenu(string input)
    {
        bool isValidNumber = (input == "1" || input == "2" || input == "3");
        if (isValidNumber)
        {
            level = int.Parse(input);
            Askforpassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please choose valid level,Mr. Bond");
        }
        else if (input == "47")
        {
            Terminal.WriteLine("Agent 47, choose valid level");
        }
        else
        {
            Terminal.WriteLine("Please,Choose valid level");
            Terminal.WriteLine(menupoint);
        }
    }
    void Askforpassword()
    {
        CurrentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menupoint);

    }
    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1password[Random.Range(0, level1password.Length)];
                break;
            case 2:
                password = level2password[Random.Range(0, level2password.Length)];
                break;
            case 3:
                password = level3password[Random.Range(0, level3password.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }

    }
    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Askforpassword();
        }
    }

    void DisplayWinScreen()
    {
        CurrentScreen = Screen.WinScreen;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menupoint);
    }
    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("You got the Car...");
                Terminal.WriteLine(@"
  ______
 /|_||_\`.__
(   _    _ _\
=`-(_)--(_)-' 
");
                Terminal.WriteLine("Play again for a greater challenge.");
                break;
            case 2:
                Terminal.WriteLine("You got the Boat...");
                Terminal.WriteLine(@"
                __/___            
          _____/______|           
  _______/_____\_______\_____     
  \              < < <       |    
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Terminal.WriteLine("Play again for a greater challenge.");
                break;
            case 3:
                Terminal.WriteLine("You got the plane...");
                Terminal.WriteLine(@"
     ____       _
    |__\_\_o,___/ \
   ([___\_\_____-\'
    | o'");
                Terminal.WriteLine("Play again for a greater challenge.");
                break;

        }
    }
}
