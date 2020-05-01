using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Assignment {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    public List<Student> Students;
    public string CurrentStudentEmail;

    public MainWindow(List<Student> std) {
      InitializeComponent();
      Students = std;
    }
    public MainWindow() {
      InitializeComponent();
      Students = new List<Student>();
      Students.Add(new Student() { Email = "someone@uni.com", Password = "letmein"});
      Students.Add(new Student() { Email = "admin@uni.com", Password = "letmein" });
      Students.Add(new Student() { Email = "student@uni.com", Password = "letmein" });
    }

    private void Login_OnClick(object sender, RoutedEventArgs e) {
      bool login = false;
      // Login Functionality
      foreach (var student in Students) {
        if (EmailBox.Text == student.Email && PasswordBox.Password == student.Password) {
          login = true;
          CurrentStudentEmail = student.Email;
          // Login button to open a new window
          var home = new Home(CurrentStudentEmail, Students);
          home.Show();
          Close();
        }
      }

      if (!login) {
        MessageBox.Show("Invalid Email or Password");
      }
    }
  }

  public class Student {

    public string Email { get; set; }
    public string Password { get; set; }

    public List<AddressBook> Addresses = new List<AddressBook>() {
      new AddressBook() {
        FirstName = "Sana", LastName = "Saeed", Address = "Block D", PhoneNumber = "0331",
        Photo = ".//Images/profile.jpg", Company = "Company Co", JobTitle = "Engineer"
      }
    };
  }


  public class AddressBook {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Company { get; set; }
    public string JobTitle { get; set; }
    public string Address { get; set; }
    public string Photo { get; set; }
  }
}
