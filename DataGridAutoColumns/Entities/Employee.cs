using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DasDataGrid.Entities
{
  public class Employee : INotifyPropertyChanged
  {
    private string _firstName;
    private string _lastName;
    private DateTime _startDate;
    private DateTime? _endDate;
    private Uri _homepage;
    private bool _isBoss;
    private Department _department;
    private bool _isMarried;
    private ObservableCollection<string> _responsibilities;

    public event PropertyChangedEventHandler PropertyChanged;

    public string FirstName
    {
      get { return _firstName; }
      set
      {
        _firstName = value;
        Changed("FirstName");
      }
    }
    public string LastName
    {
      get { return _lastName; }
      set
      {
        _lastName = value;
        Changed("LastName");
      }
    }
    public DateTime StartDate
    {
      get { return _startDate; }
      set
      {
        _startDate = value;
        Changed("StartDate");
      }
    }
    public DateTime? EndDate
    {
      get { return _endDate; }
      set
      {
        _endDate = value;
        Changed("EndDate");
      }
    }
    public Uri Homepage
    {
      get { return _homepage; }
      set
      {
        _homepage = value;
        Changed("Homepage");
      }
    }
    public bool IsBoss
    {
      get { return _isBoss; }
      set
      {
        _isBoss = value;
        Changed("IsBoss");
      }
    }
    public Department Department
    {
      get { return _department; }
      set
      {
        _department = value;
        Changed("Department");
      }
    }
    public bool IsMarried
    {
      get { return _isMarried; }
      set
      {
        _isMarried = value;
        Changed("IsMarried");
      }
    }
    public ObservableCollection<string> Responsibilities
    {
      get { return _responsibilities; }
      set
      {
        _responsibilities = value;
        Changed("Responsibilities");
      }
    }

    private void Changed(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
