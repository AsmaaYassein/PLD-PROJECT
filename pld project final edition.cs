
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF         =  0, // (EOF)
        SYMBOL_ERROR       =  1, // (Error)
        SYMBOL_WHITESPACE  =  2, // Whitespace
        SYMBOL_MINUS       =  3, // '-'
        SYMBOL_MINUSMINUS  =  4, // '--'
        SYMBOL_EXCLAMEQ    =  5, // '!='
        SYMBOL_PERCENT     =  6, // '%'
        SYMBOL_LPAREN      =  7, // '('
        SYMBOL_RPAREN      =  8, // ')'
        SYMBOL_TIMES       =  9, // '*'
        SYMBOL_TIMESTIMES  = 10, // '**'
        SYMBOL_COMMA       = 11, // ','
        SYMBOL_DIV         = 12, // '/'
        SYMBOL_COLONMINUS  = 13, // ':-'
        SYMBOL_LBRACE      = 14, // '{'
        SYMBOL_RBRACE      = 15, // '}'
        SYMBOL_PLUS        = 16, // '+'
        SYMBOL_PLUSPLUS    = 17, // '++'
        SYMBOL_LT          = 18, // '<'
        SYMBOL_EQ          = 19, // '='
        SYMBOL_EQEQ        = 20, // '=='
        SYMBOL_GT          = 21, // '>'
        SYMBOL_DEF         = 22, // def
        SYMBOL_DIGIT       = 23, // digit
        SYMBOL_DO          = 24, // do
        SYMBOL_ELSE        = 25, // else
        SYMBOL_FOR         = 26, // for
        SYMBOL_ID          = 27, // id
        SYMBOL_IF          = 28, // if
        SYMBOL_RETURN      = 29, // return
        SYMBOL_WHILE       = 30, // while
        SYMBOL_ARGUMENTS   = 31, // <arguments>
        SYMBOL_ASSIGN      = 32, // <assign>
        SYMBOL_CONCEPT     = 33, // <concept>
        SYMBOL_COND        = 34, // <cond>
        SYMBOL_DIGIT2      = 35, // <digit>
        SYMBOL_DOWHILESTAT = 36, // <doWhileSTAT>
        SYMBOL_EXP         = 37, // <exp>
        SYMBOL_EXPR        = 38, // <expr>
        SYMBOL_FACTOR      = 39, // <factor>
        SYMBOL_FORSTAT     = 40, // <forSTAT>
        SYMBOL_FUNCALLSTAT = 41, // <funcallSTAT>
        SYMBOL_FUNSTAT     = 42, // <funSTAT>
        SYMBOL_ID2         = 43, // <id>
        SYMBOL_IFSTAT      = 44, // <ifSTAT>
        SYMBOL_LOOPSTAT    = 45, // <loopSTAT>
        SYMBOL_OP          = 46, // <op>
        SYMBOL_PARAMETERS  = 47, // <parameters>
        SYMBOL_PROGRAM     = 48, // <program>
        SYMBOL_REST        = 49, // <rest>
        SYMBOL_RETURNSTAT  = 50, // <returnSTAT>
        SYMBOL_STATEMENT   = 51, // <statement>
        SYMBOL_STEP        = 52, // <step>
        SYMBOL_TERM        = 53, // <term>
        SYMBOL_WHILESTAT   = 54  // <whileSTAT>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                                             =  0, // <program> ::= <concept>
        RULE_PROGRAM2                                            =  1, // <program> ::= <concept> <program>
        RULE_CONCEPT                                             =  2, // <concept> ::= <assign>
        RULE_CONCEPT2                                            =  3, // <concept> ::= <ifSTAT>
        RULE_CONCEPT3                                            =  4, // <concept> ::= <loopSTAT>
        RULE_CONCEPT4                                            =  5, // <concept> ::= <funSTAT> <concept>
        RULE_ASSIGN_EQ                                           =  6, // <assign> ::= <id> '=' <expr>
        RULE_ID_ID                                               =  7, // <id> ::= id
        RULE_EXPR_PLUS                                           =  8, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                          =  9, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                                = 10, // <expr> ::= <term>
        RULE_TERM_TIMES                                          = 11, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                            = 12, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                        = 13, // <term> ::= <term> '%' <factor>
        RULE_TERM                                                = 14, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                                   = 15, // <factor> ::= <factor> '**' <exp>
        RULE_FACTOR                                              = 16, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                                   = 17, // <exp> ::= '(' <expr> ')'
        RULE_EXP_ID                                              = 18, // <exp> ::= id
        RULE_EXP_DIGIT                                           = 19, // <exp> ::= digit
        RULE_DIGIT_DIGIT                                         = 20, // <digit> ::= digit
        RULE_IFSTAT_IF_LPAREN_RPAREN_COLONMINUS                  = 21, // <ifSTAT> ::= if '(' <cond> ')' ':-' <rest>
        RULE_IFSTAT_IF_LPAREN_RPAREN_COLONMINUS_ELSE             = 22, // <ifSTAT> ::= if '(' <cond> ')' ':-' <rest> else <rest>
        RULE_COND                                                = 23, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LT                                               = 24, // <op> ::= '<'
        RULE_OP_GT                                               = 25, // <op> ::= '>'
        RULE_OP_EQEQ                                             = 26, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                         = 27, // <op> ::= '!='
        RULE_LOOPSTAT                                            = 28, // <loopSTAT> ::= <forSTAT>
        RULE_LOOPSTAT2                                           = 29, // <loopSTAT> ::= <whileSTAT>
        RULE_LOOPSTAT3                                           = 30, // <loopSTAT> ::= <doWhileSTAT>
        RULE_FORSTAT_FOR_LPAREN_COMMA_COMMA_RPAREN_LBRACE_RBRACE = 31, // <forSTAT> ::= for '(' <assign> ',' <cond> ',' <step> ')' '{' <rest> '}'
        RULE_STEP_MINUSMINUS                                     = 32, // <step> ::= '--' <id>
        RULE_STEP_MINUSMINUS2                                    = 33, // <step> ::= <id> '--'
        RULE_STEP_PLUSPLUS                                       = 34, // <step> ::= '++' <id>
        RULE_STEP_PLUSPLUS2                                      = 35, // <step> ::= <id> '++'
        RULE_STEP                                                = 36, // <step> ::= <assign>
        RULE_WHILESTAT_WHILE_LPAREN_RPAREN_LBRACE_RBRACE         = 37, // <whileSTAT> ::= while '(' <cond> ')' '{' <rest> '}'
        RULE_DOWHILESTAT_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN    = 38, // <doWhileSTAT> ::= do '{' <rest> '}' while '(' <cond> ')'
        RULE_FUNSTAT_DEF_LPAREN_RPAREN_LBRACE_RBRACE             = 39, // <funSTAT> ::= def <id> '(' <parameters> ')' '{' <rest> '}'
        RULE_PARAMETERS                                          = 40, // <parameters> ::= <id>
        RULE_PARAMETERS_COMMA                                    = 41, // <parameters> ::= <parameters> ',' <id>
        RULE_REST                                                = 42, // <rest> ::= <statement>
        RULE_REST2                                               = 43, // <rest> ::= <statement> <rest>
        RULE_STATEMENT                                           = 44, // <statement> ::= <concept>
        RULE_STATEMENT2                                          = 45, // <statement> ::= <returnSTAT>
        RULE_STATEMENT3                                          = 46, // <statement> ::= <funSTAT>
        RULE_RETURNSTAT_RETURN                                   = 47, // <returnSTAT> ::= return <expr>
        RULE_FUNCALLSTAT_LPAREN_RPAREN                           = 48, // <funcallSTAT> ::= <id> '(' <arguments> ')'
        RULE_ARGUMENTS                                           = 49, // <arguments> ::= <expr>
        RULE_ARGUMENTS_COMMA                                     = 50  // <arguments> ::= <arguments> ',' <expr>
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox l;
        ListBox ls;

        public MyParser(string filename , ListBox Lst , ListBox lst2)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            l = Lst;
            ls = lst2;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLONMINUS :
                //':-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEF :
                //def
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENTS :
                //<arguments>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOWHILESTAT :
                //<doWhileSTAT>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORSTAT :
                //<forSTAT>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCALLSTAT :
                //<funcallSTAT>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNSTAT :
                //<funSTAT>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFSTAT :
                //<ifSTAT>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOPSTAT :
                //<loopSTAT>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETERS :
                //<parameters>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REST :
                //<rest>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURNSTAT :
                //<returnSTAT>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILESTAT :
                //<whileSTAT>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<program> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAM2 :
                //<program> ::= <concept> <program>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <ifSTAT>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <loopSTAT>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <funSTAT> <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ :
                //<assign> ::= <id> '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_ID :
                //<exp> ::= id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_DIGIT :
                //<exp> ::= digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTAT_IF_LPAREN_RPAREN_COLONMINUS :
                //<ifSTAT> ::= if '(' <cond> ')' ':-' <rest>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTAT_IF_LPAREN_RPAREN_COLONMINUS_ELSE :
                //<ifSTAT> ::= if '(' <cond> ')' ':-' <rest> else <rest>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOOPSTAT :
                //<loopSTAT> ::= <forSTAT>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOOPSTAT2 :
                //<loopSTAT> ::= <whileSTAT>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOOPSTAT3 :
                //<loopSTAT> ::= <doWhileSTAT>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORSTAT_FOR_LPAREN_COMMA_COMMA_RPAREN_LBRACE_RBRACE :
                //<forSTAT> ::= for '(' <assign> ',' <cond> ',' <step> ')' '{' <rest> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS2 :
                //<step> ::= <id> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS2 :
                //<step> ::= <id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<step> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILESTAT_WHILE_LPAREN_RPAREN_LBRACE_RBRACE :
                //<whileSTAT> ::= while '(' <cond> ')' '{' <rest> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DOWHILESTAT_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN :
                //<doWhileSTAT> ::= do '{' <rest> '}' while '(' <cond> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNSTAT_DEF_LPAREN_RPAREN_LBRACE_RBRACE :
                //<funSTAT> ::= def <id> '(' <parameters> ')' '{' <rest> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS :
                //<parameters> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS_COMMA :
                //<parameters> ::= <parameters> ',' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_REST :
                //<rest> ::= <statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_REST2 :
                //<rest> ::= <statement> <rest>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<statement> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<statement> ::= <returnSTAT>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<statement> ::= <funSTAT>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNSTAT_RETURN :
                //<returnSTAT> ::= return <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCALLSTAT_LPAREN_RPAREN :
                //<funcallSTAT> ::= <id> '(' <arguments> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS :
                //<arguments> ::= <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS_COMMA :
                //<arguments> ::= <arguments> ',' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+" in line "+args.UnexpectedToken.Location.LineNr;
            l.Items.Add(message);
            string m2 = "Expected token "+ args.ExpectedTokens.ToString();
            l.Items.Add(m2); 
            //todo: Report message to UI?
        }
        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            string info = args.Token.Text + "   \t \t" + (SymbolConstants)args.Token.Symbol.Id;
            ls.Items.Add(info);
        }

    }
}
