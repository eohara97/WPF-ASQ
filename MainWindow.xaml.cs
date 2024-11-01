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


        // Update window title to indicate unsaved changes
        private void UpdateWindowTitle(bool isUnsaved)
        {
            NotepadWindow.Title = isUnsaved ? "Not Notepad WPF - Unsaved" : "Not Notepad WPF";
        }

        // Consolidated method to save content
        private void SaveContent()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, txtNotepad.Text);
                UnchangedTextBox = true;
                UpdateWindowTitle(false);
            }
        }

        // Method to open and load content from a file
        private void LoadContentFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtNotepad.Text = File.ReadAllText(openFileDialog.FileName);
                UnchangedTextBox = true;
                UpdateWindowTitle(false);
            }
        }

        private bool PromptSaveIfUnsaved()
        {
            if (UnchangedTextBox == false)
            {
                var result = MessageBox.Show("Do you want to save changes?", "Unsaved Changes", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    SaveContent();
                }
                return result == MessageBoxResult.Yes;
            }
            return true;
        }

        /*  -- Method Header Comment
        Name	:	mnuSave_Click
        Purpose :	to save the text in the text editor
        Inputs	:	object: sender - reference to the object that raised the event
        :   RoutedEventArgs: e - event data
        Outputs	:	NONE
        Returns	:	NONE
        */
        private void mnuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveContent();
        }

        /*  -- Method Header Comment
        Name	:	mnuNew_Click
        Purpose :	to create a new instance of the text editor (clears existing text)
        Inputs	:	object: sender - reference to the object that raised the event
                :   RoutedEventArgs: e - event data
        Outputs	:	Clears the text editor after prompting to save any unsaved changes
        Returns	:	NONE
        */
        private void mnuNew_Click(object sender, RoutedEventArgs e)
        {
            if (PromptSaveIfUnsaved())
            {
                txtNotepad.Clear();
                UnchangedTextBox = true;
                UpdateWindowTitle(false);
            }
        }

        /*  -- Method Header Comment
        Name	:	mnuOpen_Click
        Purpose :	to open a file and load its content into the text editor
        Inputs	:	object: sender - reference to the object that raised the event
                :   RoutedEventArgs: e - event data
        Outputs	:	Loads file content after prompting to save any unsaved changes
        Returns	:	NONE
        */
        private void mnuOpen_Click(object sender, RoutedEventArgs e)
        {
            if (PromptSaveIfUnsaved())
            {
                LoadContentFromFile();
            }
        }

        /*  -- Method Header Comment
        Name	:	mnuExit_Click
        Purpose :	to exit the application
        Inputs	:	object: sender - reference to the object that raised the event
                :   RoutedEventArgs: e - event data
        Outputs	:	Exits the application after prompting to save any unsaved changes
        Returns	:	NONE
        */
        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            if (PromptSaveIfUnsaved())
            {
                Application.Current.Shutdown();
            }
        }

        /*  -- Method Header Comment
        Name	:	mnuAbout_Click
        Purpose :	to display a window with information about the text editor
        Inputs	:	object: sender - reference to the object that raised the event
                :   RoutedEventArgs: e - event data
        Outputs	:	Displays an information dialog
        Returns	:	NONE
        */
        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        /*  -- Method Header Comment
        Name	:	txtNotepad_TextChanged
        Purpose :	to update the status of UnchangedTextBox and character count when text changes
        Inputs	:	object: sender - reference to the object that raised the event
                :   TextChangedEventArgs: e - event data
        Outputs	:	Updates UnchangedTextBox and character counter
        Returns	:	NONE
        */
        private void txtNotepad_TextChanged(object sender, TextChangedEventArgs e)
        {
            UnchangedTextBox = false;
            CharacterCounter = txtNotepad.Text.Length;
            tblCounter.Text = "Total Characters: " + CharacterCounter.ToString();
            UpdateWindowTitle(true);
        }


        /*  -- Method Header Comment
        Name	:	BrainMethod
        Purpose :	A complex, deeply nested method added for testing CodeScene’s complexity detection
        Inputs	:	NONE
        Outputs	:	Complex nested logic without actual functionality
        Returns	:	string - a placeholder return value to complete the method
        */
        private string BrainMethod()
        {
            // Starting a complex function with deeply nested conditionals and loops
            string result = "";
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (j > 1)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                if (k == 2)
                                {
                                    result += "Nested"; // Dummy operation
                                }
                                else
                                {
                                    for (int m = 0; m < 2; m++)
                                    {
                                        if (m == 1)
                                        {
                                            result += " Complexity"; // Dummy operation
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int n = 0; n < 2; n++)
                    {
                        if (n == 1)
                        {
                            result += " Detected"; // Dummy operation
                        }
                    }
                }
            }
            return result;
        }
    }
}
