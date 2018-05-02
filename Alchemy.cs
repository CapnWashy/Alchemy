
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
        SYMBOL_EOF                        =   0, // (EOF)
        SYMBOL_ERROR                      =   1, // (Error)
        SYMBOL_COMMENT                    =   2, // Comment
        SYMBOL_NEWLINE                    =   3, // NewLine
        SYMBOL_WHITESPACE                 =   4, // Whitespace
        SYMBOL_PIPEPIPE                   =   5, // '||'
        SYMBOL_PIPELT                     =   6, // '|<'
        SYMBOL_GTPIPE                     =   7, // '>|'
        SYMBOL_MINUS                      =   8, // '-'
        SYMBOL_MINUSMINUS                 =   9, // '--'
        SYMBOL_EXCLAM                     =  10, // '!'
        SYMBOL_EXCLAMEQ                   =  11, // '!='
        SYMBOL_PERCENT                    =  12, // '%'
        SYMBOL_PERCENTEQ                  =  13, // '%='
        SYMBOL_AMP                        =  14, // '&'
        SYMBOL_AMPEQ                      =  15, // '&='
        SYMBOL_LPAREN                     =  16, // '('
        SYMBOL_RPAREN                     =  17, // ')'
        SYMBOL_TIMES                      =  18, // '*'
        SYMBOL_TIMESEQ                    =  19, // '*='
        SYMBOL_COMMA                      =  20, // ','
        SYMBOL_DIV                        =  21, // '/'
        SYMBOL_DIVEQ                      =  22, // '/='
        SYMBOL_COLON                      =  23, // ':'
        SYMBOL_SEMI                       =  24, // ';'
        SYMBOL_QUESTION                   =  25, // '?'
        SYMBOL_LBRACKET                   =  26, // '['
        SYMBOL_RBRACKET                   =  27, // ']'
        SYMBOL_CARET                      =  28, // '^'
        SYMBOL_CARETEQ                    =  29, // '^='
        SYMBOL_LBRACE                     =  30, // '{'
        SYMBOL_PIPE                       =  31, // '|'
        SYMBOL_PIPEEQ                     =  32, // '|='
        SYMBOL_RBRACE                     =  33, // '}'
        SYMBOL_TILDE                      =  34, // '~'
        SYMBOL_PLUS                       =  35, // '+'
        SYMBOL_PLUSPLUS                   =  36, // '++'
        SYMBOL_PLUSEQ                     =  37, // '+='
        SYMBOL_LT                         =  38, // '<'
        SYMBOL_LTLT                       =  39, // '<<'
        SYMBOL_LTLTEQ                     =  40, // '<<='
        SYMBOL_LTEQ                       =  41, // '<='
        SYMBOL_EQ                         =  42, // '='
        SYMBOL_MINUSEQ                    =  43, // '-='
        SYMBOL_EQEQ                       =  44, // '=='
        SYMBOL_GT                         =  45, // '>'
        SYMBOL_MINUSGT                    =  46, // '->'
        SYMBOL_GTEQ                       =  47, // '>='
        SYMBOL_GTGT                       =  48, // '>>'
        SYMBOL_GTGTEQ                     =  49, // '>>='
        SYMBOL_ABSTRACT                   =  50, // abstract
        SYMBOL_ADD                        =  51, // add
        SYMBOL_AND                        =  52, // and
        SYMBOL_AS                         =  53, // as
        SYMBOL_ASSEMBLY                   =  54, // assembly
        SYMBOL_BASE                       =  55, // base
        SYMBOL_BOOL                       =  56, // bool
        SYMBOL_BREAK                      =  57, // break
        SYMBOL_BYTE                       =  58, // byte
        SYMBOL_CASE                       =  59, // case
        SYMBOL_CATCH                      =  60, // catch
        SYMBOL_CHAR                       =  61, // char
        SYMBOL_CHARLITERAL                =  62, // CharLiteral
        SYMBOL_CHECKED                    =  63, // checked
        SYMBOL_CLASS                      =  64, // class
        SYMBOL_CONST                      =  65, // const
        SYMBOL_CONTINUE                   =  66, // continue
        SYMBOL_DECIMAL                    =  67, // decimal
        SYMBOL_DECLITERAL                 =  68, // DecLiteral
        SYMBOL_DEFAULT                    =  69, // default
        SYMBOL_DELEGATE                   =  70, // delegate
        SYMBOL_DO                         =  71, // do
        SYMBOL_DOUBLE                     =  72, // double
        SYMBOL_ELSE                       =  73, // else
        SYMBOL_ELSEIF                     =  74, // elseif
        SYMBOL_ENUM                       =  75, // enum
        SYMBOL_EVENT                      =  76, // event
        SYMBOL_EXPLICIT                   =  77, // explicit
        SYMBOL_EXTERN                     =  78, // extern
        SYMBOL_FALSE                      =  79, // false
        SYMBOL_FIELD                      =  80, // field
        SYMBOL_FINALLY                    =  81, // finally
        SYMBOL_FIXED                      =  82, // fixed
        SYMBOL_FLOAT                      =  83, // float
        SYMBOL_FOR                        =  84, // for
        SYMBOL_FOREACH                    =  85, // foreach
        SYMBOL_GET                        =  86, // get
        SYMBOL_GOTO                       =  87, // goto
        SYMBOL_HEXLITERAL                 =  88, // HexLiteral
        SYMBOL_IDENTIFIER                 =  89, // Identifier
        SYMBOL_IF                         =  90, // if
        SYMBOL_IMPLICIT                   =  91, // implicit
        SYMBOL_IN                         =  92, // in
        SYMBOL_INT                        =  93, // int
        SYMBOL_INTERFACE                  =  94, // interface
        SYMBOL_INTERNAL                   =  95, // internal
        SYMBOL_IS                         =  96, // is
        SYMBOL_LOCK                       =  97, // lock
        SYMBOL_LONG                       =  98, // long
        SYMBOL_MEMBERNAME                 =  99, // MemberName
        SYMBOL_METHOD                     = 100, // method
        SYMBOL_MODULE                     = 101, // module
        SYMBOL_NAMESPACE                  = 102, // namespace
        SYMBOL_NEW                        = 103, // new
        SYMBOL_NOT                        = 104, // not
        SYMBOL_NULL                       = 105, // null
        SYMBOL_OBJECT                     = 106, // object
        SYMBOL_OPERATOR                   = 107, // operator
        SYMBOL_OR                         = 108, // or
        SYMBOL_OUT                        = 109, // out
        SYMBOL_OVERRIDE                   = 110, // override
        SYMBOL_PARAM                      = 111, // param
        SYMBOL_PARAMS                     = 112, // params
        SYMBOL_PARTIAL                    = 113, // partial
        SYMBOL_PRIVATE                    = 114, // private
        SYMBOL_PROPERTY                   = 115, // property
        SYMBOL_PROTECTED                  = 116, // protected
        SYMBOL_PUBLIC                     = 117, // public
        SYMBOL_READONLY                   = 118, // readonly
        SYMBOL_REALLITERAL                = 119, // RealLiteral
        SYMBOL_REF                        = 120, // ref
        SYMBOL_REMOVE                     = 121, // remove
        SYMBOL_RETURN                     = 122, // return
        SYMBOL_SBYTE                      = 123, // sbyte
        SYMBOL_SEALED                     = 124, // sealed
        SYMBOL_SET                        = 125, // set
        SYMBOL_SHORT                      = 126, // short
        SYMBOL_SIZEOF                     = 127, // sizeof
        SYMBOL_STACKALLOC                 = 128, // stackalloc
        SYMBOL_STATIC                     = 129, // static
        SYMBOL_STRING                     = 130, // string
        SYMBOL_STRINGLITERAL              = 131, // StringLiteral
        SYMBOL_STRUCT                     = 132, // struct
        SYMBOL_SWITCH                     = 133, // switch
        SYMBOL_THIS                       = 134, // this
        SYMBOL_THROW                      = 135, // throw
        SYMBOL_TRUE                       = 136, // true
        SYMBOL_TRY                        = 137, // try
        SYMBOL_TYPE                       = 138, // type
        SYMBOL_TYPEOF                     = 139, // typeof
        SYMBOL_UINT                       = 140, // uint
        SYMBOL_ULONG                      = 141, // ulong
        SYMBOL_UNCHECKED                  = 142, // unchecked
        SYMBOL_UNSAFE                     = 143, // unsafe
        SYMBOL_USHORT                     = 144, // ushort
        SYMBOL_USING                      = 145, // using
        SYMBOL_VIRTUAL                    = 146, // virtual
        SYMBOL_VOID                       = 147, // void
        SYMBOL_VOLATILE                   = 148, // volatile
        SYMBOL_WHILE                      = 149, // while
        SYMBOL_ACCESSOPT                  = 150, // <Access Opt>
        SYMBOL_ACCESSORDEC                = 151, // <Accessor Dec>
        SYMBOL_ADDEXP                     = 152, // <Add Exp>
        SYMBOL_ANDEXP                     = 153, // <And Exp>
        SYMBOL_ARGLIST                    = 154, // <Arg List>
        SYMBOL_ARGLISTOPT                 = 155, // <Arg List Opt>
        SYMBOL_ARGUMENT                   = 156, // <Argument>
        SYMBOL_ARRAYINITIALIZER           = 157, // <Array Initializer>
        SYMBOL_ARRAYINITIALIZEROPT        = 158, // <Array Initializer Opt>
        SYMBOL_ASSIGNTAIL                 = 159, // <Assign Tail>
        SYMBOL_ATTRIBLIST                 = 160, // <Attrib List>
        SYMBOL_ATTRIBOPT                  = 161, // <Attrib Opt>
        SYMBOL_ATTRIBSECTION              = 162, // <Attrib Section>
        SYMBOL_ATTRIBTARGETSPECOPT        = 163, // <Attrib Target Spec Opt>
        SYMBOL_ATTRIBUTE                  = 164, // <Attribute>
        SYMBOL_BASETYPE                   = 165, // <Base Type>
        SYMBOL_BLOCK                      = 166, // <Block>
        SYMBOL_BLOCKORSEMI                = 167, // <Block or Semi>
        SYMBOL_CATCHCLAUSE                = 168, // <Catch Clause>
        SYMBOL_CATCHCLAUSES               = 169, // <Catch Clauses>
        SYMBOL_CLASSBASELIST              = 170, // <Class Base List>
        SYMBOL_CLASSBASEOPT               = 171, // <Class Base Opt>
        SYMBOL_CLASSDECL                  = 172, // <Class Decl>
        SYMBOL_CLASSITEM                  = 173, // <Class Item>
        SYMBOL_CLASSITEMDECSOPT           = 174, // <Class Item Decs Opt>
        SYMBOL_COMPAREEXP                 = 175, // <Compare Exp>
        SYMBOL_COMPILATIONITEM            = 176, // <Compilation Item>
        SYMBOL_COMPILATIONITEMS           = 177, // <Compilation Items>
        SYMBOL_COMPILATIONUNIT            = 178, // <Compilation Unit>
        SYMBOL_CONDITIONALEXP             = 179, // <Conditional Exp>
        SYMBOL_CONSTANTDEC                = 180, // <Constant Dec>
        SYMBOL_CONSTANTDECLARATOR         = 181, // <Constant Declarator>
        SYMBOL_CONSTANTDECLARATORS        = 182, // <Constant Declarators>
        SYMBOL_CONSTRUCTORDEC             = 183, // <Constructor Dec>
        SYMBOL_CONSTRUCTORDECLARATOR      = 184, // <Constructor Declarator>
        SYMBOL_CONSTRUCTORINIT            = 185, // <Constructor Init>
        SYMBOL_CONSTRUCTORINITOPT         = 186, // <Constructor Init Opt>
        SYMBOL_CONVERSIONOPERATORDECL     = 187, // <Conversion Operator Decl>
        SYMBOL_DELEGATEDECL               = 188, // <Delegate Decl>
        SYMBOL_DESTRUCTORDEC              = 189, // <Destructor Dec>
        SYMBOL_DIMSEPARATORS              = 190, // <Dim Separators>
        SYMBOL_ENUMBASEOPT                = 191, // <Enum Base Opt>
        SYMBOL_ENUMBODY                   = 192, // <Enum Body>
        SYMBOL_ENUMDECL                   = 193, // <Enum Decl>
        SYMBOL_ENUMITEMDEC                = 194, // <Enum Item Dec>
        SYMBOL_ENUMITEMDECS               = 195, // <Enum Item Decs>
        SYMBOL_ENUMITEMDECSOPT            = 196, // <Enum Item Decs Opt>
        SYMBOL_EQUALITYEXP                = 197, // <Equality Exp>
        SYMBOL_EVENTACCESSORDECS          = 198, // <Event Accessor Decs>
        SYMBOL_EVENTDEC                   = 199, // <Event Dec>
        SYMBOL_EXPRESSION                 = 200, // <Expression>
        SYMBOL_EXPRESSIONLIST             = 201, // <Expression List>
        SYMBOL_EXPRESSIONOPT              = 202, // <Expression Opt>
        SYMBOL_FIELDDEC                   = 203, // <Field Dec>
        SYMBOL_FINALLYCLAUSEOPT           = 204, // <Finally Clause Opt>
        SYMBOL_FIXEDPTRDEC                = 205, // <Fixed Ptr Dec>
        SYMBOL_FIXEDPTRDECS               = 206, // <Fixed Ptr Decs>
        SYMBOL_FORCONDITIONOPT            = 207, // <For Condition Opt>
        SYMBOL_FORINITOPT                 = 208, // <For Init Opt>
        SYMBOL_FORITERATOROPT             = 209, // <For Iterator Opt>
        SYMBOL_FORMALPARAM                = 210, // <Formal Param>
        SYMBOL_FORMALPARAMLIST            = 211, // <Formal Param List>
        SYMBOL_FORMALPARAMLISTOPT         = 212, // <Formal Param List Opt>
        SYMBOL_HEADER                     = 213, // <Header>
        SYMBOL_INDEXERDEC                 = 214, // <Indexer Dec>
        SYMBOL_INTEGRALTYPE               = 215, // <Integral Type>
        SYMBOL_INTERFACEACCESSORS         = 216, // <Interface Accessors>
        SYMBOL_INTERFACEBASEOPT           = 217, // <Interface Base Opt>
        SYMBOL_INTERFACEDECL              = 218, // <Interface Decl>
        SYMBOL_INTERFACEEMPTYBODY         = 219, // <Interface Empty Body>
        SYMBOL_INTERFACEEVENTDEC          = 220, // <Interface Event Dec>
        SYMBOL_INTERFACEINDEXERDEC        = 221, // <Interface Indexer Dec>
        SYMBOL_INTERFACEITEMDEC           = 222, // <Interface Item Dec>
        SYMBOL_INTERFACEITEMDECSOPT       = 223, // <Interface Item Decs Opt>
        SYMBOL_INTERFACEMETHODDEC         = 224, // <Interface Method Dec>
        SYMBOL_INTERFACEPROPERTYDEC       = 225, // <Interface Property Dec>
        SYMBOL_LITERAL                    = 226, // <Literal>
        SYMBOL_LOCALVARDECL               = 227, // <Local Var Decl>
        SYMBOL_LOGICALANDEXP              = 228, // <Logical And Exp>
        SYMBOL_LOGICALOREXP               = 229, // <Logical Or Exp>
        SYMBOL_LOGICALXOREXP              = 230, // <Logical Xor Exp>
        SYMBOL_MEMBERLIST                 = 231, // <Member List>
        SYMBOL_METHOD2                    = 232, // <Method>
        SYMBOL_METHODDEC                  = 233, // <Method Dec>
        SYMBOL_METHODEXP                  = 234, // <Method Exp>
        SYMBOL_METHODSOPT                 = 235, // <Methods Opt>
        SYMBOL_MODIFIER                   = 236, // <Modifier>
        SYMBOL_MODIFIERLISTOPT            = 237, // <Modifier List Opt>
        SYMBOL_MULTEXP                    = 238, // <Mult Exp>
        SYMBOL_NAMESPACEDEC               = 239, // <Namespace Dec>
        SYMBOL_NAMESPACEITEM              = 240, // <Namespace Item>
        SYMBOL_NAMESPACEITEMS             = 241, // <Namespace Items>
        SYMBOL_NEWOPT                     = 242, // <New Opt>
        SYMBOL_NONARRAYTYPE               = 243, // <Non Array Type>
        SYMBOL_NORMALSTM                  = 244, // <Normal Stm>
        SYMBOL_OBJECTEXP                  = 245, // <Object Exp>
        SYMBOL_OPERATORDEC                = 246, // <Operator Dec>
        SYMBOL_OREXP                      = 247, // <Or Exp>
        SYMBOL_OTHERTYPE                  = 248, // <Other Type>
        SYMBOL_OVERLOADOP                 = 249, // <Overload Op>
        SYMBOL_OVERLOADOPERATORDECL       = 250, // <Overload Operator Decl>
        SYMBOL_POINTEROPT                 = 251, // <Pointer Opt>
        SYMBOL_PRIMARY                    = 252, // <Primary>
        SYMBOL_PRIMARYARRAYCREATIONEXP    = 253, // <Primary Array Creation Exp>
        SYMBOL_PRIMARYEXP                 = 254, // <Primary Exp>
        SYMBOL_PROPERTYDEC                = 255, // <Property Dec>
        SYMBOL_QUALIFIEDID                = 256, // <Qualified ID>
        SYMBOL_RANKSPECIFIER              = 257, // <Rank Specifier>
        SYMBOL_RANKSPECIFIERS             = 258, // <Rank Specifiers>
        SYMBOL_RANKSPECIFIERSOPT          = 259, // <Rank Specifiers Opt>
        SYMBOL_RESOURCE                   = 260, // <Resource>
        SYMBOL_SEMICOLONOPT               = 261, // <Semicolon Opt>
        SYMBOL_SHIFTEXP                   = 262, // <Shift Exp>
        SYMBOL_STATEMENT                  = 263, // <Statement>
        SYMBOL_STATEMENTEXP               = 264, // <Statement Exp>
        SYMBOL_STATEMENTEXPLIST           = 265, // <Statement Exp List>
        SYMBOL_STMLIST                    = 266, // <Stm List>
        SYMBOL_STRUCTDECL                 = 267, // <Struct Decl>
        SYMBOL_SWITCHLABEL                = 268, // <Switch Label>
        SYMBOL_SWITCHLABELS               = 269, // <Switch Labels>
        SYMBOL_SWITCHSECTION              = 270, // <Switch Section>
        SYMBOL_SWITCHSECTIONSOPT          = 271, // <Switch Sections Opt>
        SYMBOL_THENSTM                    = 272, // <Then Stm>
        SYMBOL_TYPE2                      = 273, // <Type>
        SYMBOL_TYPEDECL                   = 274, // <Type Decl>
        SYMBOL_UNARYEXP                   = 275, // <Unary Exp>
        SYMBOL_USINGDIRECTIVE             = 276, // <Using Directive>
        SYMBOL_USINGLIST                  = 277, // <Using List>
        SYMBOL_VALIDID                    = 278, // <Valid ID>
        SYMBOL_VARIABLEDECLARATOR         = 279, // <Variable Declarator>
        SYMBOL_VARIABLEDECS               = 280, // <Variable Decs>
        SYMBOL_VARIABLEINITIALIZER        = 281, // <Variable Initializer>
        SYMBOL_VARIABLEINITIALIZERLIST    = 282, // <Variable Initializer List>
        SYMBOL_VARIABLEINITIALIZERLISTOPT = 283  // <Variable Initializer List Opt>
    };

    enum RuleConstants : int
    {
        RULE_BLOCKORSEMI                                                             =   0, // <Block or Semi> ::= <Block>
        RULE_BLOCKORSEMI_SEMI                                                        =   1, // <Block or Semi> ::= ';'
        RULE_VALIDID_IDENTIFIER                                                      =   2, // <Valid ID> ::= Identifier
        RULE_VALIDID_THIS                                                            =   3, // <Valid ID> ::= this
        RULE_VALIDID_BASE                                                            =   4, // <Valid ID> ::= base
        RULE_VALIDID                                                                 =   5, // <Valid ID> ::= <Base Type>
        RULE_QUALIFIEDID                                                             =   6, // <Qualified ID> ::= <Valid ID> <Member List>
        RULE_MEMBERLIST_MEMBERNAME                                                   =   7, // <Member List> ::= <Member List> MemberName
        RULE_MEMBERLIST                                                              =   8, // <Member List> ::= 
        RULE_SEMICOLONOPT_SEMI                                                       =   9, // <Semicolon Opt> ::= ';'
        RULE_SEMICOLONOPT                                                            =  10, // <Semicolon Opt> ::= 
        RULE_LITERAL_TRUE                                                            =  11, // <Literal> ::= true
        RULE_LITERAL_FALSE                                                           =  12, // <Literal> ::= false
        RULE_LITERAL_DECLITERAL                                                      =  13, // <Literal> ::= DecLiteral
        RULE_LITERAL_HEXLITERAL                                                      =  14, // <Literal> ::= HexLiteral
        RULE_LITERAL_REALLITERAL                                                     =  15, // <Literal> ::= RealLiteral
        RULE_LITERAL_CHARLITERAL                                                     =  16, // <Literal> ::= CharLiteral
        RULE_LITERAL_STRINGLITERAL                                                   =  17, // <Literal> ::= StringLiteral
        RULE_LITERAL_NULL                                                            =  18, // <Literal> ::= null
        RULE_TYPE                                                                    =  19, // <Type> ::= <Non Array Type>
        RULE_TYPE_TIMES                                                              =  20, // <Type> ::= <Non Array Type> '*'
        RULE_TYPE2                                                                   =  21, // <Type> ::= <Non Array Type> <Rank Specifiers>
        RULE_TYPE_TIMES2                                                             =  22, // <Type> ::= <Non Array Type> <Rank Specifiers> '*'
        RULE_POINTEROPT_TIMES                                                        =  23, // <Pointer Opt> ::= '*'
        RULE_POINTEROPT                                                              =  24, // <Pointer Opt> ::= 
        RULE_NONARRAYTYPE                                                            =  25, // <Non Array Type> ::= <Qualified ID>
        RULE_BASETYPE                                                                =  26, // <Base Type> ::= <Other Type>
        RULE_BASETYPE2                                                               =  27, // <Base Type> ::= <Integral Type>
        RULE_OTHERTYPE_FLOAT                                                         =  28, // <Other Type> ::= float
        RULE_OTHERTYPE_DOUBLE                                                        =  29, // <Other Type> ::= double
        RULE_OTHERTYPE_DECIMAL                                                       =  30, // <Other Type> ::= decimal
        RULE_OTHERTYPE_BOOL                                                          =  31, // <Other Type> ::= bool
        RULE_OTHERTYPE_VOID                                                          =  32, // <Other Type> ::= void
        RULE_OTHERTYPE_OBJECT                                                        =  33, // <Other Type> ::= object
        RULE_OTHERTYPE_STRING                                                        =  34, // <Other Type> ::= string
        RULE_INTEGRALTYPE_SBYTE                                                      =  35, // <Integral Type> ::= sbyte
        RULE_INTEGRALTYPE_BYTE                                                       =  36, // <Integral Type> ::= byte
        RULE_INTEGRALTYPE_SHORT                                                      =  37, // <Integral Type> ::= short
        RULE_INTEGRALTYPE_USHORT                                                     =  38, // <Integral Type> ::= ushort
        RULE_INTEGRALTYPE_INT                                                        =  39, // <Integral Type> ::= int
        RULE_INTEGRALTYPE_UINT                                                       =  40, // <Integral Type> ::= uint
        RULE_INTEGRALTYPE_LONG                                                       =  41, // <Integral Type> ::= long
        RULE_INTEGRALTYPE_ULONG                                                      =  42, // <Integral Type> ::= ulong
        RULE_INTEGRALTYPE_CHAR                                                       =  43, // <Integral Type> ::= char
        RULE_RANKSPECIFIERSOPT                                                       =  44, // <Rank Specifiers Opt> ::= <Rank Specifiers Opt> <Rank Specifier>
        RULE_RANKSPECIFIERSOPT2                                                      =  45, // <Rank Specifiers Opt> ::= 
        RULE_RANKSPECIFIERS                                                          =  46, // <Rank Specifiers> ::= <Rank Specifiers> <Rank Specifier>
        RULE_RANKSPECIFIERS2                                                         =  47, // <Rank Specifiers> ::= <Rank Specifier>
        RULE_RANKSPECIFIER_LBRACKET_RBRACKET                                         =  48, // <Rank Specifier> ::= '[' <Dim Separators> ']'
        RULE_DIMSEPARATORS_COMMA                                                     =  49, // <Dim Separators> ::= <Dim Separators> ','
        RULE_DIMSEPARATORS                                                           =  50, // <Dim Separators> ::= 
        RULE_EXPRESSIONOPT                                                           =  51, // <Expression Opt> ::= <Expression>
        RULE_EXPRESSIONOPT2                                                          =  52, // <Expression Opt> ::= 
        RULE_EXPRESSIONLIST                                                          =  53, // <Expression List> ::= <Expression>
        RULE_EXPRESSIONLIST_COMMA                                                    =  54, // <Expression List> ::= <Expression> ',' <Expression List>
        RULE_EXPRESSION_EQ                                                           =  55, // <Expression> ::= <Conditional Exp> '=' <Expression>
        RULE_EXPRESSION_PLUSEQ                                                       =  56, // <Expression> ::= <Conditional Exp> '+=' <Expression>
        RULE_EXPRESSION_MINUSEQ                                                      =  57, // <Expression> ::= <Conditional Exp> '-=' <Expression>
        RULE_EXPRESSION_TIMESEQ                                                      =  58, // <Expression> ::= <Conditional Exp> '*=' <Expression>
        RULE_EXPRESSION_DIVEQ                                                        =  59, // <Expression> ::= <Conditional Exp> '/=' <Expression>
        RULE_EXPRESSION_CARETEQ                                                      =  60, // <Expression> ::= <Conditional Exp> '^=' <Expression>
        RULE_EXPRESSION_AMPEQ                                                        =  61, // <Expression> ::= <Conditional Exp> '&=' <Expression>
        RULE_EXPRESSION_PIPEEQ                                                       =  62, // <Expression> ::= <Conditional Exp> '|=' <Expression>
        RULE_EXPRESSION_PERCENTEQ                                                    =  63, // <Expression> ::= <Conditional Exp> '%=' <Expression>
        RULE_EXPRESSION_LTLTEQ                                                       =  64, // <Expression> ::= <Conditional Exp> '<<=' <Expression>
        RULE_EXPRESSION_GTGTEQ                                                       =  65, // <Expression> ::= <Conditional Exp> '>>=' <Expression>
        RULE_EXPRESSION                                                              =  66, // <Expression> ::= <Conditional Exp>
        RULE_CONDITIONALEXP_QUESTION_COLON                                           =  67, // <Conditional Exp> ::= <Or Exp> '?' <Or Exp> ':' <Conditional Exp>
        RULE_CONDITIONALEXP                                                          =  68, // <Conditional Exp> ::= <Or Exp>
        RULE_OREXP_OR                                                                =  69, // <Or Exp> ::= <Or Exp> or <And Exp>
        RULE_OREXP                                                                   =  70, // <Or Exp> ::= <And Exp>
        RULE_ANDEXP_AND                                                              =  71, // <And Exp> ::= <And Exp> and <Logical Or Exp>
        RULE_ANDEXP                                                                  =  72, // <And Exp> ::= <Logical Or Exp>
        RULE_LOGICALOREXP_PIPE                                                       =  73, // <Logical Or Exp> ::= <Logical Or Exp> '|' <Logical Xor Exp>
        RULE_LOGICALOREXP                                                            =  74, // <Logical Or Exp> ::= <Logical Xor Exp>
        RULE_LOGICALXOREXP_CARET                                                     =  75, // <Logical Xor Exp> ::= <Logical Xor Exp> '^' <Logical And Exp>
        RULE_LOGICALXOREXP                                                           =  76, // <Logical Xor Exp> ::= <Logical And Exp>
        RULE_LOGICALANDEXP_AMP                                                       =  77, // <Logical And Exp> ::= <Logical And Exp> '&' <Equality Exp>
        RULE_LOGICALANDEXP                                                           =  78, // <Logical And Exp> ::= <Equality Exp>
        RULE_EQUALITYEXP_EQEQ                                                        =  79, // <Equality Exp> ::= <Equality Exp> '==' <Compare Exp>
        RULE_EQUALITYEXP_NOT                                                         =  80, // <Equality Exp> ::= <Equality Exp> not <Compare Exp>
        RULE_EQUALITYEXP                                                             =  81, // <Equality Exp> ::= <Compare Exp>
        RULE_COMPAREEXP_LT                                                           =  82, // <Compare Exp> ::= <Compare Exp> '<' <Shift Exp>
        RULE_COMPAREEXP_GT                                                           =  83, // <Compare Exp> ::= <Compare Exp> '>' <Shift Exp>
        RULE_COMPAREEXP_LTEQ                                                         =  84, // <Compare Exp> ::= <Compare Exp> '<=' <Shift Exp>
        RULE_COMPAREEXP_GTEQ                                                         =  85, // <Compare Exp> ::= <Compare Exp> '>=' <Shift Exp>
        RULE_COMPAREEXP_IS                                                           =  86, // <Compare Exp> ::= <Compare Exp> is <Type>
        RULE_COMPAREEXP_AS                                                           =  87, // <Compare Exp> ::= <Compare Exp> as <Type>
        RULE_COMPAREEXP                                                              =  88, // <Compare Exp> ::= <Shift Exp>
        RULE_SHIFTEXP_LTLT                                                           =  89, // <Shift Exp> ::= <Shift Exp> '<<' <Add Exp>
        RULE_SHIFTEXP_GTGT                                                           =  90, // <Shift Exp> ::= <Shift Exp> '>>' <Add Exp>
        RULE_SHIFTEXP                                                                =  91, // <Shift Exp> ::= <Add Exp>
        RULE_ADDEXP_PLUS                                                             =  92, // <Add Exp> ::= <Add Exp> '+' <Mult Exp>
        RULE_ADDEXP_MINUS                                                            =  93, // <Add Exp> ::= <Add Exp> '-' <Mult Exp>
        RULE_ADDEXP                                                                  =  94, // <Add Exp> ::= <Mult Exp>
        RULE_MULTEXP_TIMES                                                           =  95, // <Mult Exp> ::= <Mult Exp> '*' <Unary Exp>
        RULE_MULTEXP_DIV                                                             =  96, // <Mult Exp> ::= <Mult Exp> '/' <Unary Exp>
        RULE_MULTEXP_PERCENT                                                         =  97, // <Mult Exp> ::= <Mult Exp> '%' <Unary Exp>
        RULE_MULTEXP                                                                 =  98, // <Mult Exp> ::= <Unary Exp>
        RULE_UNARYEXP_EXCLAM                                                         =  99, // <Unary Exp> ::= '!' <Unary Exp>
        RULE_UNARYEXP_TILDE                                                          = 100, // <Unary Exp> ::= '~' <Unary Exp>
        RULE_UNARYEXP_MINUS                                                          = 101, // <Unary Exp> ::= '-' <Unary Exp>
        RULE_UNARYEXP_PLUSPLUS                                                       = 102, // <Unary Exp> ::= '++' <Unary Exp>
        RULE_UNARYEXP_MINUSMINUS                                                     = 103, // <Unary Exp> ::= '--' <Unary Exp>
        RULE_UNARYEXP_LPAREN_RPAREN                                                  = 104, // <Unary Exp> ::= '(' <Expression> ')' <Object Exp>
        RULE_UNARYEXP                                                                = 105, // <Unary Exp> ::= <Object Exp>
        RULE_OBJECTEXP_DELEGATE_LPAREN_RPAREN                                        = 106, // <Object Exp> ::= delegate '(' <Formal Param List Opt> ')' <Block>
        RULE_OBJECTEXP                                                               = 107, // <Object Exp> ::= <Primary Array Creation Exp>
        RULE_OBJECTEXP2                                                              = 108, // <Object Exp> ::= <Method Exp>
        RULE_PRIMARYARRAYCREATIONEXP_NEW_LBRACKET_RBRACKET                           = 109, // <Primary Array Creation Exp> ::= new <Non Array Type> '[' <Expression List> ']' <Rank Specifiers Opt> <Array Initializer Opt>
        RULE_PRIMARYARRAYCREATIONEXP_NEW                                             = 110, // <Primary Array Creation Exp> ::= new <Non Array Type> <Rank Specifiers> <Array Initializer>
        RULE_METHODEXP                                                               = 111, // <Method Exp> ::= <Method Exp> <Method>
        RULE_METHODEXP2                                                              = 112, // <Method Exp> ::= <Primary Exp>
        RULE_PRIMARYEXP_TYPEOF_LPAREN_RPAREN                                         = 113, // <Primary Exp> ::= typeof '(' <Type> ')'
        RULE_PRIMARYEXP_SIZEOF_LPAREN_RPAREN                                         = 114, // <Primary Exp> ::= sizeof '(' <Type> ')'
        RULE_PRIMARYEXP_CHECKED_LPAREN_RPAREN                                        = 115, // <Primary Exp> ::= checked '(' <Expression> ')'
        RULE_PRIMARYEXP_UNCHECKED_LPAREN_RPAREN                                      = 116, // <Primary Exp> ::= unchecked '(' <Expression> ')'
        RULE_PRIMARYEXP_NEW_LPAREN_RPAREN                                            = 117, // <Primary Exp> ::= new <Non Array Type> '(' <Arg List Opt> ')'
        RULE_PRIMARYEXP                                                              = 118, // <Primary Exp> ::= <Primary>
        RULE_PRIMARYEXP_LPAREN_RPAREN                                                = 119, // <Primary Exp> ::= '(' <Expression> ')'
        RULE_PRIMARY                                                                 = 120, // <Primary> ::= <Valid ID>
        RULE_PRIMARY_LPAREN_RPAREN                                                   = 121, // <Primary> ::= <Valid ID> '(' <Arg List Opt> ')'
        RULE_PRIMARY2                                                                = 122, // <Primary> ::= <Literal>
        RULE_ARGLISTOPT                                                              = 123, // <Arg List Opt> ::= <Arg List>
        RULE_ARGLISTOPT2                                                             = 124, // <Arg List Opt> ::= 
        RULE_ARGLIST_COMMA                                                           = 125, // <Arg List> ::= <Arg List> ',' <Argument>
        RULE_ARGLIST                                                                 = 126, // <Arg List> ::= <Argument>
        RULE_ARGUMENT                                                                = 127, // <Argument> ::= <Expression>
        RULE_ARGUMENT_REF                                                            = 128, // <Argument> ::= ref <Expression>
        RULE_ARGUMENT_OUT                                                            = 129, // <Argument> ::= out <Expression>
        RULE_STMLIST                                                                 = 130, // <Stm List> ::= <Stm List> <Statement>
        RULE_STMLIST2                                                                = 131, // <Stm List> ::= <Statement>
        RULE_STATEMENT_IDENTIFIER_COLON                                              = 132, // <Statement> ::= Identifier ':'
        RULE_STATEMENT_SEMI                                                          = 133, // <Statement> ::= <Local Var Decl> ';'
        RULE_STATEMENT_IF_LPAREN_RPAREN                                              = 134, // <Statement> ::= if '(' <Expression> ')' <Statement>
        RULE_STATEMENT_IF_LPAREN_RPAREN_ELSE                                         = 135, // <Statement> ::= if '(' <Expression> ')' <Then Stm> else <Statement>
        RULE_STATEMENT_ELSEIF_LPAREN_RPAREN                                          = 136, // <Statement> ::= elseif '(' <Expression> ')' <Statement>
        RULE_STATEMENT_FOR_LPAREN_SEMI_SEMI_RPAREN                                   = 137, // <Statement> ::= for '(' <For Init Opt> ';' <For Condition Opt> ';' <For Iterator Opt> ')' <Statement>
        RULE_STATEMENT_FOREACH_LPAREN_IDENTIFIER_IN_RPAREN                           = 138, // <Statement> ::= foreach '(' <Type> Identifier in <Expression> ')' <Statement>
        RULE_STATEMENT_WHILE_LPAREN_RPAREN                                           = 139, // <Statement> ::= while '(' <Expression> ')' <Statement>
        RULE_STATEMENT_LOCK_LPAREN_RPAREN                                            = 140, // <Statement> ::= lock '(' <Expression> ')' <Statement>
        RULE_STATEMENT_USING_LPAREN_RPAREN                                           = 141, // <Statement> ::= using '(' <Resource> ')' <Statement>
        RULE_STATEMENT_FIXED_LPAREN_RPAREN                                           = 142, // <Statement> ::= fixed '(' <Type> <Fixed Ptr Decs> ')' <Statement>
        RULE_STATEMENT_DELEGATE_LPAREN_RPAREN                                        = 143, // <Statement> ::= delegate '(' <Formal Param List Opt> ')' <Statement>
        RULE_STATEMENT                                                               = 144, // <Statement> ::= <Normal Stm>
        RULE_THENSTM_IF_LPAREN_RPAREN_ELSE                                           = 145, // <Then Stm> ::= if '(' <Expression> ')' <Then Stm> else <Then Stm>
        RULE_THENSTM_FOR_LPAREN_SEMI_SEMI_RPAREN                                     = 146, // <Then Stm> ::= for '(' <For Init Opt> ';' <For Condition Opt> ';' <For Iterator Opt> ')' <Then Stm>
        RULE_THENSTM_FOREACH_LPAREN_IDENTIFIER_IN_RPAREN                             = 147, // <Then Stm> ::= foreach '(' <Type> Identifier in <Expression> ')' <Then Stm>
        RULE_THENSTM_WHILE_LPAREN_RPAREN                                             = 148, // <Then Stm> ::= while '(' <Expression> ')' <Then Stm>
        RULE_THENSTM_LOCK_LPAREN_RPAREN                                              = 149, // <Then Stm> ::= lock '(' <Expression> ')' <Then Stm>
        RULE_THENSTM_USING_LPAREN_RPAREN                                             = 150, // <Then Stm> ::= using '(' <Resource> ')' <Then Stm>
        RULE_THENSTM_FIXED_LPAREN_RPAREN                                             = 151, // <Then Stm> ::= fixed '(' <Type> <Fixed Ptr Decs> ')' <Then Stm>
        RULE_THENSTM_DELEGATE_LPAREN_RPAREN                                          = 152, // <Then Stm> ::= delegate '(' <Formal Param List Opt> ')' <Then Stm>
        RULE_THENSTM                                                                 = 153, // <Then Stm> ::= <Normal Stm>
        RULE_NORMALSTM_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE                            = 154, // <Normal Stm> ::= switch '(' <Expression> ')' '{' <Switch Sections Opt> '}'
        RULE_NORMALSTM_DO_WHILE_LPAREN_RPAREN_SEMI                                   = 155, // <Normal Stm> ::= do <Normal Stm> while '(' <Expression> ')' ';'
        RULE_NORMALSTM_TRY                                                           = 156, // <Normal Stm> ::= try <Block> <Catch Clauses> <Finally Clause Opt>
        RULE_NORMALSTM_CHECKED                                                       = 157, // <Normal Stm> ::= checked <Block>
        RULE_NORMALSTM_UNCHECKED                                                     = 158, // <Normal Stm> ::= unchecked <Block>
        RULE_NORMALSTM_UNSAFE                                                        = 159, // <Normal Stm> ::= unsafe <Block>
        RULE_NORMALSTM_BREAK_SEMI                                                    = 160, // <Normal Stm> ::= break ';'
        RULE_NORMALSTM_CONTINUE_SEMI                                                 = 161, // <Normal Stm> ::= continue ';'
        RULE_NORMALSTM_GOTO_IDENTIFIER_SEMI                                          = 162, // <Normal Stm> ::= goto Identifier ';'
        RULE_NORMALSTM_GOTO_CASE_SEMI                                                = 163, // <Normal Stm> ::= goto case <Expression> ';'
        RULE_NORMALSTM_GOTO_DEFAULT_SEMI                                             = 164, // <Normal Stm> ::= goto default ';'
        RULE_NORMALSTM_RETURN_SEMI                                                   = 165, // <Normal Stm> ::= return <Expression Opt> ';'
        RULE_NORMALSTM_THROW_SEMI                                                    = 166, // <Normal Stm> ::= throw <Expression Opt> ';'
        RULE_NORMALSTM_SEMI                                                          = 167, // <Normal Stm> ::= <Statement Exp> ';'
        RULE_NORMALSTM_SEMI2                                                         = 168, // <Normal Stm> ::= ';'
        RULE_NORMALSTM                                                               = 169, // <Normal Stm> ::= <Block>
        RULE_BLOCK_LBRACE_RBRACE                                                     = 170, // <Block> ::= '{' <Stm List> '}'
        RULE_BLOCK_LBRACE_RBRACE2                                                    = 171, // <Block> ::= '{' '}'
        RULE_VARIABLEDECS                                                            = 172, // <Variable Decs> ::= <Variable Declarator>
        RULE_VARIABLEDECS_COMMA                                                      = 173, // <Variable Decs> ::= <Variable Decs> ',' <Variable Declarator>
        RULE_VARIABLEDECLARATOR_IDENTIFIER                                           = 174, // <Variable Declarator> ::= Identifier
        RULE_VARIABLEDECLARATOR_IDENTIFIER_EQ                                        = 175, // <Variable Declarator> ::= Identifier '=' <Variable Initializer>
        RULE_VARIABLEINITIALIZER                                                     = 176, // <Variable Initializer> ::= <Expression>
        RULE_VARIABLEINITIALIZER2                                                    = 177, // <Variable Initializer> ::= <Array Initializer>
        RULE_VARIABLEINITIALIZER_STACKALLOC_LBRACKET_RBRACKET                        = 178, // <Variable Initializer> ::= stackalloc <Non Array Type> '[' <Non Array Type> ']'
        RULE_CONSTANTDECLARATORS                                                     = 179, // <Constant Declarators> ::= <Constant Declarator>
        RULE_CONSTANTDECLARATORS_COMMA                                               = 180, // <Constant Declarators> ::= <Constant Declarators> ',' <Constant Declarator>
        RULE_CONSTANTDECLARATOR_IDENTIFIER_EQ                                        = 181, // <Constant Declarator> ::= Identifier '=' <Expression>
        RULE_SWITCHSECTIONSOPT                                                       = 182, // <Switch Sections Opt> ::= <Switch Sections Opt> <Switch Section>
        RULE_SWITCHSECTIONSOPT2                                                      = 183, // <Switch Sections Opt> ::= 
        RULE_SWITCHSECTION                                                           = 184, // <Switch Section> ::= <Switch Labels> <Stm List>
        RULE_SWITCHLABELS                                                            = 185, // <Switch Labels> ::= <Switch Label>
        RULE_SWITCHLABELS2                                                           = 186, // <Switch Labels> ::= <Switch Labels> <Switch Label>
        RULE_SWITCHLABEL_CASE_COLON                                                  = 187, // <Switch Label> ::= case <Expression> ':'
        RULE_SWITCHLABEL_DEFAULT_COLON                                               = 188, // <Switch Label> ::= default ':'
        RULE_FORINITOPT                                                              = 189, // <For Init Opt> ::= <Local Var Decl>
        RULE_FORINITOPT2                                                             = 190, // <For Init Opt> ::= <Statement Exp List>
        RULE_FORINITOPT3                                                             = 191, // <For Init Opt> ::= 
        RULE_FORITERATOROPT                                                          = 192, // <For Iterator Opt> ::= <Statement Exp List>
        RULE_FORITERATOROPT2                                                         = 193, // <For Iterator Opt> ::= 
        RULE_FORCONDITIONOPT                                                         = 194, // <For Condition Opt> ::= <Expression>
        RULE_FORCONDITIONOPT2                                                        = 195, // <For Condition Opt> ::= 
        RULE_STATEMENTEXPLIST_COMMA                                                  = 196, // <Statement Exp List> ::= <Statement Exp List> ',' <Statement Exp>
        RULE_STATEMENTEXPLIST                                                        = 197, // <Statement Exp List> ::= <Statement Exp>
        RULE_CATCHCLAUSES                                                            = 198, // <Catch Clauses> ::= <Catch Clause> <Catch Clauses>
        RULE_CATCHCLAUSES2                                                           = 199, // <Catch Clauses> ::= 
        RULE_CATCHCLAUSE_CATCH_LPAREN_IDENTIFIER_RPAREN                              = 200, // <Catch Clause> ::= catch '(' <Qualified ID> Identifier ')' <Block>
        RULE_CATCHCLAUSE_CATCH_LPAREN_RPAREN                                         = 201, // <Catch Clause> ::= catch '(' <Qualified ID> ')' <Block>
        RULE_CATCHCLAUSE_CATCH                                                       = 202, // <Catch Clause> ::= catch <Block>
        RULE_FINALLYCLAUSEOPT_FINALLY                                                = 203, // <Finally Clause Opt> ::= finally <Block>
        RULE_FINALLYCLAUSEOPT                                                        = 204, // <Finally Clause Opt> ::= 
        RULE_RESOURCE                                                                = 205, // <Resource> ::= <Local Var Decl>
        RULE_RESOURCE2                                                               = 206, // <Resource> ::= <Statement Exp>
        RULE_FIXEDPTRDECS                                                            = 207, // <Fixed Ptr Decs> ::= <Fixed Ptr Dec>
        RULE_FIXEDPTRDECS_COMMA                                                      = 208, // <Fixed Ptr Decs> ::= <Fixed Ptr Decs> ',' <Fixed Ptr Dec>
        RULE_FIXEDPTRDEC_IDENTIFIER_EQ                                               = 209, // <Fixed Ptr Dec> ::= Identifier '=' <Expression>
        RULE_LOCALVARDECL                                                            = 210, // <Local Var Decl> ::= <Qualified ID> <Rank Specifiers> <Pointer Opt> <Variable Decs>
        RULE_LOCALVARDECL2                                                           = 211, // <Local Var Decl> ::= <Qualified ID> <Pointer Opt> <Variable Decs>
        RULE_STATEMENTEXP_LPAREN_RPAREN                                              = 212, // <Statement Exp> ::= <Qualified ID> '(' <Arg List Opt> ')'
        RULE_STATEMENTEXP_LPAREN_RPAREN2                                             = 213, // <Statement Exp> ::= <Qualified ID> '(' <Arg List Opt> ')' <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP_LBRACKET_RBRACKET                                          = 214, // <Statement Exp> ::= <Qualified ID> '[' <Expression List> ']' <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP_MINUSGT_IDENTIFIER                                         = 215, // <Statement Exp> ::= <Qualified ID> '->' Identifier <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP_PLUSPLUS                                                   = 216, // <Statement Exp> ::= <Qualified ID> '++' <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP_MINUSMINUS                                                 = 217, // <Statement Exp> ::= <Qualified ID> '--' <Methods Opt> <Assign Tail>
        RULE_STATEMENTEXP                                                            = 218, // <Statement Exp> ::= <Qualified ID> <Assign Tail>
        RULE_ASSIGNTAIL_PLUSPLUS                                                     = 219, // <Assign Tail> ::= '++'
        RULE_ASSIGNTAIL_MINUSMINUS                                                   = 220, // <Assign Tail> ::= '--'
        RULE_ASSIGNTAIL_EQ                                                           = 221, // <Assign Tail> ::= '=' <Expression>
        RULE_ASSIGNTAIL_PLUSEQ                                                       = 222, // <Assign Tail> ::= '+=' <Expression>
        RULE_ASSIGNTAIL_MINUSEQ                                                      = 223, // <Assign Tail> ::= '-=' <Expression>
        RULE_ASSIGNTAIL_TIMESEQ                                                      = 224, // <Assign Tail> ::= '*=' <Expression>
        RULE_ASSIGNTAIL_DIVEQ                                                        = 225, // <Assign Tail> ::= '/=' <Expression>
        RULE_ASSIGNTAIL_CARETEQ                                                      = 226, // <Assign Tail> ::= '^=' <Expression>
        RULE_ASSIGNTAIL_AMPEQ                                                        = 227, // <Assign Tail> ::= '&=' <Expression>
        RULE_ASSIGNTAIL_PIPEEQ                                                       = 228, // <Assign Tail> ::= '|=' <Expression>
        RULE_ASSIGNTAIL_PERCENTEQ                                                    = 229, // <Assign Tail> ::= '%=' <Expression>
        RULE_ASSIGNTAIL_LTLTEQ                                                       = 230, // <Assign Tail> ::= '<<=' <Expression>
        RULE_ASSIGNTAIL_GTGTEQ                                                       = 231, // <Assign Tail> ::= '>>=' <Expression>
        RULE_METHODSOPT                                                              = 232, // <Methods Opt> ::= <Methods Opt> <Method>
        RULE_METHODSOPT2                                                             = 233, // <Methods Opt> ::= 
        RULE_METHOD_MEMBERNAME                                                       = 234, // <Method> ::= MemberName
        RULE_METHOD_MEMBERNAME_LPAREN_RPAREN                                         = 235, // <Method> ::= MemberName '(' <Arg List Opt> ')'
        RULE_METHOD_LBRACKET_RBRACKET                                                = 236, // <Method> ::= '[' <Expression List> ']'
        RULE_METHOD_MINUSGT_IDENTIFIER                                               = 237, // <Method> ::= '->' Identifier
        RULE_METHOD_PLUSPLUS                                                         = 238, // <Method> ::= '++'
        RULE_METHOD_MINUSMINUS                                                       = 239, // <Method> ::= '--'
        RULE_COMPILATIONUNIT                                                         = 240, // <Compilation Unit> ::= <Using List> <Compilation Items>
        RULE_USINGLIST                                                               = 241, // <Using List> ::= <Using List> <Using Directive>
        RULE_USINGLIST2                                                              = 242, // <Using List> ::= 
        RULE_USINGDIRECTIVE_USING_IDENTIFIER_EQ_SEMI                                 = 243, // <Using Directive> ::= using Identifier '=' <Qualified ID> ';'
        RULE_USINGDIRECTIVE_USING_SEMI                                               = 244, // <Using Directive> ::= using <Qualified ID> ';'
        RULE_COMPILATIONITEMS                                                        = 245, // <Compilation Items> ::= <Compilation Items> <Compilation Item>
        RULE_COMPILATIONITEMS2                                                       = 246, // <Compilation Items> ::= 
        RULE_COMPILATIONITEM                                                         = 247, // <Compilation Item> ::= <Namespace Dec>
        RULE_COMPILATIONITEM2                                                        = 248, // <Compilation Item> ::= <Namespace Item>
        RULE_NAMESPACEDEC_NAMESPACE_LBRACE_RBRACE                                    = 249, // <Namespace Dec> ::= <Attrib Opt> namespace <Qualified ID> '{' <Using List> <Namespace Items> '}' <Semicolon Opt>
        RULE_NAMESPACEITEMS                                                          = 250, // <Namespace Items> ::= <Namespace Items> <Namespace Item>
        RULE_NAMESPACEITEMS2                                                         = 251, // <Namespace Items> ::= 
        RULE_NAMESPACEITEM                                                           = 252, // <Namespace Item> ::= <Constant Dec>
        RULE_NAMESPACEITEM2                                                          = 253, // <Namespace Item> ::= <Field Dec>
        RULE_NAMESPACEITEM3                                                          = 254, // <Namespace Item> ::= <Method Dec>
        RULE_NAMESPACEITEM4                                                          = 255, // <Namespace Item> ::= <Property Dec>
        RULE_NAMESPACEITEM5                                                          = 256, // <Namespace Item> ::= <Type Decl>
        RULE_TYPEDECL                                                                = 257, // <Type Decl> ::= <Class Decl>
        RULE_TYPEDECL2                                                               = 258, // <Type Decl> ::= <Struct Decl>
        RULE_TYPEDECL3                                                               = 259, // <Type Decl> ::= <Interface Decl>
        RULE_TYPEDECL4                                                               = 260, // <Type Decl> ::= <Enum Decl>
        RULE_TYPEDECL5                                                               = 261, // <Type Decl> ::= <Delegate Decl>
        RULE_HEADER                                                                  = 262, // <Header> ::= <Attrib Opt> <Access Opt> <Modifier List Opt>
        RULE_ACCESSOPT_PRIVATE                                                       = 263, // <Access Opt> ::= private
        RULE_ACCESSOPT_PROTECTED                                                     = 264, // <Access Opt> ::= protected
        RULE_ACCESSOPT_PUBLIC                                                        = 265, // <Access Opt> ::= public
        RULE_ACCESSOPT_INTERNAL                                                      = 266, // <Access Opt> ::= internal
        RULE_ACCESSOPT                                                               = 267, // <Access Opt> ::= 
        RULE_MODIFIERLISTOPT                                                         = 268, // <Modifier List Opt> ::= <Modifier List Opt> <Modifier>
        RULE_MODIFIERLISTOPT2                                                        = 269, // <Modifier List Opt> ::= 
        RULE_MODIFIER_ABSTRACT                                                       = 270, // <Modifier> ::= abstract
        RULE_MODIFIER_EXTERN                                                         = 271, // <Modifier> ::= extern
        RULE_MODIFIER_NEW                                                            = 272, // <Modifier> ::= new
        RULE_MODIFIER_OVERRIDE                                                       = 273, // <Modifier> ::= override
        RULE_MODIFIER_PARTIAL                                                        = 274, // <Modifier> ::= partial
        RULE_MODIFIER_READONLY                                                       = 275, // <Modifier> ::= readonly
        RULE_MODIFIER_SEALED                                                         = 276, // <Modifier> ::= sealed
        RULE_MODIFIER_STATIC                                                         = 277, // <Modifier> ::= static
        RULE_MODIFIER_UNSAFE                                                         = 278, // <Modifier> ::= unsafe
        RULE_MODIFIER_VIRTUAL                                                        = 279, // <Modifier> ::= virtual
        RULE_MODIFIER_VOLATILE                                                       = 280, // <Modifier> ::= volatile
        RULE_CLASSDECL_CLASS_IDENTIFIER_LBRACE_RBRACE                                = 281, // <Class Decl> ::= <Header> class Identifier <Class Base Opt> '{' <Class Item Decs Opt> '}' <Semicolon Opt>
        RULE_CLASSBASEOPT_COLON                                                      = 282, // <Class Base Opt> ::= ':' <Class Base List>
        RULE_CLASSBASEOPT                                                            = 283, // <Class Base Opt> ::= 
        RULE_CLASSBASELIST_COMMA                                                     = 284, // <Class Base List> ::= <Class Base List> ',' <Non Array Type>
        RULE_CLASSBASELIST                                                           = 285, // <Class Base List> ::= <Non Array Type>
        RULE_CLASSITEMDECSOPT                                                        = 286, // <Class Item Decs Opt> ::= <Class Item Decs Opt> <Class Item>
        RULE_CLASSITEMDECSOPT2                                                       = 287, // <Class Item Decs Opt> ::= 
        RULE_CLASSITEM                                                               = 288, // <Class Item> ::= <Constant Dec>
        RULE_CLASSITEM2                                                              = 289, // <Class Item> ::= <Field Dec>
        RULE_CLASSITEM3                                                              = 290, // <Class Item> ::= <Method Dec>
        RULE_CLASSITEM4                                                              = 291, // <Class Item> ::= <Property Dec>
        RULE_CLASSITEM5                                                              = 292, // <Class Item> ::= <Event Dec>
        RULE_CLASSITEM6                                                              = 293, // <Class Item> ::= <Indexer Dec>
        RULE_CLASSITEM7                                                              = 294, // <Class Item> ::= <Operator Dec>
        RULE_CLASSITEM8                                                              = 295, // <Class Item> ::= <Constructor Dec>
        RULE_CLASSITEM9                                                              = 296, // <Class Item> ::= <Destructor Dec>
        RULE_CLASSITEM10                                                             = 297, // <Class Item> ::= <Type Decl>
        RULE_CONSTANTDEC_CONST_SEMI                                                  = 298, // <Constant Dec> ::= <Header> const <Type> <Constant Declarators> ';'
        RULE_FIELDDEC_SEMI                                                           = 299, // <Field Dec> ::= <Header> <Type> <Variable Decs> ';'
        RULE_METHODDEC_LPAREN_RPAREN                                                 = 300, // <Method Dec> ::= <Header> <Type> <Qualified ID> '(' <Formal Param List Opt> ')' <Block or Semi>
        RULE_FORMALPARAMLISTOPT                                                      = 301, // <Formal Param List Opt> ::= <Formal Param List>
        RULE_FORMALPARAMLISTOPT2                                                     = 302, // <Formal Param List Opt> ::= 
        RULE_FORMALPARAMLIST                                                         = 303, // <Formal Param List> ::= <Formal Param>
        RULE_FORMALPARAMLIST_COMMA                                                   = 304, // <Formal Param List> ::= <Formal Param List> ',' <Formal Param>
        RULE_FORMALPARAM_IDENTIFIER                                                  = 305, // <Formal Param> ::= <Attrib Opt> <Type> Identifier
        RULE_FORMALPARAM_REF_IDENTIFIER                                              = 306, // <Formal Param> ::= <Attrib Opt> ref <Type> Identifier
        RULE_FORMALPARAM_OUT_IDENTIFIER                                              = 307, // <Formal Param> ::= <Attrib Opt> out <Type> Identifier
        RULE_FORMALPARAM_PARAMS_IDENTIFIER                                           = 308, // <Formal Param> ::= <Attrib Opt> params <Type> Identifier
        RULE_PROPERTYDEC_LBRACE_RBRACE                                               = 309, // <Property Dec> ::= <Header> <Type> <Qualified ID> '{' <Accessor Dec> '}'
        RULE_ACCESSORDEC_GET                                                         = 310, // <Accessor Dec> ::= <Access Opt> get <Block or Semi>
        RULE_ACCESSORDEC_GET_SET                                                     = 311, // <Accessor Dec> ::= <Access Opt> get <Block or Semi> <Access Opt> set <Block or Semi>
        RULE_ACCESSORDEC_SET                                                         = 312, // <Accessor Dec> ::= <Access Opt> set <Block or Semi>
        RULE_ACCESSORDEC_SET_GET                                                     = 313, // <Accessor Dec> ::= <Access Opt> set <Block or Semi> <Access Opt> get <Block or Semi>
        RULE_EVENTDEC_EVENT_SEMI                                                     = 314, // <Event Dec> ::= <Header> event <Type> <Variable Decs> ';'
        RULE_EVENTDEC_EVENT_LBRACE_RBRACE                                            = 315, // <Event Dec> ::= <Header> event <Type> <Qualified ID> '{' <Event Accessor Decs> '}'
        RULE_EVENTACCESSORDECS_ADD                                                   = 316, // <Event Accessor Decs> ::= add <Block or Semi>
        RULE_EVENTACCESSORDECS_ADD_REMOVE                                            = 317, // <Event Accessor Decs> ::= add <Block or Semi> remove <Block or Semi>
        RULE_EVENTACCESSORDECS_REMOVE                                                = 318, // <Event Accessor Decs> ::= remove <Block or Semi>
        RULE_EVENTACCESSORDECS_REMOVE_ADD                                            = 319, // <Event Accessor Decs> ::= remove <Block or Semi> add <Block or Semi>
        RULE_INDEXERDEC_LBRACKET_RBRACKET_LBRACE_RBRACE                              = 320, // <Indexer Dec> ::= <Header> <Type> <Qualified ID> '[' <Formal Param List> ']' '{' <Accessor Dec> '}'
        RULE_OPERATORDEC                                                             = 321, // <Operator Dec> ::= <Header> <Overload Operator Decl> <Block or Semi>
        RULE_OPERATORDEC2                                                            = 322, // <Operator Dec> ::= <Header> <Conversion Operator Decl> <Block or Semi>
        RULE_OVERLOADOPERATORDECL_OPERATOR_LPAREN_IDENTIFIER_RPAREN                  = 323, // <Overload Operator Decl> ::= <Type> operator <Overload Op> '(' <Type> Identifier ')'
        RULE_OVERLOADOPERATORDECL_OPERATOR_LPAREN_IDENTIFIER_COMMA_IDENTIFIER_RPAREN = 324, // <Overload Operator Decl> ::= <Type> operator <Overload Op> '(' <Type> Identifier ',' <Type> Identifier ')'
        RULE_CONVERSIONOPERATORDECL_IMPLICIT_OPERATOR_LPAREN_IDENTIFIER_RPAREN       = 325, // <Conversion Operator Decl> ::= implicit operator <Type> '(' <Type> Identifier ')'
        RULE_CONVERSIONOPERATORDECL_EXPLICIT_OPERATOR_LPAREN_IDENTIFIER_RPAREN       = 326, // <Conversion Operator Decl> ::= explicit operator <Type> '(' <Type> Identifier ')'
        RULE_OVERLOADOP_PLUS                                                         = 327, // <Overload Op> ::= '+'
        RULE_OVERLOADOP_MINUS                                                        = 328, // <Overload Op> ::= '-'
        RULE_OVERLOADOP_EXCLAM                                                       = 329, // <Overload Op> ::= '!'
        RULE_OVERLOADOP_TILDE                                                        = 330, // <Overload Op> ::= '~'
        RULE_OVERLOADOP_PLUSPLUS                                                     = 331, // <Overload Op> ::= '++'
        RULE_OVERLOADOP_MINUSMINUS                                                   = 332, // <Overload Op> ::= '--'
        RULE_OVERLOADOP_TRUE                                                         = 333, // <Overload Op> ::= true
        RULE_OVERLOADOP_FALSE                                                        = 334, // <Overload Op> ::= false
        RULE_OVERLOADOP_TIMES                                                        = 335, // <Overload Op> ::= '*'
        RULE_OVERLOADOP_DIV                                                          = 336, // <Overload Op> ::= '/'
        RULE_OVERLOADOP_PERCENT                                                      = 337, // <Overload Op> ::= '%'
        RULE_OVERLOADOP_AMP                                                          = 338, // <Overload Op> ::= '&'
        RULE_OVERLOADOP_PIPE                                                         = 339, // <Overload Op> ::= '|'
        RULE_OVERLOADOP_CARET                                                        = 340, // <Overload Op> ::= '^'
        RULE_OVERLOADOP_LTLT                                                         = 341, // <Overload Op> ::= '<<'
        RULE_OVERLOADOP_GTGT                                                         = 342, // <Overload Op> ::= '>>'
        RULE_OVERLOADOP_EQEQ                                                         = 343, // <Overload Op> ::= '=='
        RULE_OVERLOADOP_EXCLAMEQ                                                     = 344, // <Overload Op> ::= '!='
        RULE_OVERLOADOP_GT                                                           = 345, // <Overload Op> ::= '>'
        RULE_OVERLOADOP_LT                                                           = 346, // <Overload Op> ::= '<'
        RULE_OVERLOADOP_GTEQ                                                         = 347, // <Overload Op> ::= '>='
        RULE_OVERLOADOP_LTEQ                                                         = 348, // <Overload Op> ::= '<='
        RULE_CONSTRUCTORDEC                                                          = 349, // <Constructor Dec> ::= <Header> <Constructor Declarator> <Block or Semi>
        RULE_CONSTRUCTORDECLARATOR_IDENTIFIER_LPAREN_RPAREN                          = 350, // <Constructor Declarator> ::= Identifier '(' <Formal Param List Opt> ')' <Constructor Init Opt>
        RULE_CONSTRUCTORINITOPT                                                      = 351, // <Constructor Init Opt> ::= <Constructor Init>
        RULE_CONSTRUCTORINITOPT2                                                     = 352, // <Constructor Init Opt> ::= 
        RULE_CONSTRUCTORINIT_COLON_BASE_LPAREN_RPAREN                                = 353, // <Constructor Init> ::= ':' base '(' <Arg List Opt> ')'
        RULE_CONSTRUCTORINIT_COLON_THIS_LPAREN_RPAREN                                = 354, // <Constructor Init> ::= ':' this '(' <Arg List Opt> ')'
        RULE_DESTRUCTORDEC_TILDE_IDENTIFIER_LPAREN_RPAREN                            = 355, // <Destructor Dec> ::= <Header> '~' Identifier '(' ')' <Block>
        RULE_STRUCTDECL_STRUCT_IDENTIFIER_LBRACE_RBRACE                              = 356, // <Struct Decl> ::= <Header> struct Identifier <Class Base Opt> '{' <Class Item Decs Opt> '}' <Semicolon Opt>
        RULE_ARRAYINITIALIZEROPT                                                     = 357, // <Array Initializer Opt> ::= <Array Initializer>
        RULE_ARRAYINITIALIZEROPT2                                                    = 358, // <Array Initializer Opt> ::= 
        RULE_ARRAYINITIALIZER_LBRACE_RBRACE                                          = 359, // <Array Initializer> ::= '{' <Variable Initializer List Opt> '}'
        RULE_ARRAYINITIALIZER_LBRACE_COMMA_RBRACE                                    = 360, // <Array Initializer> ::= '{' <Variable Initializer List> ',' '}'
        RULE_VARIABLEINITIALIZERLISTOPT                                              = 361, // <Variable Initializer List Opt> ::= <Variable Initializer List>
        RULE_VARIABLEINITIALIZERLISTOPT2                                             = 362, // <Variable Initializer List Opt> ::= 
        RULE_VARIABLEINITIALIZERLIST                                                 = 363, // <Variable Initializer List> ::= <Variable Initializer>
        RULE_VARIABLEINITIALIZERLIST_COMMA                                           = 364, // <Variable Initializer List> ::= <Variable Initializer List> ',' <Variable Initializer>
        RULE_INTERFACEDECL_INTERFACE_IDENTIFIER_LBRACE_RBRACE                        = 365, // <Interface Decl> ::= <Header> interface Identifier <Interface Base Opt> '{' <Interface Item Decs Opt> '}' <Semicolon Opt>
        RULE_INTERFACEBASEOPT_COLON                                                  = 366, // <Interface Base Opt> ::= ':' <Class Base List>
        RULE_INTERFACEBASEOPT                                                        = 367, // <Interface Base Opt> ::= 
        RULE_INTERFACEITEMDECSOPT                                                    = 368, // <Interface Item Decs Opt> ::= <Interface Item Decs Opt> <Interface Item Dec>
        RULE_INTERFACEITEMDECSOPT2                                                   = 369, // <Interface Item Decs Opt> ::= 
        RULE_INTERFACEITEMDEC                                                        = 370, // <Interface Item Dec> ::= <Interface Method Dec>
        RULE_INTERFACEITEMDEC2                                                       = 371, // <Interface Item Dec> ::= <Interface Property Dec>
        RULE_INTERFACEITEMDEC3                                                       = 372, // <Interface Item Dec> ::= <Interface Event Dec>
        RULE_INTERFACEITEMDEC4                                                       = 373, // <Interface Item Dec> ::= <Interface Indexer Dec>
        RULE_INTERFACEMETHODDEC_IDENTIFIER_LPAREN_RPAREN                             = 374, // <Interface Method Dec> ::= <Attrib Opt> <New Opt> <Type> Identifier '(' <Formal Param List Opt> ')' <Interface Empty Body>
        RULE_NEWOPT_NEW                                                              = 375, // <New Opt> ::= new
        RULE_NEWOPT                                                                  = 376, // <New Opt> ::= 
        RULE_INTERFACEPROPERTYDEC_IDENTIFIER_LBRACE_RBRACE                           = 377, // <Interface Property Dec> ::= <Attrib Opt> <New Opt> <Type> Identifier '{' <Interface Accessors> '}'
        RULE_INTERFACEINDEXERDEC_THIS_LBRACKET_RBRACKET_LBRACE_RBRACE                = 378, // <Interface Indexer Dec> ::= <Attrib Opt> <New Opt> <Type> this '[' <Formal Param List> ']' '{' <Interface Accessors> '}'
        RULE_INTERFACEACCESSORS_GET                                                  = 379, // <Interface Accessors> ::= <Attrib Opt> <Access Opt> get <Interface Empty Body>
        RULE_INTERFACEACCESSORS_SET                                                  = 380, // <Interface Accessors> ::= <Attrib Opt> <Access Opt> set <Interface Empty Body>
        RULE_INTERFACEACCESSORS_GET_SET                                              = 381, // <Interface Accessors> ::= <Attrib Opt> <Access Opt> get <Interface Empty Body> <Attrib Opt> <Access Opt> set <Interface Empty Body>
        RULE_INTERFACEACCESSORS_SET_GET                                              = 382, // <Interface Accessors> ::= <Attrib Opt> <Access Opt> set <Interface Empty Body> <Attrib Opt> <Access Opt> get <Interface Empty Body>
        RULE_INTERFACEEVENTDEC_EVENT_IDENTIFIER                                      = 383, // <Interface Event Dec> ::= <Attrib Opt> <New Opt> event <Type> Identifier <Interface Empty Body>
        RULE_INTERFACEEMPTYBODY_SEMI                                                 = 384, // <Interface Empty Body> ::= ';'
        RULE_INTERFACEEMPTYBODY_LBRACE_RBRACE                                        = 385, // <Interface Empty Body> ::= '{' '}'
        RULE_ENUMDECL_ENUM_IDENTIFIER                                                = 386, // <Enum Decl> ::= <Header> enum Identifier <Enum Base Opt> <Enum Body> <Semicolon Opt>
        RULE_ENUMBASEOPT_COLON                                                       = 387, // <Enum Base Opt> ::= ':' <Integral Type>
        RULE_ENUMBASEOPT                                                             = 388, // <Enum Base Opt> ::= 
        RULE_ENUMBODY_LBRACE_RBRACE                                                  = 389, // <Enum Body> ::= '{' <Enum Item Decs Opt> '}'
        RULE_ENUMBODY_LBRACE_COMMA_RBRACE                                            = 390, // <Enum Body> ::= '{' <Enum Item Decs> ',' '}'
        RULE_ENUMITEMDECSOPT                                                         = 391, // <Enum Item Decs Opt> ::= <Enum Item Decs>
        RULE_ENUMITEMDECSOPT2                                                        = 392, // <Enum Item Decs Opt> ::= 
        RULE_ENUMITEMDECS                                                            = 393, // <Enum Item Decs> ::= <Enum Item Dec>
        RULE_ENUMITEMDECS_COMMA                                                      = 394, // <Enum Item Decs> ::= <Enum Item Decs> ',' <Enum Item Dec>
        RULE_ENUMITEMDEC_IDENTIFIER                                                  = 395, // <Enum Item Dec> ::= <Attrib Opt> Identifier
        RULE_ENUMITEMDEC_IDENTIFIER_EQ                                               = 396, // <Enum Item Dec> ::= <Attrib Opt> Identifier '=' <Expression>
        RULE_DELEGATEDECL_DELEGATE_IDENTIFIER_LPAREN_RPAREN_SEMI                     = 397, // <Delegate Decl> ::= <Header> delegate <Type> Identifier '(' <Formal Param List Opt> ')' ';'
        RULE_ATTRIBOPT                                                               = 398, // <Attrib Opt> ::= <Attrib Opt> <Attrib Section>
        RULE_ATTRIBOPT2                                                              = 399, // <Attrib Opt> ::= 
        RULE_ATTRIBSECTION_LBRACKET_RBRACKET                                         = 400, // <Attrib Section> ::= '[' <Attrib Target Spec Opt> <Attrib List> ']'
        RULE_ATTRIBSECTION_LBRACKET_COMMA_RBRACKET                                   = 401, // <Attrib Section> ::= '[' <Attrib Target Spec Opt> <Attrib List> ',' ']'
        RULE_ATTRIBTARGETSPECOPT_ASSEMBLY_COLON                                      = 402, // <Attrib Target Spec Opt> ::= assembly ':'
        RULE_ATTRIBTARGETSPECOPT_FIELD_COLON                                         = 403, // <Attrib Target Spec Opt> ::= field ':'
        RULE_ATTRIBTARGETSPECOPT_EVENT_COLON                                         = 404, // <Attrib Target Spec Opt> ::= event ':'
        RULE_ATTRIBTARGETSPECOPT_METHOD_COLON                                        = 405, // <Attrib Target Spec Opt> ::= method ':'
        RULE_ATTRIBTARGETSPECOPT_MODULE_COLON                                        = 406, // <Attrib Target Spec Opt> ::= module ':'
        RULE_ATTRIBTARGETSPECOPT_PARAM_COLON                                         = 407, // <Attrib Target Spec Opt> ::= param ':'
        RULE_ATTRIBTARGETSPECOPT_PROPERTY_COLON                                      = 408, // <Attrib Target Spec Opt> ::= property ':'
        RULE_ATTRIBTARGETSPECOPT_RETURN_COLON                                        = 409, // <Attrib Target Spec Opt> ::= return ':'
        RULE_ATTRIBTARGETSPECOPT_TYPE_COLON                                          = 410, // <Attrib Target Spec Opt> ::= type ':'
        RULE_ATTRIBTARGETSPECOPT                                                     = 411, // <Attrib Target Spec Opt> ::= 
        RULE_ATTRIBLIST                                                              = 412, // <Attrib List> ::= <Attribute>
        RULE_ATTRIBLIST_COMMA                                                        = 413, // <Attrib List> ::= <Attrib List> ',' <Attribute>
        RULE_ATTRIBUTE_LPAREN_RPAREN                                                 = 414, // <Attribute> ::= <Qualified ID> '(' <Expression List> ')'
        RULE_ATTRIBUTE_LPAREN_RPAREN2                                                = 415, // <Attribute> ::= <Qualified ID> '(' ')'
        RULE_ATTRIBUTE                                                               = 416  // <Attribute> ::= <Qualified ID>
    };

    public class MyParser
    {
        private LALRParser parser;
       
        public MyParser(string filename, ListBox lstErrors)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
            LstErrors = lstErrors;
            this.lstErrors = lstErrors;
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

                case (int)SymbolConstants.SYMBOL_COMMENT :
                //Comment
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEWLINE :
                //NewLine
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEPIPE :
                //'||'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPELT :
                //'|<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTPIPE :
                //'>|'
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

                case (int)SymbolConstants.SYMBOL_EXCLAM :
                //'!'
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

                case (int)SymbolConstants.SYMBOL_PERCENTEQ :
                //'%='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMP :
                //'&'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMPEQ :
                //'&='
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

                case (int)SymbolConstants.SYMBOL_TIMESEQ :
                //'*='
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

                case (int)SymbolConstants.SYMBOL_DIVEQ :
                //'/='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUESTION :
                //'?'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARET :
                //'^'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARETEQ :
                //'^='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPE :
                //'|'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEEQ :
                //'|='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TILDE :
                //'~'
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

                case (int)SymbolConstants.SYMBOL_PLUSEQ :
                //'+='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTLT :
                //'<<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTLTEQ :
                //'<<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSEQ :
                //'-='
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

                case (int)SymbolConstants.SYMBOL_MINUSGT :
                //'->'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTGT :
                //'>>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTGTEQ :
                //'>>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ABSTRACT :
                //abstract
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADD :
                //add
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AND :
                //and
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AS :
                //as
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSEMBLY :
                //assembly
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BASE :
                //base
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOL :
                //bool
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BYTE :
                //byte
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CATCH :
                //catch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //char
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHARLITERAL :
                //CharLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHECKED :
                //checked
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASS :
                //class
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONST :
                //const
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONTINUE :
                //continue
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECIMAL :
                //decimal
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLITERAL :
                //DecLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DELEGATE :
                //delegate
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSEIF :
                //elseif
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENUM :
                //enum
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EVENT :
                //event
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPLICIT :
                //explicit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXTERN :
                //extern
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FALSE :
                //false
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FIELD :
                //field
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FINALLY :
                //finally
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FIXED :
                //fixed
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOREACH :
                //foreach
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GET :
                //get
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GOTO :
                //goto
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_HEXLITERAL :
                //HexLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IMPLICIT :
                //implicit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACE :
                //interface
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERNAL :
                //internal
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IS :
                //is
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOCK :
                //lock
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LONG :
                //long
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MEMBERNAME :
                //MemberName
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD :
                //method
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MODULE :
                //module
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NAMESPACE :
                //namespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEW :
                //new
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NOT :
                //not
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NULL :
                //null
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OBJECT :
                //object
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OPERATOR :
                //operator
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OR :
                //or
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OUT :
                //out
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OVERRIDE :
                //override
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAM :
                //param
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMS :
                //params
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARTIAL :
                //partial
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIVATE :
                //private
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROPERTY :
                //property
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROTECTED :
                //protected
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PUBLIC :
                //public
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_READONLY :
                //readonly
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REALLITERAL :
                //RealLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REF :
                //ref
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REMOVE :
                //remove
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SBYTE :
                //sbyte
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEALED :
                //sealed
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SET :
                //set
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SHORT :
                //short
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SIZEOF :
                //sizeof
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STACKALLOC :
                //stackalloc
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATIC :
                //static
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRUCT :
                //struct
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THIS :
                //this
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THROW :
                //throw
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //true
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRY :
                //try
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //type
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPEOF :
                //typeof
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UINT :
                //uint
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ULONG :
                //ulong
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNCHECKED :
                //unchecked
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNSAFE :
                //unsafe
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_USHORT :
                //ushort
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_USING :
                //using
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VIRTUAL :
                //virtual
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOLATILE :
                //volatile
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ACCESSOPT :
                //<Access Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ACCESSORDEC :
                //<Accessor Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP :
                //<Add Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ANDEXP :
                //<And Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGLIST :
                //<Arg List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGLISTOPT :
                //<Arg List Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENT :
                //<Argument>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARRAYINITIALIZER :
                //<Array Initializer>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARRAYINITIALIZEROPT :
                //<Array Initializer Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNTAIL :
                //<Assign Tail>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBLIST :
                //<Attrib List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBOPT :
                //<Attrib Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBSECTION :
                //<Attrib Section>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBTARGETSPECOPT :
                //<Attrib Target Spec Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ATTRIBUTE :
                //<Attribute>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BASETYPE :
                //<Base Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BLOCK :
                //<Block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BLOCKORSEMI :
                //<Block or Semi>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CATCHCLAUSE :
                //<Catch Clause>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CATCHCLAUSES :
                //<Catch Clauses>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSBASELIST :
                //<Class Base List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSBASEOPT :
                //<Class Base Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSDECL :
                //<Class Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSITEM :
                //<Class Item>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLASSITEMDECSOPT :
                //<Class Item Decs Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPAREEXP :
                //<Compare Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPILATIONITEM :
                //<Compilation Item>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPILATIONITEMS :
                //<Compilation Items>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMPILATIONUNIT :
                //<Compilation Unit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITIONALEXP :
                //<Conditional Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANTDEC :
                //<Constant Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANTDECLARATOR :
                //<Constant Declarator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTANTDECLARATORS :
                //<Constant Declarators>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTRUCTORDEC :
                //<Constructor Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTRUCTORDECLARATOR :
                //<Constructor Declarator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTRUCTORINIT :
                //<Constructor Init>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONSTRUCTORINITOPT :
                //<Constructor Init Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONVERSIONOPERATORDECL :
                //<Conversion Operator Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DELEGATEDECL :
                //<Delegate Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DESTRUCTORDEC :
                //<Destructor Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIMSEPARATORS :
                //<Dim Separators>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMBASEOPT :
                //<Enum Base Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMBODY :
                //<Enum Body>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMDECL :
                //<Enum Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMITEMDEC :
                //<Enum Item Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMITEMDECS :
                //<Enum Item Decs>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ENUMITEMDECSOPT :
                //<Enum Item Decs Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQUALITYEXP :
                //<Equality Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EVENTACCESSORDECS :
                //<Event Accessor Decs>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EVENTDEC :
                //<Event Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSIONLIST :
                //<Expression List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSIONOPT :
                //<Expression Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FIELDDEC :
                //<Field Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FINALLYCLAUSEOPT :
                //<Finally Clause Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FIXEDPTRDEC :
                //<Fixed Ptr Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FIXEDPTRDECS :
                //<Fixed Ptr Decs>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORCONDITIONOPT :
                //<For Condition Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORINITOPT :
                //<For Init Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORITERATOROPT :
                //<For Iterator Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORMALPARAM :
                //<Formal Param>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORMALPARAMLIST :
                //<Formal Param List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORMALPARAMLISTOPT :
                //<Formal Param List Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_HEADER :
                //<Header>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INDEXERDEC :
                //<Indexer Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGRALTYPE :
                //<Integral Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEACCESSORS :
                //<Interface Accessors>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEBASEOPT :
                //<Interface Base Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEDECL :
                //<Interface Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEEMPTYBODY :
                //<Interface Empty Body>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEEVENTDEC :
                //<Interface Event Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEINDEXERDEC :
                //<Interface Indexer Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEITEMDEC :
                //<Interface Item Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEITEMDECSOPT :
                //<Interface Item Decs Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEMETHODDEC :
                //<Interface Method Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTERFACEPROPERTYDEC :
                //<Interface Property Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LITERAL :
                //<Literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOCALVARDECL :
                //<Local Var Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALANDEXP :
                //<Logical And Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALOREXP :
                //<Logical Or Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALXOREXP :
                //<Logical Xor Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MEMBERLIST :
                //<Member List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD2 :
                //<Method>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHODDEC :
                //<Method Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHODEXP :
                //<Method Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHODSOPT :
                //<Methods Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MODIFIER :
                //<Modifier>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MODIFIERLISTOPT :
                //<Modifier List Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<Mult Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NAMESPACEDEC :
                //<Namespace Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NAMESPACEITEM :
                //<Namespace Item>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NAMESPACEITEMS :
                //<Namespace Items>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEWOPT :
                //<New Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NONARRAYTYPE :
                //<Non Array Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NORMALSTM :
                //<Normal Stm>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OBJECTEXP :
                //<Object Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OPERATORDEC :
                //<Operator Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OREXP :
                //<Or Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OTHERTYPE :
                //<Other Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OVERLOADOP :
                //<Overload Op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OVERLOADOPERATORDECL :
                //<Overload Operator Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_POINTEROPT :
                //<Pointer Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIMARY :
                //<Primary>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIMARYARRAYCREATIONEXP :
                //<Primary Array Creation Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIMARYEXP :
                //<Primary Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROPERTYDEC :
                //<Property Dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUALIFIEDID :
                //<Qualified ID>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RANKSPECIFIER :
                //<Rank Specifier>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RANKSPECIFIERS :
                //<Rank Specifiers>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RANKSPECIFIERSOPT :
                //<Rank Specifiers Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RESOURCE :
                //<Resource>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMICOLONOPT :
                //<Semicolon Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SHIFTEXP :
                //<Shift Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTEXP :
                //<Statement Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTEXPLIST :
                //<Statement Exp List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMLIST :
                //<Stm List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRUCTDECL :
                //<Struct Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHLABEL :
                //<Switch Label>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHLABELS :
                //<Switch Labels>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHSECTION :
                //<Switch Section>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHSECTIONSOPT :
                //<Switch Sections Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THENSTM :
                //<Then Stm>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE2 :
                //<Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPEDECL :
                //<Type Decl>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNARYEXP :
                //<Unary Exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_USINGDIRECTIVE :
                //<Using Directive>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_USINGLIST :
                //<Using List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALIDID :
                //<Valid ID>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATOR :
                //<Variable Declarator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECS :
                //<Variable Decs>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEINITIALIZER :
                //<Variable Initializer>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEINITIALIZERLIST :
                //<Variable Initializer List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEINITIALIZERLISTOPT :
                //<Variable Initializer List Opt>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_BLOCKORSEMI :
                //<Block or Semi> ::= <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCKORSEMI_SEMI :
                //<Block or Semi> ::= ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALIDID_IDENTIFIER :
                //<Valid ID> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALIDID_THIS :
                //<Valid ID> ::= this
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALIDID_BASE :
                //<Valid ID> ::= base
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALIDID :
                //<Valid ID> ::= <Base Type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_QUALIFIEDID :
                //<Qualified ID> ::= <Valid ID> <Member List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MEMBERLIST_MEMBERNAME :
                //<Member List> ::= <Member List> MemberName
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MEMBERLIST :
                //<Member List> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SEMICOLONOPT_SEMI :
                //<Semicolon Opt> ::= ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SEMICOLONOPT :
                //<Semicolon Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_TRUE :
                //<Literal> ::= true
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_FALSE :
                //<Literal> ::= false
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_DECLITERAL :
                //<Literal> ::= DecLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_HEXLITERAL :
                //<Literal> ::= HexLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_REALLITERAL :
                //<Literal> ::= RealLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_CHARLITERAL :
                //<Literal> ::= CharLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_STRINGLITERAL :
                //<Literal> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_NULL :
                //<Literal> ::= null
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE :
                //<Type> ::= <Non Array Type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_TIMES :
                //<Type> ::= <Non Array Type> '*'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE2 :
                //<Type> ::= <Non Array Type> <Rank Specifiers>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_TIMES2 :
                //<Type> ::= <Non Array Type> <Rank Specifiers> '*'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POINTEROPT_TIMES :
                //<Pointer Opt> ::= '*'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POINTEROPT :
                //<Pointer Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NONARRAYTYPE :
                //<Non Array Type> ::= <Qualified ID>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BASETYPE :
                //<Base Type> ::= <Other Type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BASETYPE2 :
                //<Base Type> ::= <Integral Type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_FLOAT :
                //<Other Type> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_DOUBLE :
                //<Other Type> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_DECIMAL :
                //<Other Type> ::= decimal
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_BOOL :
                //<Other Type> ::= bool
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_VOID :
                //<Other Type> ::= void
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_OBJECT :
                //<Other Type> ::= object
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OTHERTYPE_STRING :
                //<Other Type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_SBYTE :
                //<Integral Type> ::= sbyte
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_BYTE :
                //<Integral Type> ::= byte
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_SHORT :
                //<Integral Type> ::= short
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_USHORT :
                //<Integral Type> ::= ushort
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_INT :
                //<Integral Type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_UINT :
                //<Integral Type> ::= uint
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_LONG :
                //<Integral Type> ::= long
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_ULONG :
                //<Integral Type> ::= ulong
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTEGRALTYPE_CHAR :
                //<Integral Type> ::= char
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIERSOPT :
                //<Rank Specifiers Opt> ::= <Rank Specifiers Opt> <Rank Specifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIERSOPT2 :
                //<Rank Specifiers Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIERS :
                //<Rank Specifiers> ::= <Rank Specifiers> <Rank Specifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIERS2 :
                //<Rank Specifiers> ::= <Rank Specifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RANKSPECIFIER_LBRACKET_RBRACKET :
                //<Rank Specifier> ::= '[' <Dim Separators> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIMSEPARATORS_COMMA :
                //<Dim Separators> ::= <Dim Separators> ','
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIMSEPARATORS :
                //<Dim Separators> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONOPT :
                //<Expression Opt> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONOPT2 :
                //<Expression Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONLIST :
                //<Expression List> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSIONLIST_COMMA :
                //<Expression List> ::= <Expression> ',' <Expression List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQ :
                //<Expression> ::= <Conditional Exp> '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PLUSEQ :
                //<Expression> ::= <Conditional Exp> '+=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_MINUSEQ :
                //<Expression> ::= <Conditional Exp> '-=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_TIMESEQ :
                //<Expression> ::= <Conditional Exp> '*=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_DIVEQ :
                //<Expression> ::= <Conditional Exp> '/=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_CARETEQ :
                //<Expression> ::= <Conditional Exp> '^=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_AMPEQ :
                //<Expression> ::= <Conditional Exp> '&=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PIPEEQ :
                //<Expression> ::= <Conditional Exp> '|=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_PERCENTEQ :
                //<Expression> ::= <Conditional Exp> '%=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTLTEQ :
                //<Expression> ::= <Conditional Exp> '<<=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GTGTEQ :
                //<Expression> ::= <Conditional Exp> '>>=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Conditional Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITIONALEXP_QUESTION_COLON :
                //<Conditional Exp> ::= <Or Exp> '?' <Or Exp> ':' <Conditional Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITIONALEXP :
                //<Conditional Exp> ::= <Or Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OREXP_OR :
                //<Or Exp> ::= <Or Exp> or <And Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OREXP :
                //<Or Exp> ::= <And Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ANDEXP_AND :
                //<And Exp> ::= <And Exp> and <Logical Or Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ANDEXP :
                //<And Exp> ::= <Logical Or Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALOREXP_PIPE :
                //<Logical Or Exp> ::= <Logical Or Exp> '|' <Logical Xor Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALOREXP :
                //<Logical Or Exp> ::= <Logical Xor Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALXOREXP_CARET :
                //<Logical Xor Exp> ::= <Logical Xor Exp> '^' <Logical And Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALXOREXP :
                //<Logical Xor Exp> ::= <Logical And Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALANDEXP_AMP :
                //<Logical And Exp> ::= <Logical And Exp> '&' <Equality Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALANDEXP :
                //<Logical And Exp> ::= <Equality Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXP_EQEQ :
                //<Equality Exp> ::= <Equality Exp> '==' <Compare Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXP_NOT :
                //<Equality Exp> ::= <Equality Exp> not <Compare Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXP :
                //<Equality Exp> ::= <Compare Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_LT :
                //<Compare Exp> ::= <Compare Exp> '<' <Shift Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_GT :
                //<Compare Exp> ::= <Compare Exp> '>' <Shift Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_LTEQ :
                //<Compare Exp> ::= <Compare Exp> '<=' <Shift Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_GTEQ :
                //<Compare Exp> ::= <Compare Exp> '>=' <Shift Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_IS :
                //<Compare Exp> ::= <Compare Exp> is <Type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP_AS :
                //<Compare Exp> ::= <Compare Exp> as <Type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPAREEXP :
                //<Compare Exp> ::= <Shift Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXP_LTLT :
                //<Shift Exp> ::= <Shift Exp> '<<' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXP_GTGT :
                //<Shift Exp> ::= <Shift Exp> '>>' <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXP :
                //<Shift Exp> ::= <Add Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_PLUS :
                //<Add Exp> ::= <Add Exp> '+' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_MINUS :
                //<Add Exp> ::= <Add Exp> '-' <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP :
                //<Add Exp> ::= <Mult Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<Mult Exp> ::= <Mult Exp> '*' <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<Mult Exp> ::= <Mult Exp> '/' <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_PERCENT :
                //<Mult Exp> ::= <Mult Exp> '%' <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<Mult Exp> ::= <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_EXCLAM :
                //<Unary Exp> ::= '!' <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_TILDE :
                //<Unary Exp> ::= '~' <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_MINUS :
                //<Unary Exp> ::= '-' <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_PLUSPLUS :
                //<Unary Exp> ::= '++' <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_MINUSMINUS :
                //<Unary Exp> ::= '--' <Unary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP_LPAREN_RPAREN :
                //<Unary Exp> ::= '(' <Expression> ')' <Object Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXP :
                //<Unary Exp> ::= <Object Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OBJECTEXP_DELEGATE_LPAREN_RPAREN :
                //<Object Exp> ::= delegate '(' <Formal Param List Opt> ')' <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OBJECTEXP :
                //<Object Exp> ::= <Primary Array Creation Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OBJECTEXP2 :
                //<Object Exp> ::= <Method Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYARRAYCREATIONEXP_NEW_LBRACKET_RBRACKET :
                //<Primary Array Creation Exp> ::= new <Non Array Type> '[' <Expression List> ']' <Rank Specifiers Opt> <Array Initializer Opt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYARRAYCREATIONEXP_NEW :
                //<Primary Array Creation Exp> ::= new <Non Array Type> <Rank Specifiers> <Array Initializer>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODEXP :
                //<Method Exp> ::= <Method Exp> <Method>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODEXP2 :
                //<Method Exp> ::= <Primary Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_TYPEOF_LPAREN_RPAREN :
                //<Primary Exp> ::= typeof '(' <Type> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_SIZEOF_LPAREN_RPAREN :
                //<Primary Exp> ::= sizeof '(' <Type> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_CHECKED_LPAREN_RPAREN :
                //<Primary Exp> ::= checked '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_UNCHECKED_LPAREN_RPAREN :
                //<Primary Exp> ::= unchecked '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_NEW_LPAREN_RPAREN :
                //<Primary Exp> ::= new <Non Array Type> '(' <Arg List Opt> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP :
                //<Primary Exp> ::= <Primary>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXP_LPAREN_RPAREN :
                //<Primary Exp> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY :
                //<Primary> ::= <Valid ID>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY_LPAREN_RPAREN :
                //<Primary> ::= <Valid ID> '(' <Arg List Opt> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARY2 :
                //<Primary> ::= <Literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGLISTOPT :
                //<Arg List Opt> ::= <Arg List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGLISTOPT2 :
                //<Arg List Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGLIST_COMMA :
                //<Arg List> ::= <Arg List> ',' <Argument>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGLIST :
                //<Arg List> ::= <Argument>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENT :
                //<Argument> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENT_REF :
                //<Argument> ::= ref <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENT_OUT :
                //<Argument> ::= out <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMLIST :
                //<Stm List> ::= <Stm List> <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMLIST2 :
                //<Stm List> ::= <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_IDENTIFIER_COLON :
                //<Statement> ::= Identifier ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_SEMI :
                //<Statement> ::= <Local Var Decl> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_IF_LPAREN_RPAREN :
                //<Statement> ::= if '(' <Expression> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_IF_LPAREN_RPAREN_ELSE :
                //<Statement> ::= if '(' <Expression> ')' <Then Stm> else <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_ELSEIF_LPAREN_RPAREN :
                //<Statement> ::= elseif '(' <Expression> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_FOR_LPAREN_SEMI_SEMI_RPAREN :
                //<Statement> ::= for '(' <For Init Opt> ';' <For Condition Opt> ';' <For Iterator Opt> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_FOREACH_LPAREN_IDENTIFIER_IN_RPAREN :
                //<Statement> ::= foreach '(' <Type> Identifier in <Expression> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_WHILE_LPAREN_RPAREN :
                //<Statement> ::= while '(' <Expression> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_LOCK_LPAREN_RPAREN :
                //<Statement> ::= lock '(' <Expression> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_USING_LPAREN_RPAREN :
                //<Statement> ::= using '(' <Resource> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_FIXED_LPAREN_RPAREN :
                //<Statement> ::= fixed '(' <Type> <Fixed Ptr Decs> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT_DELEGATE_LPAREN_RPAREN :
                //<Statement> ::= delegate '(' <Formal Param List Opt> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <Normal Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_THENSTM_IF_LPAREN_RPAREN_ELSE :
                //<Then Stm> ::= if '(' <Expression> ')' <Then Stm> else <Then Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_THENSTM_FOR_LPAREN_SEMI_SEMI_RPAREN :
                //<Then Stm> ::= for '(' <For Init Opt> ';' <For Condition Opt> ';' <For Iterator Opt> ')' <Then Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_THENSTM_FOREACH_LPAREN_IDENTIFIER_IN_RPAREN :
                //<Then Stm> ::= foreach '(' <Type> Identifier in <Expression> ')' <Then Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_THENSTM_WHILE_LPAREN_RPAREN :
                //<Then Stm> ::= while '(' <Expression> ')' <Then Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_THENSTM_LOCK_LPAREN_RPAREN :
                //<Then Stm> ::= lock '(' <Expression> ')' <Then Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_THENSTM_USING_LPAREN_RPAREN :
                //<Then Stm> ::= using '(' <Resource> ')' <Then Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_THENSTM_FIXED_LPAREN_RPAREN :
                //<Then Stm> ::= fixed '(' <Type> <Fixed Ptr Decs> ')' <Then Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_THENSTM_DELEGATE_LPAREN_RPAREN :
                //<Then Stm> ::= delegate '(' <Formal Param List Opt> ')' <Then Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_THENSTM :
                //<Then Stm> ::= <Normal Stm>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE :
                //<Normal Stm> ::= switch '(' <Expression> ')' '{' <Switch Sections Opt> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_DO_WHILE_LPAREN_RPAREN_SEMI :
                //<Normal Stm> ::= do <Normal Stm> while '(' <Expression> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_TRY :
                //<Normal Stm> ::= try <Block> <Catch Clauses> <Finally Clause Opt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_CHECKED :
                //<Normal Stm> ::= checked <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_UNCHECKED :
                //<Normal Stm> ::= unchecked <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_UNSAFE :
                //<Normal Stm> ::= unsafe <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_BREAK_SEMI :
                //<Normal Stm> ::= break ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_CONTINUE_SEMI :
                //<Normal Stm> ::= continue ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_GOTO_IDENTIFIER_SEMI :
                //<Normal Stm> ::= goto Identifier ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_GOTO_CASE_SEMI :
                //<Normal Stm> ::= goto case <Expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_GOTO_DEFAULT_SEMI :
                //<Normal Stm> ::= goto default ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_RETURN_SEMI :
                //<Normal Stm> ::= return <Expression Opt> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_THROW_SEMI :
                //<Normal Stm> ::= throw <Expression Opt> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_SEMI :
                //<Normal Stm> ::= <Statement Exp> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM_SEMI2 :
                //<Normal Stm> ::= ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NORMALSTM :
                //<Normal Stm> ::= <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK_LBRACE_RBRACE :
                //<Block> ::= '{' <Stm List> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK_LBRACE_RBRACE2 :
                //<Block> ::= '{' '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECS :
                //<Variable Decs> ::= <Variable Declarator>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECS_COMMA :
                //<Variable Decs> ::= <Variable Decs> ',' <Variable Declarator>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATOR_IDENTIFIER :
                //<Variable Declarator> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATOR_IDENTIFIER_EQ :
                //<Variable Declarator> ::= Identifier '=' <Variable Initializer>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZER :
                //<Variable Initializer> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZER2 :
                //<Variable Initializer> ::= <Array Initializer>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZER_STACKALLOC_LBRACKET_RBRACKET :
                //<Variable Initializer> ::= stackalloc <Non Array Type> '[' <Non Array Type> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDECLARATORS :
                //<Constant Declarators> ::= <Constant Declarator>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDECLARATORS_COMMA :
                //<Constant Declarators> ::= <Constant Declarators> ',' <Constant Declarator>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDECLARATOR_IDENTIFIER_EQ :
                //<Constant Declarator> ::= Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHSECTIONSOPT :
                //<Switch Sections Opt> ::= <Switch Sections Opt> <Switch Section>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHSECTIONSOPT2 :
                //<Switch Sections Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHSECTION :
                //<Switch Section> ::= <Switch Labels> <Stm List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABELS :
                //<Switch Labels> ::= <Switch Label>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABELS2 :
                //<Switch Labels> ::= <Switch Labels> <Switch Label>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABEL_CASE_COLON :
                //<Switch Label> ::= case <Expression> ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABEL_DEFAULT_COLON :
                //<Switch Label> ::= default ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORINITOPT :
                //<For Init Opt> ::= <Local Var Decl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORINITOPT2 :
                //<For Init Opt> ::= <Statement Exp List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORINITOPT3 :
                //<For Init Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORITERATOROPT :
                //<For Iterator Opt> ::= <Statement Exp List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORITERATOROPT2 :
                //<For Iterator Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORCONDITIONOPT :
                //<For Condition Opt> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORCONDITIONOPT2 :
                //<For Condition Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXPLIST_COMMA :
                //<Statement Exp List> ::= <Statement Exp List> ',' <Statement Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXPLIST :
                //<Statement Exp List> ::= <Statement Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSES :
                //<Catch Clauses> ::= <Catch Clause> <Catch Clauses>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSES2 :
                //<Catch Clauses> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSE_CATCH_LPAREN_IDENTIFIER_RPAREN :
                //<Catch Clause> ::= catch '(' <Qualified ID> Identifier ')' <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSE_CATCH_LPAREN_RPAREN :
                //<Catch Clause> ::= catch '(' <Qualified ID> ')' <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CATCHCLAUSE_CATCH :
                //<Catch Clause> ::= catch <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FINALLYCLAUSEOPT_FINALLY :
                //<Finally Clause Opt> ::= finally <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FINALLYCLAUSEOPT :
                //<Finally Clause Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RESOURCE :
                //<Resource> ::= <Local Var Decl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RESOURCE2 :
                //<Resource> ::= <Statement Exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FIXEDPTRDECS :
                //<Fixed Ptr Decs> ::= <Fixed Ptr Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FIXEDPTRDECS_COMMA :
                //<Fixed Ptr Decs> ::= <Fixed Ptr Decs> ',' <Fixed Ptr Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FIXEDPTRDEC_IDENTIFIER_EQ :
                //<Fixed Ptr Dec> ::= Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOCALVARDECL :
                //<Local Var Decl> ::= <Qualified ID> <Rank Specifiers> <Pointer Opt> <Variable Decs>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOCALVARDECL2 :
                //<Local Var Decl> ::= <Qualified ID> <Pointer Opt> <Variable Decs>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_LPAREN_RPAREN :
                //<Statement Exp> ::= <Qualified ID> '(' <Arg List Opt> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_LPAREN_RPAREN2 :
                //<Statement Exp> ::= <Qualified ID> '(' <Arg List Opt> ')' <Methods Opt> <Assign Tail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_LBRACKET_RBRACKET :
                //<Statement Exp> ::= <Qualified ID> '[' <Expression List> ']' <Methods Opt> <Assign Tail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_MINUSGT_IDENTIFIER :
                //<Statement Exp> ::= <Qualified ID> '->' Identifier <Methods Opt> <Assign Tail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_PLUSPLUS :
                //<Statement Exp> ::= <Qualified ID> '++' <Methods Opt> <Assign Tail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP_MINUSMINUS :
                //<Statement Exp> ::= <Qualified ID> '--' <Methods Opt> <Assign Tail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTEXP :
                //<Statement Exp> ::= <Qualified ID> <Assign Tail>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_PLUSPLUS :
                //<Assign Tail> ::= '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_MINUSMINUS :
                //<Assign Tail> ::= '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_EQ :
                //<Assign Tail> ::= '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_PLUSEQ :
                //<Assign Tail> ::= '+=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_MINUSEQ :
                //<Assign Tail> ::= '-=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_TIMESEQ :
                //<Assign Tail> ::= '*=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_DIVEQ :
                //<Assign Tail> ::= '/=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_CARETEQ :
                //<Assign Tail> ::= '^=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_AMPEQ :
                //<Assign Tail> ::= '&=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_PIPEEQ :
                //<Assign Tail> ::= '|=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_PERCENTEQ :
                //<Assign Tail> ::= '%=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_LTLTEQ :
                //<Assign Tail> ::= '<<=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNTAIL_GTGTEQ :
                //<Assign Tail> ::= '>>=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODSOPT :
                //<Methods Opt> ::= <Methods Opt> <Method>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODSOPT2 :
                //<Methods Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_MEMBERNAME :
                //<Method> ::= MemberName
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_MEMBERNAME_LPAREN_RPAREN :
                //<Method> ::= MemberName '(' <Arg List Opt> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_LBRACKET_RBRACKET :
                //<Method> ::= '[' <Expression List> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_MINUSGT_IDENTIFIER :
                //<Method> ::= '->' Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_PLUSPLUS :
                //<Method> ::= '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_MINUSMINUS :
                //<Method> ::= '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONUNIT :
                //<Compilation Unit> ::= <Using List> <Compilation Items>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_USINGLIST :
                //<Using List> ::= <Using List> <Using Directive>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_USINGLIST2 :
                //<Using List> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_USINGDIRECTIVE_USING_IDENTIFIER_EQ_SEMI :
                //<Using Directive> ::= using Identifier '=' <Qualified ID> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_USINGDIRECTIVE_USING_SEMI :
                //<Using Directive> ::= using <Qualified ID> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONITEMS :
                //<Compilation Items> ::= <Compilation Items> <Compilation Item>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONITEMS2 :
                //<Compilation Items> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONITEM :
                //<Compilation Item> ::= <Namespace Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMPILATIONITEM2 :
                //<Compilation Item> ::= <Namespace Item>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEDEC_NAMESPACE_LBRACE_RBRACE :
                //<Namespace Dec> ::= <Attrib Opt> namespace <Qualified ID> '{' <Using List> <Namespace Items> '}' <Semicolon Opt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEMS :
                //<Namespace Items> ::= <Namespace Items> <Namespace Item>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEMS2 :
                //<Namespace Items> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM :
                //<Namespace Item> ::= <Constant Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM2 :
                //<Namespace Item> ::= <Field Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM3 :
                //<Namespace Item> ::= <Method Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM4 :
                //<Namespace Item> ::= <Property Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NAMESPACEITEM5 :
                //<Namespace Item> ::= <Type Decl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL :
                //<Type Decl> ::= <Class Decl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL2 :
                //<Type Decl> ::= <Struct Decl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL3 :
                //<Type Decl> ::= <Interface Decl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL4 :
                //<Type Decl> ::= <Enum Decl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPEDECL5 :
                //<Type Decl> ::= <Delegate Decl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_HEADER :
                //<Header> ::= <Attrib Opt> <Access Opt> <Modifier List Opt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT_PRIVATE :
                //<Access Opt> ::= private
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT_PROTECTED :
                //<Access Opt> ::= protected
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT_PUBLIC :
                //<Access Opt> ::= public
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT_INTERNAL :
                //<Access Opt> ::= internal
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESSOPT :
                //<Access Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODIFIERLISTOPT :
                //<Modifier List Opt> ::= <Modifier List Opt> <Modifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODIFIERLISTOPT2 :
                //<Modifier List Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_ABSTRACT :
                //<Modifier> ::= abstract
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_EXTERN :
                //<Modifier> ::= extern
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_NEW :
                //<Modifier> ::= new
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_OVERRIDE :
                //<Modifier> ::= override
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_PARTIAL :
                //<Modifier> ::= partial
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_READONLY :
                //<Modifier> ::= readonly
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_SEALED :
                //<Modifier> ::= sealed
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_STATIC :
                //<Modifier> ::= static
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_UNSAFE :
                //<Modifier> ::= unsafe
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_VIRTUAL :
                //<Modifier> ::= virtual
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MODIFIER_VOLATILE :
                //<Modifier> ::= volatile
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSDECL_CLASS_IDENTIFIER_LBRACE_RBRACE :
                //<Class Decl> ::= <Header> class Identifier <Class Base Opt> '{' <Class Item Decs Opt> '}' <Semicolon Opt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSBASEOPT_COLON :
                //<Class Base Opt> ::= ':' <Class Base List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSBASEOPT :
                //<Class Base Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSBASELIST_COMMA :
                //<Class Base List> ::= <Class Base List> ',' <Non Array Type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSBASELIST :
                //<Class Base List> ::= <Non Array Type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSITEMDECSOPT :
                //<Class Item Decs Opt> ::= <Class Item Decs Opt> <Class Item>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSITEMDECSOPT2 :
                //<Class Item Decs Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM :
                //<Class Item> ::= <Constant Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM2 :
                //<Class Item> ::= <Field Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM3 :
                //<Class Item> ::= <Method Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM4 :
                //<Class Item> ::= <Property Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM5 :
                //<Class Item> ::= <Event Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM6 :
                //<Class Item> ::= <Indexer Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM7 :
                //<Class Item> ::= <Operator Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM8 :
                //<Class Item> ::= <Constructor Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM9 :
                //<Class Item> ::= <Destructor Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CLASSITEM10 :
                //<Class Item> ::= <Type Decl>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTANTDEC_CONST_SEMI :
                //<Constant Dec> ::= <Header> const <Type> <Constant Declarators> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FIELDDEC_SEMI :
                //<Field Dec> ::= <Header> <Type> <Variable Decs> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODDEC_LPAREN_RPAREN :
                //<Method Dec> ::= <Header> <Type> <Qualified ID> '(' <Formal Param List Opt> ')' <Block or Semi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAMLISTOPT :
                //<Formal Param List Opt> ::= <Formal Param List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAMLISTOPT2 :
                //<Formal Param List Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAMLIST :
                //<Formal Param List> ::= <Formal Param>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAMLIST_COMMA :
                //<Formal Param List> ::= <Formal Param List> ',' <Formal Param>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAM_IDENTIFIER :
                //<Formal Param> ::= <Attrib Opt> <Type> Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAM_REF_IDENTIFIER :
                //<Formal Param> ::= <Attrib Opt> ref <Type> Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAM_OUT_IDENTIFIER :
                //<Formal Param> ::= <Attrib Opt> out <Type> Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAM_PARAMS_IDENTIFIER :
                //<Formal Param> ::= <Attrib Opt> params <Type> Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROPERTYDEC_LBRACE_RBRACE :
                //<Property Dec> ::= <Header> <Type> <Qualified ID> '{' <Accessor Dec> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESSORDEC_GET :
                //<Accessor Dec> ::= <Access Opt> get <Block or Semi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESSORDEC_GET_SET :
                //<Accessor Dec> ::= <Access Opt> get <Block or Semi> <Access Opt> set <Block or Semi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESSORDEC_SET :
                //<Accessor Dec> ::= <Access Opt> set <Block or Semi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ACCESSORDEC_SET_GET :
                //<Accessor Dec> ::= <Access Opt> set <Block or Semi> <Access Opt> get <Block or Semi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EVENTDEC_EVENT_SEMI :
                //<Event Dec> ::= <Header> event <Type> <Variable Decs> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EVENTDEC_EVENT_LBRACE_RBRACE :
                //<Event Dec> ::= <Header> event <Type> <Qualified ID> '{' <Event Accessor Decs> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EVENTACCESSORDECS_ADD :
                //<Event Accessor Decs> ::= add <Block or Semi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EVENTACCESSORDECS_ADD_REMOVE :
                //<Event Accessor Decs> ::= add <Block or Semi> remove <Block or Semi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EVENTACCESSORDECS_REMOVE :
                //<Event Accessor Decs> ::= remove <Block or Semi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EVENTACCESSORDECS_REMOVE_ADD :
                //<Event Accessor Decs> ::= remove <Block or Semi> add <Block or Semi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INDEXERDEC_LBRACKET_RBRACKET_LBRACE_RBRACE :
                //<Indexer Dec> ::= <Header> <Type> <Qualified ID> '[' <Formal Param List> ']' '{' <Accessor Dec> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPERATORDEC :
                //<Operator Dec> ::= <Header> <Overload Operator Decl> <Block or Semi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OPERATORDEC2 :
                //<Operator Dec> ::= <Header> <Conversion Operator Decl> <Block or Semi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOPERATORDECL_OPERATOR_LPAREN_IDENTIFIER_RPAREN :
                //<Overload Operator Decl> ::= <Type> operator <Overload Op> '(' <Type> Identifier ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOPERATORDECL_OPERATOR_LPAREN_IDENTIFIER_COMMA_IDENTIFIER_RPAREN :
                //<Overload Operator Decl> ::= <Type> operator <Overload Op> '(' <Type> Identifier ',' <Type> Identifier ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONVERSIONOPERATORDECL_IMPLICIT_OPERATOR_LPAREN_IDENTIFIER_RPAREN :
                //<Conversion Operator Decl> ::= implicit operator <Type> '(' <Type> Identifier ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONVERSIONOPERATORDECL_EXPLICIT_OPERATOR_LPAREN_IDENTIFIER_RPAREN :
                //<Conversion Operator Decl> ::= explicit operator <Type> '(' <Type> Identifier ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_PLUS :
                //<Overload Op> ::= '+'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_MINUS :
                //<Overload Op> ::= '-'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_EXCLAM :
                //<Overload Op> ::= '!'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_TILDE :
                //<Overload Op> ::= '~'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_PLUSPLUS :
                //<Overload Op> ::= '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_MINUSMINUS :
                //<Overload Op> ::= '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_TRUE :
                //<Overload Op> ::= true
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_FALSE :
                //<Overload Op> ::= false
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_TIMES :
                //<Overload Op> ::= '*'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_DIV :
                //<Overload Op> ::= '/'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_PERCENT :
                //<Overload Op> ::= '%'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_AMP :
                //<Overload Op> ::= '&'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_PIPE :
                //<Overload Op> ::= '|'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_CARET :
                //<Overload Op> ::= '^'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_LTLT :
                //<Overload Op> ::= '<<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_GTGT :
                //<Overload Op> ::= '>>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_EQEQ :
                //<Overload Op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_EXCLAMEQ :
                //<Overload Op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_GT :
                //<Overload Op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_LT :
                //<Overload Op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_GTEQ :
                //<Overload Op> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OVERLOADOP_LTEQ :
                //<Overload Op> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORDEC :
                //<Constructor Dec> ::= <Header> <Constructor Declarator> <Block or Semi>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORDECLARATOR_IDENTIFIER_LPAREN_RPAREN :
                //<Constructor Declarator> ::= Identifier '(' <Formal Param List Opt> ')' <Constructor Init Opt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORINITOPT :
                //<Constructor Init Opt> ::= <Constructor Init>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORINITOPT2 :
                //<Constructor Init Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORINIT_COLON_BASE_LPAREN_RPAREN :
                //<Constructor Init> ::= ':' base '(' <Arg List Opt> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORINIT_COLON_THIS_LPAREN_RPAREN :
                //<Constructor Init> ::= ':' this '(' <Arg List Opt> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DESTRUCTORDEC_TILDE_IDENTIFIER_LPAREN_RPAREN :
                //<Destructor Dec> ::= <Header> '~' Identifier '(' ')' <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STRUCTDECL_STRUCT_IDENTIFIER_LBRACE_RBRACE :
                //<Struct Decl> ::= <Header> struct Identifier <Class Base Opt> '{' <Class Item Decs Opt> '}' <Semicolon Opt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARRAYINITIALIZEROPT :
                //<Array Initializer Opt> ::= <Array Initializer>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARRAYINITIALIZEROPT2 :
                //<Array Initializer Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARRAYINITIALIZER_LBRACE_RBRACE :
                //<Array Initializer> ::= '{' <Variable Initializer List Opt> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARRAYINITIALIZER_LBRACE_COMMA_RBRACE :
                //<Array Initializer> ::= '{' <Variable Initializer List> ',' '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZERLISTOPT :
                //<Variable Initializer List Opt> ::= <Variable Initializer List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZERLISTOPT2 :
                //<Variable Initializer List Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZERLIST :
                //<Variable Initializer List> ::= <Variable Initializer>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINITIALIZERLIST_COMMA :
                //<Variable Initializer List> ::= <Variable Initializer List> ',' <Variable Initializer>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEDECL_INTERFACE_IDENTIFIER_LBRACE_RBRACE :
                //<Interface Decl> ::= <Header> interface Identifier <Interface Base Opt> '{' <Interface Item Decs Opt> '}' <Semicolon Opt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEBASEOPT_COLON :
                //<Interface Base Opt> ::= ':' <Class Base List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEBASEOPT :
                //<Interface Base Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDECSOPT :
                //<Interface Item Decs Opt> ::= <Interface Item Decs Opt> <Interface Item Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDECSOPT2 :
                //<Interface Item Decs Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDEC :
                //<Interface Item Dec> ::= <Interface Method Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDEC2 :
                //<Interface Item Dec> ::= <Interface Property Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDEC3 :
                //<Interface Item Dec> ::= <Interface Event Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEITEMDEC4 :
                //<Interface Item Dec> ::= <Interface Indexer Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEMETHODDEC_IDENTIFIER_LPAREN_RPAREN :
                //<Interface Method Dec> ::= <Attrib Opt> <New Opt> <Type> Identifier '(' <Formal Param List Opt> ')' <Interface Empty Body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEWOPT_NEW :
                //<New Opt> ::= new
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEWOPT :
                //<New Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEPROPERTYDEC_IDENTIFIER_LBRACE_RBRACE :
                //<Interface Property Dec> ::= <Attrib Opt> <New Opt> <Type> Identifier '{' <Interface Accessors> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEINDEXERDEC_THIS_LBRACKET_RBRACKET_LBRACE_RBRACE :
                //<Interface Indexer Dec> ::= <Attrib Opt> <New Opt> <Type> this '[' <Formal Param List> ']' '{' <Interface Accessors> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEACCESSORS_GET :
                //<Interface Accessors> ::= <Attrib Opt> <Access Opt> get <Interface Empty Body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEACCESSORS_SET :
                //<Interface Accessors> ::= <Attrib Opt> <Access Opt> set <Interface Empty Body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEACCESSORS_GET_SET :
                //<Interface Accessors> ::= <Attrib Opt> <Access Opt> get <Interface Empty Body> <Attrib Opt> <Access Opt> set <Interface Empty Body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEACCESSORS_SET_GET :
                //<Interface Accessors> ::= <Attrib Opt> <Access Opt> set <Interface Empty Body> <Attrib Opt> <Access Opt> get <Interface Empty Body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEEVENTDEC_EVENT_IDENTIFIER :
                //<Interface Event Dec> ::= <Attrib Opt> <New Opt> event <Type> Identifier <Interface Empty Body>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEEMPTYBODY_SEMI :
                //<Interface Empty Body> ::= ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INTERFACEEMPTYBODY_LBRACE_RBRACE :
                //<Interface Empty Body> ::= '{' '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ENUMDECL_ENUM_IDENTIFIER :
                //<Enum Decl> ::= <Header> enum Identifier <Enum Base Opt> <Enum Body> <Semicolon Opt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ENUMBASEOPT_COLON :
                //<Enum Base Opt> ::= ':' <Integral Type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ENUMBASEOPT :
                //<Enum Base Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ENUMBODY_LBRACE_RBRACE :
                //<Enum Body> ::= '{' <Enum Item Decs Opt> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ENUMBODY_LBRACE_COMMA_RBRACE :
                //<Enum Body> ::= '{' <Enum Item Decs> ',' '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDECSOPT :
                //<Enum Item Decs Opt> ::= <Enum Item Decs>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDECSOPT2 :
                //<Enum Item Decs Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDECS :
                //<Enum Item Decs> ::= <Enum Item Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDECS_COMMA :
                //<Enum Item Decs> ::= <Enum Item Decs> ',' <Enum Item Dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDEC_IDENTIFIER :
                //<Enum Item Dec> ::= <Attrib Opt> Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ENUMITEMDEC_IDENTIFIER_EQ :
                //<Enum Item Dec> ::= <Attrib Opt> Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DELEGATEDECL_DELEGATE_IDENTIFIER_LPAREN_RPAREN_SEMI :
                //<Delegate Decl> ::= <Header> delegate <Type> Identifier '(' <Formal Param List Opt> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBOPT :
                //<Attrib Opt> ::= <Attrib Opt> <Attrib Section>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBOPT2 :
                //<Attrib Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBSECTION_LBRACKET_RBRACKET :
                //<Attrib Section> ::= '[' <Attrib Target Spec Opt> <Attrib List> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBSECTION_LBRACKET_COMMA_RBRACKET :
                //<Attrib Section> ::= '[' <Attrib Target Spec Opt> <Attrib List> ',' ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_ASSEMBLY_COLON :
                //<Attrib Target Spec Opt> ::= assembly ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_FIELD_COLON :
                //<Attrib Target Spec Opt> ::= field ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_EVENT_COLON :
                //<Attrib Target Spec Opt> ::= event ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_METHOD_COLON :
                //<Attrib Target Spec Opt> ::= method ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_MODULE_COLON :
                //<Attrib Target Spec Opt> ::= module ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_PARAM_COLON :
                //<Attrib Target Spec Opt> ::= param ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_PROPERTY_COLON :
                //<Attrib Target Spec Opt> ::= property ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_RETURN_COLON :
                //<Attrib Target Spec Opt> ::= return ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT_TYPE_COLON :
                //<Attrib Target Spec Opt> ::= type ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBTARGETSPECOPT :
                //<Attrib Target Spec Opt> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBLIST :
                //<Attrib List> ::= <Attribute>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBLIST_COMMA :
                //<Attrib List> ::= <Attrib List> ',' <Attribute>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBUTE_LPAREN_RPAREN :
                //<Attribute> ::= <Qualified ID> '(' <Expression List> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBUTE_LPAREN_RPAREN2 :
                //<Attribute> ::= <Qualified ID> '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ATTRIBUTE :
                //<Attribute> ::= <Qualified ID>
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
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
