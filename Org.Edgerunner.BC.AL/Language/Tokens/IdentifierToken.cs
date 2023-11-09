﻿#region MIT License
// <copyright company = "Edgerunner.org" file = "IdentifierToken.cs">
// Copyright(c)  2023
// </copyright>
// The MIT License (MIT)
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
#endregion


using Org.Edgerunner.Buffers;
using Org.Edgerunner.Language.Lexers;

namespace Org.Edgerunner.BC.AL.Language.Tokens
{
   /// <summary>
   /// Class representing an AL identifier token. This class cannot be inherited.
   /// Implements the <see cref="IToken" />
   /// </summary>
   /// <seealso cref="IToken" />
   public sealed class IdentifierToken : AlToken
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="IdentifierToken" /> class.
      /// </summary>
      /// <param name="value">The token value.</param>
      /// <param name="start">The token start.</param>
      /// <param name="end">The token end.</param>
      /// <param name="reservedWord">The reserved word corresponding to the token if there is one.</param>
      public IdentifierToken(string value, BufferPoint start, BufferPoint end, bool reservedWord = false) : base(value, start, end)
      {
         ReservedWord = reservedWord;
      }

      /// <inheritdoc/>
      public override int TokenType => (int)Tokens.TokenType.Identifier;

      /// <summary>
      /// Gets a value indicating whether token is a reserved word.
      /// </summary>
      /// <value><c>true</c> if a reserved word; otherwise, <c>false</c>.</value>
      public bool ReservedWord { get; }

      /// <summary>
      /// Gets a value indicating whether this instance represents an operator.
      /// </summary>
      /// <value><c>true</c> if this instance represents an operator; otherwise, <c>false</c>.</value>
      public override bool IsOperator => IsBinaryOperator;

      /// <summary>
      /// Gets a value indicating whether this instance represents a binary operator.
      /// </summary>
      /// <value><c>true</c> if this instance represents a binary operator; otherwise, <c>false</c>.</value>
      public override bool IsBinaryOperator => Value.ToUpperInvariant() is "DIV" or "MOD" or "AND" or "OR" or "IN";
   }
}