using System;
using System.Collections.Generic;
using System.Linq;
using Mek.CodeGen.Expressions;

namespace Mek.CodeGen
{
	public class ExpMetadata
	{
		public static readonly ExpMetadata None = new ExpMetadata();

		public static implicit operator ExpMetadata(Type type)
		{
			return new TypeLiteralExp(type);
		}

		public static implicit operator ExpMetadata(string str)
		{
			return new StringLiteralExp(str);
		}

		public static implicit operator ExpMetadata(bool val)
		{
			return new BoolLiteralExp(val);
		}

		public static implicit operator ExpMetadata(byte val)
		{
			return new ByteLiteralExp(val);
		}

		public static implicit operator ExpMetadata(sbyte val)
		{
			return new SByteLiteralExp(val);
		}

		public static implicit operator ExpMetadata(short val)
		{
			return new ShortLiteralExp(val);
		}

		public static implicit operator ExpMetadata(ushort val)
		{
			return new UShortLiteralExp(val);
		}

		public static implicit operator ExpMetadata(char val)
		{
			return new CharLiteralExp(val);
		}

		public static implicit operator ExpMetadata(uint val)
		{
			return new UIntLiteralExp(val);
		}

		public static implicit operator ExpMetadata(long val)
		{
			return new LongLiteralExp(val);
		}

		public static implicit operator ExpMetadata(ulong val)
		{
			return new ULongLiteralExp(val);
		}

		public static implicit operator ExpMetadata(float val)
		{
			return new FloatLiteralExp(val);
		}

		public static implicit operator ExpMetadata(double val)
		{
			return new DoubleLiteralExp(val);
		}

		public static implicit operator ExpMetadata(decimal val)
		{
			return new DecimalLiteralExp(val);
		}

		public static implicit operator ExpMetadata(Enum val)
		{
			return new EnumLiteralExp(val);
		}

		public static implicit operator ExpMetadata(int number)
		{
			return new Int32LiteralExp(number);
		}

		public static ExpMetadata From(object val)
		{
			if (val == null)
				return NullExp.Instance;

			if (val is ExpMetadata)
				return (ExpMetadata)val;

			if (val is Type)
				return (Type)val;

			var type = val.GetType();

			if (type == typeof(string))
				return (string)val;

			if (type == typeof(int))
				return (int)val;

			if(type == typeof(bool))
				return (bool)val;

			if(type == typeof(byte))
				return (byte)val;

			if(type == typeof(sbyte))
				return (sbyte)val;

			if(type == typeof(short))
				return (short)val;

			if(type == typeof(ushort))
				return (ushort)val;

			if(type == typeof(char))
				return (char)val;

			if(type == typeof(uint))
				return (uint)val;

			if(type == typeof(long))
				return (long)val;

			if(type == typeof(ulong))
				return (ulong)val;

			if(type == typeof(float))
				return (float)val;

			if(type == typeof(double))
				return (double)val;

			if(type == typeof(decimal))
				return (decimal)val;

			if(type.IsEnum)
				return (Enum)val;

			throw new Exception("unable to get literal for object");
		}

		protected ExpMetadata()
		{
			this.Type = typeof(void);
		}

		public Type Type { get; protected set; }
	}
}