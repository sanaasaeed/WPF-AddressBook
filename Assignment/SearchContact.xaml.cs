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


    private void OnTextChange(object sender, TextChangedEventArgs e) {
      listBoxF.Visibility = Visibility.Visible;
      string name = this.searchBar.Text;
      foreach (var student in Students) {
        if (student.Email == CurrentEmail) {
          filteredList = student.Addresses.FindAll(s => s.FirstName.ToLower().Contains(name.ToLower()));
          listBoxF.ItemsSource = filteredList;
        }
      }
      
    }
  }
}
