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
	/// 预定义的关键字标签
	/// </summary>
	public class Tag
	{
		public readonly static int
			AND   = 256, BASIC = 257, BREAK = 258, DO   = 259, ELSE  = 260,
			EQ    = 261, FALSE = 262, GE    = 263, ID   = 264, IF    = 265,
			INDEX = 266, LE    = 267, MINUS = 268, NE   = 269, NUM   = 270,
			OR    = 271, REAL  = 272, TEMP  = 273, TRUE = 274, WHILE = 275;
	}
}
