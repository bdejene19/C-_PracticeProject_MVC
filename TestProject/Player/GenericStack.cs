using System;
using Microsoft.AspNetCore.Mvc;

namespace TestProject.Players
{
	public class GenericStack<T>
	{
        public List<T> Stack;
		public int Top = -1;
		public GenericStack(List<T>? DefaultVal = null)
		{
			Stack = DefaultVal != null ? DefaultVal : new List<T>();
			Top = Stack.Count - 1;
		}


        public void PushToStack(T NewValue)
		{
			Stack.Add(NewValue);
			Top++;
		}

		public void RemoveTop()
		{
			try
			{
                Stack.RemoveAt(Top);
                Top--;
            } catch
			{
				throw new IndexOutOfRangeException();
			}
		
		}

		public T GetTop()
		{
			try
			{
                return Stack[Top];

            } catch
			{
				throw new IndexOutOfRangeException();
			}

        }


	}
}

