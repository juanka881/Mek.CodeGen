using System;
using System.Collections.Generic;
using System.Linq;
using Mek.CodeGen.Lines;

namespace Mek.CodeGen
{
	public class DynamicLineGenerator
	{
		public void Emit(DynamicILGenerator g, LineMetadata line)
		{
			if(line is ReturnLineMetadata)
			{
				var ret = (ReturnLineMetadata)line;
				g.LoadExp(ret.Exp);
				g.Return();
			}
			else if(line is SetLocalLineMetadata)
			{
				var set = (SetLocalLineMetadata)line;
				g.LoadExp(set.Value);
				g.StoreLocal(set.Local);
			}
			else if(line is SetParameterLineMetadata)
			{
				var set = (SetParameterLineMetadata)line;
				g.LoadExp(set.Value);
				g.StoreParameter(set.Parameter);
			}
			else 
			{
				throw new Exception("unknown line, unable to emit il");
			}
		}
	}
}