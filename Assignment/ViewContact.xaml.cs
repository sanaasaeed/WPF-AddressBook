using System.Collections.Generic;
using System.Windows;

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

    private void UpdateBtnClick(object sender, RoutedEventArgs e) {
      ComboContacts.Items.Refresh();
    }
  }
}
