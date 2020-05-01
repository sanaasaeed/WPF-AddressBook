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
  /// Interaction logic for SearchContact.xaml
  /// </summary>
  public partial class SearchContact : Window {
    public string CurrentEmail;
    public List<Student> Students;
    public SearchContact() {
      InitializeComponent();
    }

    public SearchContact(string currentEmail, List<Student> students) {
      InitializeComponent();
      Students = students;
      CurrentEmail = currentEmail;
    }

    private void SearchOnKeyDown(object sender, KeyEventArgs e) {
      // listi.Content = "Hey";
      // foreach (var student in Students) {
      //   if (student.Email == CurrentEmail) {
      //     Predicate<AddressBook> addressPredicate = (AddressBook adr) => adr.FirstName == "Sana";
      //   }
      // }
      
    }
  }
}
