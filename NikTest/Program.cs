﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikTest
{
    public class Program
    {

		public class Heap<T>
		{
			public T[] _array; //массив сортируемых элементов
			private int heapsize;//число необработанных элементов
			private IComparer<T> _comparer;
			public Heap(T[] a, IComparer<T> comparer)
			{
				_array = a;
				heapsize = a.Length;
				_comparer = comparer;
			}

			public void HeapSort()
			{
				build_max_heap();//Построение пирамиды
				for (int i = _array.Length - 1; i > 0; i--)
				{

					T temp = _array[0];//Переместим текущий максимальный элемент из нулевой позиции в хвост массива
					_array[0] = _array[i];
					_array[i] = temp;

					heapsize--;//Уменьшим число необработанных элементов
					max_heapify(0);//Восстановление свойства пирамиды
				}
			}

			private int parent(int i) { return (i - 1) / 2; }//Индекс родительского узла
			private int left(int i) { return 2 * i + 1; }//Индекс левого потомка
			private int right(int i) { return 2 * i + 2; }//Индекс правого потомка

			//Метод переупорядочивает элементы пирамиды при условии,
			//что элемент с индексом i меньше хотя бы одного из своих потомков, нарушая тем самым свойство невозрастающей пирамиды
			private void max_heapify(int i)
			{
				int l = left(i);
				int r = right(i);
				int lagest = i;
				if (l < heapsize && _comparer.Compare(_array[l], _array[i]) > 0)
					lagest = l;
				if (r < heapsize && _comparer.Compare(_array[r], _array[lagest]) > 0)
					lagest = r;
				if (lagest != i)
				{
					T temp = _array[i];
					_array[i] = _array[lagest];
					_array[lagest] = temp;

					max_heapify(lagest);
				}
			}

			//метод строит невозрастающую пирамиду
			private void build_max_heap()
			{
				int i = (_array.Length - 1) / 2;

				while (i >= 0)
				{
					max_heapify(i);
					i--;
				}
			}

		}

		public class IntComparer : IComparer<int>
		{
			public int Compare(int x, int y) { return x - y; }
		}
		static void Main(string[] args)
        {
			int[] arr = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray(); //вводим элементы массива через пробел
			IntComparer myComparer = new IntComparer(); //Класс, реализующий сравнение
			Heap<int> heap = new Heap<int>(arr, myComparer);
			heap.HeapSort();

			for (int i = 0; i < heap._array.Length; i++)
            {
				Console.Write(heap._array[i] + " ");
            }

			Console.ReadKey();

		}
    }
}
