using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aries.Compiler.LexParser;

/// <summary>
/// 处理符号表和类型
/// </summary>
namespace Aries.Compiler.Symbols
{
	/// <summary>
	/// 用于存储数据类型的类
	/// </summary>
	public class Type : Word 
	{
		public int width = 0;
		public Type(string str, int tag, int width) : base(str, tag) { this.width = width; }
		public readonly static Type
			Int   = new Type("int", Tag.BASIC, 4),
			Float = new Type("float", Tag.BASIC, 8),
			Char  = new Type("char", Tag.BASIC, 1),
			Bool  = new Type("bool", Tag.BASIC, 1);

		// 检测类型
		public static bool numeric(Type p)
		{
			if (p == Char || p == Int || p == Float) return true;
			else return false;
		}

		// 类型判断
		public static Type Max(Type p1, Type p2)
		{
			if (!numeric(p1) || !numeric(p2)) return null;
			else if (p1 == Float || p2 == Float) return Float;
			else if (p1 == Int || p2 == Int) return Int;
			else return Char;
		}
	}
}
