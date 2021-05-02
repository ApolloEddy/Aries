using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aries.Compiler.Symbols;

/// <summary>
/// 词法分析器
/// </summary>
namespace Aries.Compiler.LexParser
{
	/// <summary>
	/// 存储保留关键字和其他词素的类
	/// </summary>
	class Lexer
	{
		public static int line = 1;
		char peek = ' ';
		Hashtable words = new Hashtable();
		void reserve( Word word ) { words.Add(word.lexeme, word); }
		public Lexer()
		{
			reserve(new Word("if", Tag.IF));
			reserve(new Word("else", Tag.ELSE));
			reserve(new Word("while", Tag.WHILE));
			reserve(new Word("do", Tag.DO));
			reserve(new Word("break", Tag.BREAK));
			reserve(Word.True);reserve(Word.False);
			reserve(Symbols.Type.Int); reserve(Symbols.Type.Char);
			reserve(Symbols.Type.Bool); reserve(Symbols.Type.Float);
		}
		
		///<exception cref="System.IO.IOException"></exception>
		void readChar()	{ peek = (char)Console.Read(); } //待修正

		///<exception cref="System.IO.IOException"></exception>
		bool readChar(char ch)
		{
			readChar();
			if (peek != ch) return false;
			peek = ' ';
			return true;
		}

		///<exception cref="System.IO.IOException"></exception>
		public Token scan()
		{
			// 处理空格，制表符和换行符，遇到后直接跳过
			for(; ;readChar()) 
			{
				if ((peek == ' ') || (peek == '\t')) continue;
				else if (peek == '\n') line++;
				else break;
			}
			// 处理符合词法单元（两个字符以上的符号）
			switch (peek)
			{
				case '&':if (readChar('&')) return Word.and; else return new Token('&');
				case '|': if (readChar('|')) return Word.or; else return new Token('|');
				case '=': if (readChar('=')) return Word.eq; else return new Token('=');
				case '!': if (readChar('=')) return Word.ne; else return new Token('!');
				case '<': if (readChar('=')) return Word.le; else return new Token('<');
				case '>': if (readChar('=')) return Word.ge; else return new Token('>');
			}
			// 处理数字
			if(char.IsDigit(peek))
			{
				int value = 0;
				do
				{
					value = (int)((10 * value) + char.GetNumericValue(peek)); readChar();

				} while (char.IsDigit(peek));
				if (peek != '.') return new Number(value); // 浮点数的处理
				float x = value; float d = 10;
				for(; ; )
				{
					readChar();
					if (!char.IsDigit(peek)) break;
					x = x + (int)char.GetNumericValue(peek) / d;d *= 10;
				}
				return new Real(x);
			}
			// 读入一个字符串
			if (char.IsLetter(peek))
			{
				var builder = new StringBuilder();
				do
				{
					builder.Append(peek); readChar();
				} while (char.IsLetterOrDigit(peek));
				string id = builder.ToString();
				Word word = (Word)words[id];
				if (word != null) return word;
				word = new Word(id, Tag.ID);
				words.Add(id, word);
				return word;
			}
			// 处理其他任意字符
			Token token = new Token(peek);peek = ' ';
			return token;
		}
	}
}
