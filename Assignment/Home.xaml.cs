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

namespace Assignment {
  /// <summary>
  /// Interaction logic for Home.xaml
  /// </summary>
  public partial class Home : Window {
    public string CurrentStudentEmail;
    public List<Student> Students;
    public Home(string currentStudentEmail, List<Student> students) {
      InitializeComponent();
      this.CurrentStudentEmail = currentStudentEmail;
      this.Students = students;
      // var Add = new AddContact();
    }

    public Home() {
      InitializeComponent();
    }

    private void ViewContactClick(object sender, MouseButtonEventArgs e) {
     var view = new ViewContact(CurrentStudentEmail, Students);
     view.Show();
     Close();
    }
    private void LogOutClick(object sender, RoutedEventArgs e) {
      var login = new MainWindow(Students);
      login.Show();
      Close();
    }

    private void AddContactClick(object sender, MouseButtonEventArgs e) {
      var Add = new AddContact(CurrentStudentEmail, Students);
      Add.Show();
      Close();
    }

    private void SearchContactClick(object sender, MouseButtonEventArgs e) {
      var Search = new SearchContact(CurrentStudentEmail, Students);
      Search.Show();
      Close();
    }
  }
}
