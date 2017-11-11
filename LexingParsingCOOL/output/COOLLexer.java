// $ANTLR 3.4 C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g 2017-10-16 21:16:17

import org.antlr.runtime.*;
import java.util.Stack;
import java.util.List;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked"})
public class COOLLexer extends Lexer {
    public static final int EOF=-1;
    public static final int ARROBA=4;
    public static final int ASSING=5;
    public static final int BOOLEAN=6;
    public static final int CASE=7;
    public static final int CHAR=8;
    public static final int CLASS=9;
    public static final int CL_CORCH=10;
    public static final int CL_PARENT=11;
    public static final int COMA=12;
    public static final int COMMENT=13;
    public static final int DIGIT=14;
    public static final int DIV=15;
    public static final int DOUBLEP=16;
    public static final int ELSE=17;
    public static final int END=18;
    public static final int EQ=19;
    public static final int ESAC=20;
    public static final int ESC_SEQ=21;
    public static final int EXPONENT=22;
    public static final int FI=23;
    public static final int G=24;
    public static final int GEQ=25;
    public static final int HEX_DIGIT=26;
    public static final int ID=27;
    public static final int IF=28;
    public static final int IMPLICS=29;
    public static final int IN=30;
    public static final int ISVOID=31;
    public static final int L=32;
    public static final int LEQ=33;
    public static final int LET=34;
    public static final int LOOP=35;
    public static final int LOWERCASE=36;
    public static final int MINUS=37;
    public static final int MULT=38;
    public static final int NANARITA=39;
    public static final int NEW=40;
    public static final int NL=41;
    public static final int NOT=42;
    public static final int NUMBER=43;
    public static final int OCTAL_ESC=44;
    public static final int OF=45;
    public static final int OP_CORCH=46;
    public static final int OP_PARENT=47;
    public static final int PLUS=48;
    public static final int PNT=49;
    public static final int POOL=50;
    public static final int STRING=51;
    public static final int THEN=52;
    public static final int TYPE=53;
    public static final int UNICODE_ESC=54;
    public static final int UPERCASE=55;
    public static final int WHILE=56;
    public static final int WS=57;

    // delegates
    // delegators
    public Lexer[] getDelegates() {
        return new Lexer[] {};
    }

    public COOLLexer() {} 
    public COOLLexer(CharStream input) {
        this(input, new RecognizerSharedState());
    }
    public COOLLexer(CharStream input, RecognizerSharedState state) {
        super(input,state);
    }
    public String getGrammarFileName() { return "C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g"; }

    // $ANTLR start "CLASS"
    public final void mCLASS() throws RecognitionException {
        try {
            int _type = CLASS;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:54:6: ( ( 'class' ) )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:54:8: ( 'class' )
            {
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:54:8: ( 'class' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:54:9: 'class'
            {
            match("class"); 



            }


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "CLASS"

    // $ANTLR start "UPERCASE"
    public final void mUPERCASE() throws RecognitionException {
        try {
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:55:18: ( 'A' .. 'Z' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
            {
            if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z') ) {
                input.consume();
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                recover(mse);
                throw mse;
            }


            }


        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "UPERCASE"

    // $ANTLR start "LOWERCASE"
    public final void mLOWERCASE() throws RecognitionException {
        try {
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:56:19: ( 'a' .. 'z' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
            {
            if ( (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) {
                input.consume();
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                recover(mse);
                throw mse;
            }


            }


        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "LOWERCASE"

    // $ANTLR start "DIGIT"
    public final void mDIGIT() throws RecognitionException {
        try {
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:57:15: ( '0' .. '9' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
            {
            if ( (input.LA(1) >= '0' && input.LA(1) <= '9') ) {
                input.consume();
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                recover(mse);
                throw mse;
            }


            }


        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "DIGIT"

    // $ANTLR start "OP_CORCH"
    public final void mOP_CORCH() throws RecognitionException {
        try {
            int _type = OP_CORCH;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:59:9: ( '{' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:59:11: '{'
            {
            match('{'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "OP_CORCH"

    // $ANTLR start "CL_CORCH"
    public final void mCL_CORCH() throws RecognitionException {
        try {
            int _type = CL_CORCH;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:60:9: ( '}' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:60:11: '}'
            {
            match('}'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "CL_CORCH"

    // $ANTLR start "END"
    public final void mEND() throws RecognitionException {
        try {
            int _type = END;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:61:4: ( ';' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:61:6: ';'
            {
            match(';'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "END"

    // $ANTLR start "DOUBLEP"
    public final void mDOUBLEP() throws RecognitionException {
        try {
            int _type = DOUBLEP;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:63:8: ( ':' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:63:10: ':'
            {
            match(':'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "DOUBLEP"

    // $ANTLR start "ASSING"
    public final void mASSING() throws RecognitionException {
        try {
            int _type = ASSING;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:64:7: ( '<-' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:64:9: '<-'
            {
            match("<-"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "ASSING"

    // $ANTLR start "OP_PARENT"
    public final void mOP_PARENT() throws RecognitionException {
        try {
            int _type = OP_PARENT;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:65:10: ( '(' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:65:12: '('
            {
            match('('); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "OP_PARENT"

    // $ANTLR start "CL_PARENT"
    public final void mCL_PARENT() throws RecognitionException {
        try {
            int _type = CL_PARENT;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:66:10: ( ')' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:66:12: ')'
            {
            match(')'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "CL_PARENT"

    // $ANTLR start "COMA"
    public final void mCOMA() throws RecognitionException {
        try {
            int _type = COMA;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:67:5: ( ',' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:67:7: ','
            {
            match(','); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "COMA"

    // $ANTLR start "NUMBER"
    public final void mNUMBER() throws RecognitionException {
        try {
            int _type = NUMBER;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:68:7: ( ( DIGIT )+ '.' ( DIGIT )+ | ( DIGIT )+ )
            int alt4=2;
            alt4 = dfa4.predict(input);
            switch (alt4) {
                case 1 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:68:9: ( DIGIT )+ '.' ( DIGIT )+
                    {
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:68:9: ( DIGIT )+
                    int cnt1=0;
                    loop1:
                    do {
                        int alt1=2;
                        int LA1_0 = input.LA(1);

                        if ( ((LA1_0 >= '0' && LA1_0 <= '9')) ) {
                            alt1=1;
                        }


                        switch (alt1) {
                    	case 1 :
                    	    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
                    	    {
                    	    if ( (input.LA(1) >= '0' && input.LA(1) <= '9') ) {
                    	        input.consume();
                    	    }
                    	    else {
                    	        MismatchedSetException mse = new MismatchedSetException(null,input);
                    	        recover(mse);
                    	        throw mse;
                    	    }


                    	    }
                    	    break;

                    	default :
                    	    if ( cnt1 >= 1 ) break loop1;
                                EarlyExitException eee =
                                    new EarlyExitException(1, input);
                                throw eee;
                        }
                        cnt1++;
                    } while (true);


                    match('.'); 

                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:68:22: ( DIGIT )+
                    int cnt2=0;
                    loop2:
                    do {
                        int alt2=2;
                        int LA2_0 = input.LA(1);

                        if ( ((LA2_0 >= '0' && LA2_0 <= '9')) ) {
                            alt2=1;
                        }


                        switch (alt2) {
                    	case 1 :
                    	    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
                    	    {
                    	    if ( (input.LA(1) >= '0' && input.LA(1) <= '9') ) {
                    	        input.consume();
                    	    }
                    	    else {
                    	        MismatchedSetException mse = new MismatchedSetException(null,input);
                    	        recover(mse);
                    	        throw mse;
                    	    }


                    	    }
                    	    break;

                    	default :
                    	    if ( cnt2 >= 1 ) break loop2;
                                EarlyExitException eee =
                                    new EarlyExitException(2, input);
                                throw eee;
                        }
                        cnt2++;
                    } while (true);


                    }
                    break;
                case 2 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:68:31: ( DIGIT )+
                    {
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:68:31: ( DIGIT )+
                    int cnt3=0;
                    loop3:
                    do {
                        int alt3=2;
                        int LA3_0 = input.LA(1);

                        if ( ((LA3_0 >= '0' && LA3_0 <= '9')) ) {
                            alt3=1;
                        }


                        switch (alt3) {
                    	case 1 :
                    	    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
                    	    {
                    	    if ( (input.LA(1) >= '0' && input.LA(1) <= '9') ) {
                    	        input.consume();
                    	    }
                    	    else {
                    	        MismatchedSetException mse = new MismatchedSetException(null,input);
                    	        recover(mse);
                    	        throw mse;
                    	    }


                    	    }
                    	    break;

                    	default :
                    	    if ( cnt3 >= 1 ) break loop3;
                                EarlyExitException eee =
                                    new EarlyExitException(3, input);
                                throw eee;
                        }
                        cnt3++;
                    } while (true);


                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "NUMBER"

    // $ANTLR start "BOOLEAN"
    public final void mBOOLEAN() throws RecognitionException {
        try {
            int _type = BOOLEAN;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:69:8: ( 'true' | 'false' )
            int alt5=2;
            int LA5_0 = input.LA(1);

            if ( (LA5_0=='t') ) {
                alt5=1;
            }
            else if ( (LA5_0=='f') ) {
                alt5=2;
            }
            else {
                NoViableAltException nvae =
                    new NoViableAltException("", 5, 0, input);

                throw nvae;

            }
            switch (alt5) {
                case 1 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:69:10: 'true'
                    {
                    match("true"); 



                    }
                    break;
                case 2 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:69:17: 'false'
                    {
                    match("false"); 



                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "BOOLEAN"

    // $ANTLR start "IF"
    public final void mIF() throws RecognitionException {
        try {
            int _type = IF;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:70:3: ( 'if' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:70:5: 'if'
            {
            match("if"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "IF"

    // $ANTLR start "THEN"
    public final void mTHEN() throws RecognitionException {
        try {
            int _type = THEN;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:71:5: ( 'then' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:71:7: 'then'
            {
            match("then"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "THEN"

    // $ANTLR start "ELSE"
    public final void mELSE() throws RecognitionException {
        try {
            int _type = ELSE;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:72:5: ( 'else' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:72:7: 'else'
            {
            match("else"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "ELSE"

    // $ANTLR start "FI"
    public final void mFI() throws RecognitionException {
        try {
            int _type = FI;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:73:3: ( 'fi' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:73:5: 'fi'
            {
            match("fi"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "FI"

    // $ANTLR start "WHILE"
    public final void mWHILE() throws RecognitionException {
        try {
            int _type = WHILE;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:74:6: ( 'while' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:74:8: 'while'
            {
            match("while"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "WHILE"

    // $ANTLR start "LOOP"
    public final void mLOOP() throws RecognitionException {
        try {
            int _type = LOOP;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:75:5: ( 'loop' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:75:7: 'loop'
            {
            match("loop"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "LOOP"

    // $ANTLR start "POOL"
    public final void mPOOL() throws RecognitionException {
        try {
            int _type = POOL;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:76:5: ( 'pool' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:76:7: 'pool'
            {
            match("pool"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "POOL"

    // $ANTLR start "LET"
    public final void mLET() throws RecognitionException {
        try {
            int _type = LET;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:77:5: ( 'let' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:77:8: 'let'
            {
            match("let"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "LET"

    // $ANTLR start "IN"
    public final void mIN() throws RecognitionException {
        try {
            int _type = IN;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:78:3: ( 'in' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:78:5: 'in'
            {
            match("in"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "IN"

    // $ANTLR start "CASE"
    public final void mCASE() throws RecognitionException {
        try {
            int _type = CASE;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:79:5: ( 'case' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:79:7: 'case'
            {
            match("case"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "CASE"

    // $ANTLR start "OF"
    public final void mOF() throws RecognitionException {
        try {
            int _type = OF;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:80:3: ( 'of' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:80:5: 'of'
            {
            match("of"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "OF"

    // $ANTLR start "ESAC"
    public final void mESAC() throws RecognitionException {
        try {
            int _type = ESAC;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:81:5: ( 'esac' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:81:7: 'esac'
            {
            match("esac"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "ESAC"

    // $ANTLR start "NEW"
    public final void mNEW() throws RecognitionException {
        try {
            int _type = NEW;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:82:4: ( 'new' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:82:6: 'new'
            {
            match("new"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "NEW"

    // $ANTLR start "ISVOID"
    public final void mISVOID() throws RecognitionException {
        try {
            int _type = ISVOID;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:83:7: ( 'isvoid' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:83:9: 'isvoid'
            {
            match("isvoid"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "ISVOID"

    // $ANTLR start "ARROBA"
    public final void mARROBA() throws RecognitionException {
        try {
            int _type = ARROBA;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:84:7: ( '@' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:84:9: '@'
            {
            match('@'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "ARROBA"

    // $ANTLR start "PNT"
    public final void mPNT() throws RecognitionException {
        try {
            int _type = PNT;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:85:4: ( '.' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:85:6: '.'
            {
            match('.'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "PNT"

    // $ANTLR start "NOT"
    public final void mNOT() throws RecognitionException {
        try {
            int _type = NOT;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:86:4: ( 'not' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:86:6: 'not'
            {
            match("not"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "NOT"

    // $ANTLR start "LEQ"
    public final void mLEQ() throws RecognitionException {
        try {
            int _type = LEQ;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:87:4: ( '<=' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:87:6: '<='
            {
            match("<="); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "LEQ"

    // $ANTLR start "GEQ"
    public final void mGEQ() throws RecognitionException {
        try {
            int _type = GEQ;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:88:4: ( '>=' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:88:6: '>='
            {
            match(">="); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "GEQ"

    // $ANTLR start "L"
    public final void mL() throws RecognitionException {
        try {
            int _type = L;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:89:2: ( '<' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:89:4: '<'
            {
            match('<'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "L"

    // $ANTLR start "G"
    public final void mG() throws RecognitionException {
        try {
            int _type = G;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:90:2: ( '>' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:90:4: '>'
            {
            match('>'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "G"

    // $ANTLR start "EQ"
    public final void mEQ() throws RecognitionException {
        try {
            int _type = EQ;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:91:3: ( '=' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:91:5: '='
            {
            match('='); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "EQ"

    // $ANTLR start "PLUS"
    public final void mPLUS() throws RecognitionException {
        try {
            int _type = PLUS;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:92:5: ( '+' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:92:7: '+'
            {
            match('+'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "PLUS"

    // $ANTLR start "MINUS"
    public final void mMINUS() throws RecognitionException {
        try {
            int _type = MINUS;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:93:6: ( '-' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:93:8: '-'
            {
            match('-'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "MINUS"

    // $ANTLR start "MULT"
    public final void mMULT() throws RecognitionException {
        try {
            int _type = MULT;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:94:5: ( '*' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:94:7: '*'
            {
            match('*'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "MULT"

    // $ANTLR start "DIV"
    public final void mDIV() throws RecognitionException {
        try {
            int _type = DIV;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:95:4: ( '/' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:95:6: '/'
            {
            match('/'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "DIV"

    // $ANTLR start "NANARITA"
    public final void mNANARITA() throws RecognitionException {
        try {
            int _type = NANARITA;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:96:9: ( '~' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:96:11: '~'
            {
            match('~'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "NANARITA"

    // $ANTLR start "IMPLICS"
    public final void mIMPLICS() throws RecognitionException {
        try {
            int _type = IMPLICS;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:97:9: ( '=>' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:97:11: '=>'
            {
            match("=>"); 



            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "IMPLICS"

    // $ANTLR start "ID"
    public final void mID() throws RecognitionException {
        try {
            int _type = ID;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:99:2: ( ( LOWERCASE | '_' ) ( LOWERCASE | UPERCASE | DIGIT | '_' )* )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:100:2: ( LOWERCASE | '_' ) ( LOWERCASE | UPERCASE | DIGIT | '_' )*
            {
            if ( input.LA(1)=='_'||(input.LA(1) >= 'a' && input.LA(1) <= 'z') ) {
                input.consume();
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                recover(mse);
                throw mse;
            }


            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:100:17: ( LOWERCASE | UPERCASE | DIGIT | '_' )*
            loop6:
            do {
                int alt6=2;
                int LA6_0 = input.LA(1);

                if ( ((LA6_0 >= '0' && LA6_0 <= '9')||(LA6_0 >= 'A' && LA6_0 <= 'Z')||LA6_0=='_'||(LA6_0 >= 'a' && LA6_0 <= 'z')) ) {
                    alt6=1;
                }


                switch (alt6) {
            	case 1 :
            	    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
            	    {
            	    if ( (input.LA(1) >= '0' && input.LA(1) <= '9')||(input.LA(1) >= 'A' && input.LA(1) <= 'Z')||input.LA(1)=='_'||(input.LA(1) >= 'a' && input.LA(1) <= 'z') ) {
            	        input.consume();
            	    }
            	    else {
            	        MismatchedSetException mse = new MismatchedSetException(null,input);
            	        recover(mse);
            	        throw mse;
            	    }


            	    }
            	    break;

            	default :
            	    break loop6;
                }
            } while (true);


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "ID"

    // $ANTLR start "TYPE"
    public final void mTYPE() throws RecognitionException {
        try {
            int _type = TYPE;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:103:5: ( ( UPERCASE ) ( LOWERCASE | UPERCASE | DIGIT | '_' )* )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:103:6: ( UPERCASE ) ( LOWERCASE | UPERCASE | DIGIT | '_' )*
            {
            if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z') ) {
                input.consume();
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                recover(mse);
                throw mse;
            }


            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:103:17: ( LOWERCASE | UPERCASE | DIGIT | '_' )*
            loop7:
            do {
                int alt7=2;
                int LA7_0 = input.LA(1);

                if ( ((LA7_0 >= '0' && LA7_0 <= '9')||(LA7_0 >= 'A' && LA7_0 <= 'Z')||LA7_0=='_'||(LA7_0 >= 'a' && LA7_0 <= 'z')) ) {
                    alt7=1;
                }


                switch (alt7) {
            	case 1 :
            	    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
            	    {
            	    if ( (input.LA(1) >= '0' && input.LA(1) <= '9')||(input.LA(1) >= 'A' && input.LA(1) <= 'Z')||input.LA(1)=='_'||(input.LA(1) >= 'a' && input.LA(1) <= 'z') ) {
            	        input.consume();
            	    }
            	    else {
            	        MismatchedSetException mse = new MismatchedSetException(null,input);
            	        recover(mse);
            	        throw mse;
            	    }


            	    }
            	    break;

            	default :
            	    break loop7;
                }
            } while (true);


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "TYPE"

    // $ANTLR start "NL"
    public final void mNL() throws RecognitionException {
        try {
            int _type = NL;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:105:4: ( ( '\\n' | '\\v' )+ )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:105:6: ( '\\n' | '\\v' )+
            {
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:105:6: ( '\\n' | '\\v' )+
            int cnt8=0;
            loop8:
            do {
                int alt8=2;
                int LA8_0 = input.LA(1);

                if ( (LA8_0=='\n'||LA8_0=='v') ) {
                    alt8=1;
                }


                switch (alt8) {
            	case 1 :
            	    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
            	    {
            	    if ( input.LA(1)=='\n'||input.LA(1)=='v' ) {
            	        input.consume();
            	    }
            	    else {
            	        MismatchedSetException mse = new MismatchedSetException(null,input);
            	        recover(mse);
            	        throw mse;
            	    }


            	    }
            	    break;

            	default :
            	    if ( cnt8 >= 1 ) break loop8;
                        EarlyExitException eee =
                            new EarlyExitException(8, input);
                        throw eee;
                }
                cnt8++;
            } while (true);


            _channel=HIDDEN;

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "NL"

    // $ANTLR start "COMMENT"
    public final void mCOMMENT() throws RecognitionException {
        try {
            int _type = COMMENT;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:117:5: ( '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' | '/*' ( options {greedy=false; } : . )* '*/' )
            int alt12=2;
            int LA12_0 = input.LA(1);

            if ( (LA12_0=='/') ) {
                int LA12_1 = input.LA(2);

                if ( (LA12_1=='/') ) {
                    alt12=1;
                }
                else if ( (LA12_1=='*') ) {
                    alt12=2;
                }
                else {
                    NoViableAltException nvae =
                        new NoViableAltException("", 12, 1, input);

                    throw nvae;

                }
            }
            else {
                NoViableAltException nvae =
                    new NoViableAltException("", 12, 0, input);

                throw nvae;

            }
            switch (alt12) {
                case 1 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:117:9: '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
                    {
                    match("//"); 



                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:117:14: (~ ( '\\n' | '\\r' ) )*
                    loop9:
                    do {
                        int alt9=2;
                        int LA9_0 = input.LA(1);

                        if ( ((LA9_0 >= '\u0000' && LA9_0 <= '\t')||(LA9_0 >= '\u000B' && LA9_0 <= '\f')||(LA9_0 >= '\u000E' && LA9_0 <= '\uFFFF')) ) {
                            alt9=1;
                        }


                        switch (alt9) {
                    	case 1 :
                    	    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
                    	    {
                    	    if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t')||(input.LA(1) >= '\u000B' && input.LA(1) <= '\f')||(input.LA(1) >= '\u000E' && input.LA(1) <= '\uFFFF') ) {
                    	        input.consume();
                    	    }
                    	    else {
                    	        MismatchedSetException mse = new MismatchedSetException(null,input);
                    	        recover(mse);
                    	        throw mse;
                    	    }


                    	    }
                    	    break;

                    	default :
                    	    break loop9;
                        }
                    } while (true);


                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:117:28: ( '\\r' )?
                    int alt10=2;
                    int LA10_0 = input.LA(1);

                    if ( (LA10_0=='\r') ) {
                        alt10=1;
                    }
                    switch (alt10) {
                        case 1 :
                            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:117:28: '\\r'
                            {
                            match('\r'); 

                            }
                            break;

                    }


                    match('\n'); 

                    _channel=HIDDEN;

                    }
                    break;
                case 2 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:118:9: '/*' ( options {greedy=false; } : . )* '*/'
                    {
                    match("/*"); 



                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:118:14: ( options {greedy=false; } : . )*
                    loop11:
                    do {
                        int alt11=2;
                        int LA11_0 = input.LA(1);

                        if ( (LA11_0=='*') ) {
                            int LA11_1 = input.LA(2);

                            if ( (LA11_1=='/') ) {
                                alt11=2;
                            }
                            else if ( ((LA11_1 >= '\u0000' && LA11_1 <= '.')||(LA11_1 >= '0' && LA11_1 <= '\uFFFF')) ) {
                                alt11=1;
                            }


                        }
                        else if ( ((LA11_0 >= '\u0000' && LA11_0 <= ')')||(LA11_0 >= '+' && LA11_0 <= '\uFFFF')) ) {
                            alt11=1;
                        }


                        switch (alt11) {
                    	case 1 :
                    	    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:118:42: .
                    	    {
                    	    matchAny(); 

                    	    }
                    	    break;

                    	default :
                    	    break loop11;
                        }
                    } while (true);


                    match("*/"); 



                    _channel=HIDDEN;

                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "COMMENT"

    // $ANTLR start "WS"
    public final void mWS() throws RecognitionException {
        try {
            int _type = WS;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:121:5: ( ( ' ' | '\\t' | '\\r' ) )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:121:9: ( ' ' | '\\t' | '\\r' )
            {
            if ( input.LA(1)=='\t'||input.LA(1)=='\r'||input.LA(1)==' ' ) {
                input.consume();
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                recover(mse);
                throw mse;
            }


            _channel=HIDDEN;

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "WS"

    // $ANTLR start "STRING"
    public final void mSTRING() throws RecognitionException {
        try {
            int _type = STRING;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:128:5: ( '\"' ( ESC_SEQ |~ ( '\\\\' | '\"' ) )* '\"' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:128:8: '\"' ( ESC_SEQ |~ ( '\\\\' | '\"' ) )* '\"'
            {
            match('\"'); 

            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:128:12: ( ESC_SEQ |~ ( '\\\\' | '\"' ) )*
            loop13:
            do {
                int alt13=3;
                int LA13_0 = input.LA(1);

                if ( (LA13_0=='\\') ) {
                    alt13=1;
                }
                else if ( ((LA13_0 >= '\u0000' && LA13_0 <= '!')||(LA13_0 >= '#' && LA13_0 <= '[')||(LA13_0 >= ']' && LA13_0 <= '\uFFFF')) ) {
                    alt13=2;
                }


                switch (alt13) {
            	case 1 :
            	    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:128:14: ESC_SEQ
            	    {
            	    mESC_SEQ(); 


            	    }
            	    break;
            	case 2 :
            	    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:128:24: ~ ( '\\\\' | '\"' )
            	    {
            	    if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '!')||(input.LA(1) >= '#' && input.LA(1) <= '[')||(input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) {
            	        input.consume();
            	    }
            	    else {
            	        MismatchedSetException mse = new MismatchedSetException(null,input);
            	        recover(mse);
            	        throw mse;
            	    }


            	    }
            	    break;

            	default :
            	    break loop13;
                }
            } while (true);


            match('\"'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "STRING"

    // $ANTLR start "CHAR"
    public final void mCHAR() throws RecognitionException {
        try {
            int _type = CHAR;
            int _channel = DEFAULT_TOKEN_CHANNEL;
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:131:5: ( '\\'' ( ESC_SEQ |~ ( '\\'' | '\\\\' ) ) '\\'' )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:131:8: '\\'' ( ESC_SEQ |~ ( '\\'' | '\\\\' ) ) '\\''
            {
            match('\''); 

            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:131:13: ( ESC_SEQ |~ ( '\\'' | '\\\\' ) )
            int alt14=2;
            int LA14_0 = input.LA(1);

            if ( (LA14_0=='\\') ) {
                alt14=1;
            }
            else if ( ((LA14_0 >= '\u0000' && LA14_0 <= '&')||(LA14_0 >= '(' && LA14_0 <= '[')||(LA14_0 >= ']' && LA14_0 <= '\uFFFF')) ) {
                alt14=2;
            }
            else {
                NoViableAltException nvae =
                    new NoViableAltException("", 14, 0, input);

                throw nvae;

            }
            switch (alt14) {
                case 1 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:131:15: ESC_SEQ
                    {
                    mESC_SEQ(); 


                    }
                    break;
                case 2 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:131:25: ~ ( '\\'' | '\\\\' )
                    {
                    if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '&')||(input.LA(1) >= '(' && input.LA(1) <= '[')||(input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) {
                        input.consume();
                    }
                    else {
                        MismatchedSetException mse = new MismatchedSetException(null,input);
                        recover(mse);
                        throw mse;
                    }


                    }
                    break;

            }


            match('\''); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "CHAR"

    // $ANTLR start "EXPONENT"
    public final void mEXPONENT() throws RecognitionException {
        try {
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:136:10: ( ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+ )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:136:12: ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+
            {
            if ( input.LA(1)=='E'||input.LA(1)=='e' ) {
                input.consume();
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                recover(mse);
                throw mse;
            }


            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:136:22: ( '+' | '-' )?
            int alt15=2;
            int LA15_0 = input.LA(1);

            if ( (LA15_0=='+'||LA15_0=='-') ) {
                alt15=1;
            }
            switch (alt15) {
                case 1 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
                    {
                    if ( input.LA(1)=='+'||input.LA(1)=='-' ) {
                        input.consume();
                    }
                    else {
                        MismatchedSetException mse = new MismatchedSetException(null,input);
                        recover(mse);
                        throw mse;
                    }


                    }
                    break;

            }


            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:136:33: ( '0' .. '9' )+
            int cnt16=0;
            loop16:
            do {
                int alt16=2;
                int LA16_0 = input.LA(1);

                if ( ((LA16_0 >= '0' && LA16_0 <= '9')) ) {
                    alt16=1;
                }


                switch (alt16) {
            	case 1 :
            	    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
            	    {
            	    if ( (input.LA(1) >= '0' && input.LA(1) <= '9') ) {
            	        input.consume();
            	    }
            	    else {
            	        MismatchedSetException mse = new MismatchedSetException(null,input);
            	        recover(mse);
            	        throw mse;
            	    }


            	    }
            	    break;

            	default :
            	    if ( cnt16 >= 1 ) break loop16;
                        EarlyExitException eee =
                            new EarlyExitException(16, input);
                        throw eee;
                }
                cnt16++;
            } while (true);


            }


        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "EXPONENT"

    // $ANTLR start "HEX_DIGIT"
    public final void mHEX_DIGIT() throws RecognitionException {
        try {
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:139:11: ( ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' ) )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
            {
            if ( (input.LA(1) >= '0' && input.LA(1) <= '9')||(input.LA(1) >= 'A' && input.LA(1) <= 'F')||(input.LA(1) >= 'a' && input.LA(1) <= 'f') ) {
                input.consume();
            }
            else {
                MismatchedSetException mse = new MismatchedSetException(null,input);
                recover(mse);
                throw mse;
            }


            }


        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "HEX_DIGIT"

    // $ANTLR start "ESC_SEQ"
    public final void mESC_SEQ() throws RecognitionException {
        try {
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:143:5: ( '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' ) | UNICODE_ESC | OCTAL_ESC )
            int alt17=3;
            int LA17_0 = input.LA(1);

            if ( (LA17_0=='\\') ) {
                switch ( input.LA(2) ) {
                case '\"':
                case '\'':
                case '\\':
                case 'b':
                case 'f':
                case 'n':
                case 'r':
                case 't':
                    {
                    alt17=1;
                    }
                    break;
                case 'u':
                    {
                    alt17=2;
                    }
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                    {
                    alt17=3;
                    }
                    break;
                default:
                    NoViableAltException nvae =
                        new NoViableAltException("", 17, 1, input);

                    throw nvae;

                }

            }
            else {
                NoViableAltException nvae =
                    new NoViableAltException("", 17, 0, input);

                throw nvae;

            }
            switch (alt17) {
                case 1 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:143:9: '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' )
                    {
                    match('\\'); 

                    if ( input.LA(1)=='\"'||input.LA(1)=='\''||input.LA(1)=='\\'||input.LA(1)=='b'||input.LA(1)=='f'||input.LA(1)=='n'||input.LA(1)=='r'||input.LA(1)=='t' ) {
                        input.consume();
                    }
                    else {
                        MismatchedSetException mse = new MismatchedSetException(null,input);
                        recover(mse);
                        throw mse;
                    }


                    }
                    break;
                case 2 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:144:9: UNICODE_ESC
                    {
                    mUNICODE_ESC(); 


                    }
                    break;
                case 3 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:145:9: OCTAL_ESC
                    {
                    mOCTAL_ESC(); 


                    }
                    break;

            }

        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "ESC_SEQ"

    // $ANTLR start "OCTAL_ESC"
    public final void mOCTAL_ESC() throws RecognitionException {
        try {
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:150:5: ( '\\\\' ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' ) | '\\\\' ( '0' .. '7' ) ( '0' .. '7' ) | '\\\\' ( '0' .. '7' ) )
            int alt18=3;
            int LA18_0 = input.LA(1);

            if ( (LA18_0=='\\') ) {
                int LA18_1 = input.LA(2);

                if ( ((LA18_1 >= '0' && LA18_1 <= '3')) ) {
                    int LA18_2 = input.LA(3);

                    if ( ((LA18_2 >= '0' && LA18_2 <= '7')) ) {
                        int LA18_4 = input.LA(4);

                        if ( ((LA18_4 >= '0' && LA18_4 <= '7')) ) {
                            alt18=1;
                        }
                        else {
                            alt18=2;
                        }
                    }
                    else {
                        alt18=3;
                    }
                }
                else if ( ((LA18_1 >= '4' && LA18_1 <= '7')) ) {
                    int LA18_3 = input.LA(3);

                    if ( ((LA18_3 >= '0' && LA18_3 <= '7')) ) {
                        alt18=2;
                    }
                    else {
                        alt18=3;
                    }
                }
                else {
                    NoViableAltException nvae =
                        new NoViableAltException("", 18, 1, input);

                    throw nvae;

                }
            }
            else {
                NoViableAltException nvae =
                    new NoViableAltException("", 18, 0, input);

                throw nvae;

            }
            switch (alt18) {
                case 1 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:150:9: '\\\\' ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' )
                    {
                    match('\\'); 

                    if ( (input.LA(1) >= '0' && input.LA(1) <= '3') ) {
                        input.consume();
                    }
                    else {
                        MismatchedSetException mse = new MismatchedSetException(null,input);
                        recover(mse);
                        throw mse;
                    }


                    if ( (input.LA(1) >= '0' && input.LA(1) <= '7') ) {
                        input.consume();
                    }
                    else {
                        MismatchedSetException mse = new MismatchedSetException(null,input);
                        recover(mse);
                        throw mse;
                    }


                    if ( (input.LA(1) >= '0' && input.LA(1) <= '7') ) {
                        input.consume();
                    }
                    else {
                        MismatchedSetException mse = new MismatchedSetException(null,input);
                        recover(mse);
                        throw mse;
                    }


                    }
                    break;
                case 2 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:151:9: '\\\\' ( '0' .. '7' ) ( '0' .. '7' )
                    {
                    match('\\'); 

                    if ( (input.LA(1) >= '0' && input.LA(1) <= '7') ) {
                        input.consume();
                    }
                    else {
                        MismatchedSetException mse = new MismatchedSetException(null,input);
                        recover(mse);
                        throw mse;
                    }


                    if ( (input.LA(1) >= '0' && input.LA(1) <= '7') ) {
                        input.consume();
                    }
                    else {
                        MismatchedSetException mse = new MismatchedSetException(null,input);
                        recover(mse);
                        throw mse;
                    }


                    }
                    break;
                case 3 :
                    // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:152:9: '\\\\' ( '0' .. '7' )
                    {
                    match('\\'); 

                    if ( (input.LA(1) >= '0' && input.LA(1) <= '7') ) {
                        input.consume();
                    }
                    else {
                        MismatchedSetException mse = new MismatchedSetException(null,input);
                        recover(mse);
                        throw mse;
                    }


                    }
                    break;

            }

        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "OCTAL_ESC"

    // $ANTLR start "UNICODE_ESC"
    public final void mUNICODE_ESC() throws RecognitionException {
        try {
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:157:5: ( '\\\\' 'u' HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT )
            // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:157:9: '\\\\' 'u' HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT
            {
            match('\\'); 

            match('u'); 

            mHEX_DIGIT(); 


            mHEX_DIGIT(); 


            mHEX_DIGIT(); 


            mHEX_DIGIT(); 


            }


        }
        finally {
        	// do for sure before leaving
        }
    }
    // $ANTLR end "UNICODE_ESC"

    public void mTokens() throws RecognitionException {
        // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:8: ( CLASS | OP_CORCH | CL_CORCH | END | DOUBLEP | ASSING | OP_PARENT | CL_PARENT | COMA | NUMBER | BOOLEAN | IF | THEN | ELSE | FI | WHILE | LOOP | POOL | LET | IN | CASE | OF | ESAC | NEW | ISVOID | ARROBA | PNT | NOT | LEQ | GEQ | L | G | EQ | PLUS | MINUS | MULT | DIV | NANARITA | IMPLICS | ID | TYPE | NL | COMMENT | WS | STRING | CHAR )
        int alt19=46;
        alt19 = dfa19.predict(input);
        switch (alt19) {
            case 1 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:10: CLASS
                {
                mCLASS(); 


                }
                break;
            case 2 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:16: OP_CORCH
                {
                mOP_CORCH(); 


                }
                break;
            case 3 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:25: CL_CORCH
                {
                mCL_CORCH(); 


                }
                break;
            case 4 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:34: END
                {
                mEND(); 


                }
                break;
            case 5 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:38: DOUBLEP
                {
                mDOUBLEP(); 


                }
                break;
            case 6 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:46: ASSING
                {
                mASSING(); 


                }
                break;
            case 7 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:53: OP_PARENT
                {
                mOP_PARENT(); 


                }
                break;
            case 8 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:63: CL_PARENT
                {
                mCL_PARENT(); 


                }
                break;
            case 9 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:73: COMA
                {
                mCOMA(); 


                }
                break;
            case 10 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:78: NUMBER
                {
                mNUMBER(); 


                }
                break;
            case 11 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:85: BOOLEAN
                {
                mBOOLEAN(); 


                }
                break;
            case 12 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:93: IF
                {
                mIF(); 


                }
                break;
            case 13 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:96: THEN
                {
                mTHEN(); 


                }
                break;
            case 14 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:101: ELSE
                {
                mELSE(); 


                }
                break;
            case 15 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:106: FI
                {
                mFI(); 


                }
                break;
            case 16 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:109: WHILE
                {
                mWHILE(); 


                }
                break;
            case 17 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:115: LOOP
                {
                mLOOP(); 


                }
                break;
            case 18 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:120: POOL
                {
                mPOOL(); 


                }
                break;
            case 19 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:125: LET
                {
                mLET(); 


                }
                break;
            case 20 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:129: IN
                {
                mIN(); 


                }
                break;
            case 21 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:132: CASE
                {
                mCASE(); 


                }
                break;
            case 22 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:137: OF
                {
                mOF(); 


                }
                break;
            case 23 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:140: ESAC
                {
                mESAC(); 


                }
                break;
            case 24 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:145: NEW
                {
                mNEW(); 


                }
                break;
            case 25 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:149: ISVOID
                {
                mISVOID(); 


                }
                break;
            case 26 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:156: ARROBA
                {
                mARROBA(); 


                }
                break;
            case 27 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:163: PNT
                {
                mPNT(); 


                }
                break;
            case 28 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:167: NOT
                {
                mNOT(); 


                }
                break;
            case 29 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:171: LEQ
                {
                mLEQ(); 


                }
                break;
            case 30 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:175: GEQ
                {
                mGEQ(); 


                }
                break;
            case 31 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:179: L
                {
                mL(); 


                }
                break;
            case 32 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:181: G
                {
                mG(); 


                }
                break;
            case 33 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:183: EQ
                {
                mEQ(); 


                }
                break;
            case 34 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:186: PLUS
                {
                mPLUS(); 


                }
                break;
            case 35 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:191: MINUS
                {
                mMINUS(); 


                }
                break;
            case 36 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:197: MULT
                {
                mMULT(); 


                }
                break;
            case 37 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:202: DIV
                {
                mDIV(); 


                }
                break;
            case 38 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:206: NANARITA
                {
                mNANARITA(); 


                }
                break;
            case 39 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:215: IMPLICS
                {
                mIMPLICS(); 


                }
                break;
            case 40 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:223: ID
                {
                mID(); 


                }
                break;
            case 41 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:226: TYPE
                {
                mTYPE(); 


                }
                break;
            case 42 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:231: NL
                {
                mNL(); 


                }
                break;
            case 43 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:234: COMMENT
                {
                mCOMMENT(); 


                }
                break;
            case 44 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:242: WS
                {
                mWS(); 


                }
                break;
            case 45 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:245: STRING
                {
                mSTRING(); 


                }
                break;
            case 46 :
                // C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:1:252: CHAR
                {
                mCHAR(); 


                }
                break;

        }

    }


    protected DFA4 dfa4 = new DFA4(this);
    protected DFA19 dfa19 = new DFA19(this);
    static final String DFA4_eotS =
        "\1\uffff\1\3\2\uffff";
    static final String DFA4_eofS =
        "\4\uffff";
    static final String DFA4_minS =
        "\1\60\1\56\2\uffff";
    static final String DFA4_maxS =
        "\2\71\2\uffff";
    static final String DFA4_acceptS =
        "\2\uffff\1\1\1\2";
    static final String DFA4_specialS =
        "\4\uffff}>";
    static final String[] DFA4_transitionS = {
            "\12\1",
            "\1\2\1\uffff\12\1",
            "",
            ""
    };

    static final short[] DFA4_eot = DFA.unpackEncodedString(DFA4_eotS);
    static final short[] DFA4_eof = DFA.unpackEncodedString(DFA4_eofS);
    static final char[] DFA4_min = DFA.unpackEncodedStringToUnsignedChars(DFA4_minS);
    static final char[] DFA4_max = DFA.unpackEncodedStringToUnsignedChars(DFA4_maxS);
    static final short[] DFA4_accept = DFA.unpackEncodedString(DFA4_acceptS);
    static final short[] DFA4_special = DFA.unpackEncodedString(DFA4_specialS);
    static final short[][] DFA4_transition;

    static {
        int numStates = DFA4_transitionS.length;
        DFA4_transition = new short[numStates][];
        for (int i=0; i<numStates; i++) {
            DFA4_transition[i] = DFA.unpackEncodedString(DFA4_transitionS[i]);
        }
    }

    class DFA4 extends DFA {

        public DFA4(BaseRecognizer recognizer) {
            this.recognizer = recognizer;
            this.decisionNumber = 4;
            this.eot = DFA4_eot;
            this.eof = DFA4_eof;
            this.min = DFA4_min;
            this.max = DFA4_max;
            this.accept = DFA4_accept;
            this.special = DFA4_special;
            this.transition = DFA4_transition;
        }
        public String getDescription() {
            return "68:1: NUMBER : ( ( DIGIT )+ '.' ( DIGIT )+ | ( DIGIT )+ );";
        }
    }
    static final String DFA19_eotS =
        "\1\uffff\1\37\4\uffff\1\50\4\uffff\11\37\2\uffff\1\72\1\74\3\uffff"+
        "\1\76\1\uffff\1\37\6\uffff\2\37\3\uffff\3\37\1\105\1\106\1\107\7"+
        "\37\1\117\2\37\6\uffff\6\37\3\uffff\5\37\1\134\1\37\1\uffff\1\136"+
        "\1\137\1\37\1\141\1\142\1\143\2\37\1\146\1\147\1\37\1\151\1\uffff"+
        "\1\152\2\uffff\1\153\3\uffff\1\142\1\37\2\uffff\1\155\3\uffff\1"+
        "\156\2\uffff";
    static final String DFA19_eofS =
        "\157\uffff";
    static final String DFA19_minS =
        "\1\11\1\141\4\uffff\1\55\4\uffff\1\150\1\141\1\146\1\154\1\150\1"+
        "\145\1\157\1\146\1\145\2\uffff\1\75\1\76\3\uffff\1\52\1\uffff\1"+
        "\12\6\uffff\1\141\1\163\3\uffff\1\165\1\145\1\154\3\60\1\166\1\163"+
        "\1\141\1\151\1\157\1\164\1\157\1\60\1\167\1\164\6\uffff\1\12\1\163"+
        "\2\145\1\156\1\163\3\uffff\1\157\1\145\1\143\1\154\1\160\1\60\1"+
        "\154\1\uffff\2\60\1\163\3\60\1\145\1\151\2\60\1\145\1\60\1\uffff"+
        "\1\60\2\uffff\1\60\3\uffff\1\60\1\144\2\uffff\1\60\3\uffff\1\60"+
        "\2\uffff";
    static final String DFA19_maxS =
        "\1\176\1\154\4\uffff\1\75\4\uffff\1\162\1\151\2\163\1\150\2\157"+
        "\1\146\1\157\2\uffff\1\75\1\76\3\uffff\1\57\1\uffff\1\166\6\uffff"+
        "\1\141\1\163\3\uffff\1\165\1\145\1\154\3\172\1\166\1\163\1\141\1"+
        "\151\1\157\1\164\1\157\1\172\1\167\1\164\6\uffff\1\166\1\163\2\145"+
        "\1\156\1\163\3\uffff\1\157\1\145\1\143\1\154\1\160\1\172\1\154\1"+
        "\uffff\2\172\1\163\3\172\1\145\1\151\2\172\1\145\1\172\1\uffff\1"+
        "\172\2\uffff\1\172\3\uffff\1\172\1\144\2\uffff\1\172\3\uffff\1\172"+
        "\2\uffff";
    static final String DFA19_acceptS =
        "\2\uffff\1\2\1\3\1\4\1\5\1\uffff\1\7\1\10\1\11\1\12\11\uffff\1\32"+
        "\1\33\2\uffff\1\42\1\43\1\44\1\uffff\1\46\1\uffff\1\51\1\50\1\52"+
        "\1\54\1\55\1\56\2\uffff\1\6\1\35\1\37\20\uffff\1\36\1\40\1\47\1"+
        "\41\1\53\1\45\6\uffff\1\17\1\14\1\24\7\uffff\1\26\14\uffff\1\23"+
        "\1\uffff\1\30\1\34\1\uffff\1\25\1\13\1\15\2\uffff\1\16\1\27\1\uffff"+
        "\1\21\1\22\1\1\1\uffff\1\20\1\31";
    static final String DFA19_specialS =
        "\157\uffff}>";
    static final String[] DFA19_transitionS = {
            "\1\41\1\40\2\uffff\1\41\22\uffff\1\41\1\uffff\1\42\4\uffff\1"+
            "\43\1\7\1\10\1\32\1\30\1\11\1\31\1\25\1\33\12\12\1\5\1\4\1\6"+
            "\1\27\1\26\1\uffff\1\24\32\36\4\uffff\1\37\1\uffff\2\37\1\1"+
            "\1\37\1\16\1\14\2\37\1\15\2\37\1\20\1\37\1\23\1\22\1\21\3\37"+
            "\1\13\1\37\1\35\1\17\3\37\1\2\1\uffff\1\3\1\34",
            "\1\45\12\uffff\1\44",
            "",
            "",
            "",
            "",
            "\1\46\17\uffff\1\47",
            "",
            "",
            "",
            "",
            "\1\52\11\uffff\1\51",
            "\1\53\7\uffff\1\54",
            "\1\55\7\uffff\1\56\4\uffff\1\57",
            "\1\60\6\uffff\1\61",
            "\1\62",
            "\1\64\11\uffff\1\63",
            "\1\65",
            "\1\66",
            "\1\67\11\uffff\1\70",
            "",
            "",
            "\1\71",
            "\1\73",
            "",
            "",
            "",
            "\1\75\4\uffff\1\75",
            "",
            "\1\40\153\uffff\1\77",
            "",
            "",
            "",
            "",
            "",
            "",
            "\1\100",
            "\1\101",
            "",
            "",
            "",
            "\1\102",
            "\1\103",
            "\1\104",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "\1\110",
            "\1\111",
            "\1\112",
            "\1\113",
            "\1\114",
            "\1\115",
            "\1\116",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "\1\120",
            "\1\121",
            "",
            "",
            "",
            "",
            "",
            "",
            "\1\40\153\uffff\1\77",
            "\1\122",
            "\1\123",
            "\1\124",
            "\1\125",
            "\1\126",
            "",
            "",
            "",
            "\1\127",
            "\1\130",
            "\1\131",
            "\1\132",
            "\1\133",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "\1\135",
            "",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "\1\140",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "\1\144",
            "\1\145",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "\1\150",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "",
            "",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "",
            "",
            "",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "\1\154",
            "",
            "",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "",
            "",
            "",
            "\12\37\7\uffff\32\37\4\uffff\1\37\1\uffff\32\37",
            "",
            ""
    };

    static final short[] DFA19_eot = DFA.unpackEncodedString(DFA19_eotS);
    static final short[] DFA19_eof = DFA.unpackEncodedString(DFA19_eofS);
    static final char[] DFA19_min = DFA.unpackEncodedStringToUnsignedChars(DFA19_minS);
    static final char[] DFA19_max = DFA.unpackEncodedStringToUnsignedChars(DFA19_maxS);
    static final short[] DFA19_accept = DFA.unpackEncodedString(DFA19_acceptS);
    static final short[] DFA19_special = DFA.unpackEncodedString(DFA19_specialS);
    static final short[][] DFA19_transition;

    static {
        int numStates = DFA19_transitionS.length;
        DFA19_transition = new short[numStates][];
        for (int i=0; i<numStates; i++) {
            DFA19_transition[i] = DFA.unpackEncodedString(DFA19_transitionS[i]);
        }
    }

    class DFA19 extends DFA {

        public DFA19(BaseRecognizer recognizer) {
            this.recognizer = recognizer;
            this.decisionNumber = 19;
            this.eot = DFA19_eot;
            this.eof = DFA19_eof;
            this.min = DFA19_min;
            this.max = DFA19_max;
            this.accept = DFA19_accept;
            this.special = DFA19_special;
            this.transition = DFA19_transition;
        }
        public String getDescription() {
            return "1:1: Tokens : ( CLASS | OP_CORCH | CL_CORCH | END | DOUBLEP | ASSING | OP_PARENT | CL_PARENT | COMA | NUMBER | BOOLEAN | IF | THEN | ELSE | FI | WHILE | LOOP | POOL | LET | IN | CASE | OF | ESAC | NEW | ISVOID | ARROBA | PNT | NOT | LEQ | GEQ | L | G | EQ | PLUS | MINUS | MULT | DIV | NANARITA | IMPLICS | ID | TYPE | NL | COMMENT | WS | STRING | CHAR );";
        }
    }
 

}