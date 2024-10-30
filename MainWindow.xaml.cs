using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

/*
* FILE              : MainWindow.xaml.cs
* PROJECT           : Assignment 02 - WPF Application
* PROGRAMMER        : Evan O'Hara 7618127
* FIRST VERSION     : 2022-10-02
* DESCRIPTION       : C# code that corresponds with the MainWindow.xaml code/design. Deals with the interactions of certain menu
*                   : options that have been selected. Allows for the saving, creating, opening, and reading about the text editor
*                   : in the way that a reasonable person might expect.
*/

namespace A02_WPF_Not_Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool unchangedTextBox = true;  // a bool variable that tracks whether or not there have been changes to the user text
        private int characterCounter;          // an integer variable that counts the number of characters in the user text      


        /*  -- Method Header Comment
	    Name	:	MainWindow -- CONSTRUCTOR
	    Purpose :	to instantiate a new MainWindow object
	    Inputs	:	NONE
	    Outputs	:	NONE
	    Returns	:	Nothing
        */
        public MainWindow()
        {
            InitializeComponent();
        }


        /*  -- Method Header Comment
        Name	:	AccountNum -- PROPERTIES
        Purpose :	to get and set the unchangedTextBox variable
        Inputs	:	NONE
        Outputs	:	NONE
        Returns	:	unchangedTextBox
        */
        public bool UnchangedTextBox
        {
            get { return unchangedTextBox; }
            set { unchangedTextBox = value; }
        }


        /*  -- Method Header Comment
        Name	:	CharacterCounter -- PROPERTIES
        Purpose :	to get and set the characterCounter variable
        Inputs	:	NONE
        Outputs	:	NONE
        Returns	:	characterCounter
        */
        public int CharacterCounter
        {
            get { return characterCounter; }
            set { characterCounter = value; }
        }


        /*  -- Method Header Comment
        Name	:	mnuSave_Click
        Purpose :	to save the text in the text editor
        Inputs	:	object: sender          - parameter sender contains a reference to the object that raised the event
                :   RoutedEventArgs: e      - parameter e contains the event data
        Outputs	:	NONE
        Returns	:	NONE
        */
        private void mnuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, txtNotepad.Text);    // writes all the current text into a new file
                UnchangedTextBox = true;                                        // changes UnchangedTextBox back to true (Saved)
                NotepadWindow.Title = "Not Notepad WPF";                        // changes title to remove the '- Unsaved' part
            }
        }


        /*  -- Method Header Comment
        Name	:	mnuNew_Click
        Purpose :	to create a new instance of the text editor (really though it just clears what is already in the text editor)
        Inputs	:	object: sender          - parameter sender contains a reference to the object that raised the event
                :   RoutedEventArgs: e      - parameter e contains the event data
        Outputs	:	Asks the user if they want to save any changes if they have made any changes to the text editor since it was 
                :   first instantiated or last saved
        Returns	:	NONE
        */
        private void mnuNew_Click(object sender, RoutedEventArgs e)
        {
            if (UnchangedTextBox == true)                                           // indicating there are NO unsaved changes
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    txtNotepad.Text = File.ReadAllText(openFileDialog.FileName);    // reads the selected file text into the text editor
                    UnchangedTextBox = true;                                        // changes UnchangedTextBox back to true (Saved)
                    NotepadWindow.Title = "Not Notepad WPF";                        // changes title to remove the '- Unsaved' part
                }
            }
            else
            {
                if (MessageBox.Show("Do you want to save changes?", "Unsaved Changes", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    mnuSave_Click(sender, e);
                }
                else
                {
                    txtNotepad.Clear();                                     // clears all the text from the text box
                    UnchangedTextBox = true;                                // changes UnchangedTextBox back to true (Saved)
                    NotepadWindow.Title = "Not Notepad WPF";                // changes title to remove the '- Unsaved' part
                }
            }
        }


        /*  -- Method Header Comment
        Name	:	mnuOpen_Click
        Purpose :	to save the content in the text editor to a file
        Inputs	:	object: sender          - parameter sender contains a reference to the object that raised the event
                :   RoutedEventArgs: e      - parameter e contains the event data
        Outputs	:	Asks the user if they want to save any changes if they have made any changes to the text editor since it was 
                :   first instantiated or last saved
        Returns	:	NONE
        */
        private void mnuOpen_Click(object sender, RoutedEventArgs e)
        {
            if (UnchangedTextBox == true)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    txtNotepad.Text = File.ReadAllText(openFileDialog.FileName);    // reads the selected file text into the text editor
                    UnchangedTextBox = true;                                        // changes UnchangedTextBox back to true (Saved)
                    NotepadWindow.Title = "Not Notepad WPF";                        // changes title to remove the '- Unsaved' part
                }
            }
            else
            {
                if (MessageBox.Show("Do you want to save changes?", "Unsaved Changes", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    mnuSave_Click(sender, e);
                }
                else
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == true)
                    {
                        txtNotepad.Text = File.ReadAllText(openFileDialog.FileName);    // reads the selected file text into the text editor
                        UnchangedTextBox = true;                                        // changes UnchangedTextBox back to true (Saved)
                        NotepadWindow.Title = "Not Notepad WPF";                        // changes title to remove the '- Unsaved' part
                    }
                }
            }
        }


        /*  -- Method Header Comment
        Name	:	mnuExit_Click
        Purpose :	to exit the application
        Inputs	:	object: sender          - parameter sender contains a reference to the object that raised the event
                :   RoutedEventArgs: e      - parameter e contains the event data
        Outputs	:	Asks the user if they want to save any changes if they have made any changes to the text editor since it was 
                :   first instantiated or last saved
        Returns	:	NONE
        */
        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            if (UnchangedTextBox == true)
            {
                Application.Current.Shutdown();             // shuts down the application
            }
            else
            {
                if (MessageBox.Show("Do you want to save changes?", "Unsaved Changes", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    mnuSave_Click(sender, e);               // calls the mnuSave_Click method to save text
                }
                else
                {
                    Application.Current.Shutdown();         // shuts down the apllication
                }
            }
        }


        /*  -- Method Header Comment
        Name	:	mnuAbout_Click
        Purpose :	to display a new window that contains information about the text editor
        Inputs	:	object: sender          - parameter sender contains a reference to the object that raised the event
                :   RoutedEventArgs: e      - parameter e contains the event data
        Outputs	:	A new window containing information about the text editor - mainly its capabilities
        Returns	:	NONE
        */
        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutBox aboutBox = new AboutBox();         // creates new AboutBox object - aboutBox
            aboutBox.ShowDialog();                      // shows the dialog contain in AboutBox objects - user must
        }                                               // press the X in the top right corner to exit


        /*  -- Method Header Comment
        Name	:	txtNotepad_TextChanged
        Purpose :	to change the status of the unChangedTextBox variable to be false when there has been a change to the text
                :   editor after a save or the initial instantiation. The idea behind this method is to track whether or not 
                :   the user needs to be prompted to save their unsaved work.
        Inputs	:	object: sender          - parameter sender contains a reference to the object that raised the event
                :   RoutedEventArgs: e      - parameter e contains the event data
        Outputs	:	NONE
        Returns	:	NONE
        */
        private void txtNotepad_TextChanged(object sender, TextChangedEventArgs e)
        {
            UnchangedTextBox = false;                     // updates unchangedTextBox to be false

            CharacterCounter = txtNotepad.Text.Length;     // updates the charactercounter 
            tblCounter.Text = "Total Characters: " + CharacterCounter.ToString();

            if (UnchangedTextBox == false)
            {
                NotepadWindow.Title = "Not Notepad WPF - Unsaved";  // changes the top window title to indicate there are unsaved changes 
            }                                                       // to the text
        }
    }
}
