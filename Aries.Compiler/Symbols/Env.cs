using System;
using System.Collections;
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
	/// 用于把字符串词法单元映射为类<see cref="ID"/>的基类
	/// </summary>
	class Env
	{
		private Hashtable table;
		protected Env prev;
		public Env(Env env) { table = new Hashtable(); prev = env; }
		public void put(Token token, ID id) { }
	}
}
