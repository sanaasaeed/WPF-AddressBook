using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Visibility = System.Windows.Visibility;

namespace Assignment {
  /// <summary>
  /// Interaction logic for SearchContact.xaml
  /// </summary>
  public partial class SearchContact : Window {
    public string CurrentEmail;
    public List<Student> Students;
    public List<AddressBook> filteredList = new List<AddressBook>();

    public SearchContact() {
      InitializeComponent();
    }

    public SearchContact(string currentEmail, List<Student> students) {
      InitializeComponent();
      Students = students;
      CurrentEmail = currentEmail;
    }
    // btns to get back and logout
    private void BackBtnClick(object sender, RoutedEventArgs e) {
      var home = new Home(CurrentEmail, Students);
      home.Show();
      Close();
    }

    private void LogOutClick(object sender, RoutedEventArgs e) {
      var login = new MainWindow(Students);
      login.Show();
      Close();
    }

    // Seacrh Functionality
    private void OnTextChange(object sender, TextChangedEventArgs e) {
      listBoxF.Visibility = Visibility.Visible; // Initially we should not be able to see the list
      string name = this.searchBar.Text;
      foreach (var student in Students) {
        if (student.Email == CurrentEmail) { // We are using logged in person's info
          filteredList = student.Addresses.FindAll(s => s.FirstName.ToLower().Contains(name.ToLower())); // Predicate to filter
          listBoxF.ItemsSource = filteredList; // Set List source
        }
      }
      
    }
  }
}
