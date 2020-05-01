using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

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
    // Uploading picture
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
    // btns to get back and logout
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
// Saving the contents of textboxes in the our list of addresses
    private void SubmitBtnClick(object sender, RoutedEventArgs e) {
      foreach (var student in Students) {
        if (student.Email == CurrentStudentEmail) {   // To add information to logged in user
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
      // After filling in the textboxes clear the form to fill in again
      FirstNameTb.Text = LastNameTb.Text =
        PhoneNumTb.Text = AddressTb.Text = CompanyTb.Text = JobTb.Text  = "";
      Photo.Source = new BitmapImage();
    }
  }
}
