// Copyright (c) 2013-2014 Sandstorm Development Group, Inc. and contributors
// Licensed under the MIT License:
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace Capnproto.Benchmark
{
	public class Common
	{
		public class FastRand
		{
			public int x = unchecked((int)(0x1d2acd47));
			public int y = unchecked((int)(0x58ca3e14));
			public int z = unchecked((int)(0xf563f232));
			public int w = unchecked((int)(0x0bc76199));
			
			public virtual int nextInt()
			{
				int tmp = this.x ^ (this.x << 11);
				this.x = this.y;
				this.y = this.z;
				this.z = this.w;
				this.w = this.w ^ (this.w >> 19) ^ tmp ^ (tmp >> 8);
				return this.w;
			}
			
			public virtual int nextLessThan(int range)
			{
				//Just chop off the sign bit.
				return (unchecked((int)(0x7fffffff)) & this.nextInt()) % range;
			}
			
			public virtual double nextDouble(double range)
			{
				//Just chop off the sign bit.
				return (double)(unchecked((int)(0x7fffffff)) & this.nextInt()) * range / (double)(unchecked((int)(0x7fffffff)));
			}
		}
		
		public static int div(int a, int b)
		{
			if(b == 0)
				return unchecked((int)(0x7fffffff));
			if (a == unchecked((int)(0x80000000)) && b == -1)
				return unchecked((int)(0x7fffffff));
			return a / b;
		}
		
		public static int modulus(int a, int b)
		{
			if(b == 0)
				return unchecked((int)(0x7fffffff));
			if (a == unchecked((int)(0x80000000)) && b == -1)
				return unchecked((int)(0x7fffffff));
			return a % b;
		}
		
		public static string[] WORDS = new string[] { "foo ", "bar ", "baz ", "qux ", "quux ", "corge ", "grault ", "garply ", "waldo ", "fred ", "plugh ", "xyzzy ", "thud "};
	}
}
