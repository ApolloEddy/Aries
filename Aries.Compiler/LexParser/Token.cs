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
	/// 用来表示符号的标记类的基类
	/// </summary>
	public class Token
	{
		public readonly int tag;
		public Token( int tag ) { this.tag = tag; }
		public new string ToString() { return "" + (char)tag; }
	}
}
