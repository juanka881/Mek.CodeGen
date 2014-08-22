using Mek.CodeGen.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace Mek.CodeGen
{
	public class DynamicILGenerator
	{
		private readonly ILGenerator il;
		private readonly IDictionary<LocalExp, LocalBuilder> locals;

		public DynamicILGenerator(ILGenerator il)
		{
			if(il == null)
				throw new ArgumentNullException("il");

			this.il = il;
			this.locals = new Dictionary<LocalExp, LocalBuilder>();
		}

		private OpCode GetShortOrNormalOpCode(OpCode shortOp, OpCode normalOp, int index)
		{
			var result = index <= byte.MaxValue ? shortOp : normalOp;
			return result;
		}

		public void LoadNull()
		{
			this.il.Emit(OpCodes.Ldnull);
		}

		public void LoadString(string str)
		{
			this.il.Emit(OpCodes.Ldstr, str);
		}

		public void LoadInt32(int number)
		{
			switch(number)
			{
				case -1:
					this.il.Emit(OpCodes.Ldc_I4_M1);
					break;

				case 0:
					this.il.Emit(OpCodes.Ldc_I4_0);
					break;

				case 1:
					this.il.Emit(OpCodes.Ldc_I4_1);
					break;

				case 2:
					this.il.Emit(OpCodes.Ldc_I4_2);
					break;

				case 3:
					this.il.Emit(OpCodes.Ldc_I4_3);
					break;

				case 4:
					this.il.Emit(OpCodes.Ldc_I4_4);
					break;

				case 5:
					this.il.Emit(OpCodes.Ldc_I4_5);
					break;

				case 6:
					this.il.Emit(OpCodes.Ldc_I4_6);
					break;

				case 7:
					this.il.Emit(OpCodes.Ldc_I4_7);
					break;

				case 8:
					this.il.Emit(OpCodes.Ldc_I4_8);
					break;

				default:
				{
					var op = number <= sbyte.MinValue && number >= sbyte.MaxValue ? OpCodes.Ldc_I4_S : OpCodes.Ldc_I4;
					this.il.Emit(op, number);
					break;
				}
			}
		}

		public void Return()
		{
			this.il.Emit(OpCodes.Ret);
		}

		public void Emit(OpCode op)
		{
			this.il.Emit(op);
		}

		public void DeclareLocal(LocalExp localExp)
		{
			var local = this.il.DeclareLocal(localExp.Type);
			this.locals[localExp] = local;
		}

		public void LoadExp(ExpMetadata e)
		{
			if(e is NullExp)
			{
				this.LoadNull();
			}
			else if(e is Int32LiteralExp)
			{
				var int32 = (Int32LiteralExp)e;
				this.LoadInt32(int32.Value);
			}
			else if(e is StringLiteralExp)
			{
				var str = (StringLiteralExp)e;
				this.LoadString(str.Value);
			}
			else if(e is LocalExp)
			{
				var loc = (LocalExp)e;
				this.LoadLocal(loc);
			}
			else if(e is ParameterExp)
			{
				var p = (ParameterExp)e;
				this.LoadParameter(p);
			}
			else if(e == ExpMetadata.None)
			{
				// noop
			}
			else
			{
				throw new Exception("unable to load exp into stack");
			}
		}

		public void StoreLocal(LocalExp localExp)
		{
			var local = this.locals[localExp];
			var index = local.LocalIndex;

			switch(index)
			{
				case 0:
					this.il.Emit(OpCodes.Stloc_0);
					break;

				case 1:
					this.il.Emit(OpCodes.Stloc_1);
					break;

				case 2:
					this.il.Emit(OpCodes.Stloc_2);
					break;

				case 3:
					this.il.Emit(OpCodes.Stloc_3);
					break;

				default:
					var op = this.GetShortOrNormalOpCode(OpCodes.Ldloc_S, OpCodes.Ldloc, index);
					this.il.Emit(op, index);
					break;
			}
		}

		public void LoadLocal(LocalExp localExp)
		{
			var local = this.locals[localExp];
			var index = local.LocalIndex;

			switch(index)
			{
				case 0: 
					this.il.Emit(OpCodes.Ldloc_0);
					break;

				case 1:
					this.il.Emit(OpCodes.Ldloc_1);
					break;

				case 2:
					this.il.Emit(OpCodes.Ldloc_2);
					break;

				case 3:
					this.il.Emit(OpCodes.Ldloc_3);
					break;

				default:
					var op = this.GetShortOrNormalOpCode(OpCodes.Ldloc_S, OpCodes.Ldloc, index);
					this.il.Emit(op, local.LocalIndex);
					break;
			}
		}

		public void StoreParameter(ParameterExp parameterExp)
		{
			var pos = parameterExp.Position;
			var op = this.GetShortOrNormalOpCode(OpCodes.Starg_S, OpCodes.Starg, pos);
			this.il.Emit(op, pos);
		}

		public void LoadParameter(ParameterExp parameterExp)
		{
			var pos = parameterExp.Position;

			switch(pos)
			{
				case 0:
					this.il.Emit(OpCodes.Ldarg_0);
					break;

				case 1:
					this.il.Emit(OpCodes.Ldarg_1);
					break;

				case 2: 
					this.il.Emit(OpCodes.Ldarg_2);
					break;

				case 3:
					this.il.Emit(OpCodes.Ldarg_3);
					break;

				default:
					var op = this.GetShortOrNormalOpCode(OpCodes.Ldarg_S, OpCodes.Ldarg, pos);
					this.il.Emit(op, pos);
					break;
			}
		}
	}
}