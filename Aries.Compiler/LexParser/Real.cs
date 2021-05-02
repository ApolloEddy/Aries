using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 词法分析器
/// </summary>
namespace Aries.Compiler.LexParser
{
	/// <summary>
	/// 用于处理浮点数的类
	/// </summary>
	public class Real : Token 
	{
		public readonly float value;
		public Real(float value) : base(Tag.REAL) { this.value = value; }
		public new string ToString() { return "" + value; }
	}
}
