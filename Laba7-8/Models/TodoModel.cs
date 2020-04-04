using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Laba7_8.Models
{
	[Serializable]
	public class TodoModel : INotifyPropertyChanged
	{
		public DateTime CreationDate { get; set; } = DateTime.Now;
		private string _Status;
		private string _Priority;
		private string _Name;
		private string _Description;

		[Required(ErrorMessage = "Заполните поле \"Статус\"", AllowEmptyStrings = false)]
		public string  Status
		{
			get { return _Status; }
			set 
			{
				if (_Status == value)
					return;
				_Status = value;
				OnPropertyChanged("Status");
			}
		}

		[Required(ErrorMessage = "Заполните поле \"Приоритет\"", AllowEmptyStrings = false)]
		public string Priority
		{
			get { return _Priority; }
			set 
			{
				if (_Priority == value)
					return;
				_Priority = value;
				OnPropertyChanged("Priority");
			}
		}
		[Required(ErrorMessage = "Заполните поле \"Имя\"", AllowEmptyStrings = false)]
		public string Name
		{
			get { return _Name; }
			set 
			{
				if (_Name == value)
					return;
				_Name = value;
				OnPropertyChanged("Name");
			}
		}
		[Required(ErrorMessage = "Заполните поле \"Описание\"", AllowEmptyStrings = false)]
		public string Description
		{
			get { return _Description; }
			set 
			{
				if (_Description == value)
					return;
				_Description = value;
				OnPropertyChanged("Description");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public override string ToString()
		{
			return $"{CreationDate}; {Status}; {Priority}; {Name}; \n{Description} " ;
		}




	}
}
