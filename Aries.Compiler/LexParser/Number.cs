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
	/// 用于处理数保留字和标志符等复合词法单元的类
	/// </summary>
	public class Number : Token 
	{
		public readonly int value;
		public Number( int value ) : base(Tag.NUM) { this.value = value; }
		public new string ToString() { return "" + value; }
}
