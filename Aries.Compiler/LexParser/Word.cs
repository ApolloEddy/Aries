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
	/// 用于处理其他词法的类
	/// </summary>
	public class Word : Token 
	{
		public string lexeme = "";
		public Word(string word, int tag) : base(tag) { lexeme = word; }
		public new string ToString() { return lexeme; }
		public static readonly Word
			and = new Word("&&", Tag.AND), or = new Word("||", Tag.OR),
			eq = new Word("==", Tag.EQ), ne = new Word("!=", Tag.NE),
			le = new Word("<=", Tag.LE), ge = new Word(">=", Tag.GE),
			minus = new Word("minus", Tag.MINUS),
			True = new Word("true", Tag.TRUE),
			False = new Word("false", Tag.FALSE),
			temp = new Word("t", Tag.TEMP);
	}
}
}
