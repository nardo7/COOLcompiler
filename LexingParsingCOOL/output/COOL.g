grammar COOL;
options{
language=CSharp3;
}
@lexer::members {
    public const int HIDDEN = Hidden;
}
 public program: (class)+ EOF ;

 class: CLASS TYPE (INHERITS)? TYPE OP_CORCH ( feature_list)? wsnl? CL_CORCH END wsnl
		;
 feature_list: feature ( feature)* ;
 feature: ID (attribute|methodefinition) END ;
 
attribute:  DOUBLEP (WS)? TYPE ((WS)? ASSING (WS)? expr)?  ;

 methodefinition: OP_PARENT ((WS)? params_list)? (WS)? CL_PARENT (WS)? DOUBLEP (WS)? TYPE (WS)? OP_CORCH (wsnl)? expr  CL_CORCH ;
 params_list: param ((WS)? COMA (WS)? param)*;
 param: ID (WS)? DOUBLEP (WS)? TYPE;

 expr: assignment
	   |conditionals
	   |loops
	   |blocks
	   |let
	   |case
	   |new
	   |operations;
	   
	 //  | auxid;
//auxid	:(ID|constant)? lvE	;
 constant: STRING|NUMBER|BOOLEAN;
 assignment: ID (WS)? ASSING (WS)? expr ;
 conditionals: IF WS expr wsnl THEN wsnl expr wsnl FI ;
 loops: WHILE WS expr wsnl LOOP wsnl expr wsnl POOL ;
 blocks: OP_CORCH ((wsnl)? expr END (wsnl? expr END)*)? (wsnl)? CL_CORCH ;
 let: LET WS assignment ( (WS)? COMA (WS)? assignment)* wsnl IN wsnl expr ;
 case: CASE WS expr WS OF (wsnl param WS IMPLICS wsnl expr)+ wsnl ESAC ;
 new : NEW WS TYPE ;
 //isvoid: ISVOID WS expr ;
 dispatch: (ARROBA TYPE |PNT) ID OP_PARENT WS? (expr (WS? COMA WS? expr)*)? CL_PARENT ;
 
 operations
 	:	 (NOT expr)? lv1 ;
 	lv1:  lv2 ((WS)? LEQ (WS)? lv1|GEQ (WS)? lv1|L (WS)? lv1|G (WS)? lv1|EQ (WS)? lv1)?;
 	lv2: lv3 ((WS)? PLUS (WS)? lv2|MINUS (WS)? lv2)? ;
 	lv3: lv4((WS)? MULT (WS)? lv3|DIV (WS)? lv3)?;
 	lv4: (ISVOID WS expr)?lv5 ;
 	lv5: nanarita? lv6 ;
 	lv6: (ID|OP_PARENT expr CL_PARENT)(dispatch)? ;
 	
 nanarita: NANARITA expr ;
 wsnl	:	(WS|NL)+ ;
compileUnit
	:	EOF
	;


CLASS: ('class') ;
fragment UPERCASE:'A'..'Z';
fragment LOWERCASE:'a'..'z';
fragment DIGIT: '0'..'9' ;
//fragment LETTER options {testLiterals=true;}:	UPERCASE|LOWERCASE|'ñ'|'Ñ';
OP_CORCH: '{';
CL_CORCH: '}' ;
END: ';' ;

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
ID
:
(LOWERCASE|'_') (LOWERCASE|UPERCASE|DIGIT|'_')*
;

TYPE:(UPERCASE) (LOWERCASE|UPERCASE|DIGIT|'_')*;

NL : ('\n'|'\v')+ {$channel=HIDDEN;} ;

//INT :	'0'..'9'+
 //   ;

/*FLOAT
    :   ('0'..'9')+ '.' ('0'..'9')* EXPONENT?
    |   '.' ('0'..'9')+ EXPONENT?
    |   ('0'..'9')+ EXPONENT
    ;*/

COMMENT
    :   '//' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;}
    |   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;

WS  :   ( ' '
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
