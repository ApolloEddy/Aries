using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aries.Compiler.LexParser;

/// <summary>
/// 用来处理表达式的中间转换代码
/// </summary>
namespace Aries.Compiler.Inter
{
	/// <summary>
	/// 抽象语法树的节点，用于完善编译器的报错机制
	/// </summary>
	class Node
	{
		int lexLine = 0;
		Node() { lexLine = Lexer.line; }
		/// <summary>
		/// 用于输出错误
		/// </summary>
		/// <param name="message">错误信息</param>
		void error(string message) { throw new Exception($"Near line {lexLine} : {message}"); }
		static int labels = 0;
		/// <summary>
		/// 更新节点的<see cref="labels"/>信息
		/// </summary>
		/// <returns>新的<see cref="labels"/></returns>
		public int newLabel() { return ++labels; }
		/// <summary>
		/// 发出一个用于goto关键字识别的标记<see cref="labels"/>
		/// </summary>
		/// <param name="i">标记的顺序</param>
		public void emitLabel(int i) { Console.Write($"L{i}:"); }
		/// <summary>
		/// 发出错误信息
		/// </summary>
		/// <param name="message">错误信息</param>
		public void emit(string message) { Console.WriteLine($"\t{message}"); }
	}
}
