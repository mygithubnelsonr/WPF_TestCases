using System.Collections;
using System.Diagnostics;
using System.Windows;

namespace WpfTestCases.Views
{
    /// <summary>
    /// Interaction logic for ArrayListExample.xaml
    /// </summary>
    public partial class ArrayListExample : Window
    {
        private ArrayList arrayList = new ArrayList();

        public ArrayListExample()
        {
            InitializeComponent();
            FillArrayList();
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {

            foreach (var item in arrayList)
                Debug.Print(item + ", "); //output: 1, Bill, 300, 4.5, 

            for (int i = 0; i < arrayList.Count; i++)
                Debug.Print(arrayList[i] + ", "); //output: 1, Bill, 300, 4.5,


            // adding elements using ArrayList.Add() method
            var arlist1 = new ArrayList() { 1, "Bill", " ", true, 4.5, null };

            int[] arr = { 100, 200, 300, 400 };

            Queue myQ = new Queue();
            myQ.Enqueue("Hello");
            myQ.Enqueue("World!");

            arrayList.AddRange(arlist1); //adding arraylist in arraylist 
            arrayList.AddRange(arr); //adding array in arraylist 
            arrayList.AddRange(myQ); //adding Queue in arraylist

            for (int i = 0; i < arrayList.Count; i++)
                Debug.Print(arrayList[i] + ", "); //output: 1, Bill, 300, 4.5,
        }

        private void FillArrayList()
        {
            arrayList.Add(1);
            arrayList.Add("Bill");
            arrayList.Add(" ");
            arrayList.Add(true);
            arrayList.Add(4.5);
            arrayList.Add(null);
        }
    }
}
