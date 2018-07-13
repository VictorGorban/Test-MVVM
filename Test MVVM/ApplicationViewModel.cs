using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System;
using System.Windows;

namespace Test_MVVM
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Phone selectedPhone;

        public ObservableCollection<Phone> Phones { get; set; }
        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged(nameof(SelectedPhone));
            }
        }

        public ApplicationViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone {Title="iPhone 7", Company="Apple", Price=56000 },
                new Phone {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
                new Phone {Title="Elite x3", Company="HP", Price=56000 },
                new Phone {Title="Mi5S", Company="Xiaomi", Price=35000 }
            };

            method2();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        /* 
         * 
         * 
         * 
         * 
         * 
         * 
         */

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            // Это - паттерн Invoke. "Способствовать осуществлению"
            //PropertyChangedEventHandler temp = PropertyChanged;
            //if (temp != null) // делегат МОЖЕТ быть null. Как минимум если удалить все функции из Invocation list. Типа Action a = new Action(ma); var b =a; c = a-b => null.
            //{
            //    temp (this, new PropertyChangedEventArgs(prop));
            //}
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(prop));
            // несмотря на синтаксический сахар... По-идее, это то же, что и PropertyChanged.Invoke(object sender, PropertyChangedEventArgs args)
            // Да. Посмотрел в метаданных. Это просто синтаксический сахар для делегатов и событий, компилятор все равно транслирует (..).
            // this (object sender) нужен для рефлексии, наверное. Хотя... Source of event... Sender of event... 
            // Помнишь, как ты в winForms делал var button = sender as Button? 
            // отправитель, все дела...
            // Думаю, там происходит что-то похожее. 
            // Чисто чтобы не генерировать код каждый раз.
            // Хотя это не мешает использовать рефлексию.

        }

        // событие:
        // <access modifiers> event <delegate(signature of a method to invoke)> <name>

        public EventHandler handler;

        public void MyMethod(object sender, System.EventArgs e)
        {
            MessageBox.Show("Nothing");
        }

        public void method2()
        {
            handler+=MyMethod;
            handler+=MyMethod;
            handler(null, null);
        }


    }
}