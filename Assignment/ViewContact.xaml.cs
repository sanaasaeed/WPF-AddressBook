using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Assignment {
  /// <summary>
  /// Interaction logic for ViewContact.xaml
  /// </summary>
  public partial class ViewContact : Window {
    public string CurrentStudentEmail;
    public List<Student> Students;
    public List<AddressBook> addresses;
    public ViewContact(string currentStudentEmail, List<Student> students) {
      InitializeComponent();
      this.CurrentStudentEmail = currentStudentEmail;
      this.Students = students;
      foreach (var student in Students) {
        if (student.Email == CurrentStudentEmail) {
          addresses = student.Addresses;
        }
      }
      ComboContacts.ItemsSource = addresses;
      
    }
    public ViewContact() {
      InitializeComponent();
    }
    // back and logout btns
    private void BackBtnClick(object sender, RoutedEventArgs e) {
      var home = new Home(CurrentStudentEmail, Students);
      home.Show();
      Close();
    }
    private void LogOutClick(object sender, RoutedEventArgs e) {
      var login = new MainWindow(Students);
      login.Show();
      Close();
    }
    // When we click edit or update, Textboxes are enabled
    private void UpdateBtnClick(object sender, RoutedEventArgs e) {
      FirstNameTb.IsEnabled = true;
      LastNameTb.IsEnabled = true;
      PhoneNumTb.IsEnabled = true;
      CompanyTb.IsEnabled = true;
      JobTb.IsEnabled = true;
      AddressTb.IsEnabled = true;
      ComboContacts.Items.Refresh();
    }
    // On changing combo box item list should be visible
    private void OnChange(object sender, SelectionChangedEventArgs e) {
      canvasX.Visibility = Visibility.Visible;
      StackPanelBind.Visibility = Visibility.Visible;
      panelX.Visibility = Visibility.Visible;
      FirstNameTb.IsEnabled = false;
      LastNameTb.IsEnabled = false;
      PhoneNumTb.IsEnabled = false;
      CompanyTb.IsEnabled = false;
      JobTb.IsEnabled = false;
      AddressTb.IsEnabled = false;
    }
    // Delete Button
    private void DeleteBtnClick(object sender, RoutedEventArgs e) {
      if (ComboContacts.SelectedItem != null) {
        MessageBoxResult messageBoxResult = MessageBox.Show("Are You Sure You Want To Delete?", "Delete Confirmation",
          MessageBoxButton.YesNo);
        if (messageBoxResult == MessageBoxResult.Yes) {
          foreach (var student in Students) {
            if (student.Email == CurrentStudentEmail) {
              // Remove from original list the contact that is currently selected in ComboContacts 
              student.Addresses.Remove((AddressBook)ComboContacts.SelectedItem);
              ComboContacts.Items.Refresh(); // To see the changes
              // Hide the panels as they contain nothing now
              canvasX.Visibility = Visibility.Hidden;
              StackPanelBind.Visibility = Visibility.Hidden;
              panelX.Visibility = Visibility.Hidden;
              MessageBox.Show("Contact Deleted..");
            }

          }
        }
        
      }
      else {
        // If any contact is not selected
        MessageBox.Show("Nothing to delete..");
      }
      
    }
  }
}
