using System;

namespace Calci{
	class NumberCalci{
		public int Factorial(int num){
			int result;
			if(num == 0){
				return 1;
			}
			else{
				result = Factorial(num -1 )* num;
				return result;
			}
		}
		
		static void Main(string[] args){
			NumberCalci n =  new NumberCalci();
			Console.WriteLine($"Factorial for 7 is : {n.Factorial(7)}");
			Console.WriteLine($"Factorial for 8 is : {n.Factorial(8)}");
		}
	}
}
