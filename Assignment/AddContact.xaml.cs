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
using Microsoft.Win32;

namespace Assignment {
  /// <summary>
  /// Interaction logic for AddContact.xaml
  /// </summary>
  public partial class AddContact : Window {
    public string CurrentStudentEmail;
    public List<Student> Students;
    public AddContact(string currentStudentEmail, List<Student> students) {
      InitializeComponent();
      CurrentStudentEmail = currentStudentEmail;
      this.Students = students;
    }

    private void UploadImageClick(object sender, RoutedEventArgs e) {
      OpenFileDialog op = new OpenFileDialog();
      op.Title = "Select a picture";
      op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png";
      if (op.ShowDialog() == true) {
        Uri fileUri = new Uri(op.FileName);
        Photo.Source = new BitmapImage(fileUri);

      }
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

    private void SubmitBtnClick(object sender, RoutedEventArgs e) {
      foreach (var student in Students) {
        if (student.Email == CurrentStudentEmail) {
          if (FirstNameTb.Text == "" || LastNameTb.Text == "" || PhoneNumTb.Text == "" || AddressTb.Text == "" ||
              JobTb.Text == "" || Photo.Source == null) {
            MessageBox.Show("Enter all fields");
          }
          else {
            student.Addresses.Add(new AddressBook() { FirstName = FirstNameTb.Text, LastName = LastNameTb.Text, PhoneNumber = PhoneNumTb.Text, Address = AddressTb.Text, Company = CompanyTb.Text, JobTitle = JobTb.Text, Photo = Photo.Source.ToString() });
            MessageBox.Show("Contact Saved..");
          }
          
        }
      }

      FirstNameTb.Text = LastNameTb.Text =
        PhoneNumTb.Text = AddressTb.Text = CompanyTb.Text = JobTb.Text  = "";
      Photo.Source = new BitmapImage();
    }
  }
}
