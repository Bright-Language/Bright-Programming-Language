using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Bright.Lexer
{
	/// <summary>
	/// TokenParser
	/// </summary>
	/// <remarks>
	/// TokenParser is the main parser engine for converting input into lexical tokens.
	/// </remarks>
    public class TokenParser
    {
        private readonly Dictionary<Tokens, string> _tokens;
        private readonly Dictionary<Tokens, MatchCollection> _regExMatchCollection;
        private string _inputString;
        private int _index;

		/// <summary>
		/// Tokens is an enumeration of all possible token values.
		/// </summary>
        public enum Tokens
        {
            UNDEFINED = 0,
            Method=1,
            Function=2,
            IntType=3,
            StringType=4,
            FloatType=5,
            If=6,
            Else=7,
            Identifier=8,
            Plus=9,
            Minus=10,
            Div=11,
            Mul=12,
            String=13,
            Integer=14,
            Float=15,
            Whitespace=16,
            Newline=17,
            Comment=18,
            Lparen=19,
            Rparen=20,
            OpenBrace=21,
            CloseBrace=22,
            Semicolon=23,
            EQEQ=24,
            Equals=25,
            EOF=26
        }

		/// <summary>
		/// InputString Property
		/// </summary>
		/// <value>
		/// The string value that holds the input string.
		/// </value>
        public string InputString
        {
            set
            {
                _inputString = value;
                PrepareRegex();
            }
        }

		/// <summary>
		/// Default Constructor
		/// </summary>
		/// <remarks>
		/// The constructor initalizes memory and adds all of the tokens to the token dictionary.
		/// </remarks>
        public TokenParser()
        {
            _tokens = new Dictionary<Tokens, string>();
            _regExMatchCollection = new Dictionary<Tokens, MatchCollection>();
            _index = 0;
            _inputString = string.Empty;

            _tokens.Add(Tokens.Method, "[m][e][t][h][o][d]");
            _tokens.Add(Tokens.Function, "[f][u][n][c][t][i][o][n]");
            _tokens.Add(Tokens.IntType, "[i][n][t]");
            _tokens.Add(Tokens.StringType, "[s][t][r][i][n][g]");
            _tokens.Add(Tokens.FloatType, "[f][l][o][a][t]");
            _tokens.Add(Tokens.If, "[i][f]");
            _tokens.Add(Tokens.Else, "[e][l][s][e]");
            _tokens.Add(Tokens.Identifier, "[a-zA-Z][a-zA-Z_0-9]*");
            _tokens.Add(Tokens.Plus, "\\+");
            _tokens.Add(Tokens.Minus, "\\-");
            _tokens.Add(Tokens.Div, "\\/");
            _tokens.Add(Tokens.Mul, "\\*");
            _tokens.Add(Tokens.String, "\".*?\"");
            _tokens.Add(Tokens.Integer, "[0-9]+");
            _tokens.Add(Tokens.Float, "[0-9]+\\.+[0-9]+");
            _tokens.Add(Tokens.Whitespace, "[ \\t]+");
            _tokens.Add(Tokens.Newline, "[\\r\\n]+");
            _tokens.Add(Tokens.Comment, "\\/\\*+((([^\\*])+)|([\\*]+(?!\\/)))[*]+\\/");
            _tokens.Add(Tokens.Lparen, "\\(");
            _tokens.Add(Tokens.Rparen, "\\)");
            _tokens.Add(Tokens.OpenBrace, "\\{");
            _tokens.Add(Tokens.CloseBrace, "\\}");
            _tokens.Add(Tokens.Semicolon, "\\;");
            _tokens.Add(Tokens.EQEQ, "\\==");
            _tokens.Add(Tokens.Equals, "\\=");
        }

		/// <summary>
		/// PrepareRegex prepares the regex for parsing by pre-matching the Regex tokens.
		/// </summary>
        private void PrepareRegex()
        {
            _regExMatchCollection.Clear();
            foreach (KeyValuePair<Tokens, string> pair in _tokens)
            {
                _regExMatchCollection.Add(pair.Key, Regex.Matches(_inputString, pair.Value));
            }
        }

		/// <summary>
		/// ResetParser resets the parser to its inital state. Reloading InputString is required.
		/// </summary>
		/// <seealso cref="InputString">
        public void ResetParser()
        {
            _index = 0;
            _inputString = string.Empty;
			_regExMatchCollection.Clear();
        }

		/// <summary>
		/// GetToken gets the next token in queue
		/// </summary>
		/// <remarks>
		/// GetToken attempts to the match the next character(s) using the
		/// Regex rules defined in the dictionary. If a match can not be
		/// located, then an Undefined token will be created with an empty
		/// string value. In addition, the token pointer will be incremented
		/// by one so that this token doesn't attempt to get identified again by
		/// GetToken()
		/// </remarks>
        public Token GetToken()
        {
            if (_index >= _inputString.Length)
                return null;

            foreach (KeyValuePair<Tokens, MatchCollection> pair in _regExMatchCollection)
            {
                foreach (Match match in pair.Value )
                {
                    if (match.Index == _index)
                    {
                        _index += match.Length;
                        return new Token(pair.Key, match.Value);
                    }

					if (match.Index > _index)
                    {
                        break;
                    }
                }
            }
            _index++;
            return new Token(Tokens.UNDEFINED, string.Empty);
        }

		/// <summary>
		/// Returns the next token that GetToken() will return.
		/// </summary>
		/// <seealso cref="Peek(PeekToken)">
        public PeekToken Peek()
        {
            return Peek(new PeekToken(_index, new Token(Tokens.UNDEFINED, string.Empty)));
        }

		/// <summary>
		/// Returns the next token after the Token passed here
		/// </summary>
		/// <param name="peekToken">The PeekToken token returned from a previous Peek() call</param>
		/// <seealso cref="Peek()">
        public PeekToken Peek(PeekToken peekToken)
        {
            int oldIndex = _index;

            _index = peekToken.TokenIndex;

            if (_index >= _inputString.Length)
            {
                _index = oldIndex;
                return null;
            }

            foreach (KeyValuePair<Tokens, string> pair in _tokens)
            {
                Regex r = new Regex(pair.Value);
                Match m = r.Match(_inputString, _index);

                if (m.Success && m.Index == _index)
                {
                    _index += m.Length;
                    PeekToken pt = new PeekToken(_index, new Token(pair.Key, m.Value));
                    _index = oldIndex;
                    return pt;
                }
            }
            PeekToken pt2 = new PeekToken(_index + 1, new Token(Tokens.UNDEFINED, string.Empty));
            _index = oldIndex;
            return pt2;
        }
    }

	/// <summary>
	/// A PeekToken object class
	/// </summary>
	/// <remarks>
	/// A PeekToken is a special pointer object that can be used to Peek() several
	/// tokens ahead in the GetToken() queue.
	/// </remarks>
    public class PeekToken
    {
        public int TokenIndex { get; set; }

        public Token TokenPeek { get; set; }

        public PeekToken(int index, Token value)
        {
            TokenIndex = index;
            TokenPeek = value;
        }
    }

	/// <summary>
	/// a Token object class
	/// </summary>
	/// <remarks>
	/// A Token object holds the token and token value.
	/// </remarks>
    public class Token
    {
        public TokenParser.Tokens TokenName { get; set; }

        public string TokenValue { get; set; }

        public Token(TokenParser.Tokens name, string value)
        {
            TokenName = name;
            TokenValue = value;
        }
    }

    public static class BrightLexer {
        public static List<Token> Lex(string code) {
            TokenParser tp=new();
            tp.InputString=code;
            List<Token> tokens = new List<Token>();
            while (true) {
                try {
                    Token t=tp.GetToken();
                    if (t.TokenName.ToString()!="Whitespace" && t.TokenName.ToString() != "Undefined") {
                        tokens.Add(t);
                    }
                } catch {
                    break;
                }
            }
            tokens.Add(new Token(TokenParser.Tokens.EOF, "EOF"));
            return tokens;
        }
    }
}