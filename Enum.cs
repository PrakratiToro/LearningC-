using System;

namespace EnumApp{
	
class EnumProgram{
    enum Days { Sun, Mon, tue, Wed, thu, Fri, Sat };
	static void Main(string[] args){
		int weekStart = (int)Days.Mon;
		int weekEnd = (int)Days.Fri;
		Console.WriteLine($"weekStart = {weekStart} , weekEnd = {weekEnd}");
	}

}}
