using Open_Newtonsoft_Json.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace Open_Newtonsoft_Json.Linq.JsonPath
{
	[ComVisible(false)]
	internal class JPath
	{
		private readonly string _expression;

		private int _currentIndex;

		public List<PathFilter> Filters
		{
			get;
			private set;
		}

		public JPath(string expression)
		{
			ValidationUtils.ArgumentNotNull(expression, "expression");
			_expression = expression;
			Filters = new List<PathFilter>();
			ParseMain();
		}

		private void ParseMain()
		{
			int num = 7;
			int currentIndex = _currentIndex;
			EatWhitespace();
			if (_expression.Length == _currentIndex)
			{
				return;
			}
			if (_expression[_currentIndex] == '$')
			{
				if (_expression.Length == 1)
				{
					return;
				}
				char c = _expression[_currentIndex + 1];
				if (c == '.' || c == '[')
				{
					_currentIndex++;
					currentIndex = _currentIndex;
				}
			}
			if (!ParsePath(Filters, currentIndex, query: false))
			{
				int currentIndex2 = _currentIndex;
				EatWhitespace();
				if (_currentIndex < _expression.Length)
				{
					throw new JsonException("Unexpected character while parsing path: " + _expression[currentIndex2]);
				}
			}
		}

		private bool ParsePath(List<PathFilter> filters, int currentPartStartIndex, bool query)
		{
			int num = 15;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			while (_currentIndex < _expression.Length && !flag4)
			{
				char c = _expression[_currentIndex];
				switch (c)
				{
				case ' ':
					if (_currentIndex < _expression.Length)
					{
						flag4 = true;
					}
					break;
				case '(':
				case '[':
					if (_currentIndex > currentPartStartIndex)
					{
						string text = _expression.Substring(currentPartStartIndex, _currentIndex - currentPartStartIndex);
						object obj2;
						if (!flag)
						{
							FieldFilter fieldFilter2 = new FieldFilter();
							fieldFilter2.Name = text;
							obj2 = fieldFilter2;
						}
						else
						{
							ScanFilter scanFilter2 = new ScanFilter();
							scanFilter2.Name = text;
							obj2 = scanFilter2;
						}
						PathFilter item = (PathFilter)obj2;
						filters.Add(item);
						flag = false;
					}
					filters.Add(ParseIndexer(c));
					_currentIndex++;
					currentPartStartIndex = _currentIndex;
					flag2 = true;
					flag3 = false;
					break;
				default:
					if (query && (c == '=' || c == '<' || c == '!' || c == '>' || c == '|' || c == '&'))
					{
						flag4 = true;
						break;
					}
					if (!flag2)
					{
						_currentIndex++;
						break;
					}
					throw new JsonException("Unexpected character following indexer: " + c);
				case ')':
				case ']':
					flag4 = true;
					break;
				case '.':
					if (_currentIndex > currentPartStartIndex)
					{
						string text = _expression.Substring(currentPartStartIndex, _currentIndex - currentPartStartIndex);
						if (text == "*")
						{
							text = null;
						}
						object obj;
						if (!flag)
						{
							FieldFilter fieldFilter = new FieldFilter();
							fieldFilter.Name = text;
							obj = fieldFilter;
						}
						else
						{
							ScanFilter scanFilter = new ScanFilter();
							scanFilter.Name = text;
							obj = scanFilter;
						}
						PathFilter item = (PathFilter)obj;
						filters.Add(item);
						flag = false;
					}
					if (_currentIndex + 1 < _expression.Length && _expression[_currentIndex + 1] == '.')
					{
						flag = true;
						_currentIndex++;
					}
					_currentIndex++;
					currentPartStartIndex = _currentIndex;
					flag2 = false;
					flag3 = true;
					break;
				}
			}
			bool flag5 = _currentIndex == _expression.Length;
			if (_currentIndex > currentPartStartIndex)
			{
				string text = _expression.Substring(currentPartStartIndex, _currentIndex - currentPartStartIndex).TrimEnd();
				if (text == "*")
				{
					text = null;
				}
				object obj3;
				if (!flag)
				{
					FieldFilter fieldFilter3 = new FieldFilter();
					fieldFilter3.Name = text;
					obj3 = fieldFilter3;
				}
				else
				{
					ScanFilter scanFilter3 = new ScanFilter();
					scanFilter3.Name = text;
					obj3 = scanFilter3;
				}
				PathFilter item = (PathFilter)obj3;
				filters.Add(item);
			}
			else if (flag3 && (flag5 || query))
			{
				throw new JsonException("Unexpected end while parsing path.");
			}
			return flag5;
		}

		private PathFilter ParseIndexer(char indexerOpenChar)
		{
			int num = 5;
			_currentIndex++;
			char indexerCloseChar = (indexerOpenChar == '[') ? ']' : ')';
			EnsureLength("Path ended with open indexer.");
			EatWhitespace();
			if (_expression[_currentIndex] == '\'')
			{
				return ParseQuotedField(indexerCloseChar);
			}
			if (_expression[_currentIndex] == '?')
			{
				return ParseQuery(indexerCloseChar);
			}
			return ParseArrayIndexer(indexerCloseChar);
		}

		private PathFilter ParseArrayIndexer(char indexerCloseChar)
		{
			int num = 5;
			int currentIndex = _currentIndex;
			int? num2 = null;
			List<int> list = null;
			int num3 = 0;
			int? start = null;
			int? end = null;
			int? step = null;
			int num4;
			string value;
			int value2;
			while (true)
			{
				if (_currentIndex < _expression.Length)
				{
					char c = _expression[_currentIndex];
					if (c == ' ')
					{
						num2 = _currentIndex;
						EatWhitespace();
						continue;
					}
					if (c == indexerCloseChar)
					{
						break;
					}
					switch (c)
					{
					case ',':
						num4 = (num2 ?? _currentIndex) - currentIndex;
						if (num4 != 0)
						{
							if (list == null)
							{
								list = new List<int>();
							}
							value = _expression.Substring(currentIndex, num4);
							list.Add(Convert.ToInt32(value, CultureInfo.InvariantCulture));
							_currentIndex++;
							EatWhitespace();
							currentIndex = _currentIndex;
							num2 = null;
							continue;
						}
						throw new JsonException("Array index expected.");
					case ':':
						num4 = (num2 ?? _currentIndex) - currentIndex;
						if (num4 > 0)
						{
							value = _expression.Substring(currentIndex, num4);
							value2 = Convert.ToInt32(value, CultureInfo.InvariantCulture);
							switch (num3)
							{
							case 0:
								start = value2;
								break;
							case 1:
								end = value2;
								break;
							default:
								step = value2;
								break;
							}
						}
						num3++;
						_currentIndex++;
						EatWhitespace();
						currentIndex = _currentIndex;
						num2 = null;
						continue;
					case '*':
						_currentIndex++;
						EnsureLength("Path ended with open indexer.");
						EatWhitespace();
						if (_expression[_currentIndex] != indexerCloseChar)
						{
							throw new JsonException("Unexpected character while parsing path indexer: " + c);
						}
						return new ArrayIndexFilter();
					}
					if (char.IsDigit(c) || c == '-')
					{
						if (!num2.HasValue)
						{
							_currentIndex++;
							continue;
						}
						throw new JsonException("Unexpected character while parsing path indexer: " + c);
					}
					throw new JsonException("Unexpected character while parsing path indexer: " + c);
				}
				throw new JsonException("Path ended with open indexer.");
			}
			num4 = (num2 ?? _currentIndex) - currentIndex;
			if (list != null)
			{
				if (num4 == 0)
				{
					throw new JsonException("Array index expected.");
				}
				value = _expression.Substring(currentIndex, num4);
				value2 = Convert.ToInt32(value, CultureInfo.InvariantCulture);
				list.Add(value2);
				ArrayMultipleIndexFilter arrayMultipleIndexFilter = new ArrayMultipleIndexFilter();
				arrayMultipleIndexFilter.Indexes = list;
				return arrayMultipleIndexFilter;
			}
			if (num3 > 0)
			{
				if (num4 > 0)
				{
					value = _expression.Substring(currentIndex, num4);
					value2 = Convert.ToInt32(value, CultureInfo.InvariantCulture);
					if (num3 != 1)
					{
						step = value2;
					}
					else
					{
						end = value2;
					}
				}
				ArraySliceFilter arraySliceFilter = new ArraySliceFilter();
				arraySliceFilter.Start = start;
				arraySliceFilter.End = end;
				arraySliceFilter.Step = step;
				return arraySliceFilter;
			}
			if (num4 == 0)
			{
				throw new JsonException("Array index expected.");
			}
			value = _expression.Substring(currentIndex, num4);
			value2 = Convert.ToInt32(value, CultureInfo.InvariantCulture);
			ArrayIndexFilter arrayIndexFilter = new ArrayIndexFilter();
			arrayIndexFilter.Index = value2;
			return arrayIndexFilter;
		}

		private void EatWhitespace()
		{
			while (_currentIndex < _expression.Length && _expression[_currentIndex] == ' ')
			{
				_currentIndex++;
			}
		}

		private PathFilter ParseQuery(char indexerCloseChar)
		{
			int num = 8;
			_currentIndex++;
			EnsureLength("Path ended with open indexer.");
			if (_expression[_currentIndex] != '(')
			{
				throw new JsonException("Unexpected character while parsing path indexer: " + _expression[_currentIndex]);
			}
			_currentIndex++;
			QueryExpression expression = ParseExpression();
			_currentIndex++;
			EnsureLength("Path ended with open indexer.");
			EatWhitespace();
			if (_expression[_currentIndex] != indexerCloseChar)
			{
				throw new JsonException("Unexpected character while parsing path indexer: " + _expression[_currentIndex]);
			}
			QueryFilter queryFilter = new QueryFilter();
			queryFilter.Expression = expression;
			return queryFilter;
		}

		private QueryExpression ParseExpression()
		{
			int num = 8;
			QueryExpression queryExpression = null;
			CompositeExpression compositeExpression = null;
			BooleanQueryExpression booleanQueryExpression2;
			while (true)
			{
				if (_currentIndex < _expression.Length)
				{
					EatWhitespace();
					if (_expression[_currentIndex] == '@')
					{
						_currentIndex++;
						List<PathFilter> list = new List<PathFilter>();
						if (!ParsePath(list, _currentIndex, query: true))
						{
							EatWhitespace();
							EnsureLength("Path ended with open query.");
							object value = null;
							QueryOperator queryOperator;
							if (_expression[_currentIndex] == ')' || _expression[_currentIndex] == '|' || _expression[_currentIndex] == '&')
							{
								queryOperator = QueryOperator.Exists;
							}
							else
							{
								queryOperator = ParseOperator();
								EatWhitespace();
								EnsureLength("Path ended with open query.");
								value = ParseValue();
								EatWhitespace();
								EnsureLength("Path ended with open query.");
							}
							BooleanQueryExpression booleanQueryExpression = new BooleanQueryExpression();
							booleanQueryExpression.Path = list;
							booleanQueryExpression.Operator = queryOperator;
							booleanQueryExpression.Value = ((queryOperator != QueryOperator.Exists) ? new JValue(value) : null);
							booleanQueryExpression2 = booleanQueryExpression;
							if (_expression[_currentIndex] == ')')
							{
								break;
							}
							if (_expression[_currentIndex] == '&' && Match("&&"))
							{
								if (compositeExpression == null || compositeExpression.Operator != QueryOperator.And)
								{
									CompositeExpression compositeExpression2 = new CompositeExpression();
									compositeExpression2.Operator = QueryOperator.And;
									CompositeExpression compositeExpression3 = compositeExpression2;
									compositeExpression?.Expressions.Add(compositeExpression3);
									compositeExpression = compositeExpression3;
									if (queryExpression == null)
									{
										queryExpression = compositeExpression;
									}
								}
								compositeExpression.Expressions.Add(booleanQueryExpression2);
							}
							if (_expression[_currentIndex] != '|' || !Match("||"))
							{
								continue;
							}
							if (compositeExpression == null || compositeExpression.Operator != QueryOperator.Or)
							{
								CompositeExpression compositeExpression4 = new CompositeExpression();
								compositeExpression4.Operator = QueryOperator.Or;
								CompositeExpression compositeExpression5 = compositeExpression4;
								compositeExpression?.Expressions.Add(compositeExpression5);
								compositeExpression = compositeExpression5;
								if (queryExpression == null)
								{
									queryExpression = compositeExpression;
								}
							}
							compositeExpression.Expressions.Add(booleanQueryExpression2);
							continue;
						}
						throw new JsonException("Path ended with open query.");
					}
					throw new JsonException("Unexpected character while parsing path query: " + _expression[_currentIndex]);
				}
				throw new JsonException("Path ended with open query.");
			}
			if (compositeExpression != null)
			{
				compositeExpression.Expressions.Add(booleanQueryExpression2);
				return queryExpression;
			}
			return booleanQueryExpression2;
		}

		private object ParseValue()
		{
			int num = 19;
			char c = _expression[_currentIndex];
			if (c == '\'')
			{
				return ReadQuotedString();
			}
			if (char.IsDigit(c) || c == '-')
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(c);
				_currentIndex++;
				while (_currentIndex < _expression.Length)
				{
					c = _expression[_currentIndex];
					if (c != ' ' && c != ')')
					{
						stringBuilder.Append(c);
						_currentIndex++;
						continue;
					}
					string text = stringBuilder.ToString();
					if (text.IndexOfAny(new char[3]
					{
						'.',
						'E',
						'e'
					}) != -1)
					{
						if (double.TryParse(text, NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent, CultureInfo.InvariantCulture, out double result))
						{
							return result;
						}
						throw new JsonException("Could not read query value.");
					}
					if (long.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out long result2))
					{
						return result2;
					}
					throw new JsonException("Could not read query value.");
				}
			}
			else
			{
				switch (c)
				{
				case 't':
					if (Match("true"))
					{
						return true;
					}
					break;
				case 'f':
					if (Match("false"))
					{
						return false;
					}
					break;
				case 'n':
					if (Match("null"))
					{
						return null;
					}
					break;
				}
			}
			throw new JsonException("Could not read query value.");
		}

		private string ReadQuotedString()
		{
			int num = 12;
			StringBuilder stringBuilder = new StringBuilder();
			_currentIndex++;
			while (true)
			{
				if (_currentIndex < _expression.Length)
				{
					char c = _expression[_currentIndex];
					if (c == '\\' && _currentIndex + 1 < _expression.Length)
					{
						_currentIndex++;
						if (_expression[_currentIndex] == '\'')
						{
							stringBuilder.Append('\'');
						}
						else
						{
							if (_expression[_currentIndex] != '\\')
							{
								throw new JsonException("Unknown escape chracter: \\" + _expression[_currentIndex]);
							}
							stringBuilder.Append('\\');
						}
						_currentIndex++;
					}
					else
					{
						if (c == '\'')
						{
							break;
						}
						_currentIndex++;
						stringBuilder.Append(c);
					}
					continue;
				}
				throw new JsonException("Path ended with an open string.");
			}
			_currentIndex++;
			return stringBuilder.ToString();
		}

		private bool Match(string string_0)
		{
			int num = _currentIndex;
			int num2 = 0;
			while (true)
			{
				if (num2 < string_0.Length)
				{
					char c = string_0[num2];
					if (num >= _expression.Length || _expression[num] != c)
					{
						break;
					}
					num++;
					num2++;
					continue;
				}
				_currentIndex = num;
				return true;
			}
			return false;
		}

		private QueryOperator ParseOperator()
		{
			int num = 12;
			if (_currentIndex + 1 >= _expression.Length)
			{
				throw new JsonException("Path ended with open query.");
			}
			if (Match("=="))
			{
				return QueryOperator.Equals;
			}
			if (Match("!=") || Match("<>"))
			{
				return QueryOperator.NotEquals;
			}
			if (Match("<="))
			{
				return QueryOperator.LessThanOrEquals;
			}
			if (Match("<"))
			{
				return QueryOperator.LessThan;
			}
			if (Match(">="))
			{
				return QueryOperator.GreaterThanOrEquals;
			}
			if (Match(">"))
			{
				return QueryOperator.GreaterThan;
			}
			throw new JsonException("Could not read query operator.");
		}

		private PathFilter ParseQuotedField(char indexerCloseChar)
		{
			int num = 15;
			List<string> list = null;
			while (true)
			{
				if (_currentIndex < _expression.Length)
				{
					string text = ReadQuotedString();
					EatWhitespace();
					EnsureLength("Path ended with open indexer.");
					if (_expression[_currentIndex] != indexerCloseChar)
					{
						if (_expression[_currentIndex] != ',')
						{
							break;
						}
						_currentIndex++;
						EatWhitespace();
						if (list == null)
						{
							list = new List<string>();
						}
						list.Add(text);
						continue;
					}
					if (list != null)
					{
						list.Add(text);
						FieldMultipleFilter fieldMultipleFilter = new FieldMultipleFilter();
						fieldMultipleFilter.Names = list;
						return fieldMultipleFilter;
					}
					FieldFilter fieldFilter = new FieldFilter();
					fieldFilter.Name = text;
					return fieldFilter;
				}
				throw new JsonException("Path ended with open indexer.");
			}
			throw new JsonException("Unexpected character while parsing path indexer: " + _expression[_currentIndex]);
		}

		private void EnsureLength(string message)
		{
			if (_currentIndex >= _expression.Length)
			{
				throw new JsonException(message);
			}
		}

		internal IEnumerable<JToken> Evaluate(JToken jtoken_0, bool errorWhenNoMatch)
		{
			return Evaluate(Filters, jtoken_0, errorWhenNoMatch);
		}

		internal static IEnumerable<JToken> Evaluate(List<PathFilter> filters, JToken jtoken_0, bool errorWhenNoMatch)
		{
			IEnumerable<JToken> enumerable = new JToken[1]
			{
				jtoken_0
			};
			foreach (PathFilter filter in filters)
			{
				enumerable = filter.ExecuteFilter(enumerable, errorWhenNoMatch);
			}
			return enumerable;
		}
	}
}
