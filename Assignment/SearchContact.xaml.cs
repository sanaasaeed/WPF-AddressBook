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
using System.Windows.Shapes;
using Visibility = System.Windows.Visibility;

namespace Assignment {
  /// <summary>
  /// Interaction logic for SearchContact.xaml
  /// </summary>
  public partial class SearchContact : Window {
    public string CurrentEmail;
    public List<Student> Students;
    public List<AddressBook> addresses;
    public SearchContact() {
      InitializeComponent();
    }

    public SearchContact(string currentEmail, List<Student> students) {
      InitializeComponent();
      Students = students;
      CurrentEmail = currentEmail;
      foreach (var student in Students) {
        if (student.Email == CurrentEmail) {
          addresses = student.Addresses;
        }
      }
      listBoxF.ItemsSource = addresses;
    }


    private void OnTextChange(object sender, TextChangedEventArgs e) {
      listBoxF.Visibility = Visibility.Visible;
      string name = this.searchBar.Text;
      // List<AddressBook> addr = addresses[name.ToLower()];
    }
  }
}
