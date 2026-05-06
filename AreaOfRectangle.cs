using System;

namespace AreaOfRectangle{
	class Rectangle{
		double length;
		double width;
		
		public void AcceptDetails(){
			length = 3;
			width = 10;
		}
		
		public double GetArea(){
			return length * width;
		}
		
		public void Display(){
			Console.WriteLine("L = {0}", length);
			Console.WriteLine($"W = {width}");
			Console.WriteLine($"A = {GetArea()}");
		}
	}
	
	class ExeRectangle{
		static void Main(string[] args){
			Rectangle r = new Rectangle();
			r.AcceptDetails();
			r.Display();
			Console.ReadLine(); 
		}
	}
}

