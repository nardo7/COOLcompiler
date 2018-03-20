grammar COOL;
options{
language=CSharp3;
output=AST;
ASTLabelType=COOLCommonTree;
}

tokens{
PROGRAM;
PARAM;
PARAMLIST;
METHODEFINITION;
BODY;
ASSIGNMENT_LIST;
VAR_DECLARATION_LIST;
VAR_DECLARATION;
ATTRIBUTE;
METHOD;
BLOCK;
DISPATCH;
CONDITION;
CASEBRANCH;
CASEBRANCHES;
}
@header{
using LexingParsingCOOL;
}
@lexer::members {
    public const int HIDDEN = Hidden;
     public enum tokens
    {
        ARROBA = 4, ASSIGNMENT_LIST, ASSING, ATTRIBUTE, BLOCK, BODY, BOOLEAN,
        CASE, CHAR, CLASS, CL_LLAVE, CL_PARENT, COMA, COMMENT, DIGIT, DISPATCH, DIV,
        DOUBLEP, ELSE, END, EQ, ESAC, ESC_SEQ, EXPONENT, FI, G, GEQ, HEX_DIGIT, ID,
        IF, IMPLICS, IN, INHERITS, ISVOID, L, LEQ, LET, LOOP, LOWERCASE, METHOD, METHODEFINITION,
        MINUS, MULT, NANARITA, NEW, NL, NOT, NUMBER, OCTAL_ESC, OF, OP_LLAVE, OP_PARENT,
        PARAM, PARAMLIST, PLUS, PNT, POOL, PROGRAM, STRING, THEN, TYPE, UNICODE_ESC,
        UPERCASE, VAR_DECLARATION, VAR_DECLARATION_LIST, WHILE, WS,

    }
}

 public program: (class)+ EOF->^(PROGRAM (class)+) ;

 class: (CLASS^ TYPE (INHERITS TYPE)? OP_LLAVE! ( feature_list)? CL_LLAVE! END!)
		;
 feature_list: feature+;
 feature: (ID (attribute-> ^(ATTRIBUTE ID attribute)|methodefinition-> ^(METHOD ID methodefinition)) END) ;
 
attribute:  DOUBLEP! TYPE (ASSING expr)?  ;
 methodefinition: OP_PARENT (params_list )?  CL_PARENT  DOUBLEP  TYPE  OP_LLAVE  expr  CL_LLAVE->^(METHODEFINITION params_list? TYPE ^(BODY expr)) ;
 params_list: param (COMA  param)*->^(PARAMLIST param param*);
 param: (ID  DOUBLEP  TYPE)->^(PARAM ID TYPE);

 expr: assignment
	   |conditionals
	   |loops
	   |blocks
	   |let
	   |case
	   |new
	   |operations
	   |TYPE^
	   |(NOT^ expr)
	   |(ISVOID^  expr)
	   |nanarita;
exprList:	expr END! (expr END!)*;
 assignment: (ID ASSING^  expr) ;
 conditionals: (IF expr (THEN expr) (ELSE expr)? FI)->^(IF expr ^(THEN expr) ^(ELSE expr)?) ;
 loops: WHILE^  expr LOOP! expr POOL! ;//-> LOOP^ expr LOOP WHILE^ expr ;
 blocks: OP_LLAVE  exprList CL_LLAVE->^(BLOCK exprList) ;
 let: (LET  var_list_declaration IN expr)->^(LET var_list_declaration ^(BODY expr)) ;
 vardeclaration
 	:	ID attribute->^(VAR_DECLARATION ID  attribute);
 var_list_declaration
 	:	 (vardeclaration-> vardeclaration) (COMA vardeclaration->^(VAR_DECLARATION_LIST $var_list_declaration vardeclaration))*;
 case: CASE^ expr OF! caseBranches ESAC! ;
 caseBranch
 	:	param IMPLICS expr END-> ^(CASEBRANCH param expr);
 caseBranches
 	:	(caseBranch->caseBranch) (caseBranch->^( CASEBRANCHES $caseBranches caseBranch))*;
 new : (NEW^ TYPE) ;
 
 dispatch: (ARROBA! TYPE PNT!|PNT!) ID OP_PARENT (expr ( COMA! expr)*)? CL_PARENT! ;
 exprlist1
 	:	(expr ( COMA! expr)*)?;
 dispatch2
 	:	 OP_PARENT (expr ( COMA! expr)*)? CL_PARENT! ;
 	dispatch3:
 	PNT! dispatch2;
 operations
 	:	 lv1 ;
 	lv1:  lv2 ( LEQ^ lv1|GEQ^ lv1|L^ lv1|G^ lv1|EQ^ lv1)?;
 	lv2: lv3 ( PLUS^  lv2|MINUS^  lv2)? ;
 	lv3: lv4( MULT^  lv3|DIV^  lv3)?;
 	lv4: lv5 ;
 	lv5:  lv6 ;
 	lv6: ((ID->ID) (dispatchrec->^(DISPATCH $lv6 dispatchrec)|(dispatch2->^(DISPATCH $lv6 dispatch2))?
 	|(tmp2->tmp2) (dispatch->^(DISPATCH $lv6 dispatch))?
 	|(constant->constant) (dispatch->^(DISPATCH $lv6 dispatch))?;
 	tmp2: OP_PARENT! expr CL_PARENT!;
 nanarita: NANARITA^ expr ;
  constant: STRING|NUMBER|BOOLEAN;
 wsnl	:	(WS|NL)+ ;
compileUnit
	:	EOF
	;

dispatchrec
	:	 (dispatch->^(DISPATCH dispatch)) (dispatchrec)?;
CLASS: ('class') ;
fragment UPERCASE:'A'..'Z';
fragment LOWERCASE:'a'..'z';
fragment DIGIT: '0'..'9' ;
//fragment LETTER options {testLiterals=true;}:	UPERCASE|LOWERCASE|'ñ'|'Ñ';
OP_LLAVE: '{';
CL_LLAVE: '}' ;
END: ';' ;

//PARAM	:	;

//PARAMLIST:	;
DOUBLEP: ':' ;
ASSING: '<-' ;
OP_PARENT: '(' ;
CL_PARENT: ')' ;
COMA: ',' ;
NUMBER: (DIGIT)+ '.' (DIGIT)+|DIGIT+ ;
BOOLEAN: 'true'|'false' ;
IF: 'if' ;
THEN: 'then' ;
ELSE: 'else' ;
FI: 'fi' ;
WHILE: 'while' ;
LOOP: 'loop' ;
POOL: 'pool' ;
LET	:	 'let' ;
IN: 'in' ;
CASE: 'case' ;
OF: 'of' ;
ESAC: 'esac' ;
NEW: 'new' ;
ISVOID: 'isvoid' ;
ARROBA: '@' ;
PNT: '.' ;
NOT: 'not' ;
LEQ: '<=' ;
GEQ: '>=' ;
L: '<' ;
G: '>' ;
EQ: '=' ;
PLUS: '+' ;
MINUS: '-' ;
MULT: '*' ;
DIV: '/' ;
NANARITA: '~';
IMPLICS	:	'=>';
INHERITS:	'inherits';


NL : ('\n')+ {$channel=HIDDEN;} ;

//INT :	'0'..'9'+
 //   ;

/*FLOAT
    :   ('0'..'9')+ '.' ('0'..'9')* EXPONENT?
    |   '.' ('0'..'9')+ EXPONENT?
    |   ('0'..'9')+ EXPONENT
    ;*/

COMMENT
    :   '--' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;}
    |   '(*' ( options {greedy=false;} : . )* '*)' {$channel=HIDDEN;}
    ;

  WS:   ( ' '
        | '\t'
        | '\r'
        ) {$channel=HIDDEN;}
    ;

STRING
    :  '"' ( ESC_SEQ | ~('\\'|'"') )* '"'
    ;

CHAR:  '\'' ( ESC_SEQ | ~('\''|'\\') ) '\''
    ;

fragment
EXPONENT : ('e'|'E') ('+'|'-')? ('0'..'9')+ ;

fragment
HEX_DIGIT : ('0'..'9'|'a'..'f'|'A'..'F') ;

fragment
ESC_SEQ
    :   '\\' ('b'|'t'|'n'|'f'|'r'|'\"'|'\''|'\\')
    |   UNICODE_ESC
    |   OCTAL_ESC
    ;

fragment
OCTAL_ESC
    :   '\\' ('0'..'3') ('0'..'7') ('0'..'7')
    |   '\\' ('0'..'7') ('0'..'7')
    |   '\\' ('0'..'7')
    ;

fragment
UNICODE_ESC
    :   '\\' 'u' HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT
    ;
    
    ID
:
(LOWERCASE|'_') (LOWERCASE|UPERCASE|DIGIT|'_')*
;


TYPE:(UPERCASE) (LOWERCASE|UPERCASE|DIGIT|'_')*;
