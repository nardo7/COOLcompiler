// $ANTLR 3.5.1 C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g 2017-10-18 21:17:20

import org.antlr.runtime.*;
import java.util.Stack;
import java.util.List;
import java.util.ArrayList;

import org.antlr.runtime.debug.*;
import java.io.IOException;
import org.antlr.runtime.tree.*;


@SuppressWarnings("all")
public class COOLParser extends DebugParser {
	public static final String[] tokenNames = new String[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "ARROBA", "ASSING", "BOOLEAN", 
		"CASE", "CHAR", "CLASS", "CL_CORCH", "CL_PARENT", "COMA", "COMMENT", "DIGIT", 
		"DIV", "DOUBLEP", "ELSE", "END", "EQ", "ESAC", "ESC_SEQ", "EXPONENT", 
		"FI", "G", "GEQ", "HEX_DIGIT", "ID", "IF", "IMPLICS", "IN", "INHERITS", 
		"ISVOID", "L", "LEQ", "LET", "LOOP", "LOWERCASE", "MINUS", "MULT", "NANARITA", 
		"NEW", "NL", "NOT", "NUMBER", "OCTAL_ESC", "OF", "OP_CORCH", "OP_PARENT", 
		"PLUS", "PNT", "POOL", "STRING", "THEN", "TYPE", "UNICODE_ESC", "UPERCASE", 
		"WHILE", "WS"
	};
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
	public static final int INHERITS=31;
	public static final int ISVOID=32;
	public static final int L=33;
	public static final int LEQ=34;
	public static final int LET=35;
	public static final int LOOP=36;
	public static final int LOWERCASE=37;
	public static final int MINUS=38;
	public static final int MULT=39;
	public static final int NANARITA=40;
	public static final int NEW=41;
	public static final int NL=42;
	public static final int NOT=43;
	public static final int NUMBER=44;
	public static final int OCTAL_ESC=45;
	public static final int OF=46;
	public static final int OP_CORCH=47;
	public static final int OP_PARENT=48;
	public static final int PLUS=49;
	public static final int PNT=50;
	public static final int POOL=51;
	public static final int STRING=52;
	public static final int THEN=53;
	public static final int TYPE=54;
	public static final int UNICODE_ESC=55;
	public static final int UPERCASE=56;
	public static final int WHILE=57;
	public static final int WS=58;

	// delegates
	public Parser[] getDelegates() {
		return new Parser[] {};
	}

	// delegators


	public static final String[] ruleNames = new String[] {
		"invalidRule", "case", "new", "lv3", "wsnl", "compileUnit", "conditionals", 
		"lv4", "lv6", "params_list", "nanarita", "param", "class", "assignment", 
		"dispatch", "expr", "feature_list", "program", "attribute", "lv2", "constant", 
		"lv1", "operations", "loops", "feature", "let", "methodefinition", "lv5", 
		"blocks"
	};

	public static final boolean[] decisionCanBacktrack = new boolean[] {
		false, // invalid decision
		false, false, false, false, false, false, false, false, false, false, 
		    false, false, false, false, false, false, false, false, false, false, 
		    false, false, false, false, false
	};

 
	public int ruleLevel = 0;
	public int getRuleLevel() { return ruleLevel; }
	public void incRuleLevel() { ruleLevel++; }
	public void decRuleLevel() { ruleLevel--; }
	public COOLParser(TokenStream input) {
		this(input, DebugEventSocketProxy.DEFAULT_DEBUGGER_PORT, new RecognizerSharedState());
	}
	public COOLParser(TokenStream input, int port, RecognizerSharedState state) {
		super(input, state);
		DebugEventSocketProxy proxy =
			new DebugEventSocketProxy(this,port,adaptor);
		setDebugListener(proxy);
		setTokenStream(new DebugTokenStream(input,proxy));
		try {
			proxy.handshake();
		}
		catch (IOException ioe) {
			reportError(ioe);
		}
		TreeAdaptor adap = new CommonTreeAdaptor();
		setTreeAdaptor(adap);
		proxy.setTreeAdaptor(adap);
	}

	public COOLParser(TokenStream input, DebugEventListener dbg) {
		super(input, dbg);
		 
		TreeAdaptor adap = new CommonTreeAdaptor();
		setTreeAdaptor(adap);

	}

	protected boolean evalPredicate(boolean result, String predicate) {
		dbg.semanticPredicate(result, predicate);
		return result;
	}

		protected DebugTreeAdaptor adaptor;
		public void setTreeAdaptor(TreeAdaptor adaptor) {
			this.adaptor = new DebugTreeAdaptor(dbg,adaptor);
		}
		public TreeAdaptor getTreeAdaptor() {
			return adaptor;
		}
	@Override public String[] getTokenNames() { return COOLParser.tokenNames; }
	@Override public String getGrammarFileName() { return "C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g"; }


	public static class program_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "program"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:8:9: public program : ( class )+ EOF ;
	public final COOLParser.program_return program() throws RecognitionException {
		COOLParser.program_return retval = new COOLParser.program_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token EOF2=null;
		ParserRuleReturnScope class1 =null;

		Object EOF2_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "program");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(8, 8);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:8:16: ( ( class )+ EOF )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:8:18: ( class )+ EOF
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(8,18);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:8:18: ( class )+
			int cnt1=0;
			try { dbg.enterSubRule(1);

			loop1:
			while (true) {
				int alt1=2;
				try { dbg.enterDecision(1, decisionCanBacktrack[1]);

				int LA1_0 = input.LA(1);
				if ( (LA1_0==CLASS) ) {
					alt1=1;
				}

				} finally {dbg.exitDecision(1);}

				switch (alt1) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:8:19: class
					{
					dbg.location(8,19);
					pushFollow(FOLLOW_class_in_program29);
					class1=class();
					state._fsp--;

					adaptor.addChild(root_0, class1.getTree());

					}
					break;

				default :
					if ( cnt1 >= 1 ) break loop1;
					EarlyExitException eee = new EarlyExitException(1, input);
					dbg.recognitionException(eee);

					throw eee;
				}
				cnt1++;
			}
			} finally {dbg.exitSubRule(1);}
			dbg.location(8,27);
			EOF2=(Token)match(input,EOF,FOLLOW_EOF_in_program33); 
			EOF2_tree = (Object)adaptor.create(EOF2);
			adaptor.addChild(root_0, EOF2_tree);

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(8, 30);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "program");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "program"


	public static class class_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "class"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:10:2: class : CLASS TYPE ( INHERITS TYPE )? OP_CORCH ( feature_list )? CL_CORCH END ;
	public final COOLParser.class_return class() throws RecognitionException {
		COOLParser.class_return retval = new COOLParser.class_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token CLASS3=null;
		Token TYPE4=null;
		Token INHERITS5=null;
		Token TYPE6=null;
		Token OP_CORCH7=null;
		Token CL_CORCH9=null;
		Token END10=null;
		ParserRuleReturnScope feature_list8 =null;

		Object CLASS3_tree=null;
		Object TYPE4_tree=null;
		Object INHERITS5_tree=null;
		Object TYPE6_tree=null;
		Object OP_CORCH7_tree=null;
		Object CL_CORCH9_tree=null;
		Object END10_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "class");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(10, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:10:7: ( CLASS TYPE ( INHERITS TYPE )? OP_CORCH ( feature_list )? CL_CORCH END )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:10:9: CLASS TYPE ( INHERITS TYPE )? OP_CORCH ( feature_list )? CL_CORCH END
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(10,9);
			CLASS3=(Token)match(input,CLASS,FOLLOW_CLASS_in_class42); 
			CLASS3_tree = (Object)adaptor.create(CLASS3);
			adaptor.addChild(root_0, CLASS3_tree);
			dbg.location(10,15);
			TYPE4=(Token)match(input,TYPE,FOLLOW_TYPE_in_class44); 
			TYPE4_tree = (Object)adaptor.create(TYPE4);
			adaptor.addChild(root_0, TYPE4_tree);
			dbg.location(10,20);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:10:20: ( INHERITS TYPE )?
			int alt2=2;
			try { dbg.enterSubRule(2);
			try { dbg.enterDecision(2, decisionCanBacktrack[2]);

			int LA2_0 = input.LA(1);
			if ( (LA2_0==INHERITS) ) {
				alt2=1;
			}
			} finally {dbg.exitDecision(2);}

			switch (alt2) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:10:21: INHERITS TYPE
					{
					dbg.location(10,21);
					INHERITS5=(Token)match(input,INHERITS,FOLLOW_INHERITS_in_class47); 
					INHERITS5_tree = (Object)adaptor.create(INHERITS5);
					adaptor.addChild(root_0, INHERITS5_tree);
					dbg.location(10,30);
					TYPE6=(Token)match(input,TYPE,FOLLOW_TYPE_in_class49); 
					TYPE6_tree = (Object)adaptor.create(TYPE6);
					adaptor.addChild(root_0, TYPE6_tree);

					}
					break;

			}
			} finally {dbg.exitSubRule(2);}
			dbg.location(10,37);
			OP_CORCH7=(Token)match(input,OP_CORCH,FOLLOW_OP_CORCH_in_class53); 
			OP_CORCH7_tree = (Object)adaptor.create(OP_CORCH7);
			adaptor.addChild(root_0, OP_CORCH7_tree);
			dbg.location(10,46);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:10:46: ( feature_list )?
			int alt3=2;
			try { dbg.enterSubRule(3);
			try { dbg.enterDecision(3, decisionCanBacktrack[3]);

			int LA3_0 = input.LA(1);
			if ( (LA3_0==ID) ) {
				alt3=1;
			}
			} finally {dbg.exitDecision(3);}

			switch (alt3) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:10:48: feature_list
					{
					dbg.location(10,48);
					pushFollow(FOLLOW_feature_list_in_class57);
					feature_list8=feature_list();
					state._fsp--;

					adaptor.addChild(root_0, feature_list8.getTree());

					}
					break;

			}
			} finally {dbg.exitSubRule(3);}
			dbg.location(10,63);
			CL_CORCH9=(Token)match(input,CL_CORCH,FOLLOW_CL_CORCH_in_class61); 
			CL_CORCH9_tree = (Object)adaptor.create(CL_CORCH9);
			adaptor.addChild(root_0, CL_CORCH9_tree);
			dbg.location(10,72);
			END10=(Token)match(input,END,FOLLOW_END_in_class63); 
			END10_tree = (Object)adaptor.create(END10);
			adaptor.addChild(root_0, END10_tree);

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(11, 2);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "class");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "class"


	public static class feature_list_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "feature_list"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:12:2: feature_list : feature ( feature )* ;
	public final COOLParser.feature_list_return feature_list() throws RecognitionException {
		COOLParser.feature_list_return retval = new COOLParser.feature_list_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		ParserRuleReturnScope feature11 =null;
		ParserRuleReturnScope feature12 =null;


		try { dbg.enterRule(getGrammarFileName(), "feature_list");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(12, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:12:14: ( feature ( feature )* )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:12:16: feature ( feature )*
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(12,16);
			pushFollow(FOLLOW_feature_in_feature_list73);
			feature11=feature();
			state._fsp--;

			adaptor.addChild(root_0, feature11.getTree());
			dbg.location(12,24);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:12:24: ( feature )*
			try { dbg.enterSubRule(4);

			loop4:
			while (true) {
				int alt4=2;
				try { dbg.enterDecision(4, decisionCanBacktrack[4]);

				int LA4_0 = input.LA(1);
				if ( (LA4_0==ID) ) {
					alt4=1;
				}

				} finally {dbg.exitDecision(4);}

				switch (alt4) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:12:26: feature
					{
					dbg.location(12,26);
					pushFollow(FOLLOW_feature_in_feature_list77);
					feature12=feature();
					state._fsp--;

					adaptor.addChild(root_0, feature12.getTree());

					}
					break;

				default :
					break loop4;
				}
			}
			} finally {dbg.exitSubRule(4);}

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(12, 35);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "feature_list");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "feature_list"


	public static class feature_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "feature"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:13:2: feature : ID ( attribute | methodefinition ) END ;
	public final COOLParser.feature_return feature() throws RecognitionException {
		COOLParser.feature_return retval = new COOLParser.feature_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token ID13=null;
		Token END16=null;
		ParserRuleReturnScope attribute14 =null;
		ParserRuleReturnScope methodefinition15 =null;

		Object ID13_tree=null;
		Object END16_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "feature");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(13, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:13:9: ( ID ( attribute | methodefinition ) END )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:13:11: ID ( attribute | methodefinition ) END
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(13,11);
			ID13=(Token)match(input,ID,FOLLOW_ID_in_feature87); 
			ID13_tree = (Object)adaptor.create(ID13);
			adaptor.addChild(root_0, ID13_tree);
			dbg.location(13,14);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:13:14: ( attribute | methodefinition )
			int alt5=2;
			try { dbg.enterSubRule(5);
			try { dbg.enterDecision(5, decisionCanBacktrack[5]);

			int LA5_0 = input.LA(1);
			if ( (LA5_0==DOUBLEP) ) {
				alt5=1;
			}
			else if ( (LA5_0==OP_PARENT) ) {
				alt5=2;
			}

			else {
				NoViableAltException nvae =
					new NoViableAltException("", 5, 0, input);
				dbg.recognitionException(nvae);
				throw nvae;
			}

			} finally {dbg.exitDecision(5);}

			switch (alt5) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:13:15: attribute
					{
					dbg.location(13,15);
					pushFollow(FOLLOW_attribute_in_feature90);
					attribute14=attribute();
					state._fsp--;

					adaptor.addChild(root_0, attribute14.getTree());

					}
					break;
				case 2 :
					dbg.enterAlt(2);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:13:25: methodefinition
					{
					dbg.location(13,25);
					pushFollow(FOLLOW_methodefinition_in_feature92);
					methodefinition15=methodefinition();
					state._fsp--;

					adaptor.addChild(root_0, methodefinition15.getTree());

					}
					break;

			}
			} finally {dbg.exitSubRule(5);}
			dbg.location(13,42);
			END16=(Token)match(input,END,FOLLOW_END_in_feature95); 
			END16_tree = (Object)adaptor.create(END16);
			adaptor.addChild(root_0, END16_tree);

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(13, 45);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "feature");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "feature"


	public static class attribute_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "attribute"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:15:1: attribute : DOUBLEP TYPE ( ASSING expr )? ;
	public final COOLParser.attribute_return attribute() throws RecognitionException {
		COOLParser.attribute_return retval = new COOLParser.attribute_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token DOUBLEP17=null;
		Token TYPE18=null;
		Token ASSING19=null;
		ParserRuleReturnScope expr20 =null;

		Object DOUBLEP17_tree=null;
		Object TYPE18_tree=null;
		Object ASSING19_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "attribute");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(15, 0);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:15:10: ( DOUBLEP TYPE ( ASSING expr )? )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:15:13: DOUBLEP TYPE ( ASSING expr )?
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(15,13);
			DOUBLEP17=(Token)match(input,DOUBLEP,FOLLOW_DOUBLEP_in_attribute105); 
			DOUBLEP17_tree = (Object)adaptor.create(DOUBLEP17);
			adaptor.addChild(root_0, DOUBLEP17_tree);
			dbg.location(15,21);
			TYPE18=(Token)match(input,TYPE,FOLLOW_TYPE_in_attribute107); 
			TYPE18_tree = (Object)adaptor.create(TYPE18);
			adaptor.addChild(root_0, TYPE18_tree);
			dbg.location(15,26);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:15:26: ( ASSING expr )?
			int alt6=2;
			try { dbg.enterSubRule(6);
			try { dbg.enterDecision(6, decisionCanBacktrack[6]);

			int LA6_0 = input.LA(1);
			if ( (LA6_0==ASSING) ) {
				alt6=1;
			}
			} finally {dbg.exitDecision(6);}

			switch (alt6) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:15:28: ASSING expr
					{
					dbg.location(15,28);
					ASSING19=(Token)match(input,ASSING,FOLLOW_ASSING_in_attribute111); 
					ASSING19_tree = (Object)adaptor.create(ASSING19);
					adaptor.addChild(root_0, ASSING19_tree);
					dbg.location(15,35);
					pushFollow(FOLLOW_expr_in_attribute113);
					expr20=expr();
					state._fsp--;

					adaptor.addChild(root_0, expr20.getTree());

					}
					break;

			}
			} finally {dbg.exitSubRule(6);}

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(15, 42);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "attribute");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "attribute"


	public static class methodefinition_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "methodefinition"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:17:2: methodefinition : OP_PARENT ( params_list )? CL_PARENT DOUBLEP TYPE OP_CORCH expr CL_CORCH ;
	public final COOLParser.methodefinition_return methodefinition() throws RecognitionException {
		COOLParser.methodefinition_return retval = new COOLParser.methodefinition_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token OP_PARENT21=null;
		Token CL_PARENT23=null;
		Token DOUBLEP24=null;
		Token TYPE25=null;
		Token OP_CORCH26=null;
		Token CL_CORCH28=null;
		ParserRuleReturnScope params_list22 =null;
		ParserRuleReturnScope expr27 =null;

		Object OP_PARENT21_tree=null;
		Object CL_PARENT23_tree=null;
		Object DOUBLEP24_tree=null;
		Object TYPE25_tree=null;
		Object OP_CORCH26_tree=null;
		Object CL_CORCH28_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "methodefinition");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(17, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:17:17: ( OP_PARENT ( params_list )? CL_PARENT DOUBLEP TYPE OP_CORCH expr CL_CORCH )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:17:19: OP_PARENT ( params_list )? CL_PARENT DOUBLEP TYPE OP_CORCH expr CL_CORCH
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(17,19);
			OP_PARENT21=(Token)match(input,OP_PARENT,FOLLOW_OP_PARENT_in_methodefinition125); 
			OP_PARENT21_tree = (Object)adaptor.create(OP_PARENT21);
			adaptor.addChild(root_0, OP_PARENT21_tree);
			dbg.location(17,29);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:17:29: ( params_list )?
			int alt7=2;
			try { dbg.enterSubRule(7);
			try { dbg.enterDecision(7, decisionCanBacktrack[7]);

			int LA7_0 = input.LA(1);
			if ( (LA7_0==ID) ) {
				alt7=1;
			}
			} finally {dbg.exitDecision(7);}

			switch (alt7) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:17:31: params_list
					{
					dbg.location(17,31);
					pushFollow(FOLLOW_params_list_in_methodefinition129);
					params_list22=params_list();
					state._fsp--;

					adaptor.addChild(root_0, params_list22.getTree());

					}
					break;

			}
			} finally {dbg.exitSubRule(7);}
			dbg.location(17,46);
			CL_PARENT23=(Token)match(input,CL_PARENT,FOLLOW_CL_PARENT_in_methodefinition134); 
			CL_PARENT23_tree = (Object)adaptor.create(CL_PARENT23);
			adaptor.addChild(root_0, CL_PARENT23_tree);
			dbg.location(17,57);
			DOUBLEP24=(Token)match(input,DOUBLEP,FOLLOW_DOUBLEP_in_methodefinition137); 
			DOUBLEP24_tree = (Object)adaptor.create(DOUBLEP24);
			adaptor.addChild(root_0, DOUBLEP24_tree);
			dbg.location(17,66);
			TYPE25=(Token)match(input,TYPE,FOLLOW_TYPE_in_methodefinition140); 
			TYPE25_tree = (Object)adaptor.create(TYPE25);
			adaptor.addChild(root_0, TYPE25_tree);
			dbg.location(17,72);
			OP_CORCH26=(Token)match(input,OP_CORCH,FOLLOW_OP_CORCH_in_methodefinition143); 
			OP_CORCH26_tree = (Object)adaptor.create(OP_CORCH26);
			adaptor.addChild(root_0, OP_CORCH26_tree);
			dbg.location(17,82);
			pushFollow(FOLLOW_expr_in_methodefinition146);
			expr27=expr();
			state._fsp--;

			adaptor.addChild(root_0, expr27.getTree());
			dbg.location(17,88);
			CL_CORCH28=(Token)match(input,CL_CORCH,FOLLOW_CL_CORCH_in_methodefinition149); 
			CL_CORCH28_tree = (Object)adaptor.create(CL_CORCH28);
			adaptor.addChild(root_0, CL_CORCH28_tree);

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(17, 96);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "methodefinition");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "methodefinition"


	public static class params_list_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "params_list"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:18:2: params_list : param ( COMA param )* ;
	public final COOLParser.params_list_return params_list() throws RecognitionException {
		COOLParser.params_list_return retval = new COOLParser.params_list_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token COMA30=null;
		ParserRuleReturnScope param29 =null;
		ParserRuleReturnScope param31 =null;

		Object COMA30_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "params_list");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(18, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:18:13: ( param ( COMA param )* )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:18:15: param ( COMA param )*
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(18,15);
			pushFollow(FOLLOW_param_in_params_list157);
			param29=param();
			state._fsp--;

			adaptor.addChild(root_0, param29.getTree());
			dbg.location(18,21);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:18:21: ( COMA param )*
			try { dbg.enterSubRule(8);

			loop8:
			while (true) {
				int alt8=2;
				try { dbg.enterDecision(8, decisionCanBacktrack[8]);

				int LA8_0 = input.LA(1);
				if ( (LA8_0==COMA) ) {
					alt8=1;
				}

				} finally {dbg.exitDecision(8);}

				switch (alt8) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:18:23: COMA param
					{
					dbg.location(18,23);
					COMA30=(Token)match(input,COMA,FOLLOW_COMA_in_params_list161); 
					COMA30_tree = (Object)adaptor.create(COMA30);
					adaptor.addChild(root_0, COMA30_tree);
					dbg.location(18,29);
					pushFollow(FOLLOW_param_in_params_list164);
					param31=param();
					state._fsp--;

					adaptor.addChild(root_0, param31.getTree());

					}
					break;

				default :
					break loop8;
				}
			}
			} finally {dbg.exitSubRule(8);}

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(18, 35);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "params_list");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "params_list"


	public static class param_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "param"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:19:2: param : ID DOUBLEP TYPE ;
	public final COOLParser.param_return param() throws RecognitionException {
		COOLParser.param_return retval = new COOLParser.param_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token ID32=null;
		Token DOUBLEP33=null;
		Token TYPE34=null;

		Object ID32_tree=null;
		Object DOUBLEP33_tree=null;
		Object TYPE34_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "param");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(19, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:19:7: ( ID DOUBLEP TYPE )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:19:9: ID DOUBLEP TYPE
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(19,9);
			ID32=(Token)match(input,ID,FOLLOW_ID_in_param173); 
			ID32_tree = (Object)adaptor.create(ID32);
			adaptor.addChild(root_0, ID32_tree);
			dbg.location(19,13);
			DOUBLEP33=(Token)match(input,DOUBLEP,FOLLOW_DOUBLEP_in_param176); 
			DOUBLEP33_tree = (Object)adaptor.create(DOUBLEP33);
			adaptor.addChild(root_0, DOUBLEP33_tree);
			dbg.location(19,22);
			TYPE34=(Token)match(input,TYPE,FOLLOW_TYPE_in_param179); 
			TYPE34_tree = (Object)adaptor.create(TYPE34);
			adaptor.addChild(root_0, TYPE34_tree);

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(19, 25);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "param");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "param"


	public static class expr_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "expr"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:21:2: expr : ( assignment | conditionals | loops | blocks | let | case | new | operations | TYPE );
	public final COOLParser.expr_return expr() throws RecognitionException {
		COOLParser.expr_return retval = new COOLParser.expr_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token TYPE43=null;
		ParserRuleReturnScope assignment35 =null;
		ParserRuleReturnScope conditionals36 =null;
		ParserRuleReturnScope loops37 =null;
		ParserRuleReturnScope blocks38 =null;
		ParserRuleReturnScope let39 =null;
		ParserRuleReturnScope case40 =null;
		ParserRuleReturnScope new41 =null;
		ParserRuleReturnScope operations42 =null;

		Object TYPE43_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "expr");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(21, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:21:6: ( assignment | conditionals | loops | blocks | let | case | new | operations | TYPE )
			int alt9=9;
			try { dbg.enterDecision(9, decisionCanBacktrack[9]);

			switch ( input.LA(1) ) {
			case ID:
				{
				int LA9_1 = input.LA(2);
				if ( (LA9_1==ASSING) ) {
					alt9=1;
				}
				else if ( (LA9_1==ARROBA||LA9_1==BOOLEAN||(LA9_1 >= CL_CORCH && LA9_1 <= COMA)||LA9_1==DIV||(LA9_1 >= END && LA9_1 <= ESAC)||(LA9_1 >= FI && LA9_1 <= GEQ)||LA9_1==ID||LA9_1==IN||(LA9_1 >= ISVOID && LA9_1 <= LEQ)||LA9_1==LOOP||(LA9_1 >= MINUS && LA9_1 <= NANARITA)||LA9_1==NUMBER||LA9_1==OF||(LA9_1 >= OP_PARENT && LA9_1 <= THEN)) ) {
					alt9=8;
				}

				else {
					int nvaeMark = input.mark();
					try {
						input.consume();
						NoViableAltException nvae =
							new NoViableAltException("", 9, 1, input);
						dbg.recognitionException(nvae);
						throw nvae;
					} finally {
						input.rewind(nvaeMark);
					}
				}

				}
				break;
			case IF:
				{
				alt9=2;
				}
				break;
			case WHILE:
				{
				alt9=3;
				}
				break;
			case OP_CORCH:
				{
				alt9=4;
				}
				break;
			case LET:
				{
				alt9=5;
				}
				break;
			case CASE:
				{
				alt9=6;
				}
				break;
			case NEW:
				{
				alt9=7;
				}
				break;
			case BOOLEAN:
			case ISVOID:
			case NANARITA:
			case NOT:
			case NUMBER:
			case OP_PARENT:
			case STRING:
				{
				alt9=8;
				}
				break;
			case TYPE:
				{
				alt9=9;
				}
				break;
			default:
				NoViableAltException nvae =
					new NoViableAltException("", 9, 0, input);
				dbg.recognitionException(nvae);
				throw nvae;
			}
			} finally {dbg.exitDecision(9);}

			switch (alt9) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:21:8: assignment
					{
					root_0 = (Object)adaptor.nil();


					dbg.location(21,8);
					pushFollow(FOLLOW_assignment_in_expr187);
					assignment35=assignment();
					state._fsp--;

					adaptor.addChild(root_0, assignment35.getTree());

					}
					break;
				case 2 :
					dbg.enterAlt(2);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:22:6: conditionals
					{
					root_0 = (Object)adaptor.nil();


					dbg.location(22,6);
					pushFollow(FOLLOW_conditionals_in_expr194);
					conditionals36=conditionals();
					state._fsp--;

					adaptor.addChild(root_0, conditionals36.getTree());

					}
					break;
				case 3 :
					dbg.enterAlt(3);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:23:6: loops
					{
					root_0 = (Object)adaptor.nil();


					dbg.location(23,6);
					pushFollow(FOLLOW_loops_in_expr201);
					loops37=loops();
					state._fsp--;

					adaptor.addChild(root_0, loops37.getTree());

					}
					break;
				case 4 :
					dbg.enterAlt(4);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:24:6: blocks
					{
					root_0 = (Object)adaptor.nil();


					dbg.location(24,6);
					pushFollow(FOLLOW_blocks_in_expr208);
					blocks38=blocks();
					state._fsp--;

					adaptor.addChild(root_0, blocks38.getTree());

					}
					break;
				case 5 :
					dbg.enterAlt(5);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:25:6: let
					{
					root_0 = (Object)adaptor.nil();


					dbg.location(25,6);
					pushFollow(FOLLOW_let_in_expr215);
					let39=let();
					state._fsp--;

					adaptor.addChild(root_0, let39.getTree());

					}
					break;
				case 6 :
					dbg.enterAlt(6);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:26:6: case
					{
					root_0 = (Object)adaptor.nil();


					dbg.location(26,6);
					pushFollow(FOLLOW_case_in_expr222);
					case40=case();
					state._fsp--;

					adaptor.addChild(root_0, case40.getTree());

					}
					break;
				case 7 :
					dbg.enterAlt(7);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:27:6: new
					{
					root_0 = (Object)adaptor.nil();


					dbg.location(27,6);
					pushFollow(FOLLOW_new_in_expr229);
					new41=new();
					state._fsp--;

					adaptor.addChild(root_0, new41.getTree());

					}
					break;
				case 8 :
					dbg.enterAlt(8);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:28:6: operations
					{
					root_0 = (Object)adaptor.nil();


					dbg.location(28,6);
					pushFollow(FOLLOW_operations_in_expr236);
					operations42=operations();
					state._fsp--;

					adaptor.addChild(root_0, operations42.getTree());

					}
					break;
				case 9 :
					dbg.enterAlt(9);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:29:6: TYPE
					{
					root_0 = (Object)adaptor.nil();


					dbg.location(29,6);
					TYPE43=(Token)match(input,TYPE,FOLLOW_TYPE_in_expr243); 
					TYPE43_tree = (Object)adaptor.create(TYPE43);
					adaptor.addChild(root_0, TYPE43_tree);

					}
					break;

			}
			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(29, 9);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "expr");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "expr"


	public static class assignment_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "assignment"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:33:2: assignment : ID ASSING expr ;
	public final COOLParser.assignment_return assignment() throws RecognitionException {
		COOLParser.assignment_return retval = new COOLParser.assignment_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token ID44=null;
		Token ASSING45=null;
		ParserRuleReturnScope expr46 =null;

		Object ID44_tree=null;
		Object ASSING45_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "assignment");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(33, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:33:12: ( ID ASSING expr )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:33:14: ID ASSING expr
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(33,14);
			ID44=(Token)match(input,ID,FOLLOW_ID_in_assignment255); 
			ID44_tree = (Object)adaptor.create(ID44);
			adaptor.addChild(root_0, ID44_tree);
			dbg.location(33,17);
			ASSING45=(Token)match(input,ASSING,FOLLOW_ASSING_in_assignment257); 
			ASSING45_tree = (Object)adaptor.create(ASSING45);
			adaptor.addChild(root_0, ASSING45_tree);
			dbg.location(33,25);
			pushFollow(FOLLOW_expr_in_assignment260);
			expr46=expr();
			state._fsp--;

			adaptor.addChild(root_0, expr46.getTree());

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(33, 29);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "assignment");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "assignment"


	public static class conditionals_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "conditionals"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:34:2: conditionals : IF expr THEN expr FI ;
	public final COOLParser.conditionals_return conditionals() throws RecognitionException {
		COOLParser.conditionals_return retval = new COOLParser.conditionals_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token IF47=null;
		Token THEN49=null;
		Token FI51=null;
		ParserRuleReturnScope expr48 =null;
		ParserRuleReturnScope expr50 =null;

		Object IF47_tree=null;
		Object THEN49_tree=null;
		Object FI51_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "conditionals");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(34, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:34:14: ( IF expr THEN expr FI )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:34:16: IF expr THEN expr FI
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(34,16);
			IF47=(Token)match(input,IF,FOLLOW_IF_in_conditionals268); 
			IF47_tree = (Object)adaptor.create(IF47);
			adaptor.addChild(root_0, IF47_tree);
			dbg.location(34,19);
			pushFollow(FOLLOW_expr_in_conditionals270);
			expr48=expr();
			state._fsp--;

			adaptor.addChild(root_0, expr48.getTree());
			dbg.location(34,24);
			THEN49=(Token)match(input,THEN,FOLLOW_THEN_in_conditionals272); 
			THEN49_tree = (Object)adaptor.create(THEN49);
			adaptor.addChild(root_0, THEN49_tree);
			dbg.location(34,29);
			pushFollow(FOLLOW_expr_in_conditionals274);
			expr50=expr();
			state._fsp--;

			adaptor.addChild(root_0, expr50.getTree());
			dbg.location(34,34);
			FI51=(Token)match(input,FI,FOLLOW_FI_in_conditionals276); 
			FI51_tree = (Object)adaptor.create(FI51);
			adaptor.addChild(root_0, FI51_tree);

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(34, 36);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "conditionals");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "conditionals"


	public static class loops_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "loops"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:35:2: loops : WHILE expr LOOP expr POOL ;
	public final COOLParser.loops_return loops() throws RecognitionException {
		COOLParser.loops_return retval = new COOLParser.loops_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token WHILE52=null;
		Token LOOP54=null;
		Token POOL56=null;
		ParserRuleReturnScope expr53 =null;
		ParserRuleReturnScope expr55 =null;

		Object WHILE52_tree=null;
		Object LOOP54_tree=null;
		Object POOL56_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "loops");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(35, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:35:7: ( WHILE expr LOOP expr POOL )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:35:9: WHILE expr LOOP expr POOL
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(35,9);
			WHILE52=(Token)match(input,WHILE,FOLLOW_WHILE_in_loops284); 
			WHILE52_tree = (Object)adaptor.create(WHILE52);
			adaptor.addChild(root_0, WHILE52_tree);
			dbg.location(35,16);
			pushFollow(FOLLOW_expr_in_loops287);
			expr53=expr();
			state._fsp--;

			adaptor.addChild(root_0, expr53.getTree());
			dbg.location(35,21);
			LOOP54=(Token)match(input,LOOP,FOLLOW_LOOP_in_loops289); 
			LOOP54_tree = (Object)adaptor.create(LOOP54);
			adaptor.addChild(root_0, LOOP54_tree);
			dbg.location(35,26);
			pushFollow(FOLLOW_expr_in_loops291);
			expr55=expr();
			state._fsp--;

			adaptor.addChild(root_0, expr55.getTree());
			dbg.location(35,31);
			POOL56=(Token)match(input,POOL,FOLLOW_POOL_in_loops293); 
			POOL56_tree = (Object)adaptor.create(POOL56);
			adaptor.addChild(root_0, POOL56_tree);

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(35, 35);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "loops");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "loops"


	public static class blocks_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "blocks"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:36:2: blocks : OP_CORCH ( expr END ( expr END )* )? CL_CORCH ;
	public final COOLParser.blocks_return blocks() throws RecognitionException {
		COOLParser.blocks_return retval = new COOLParser.blocks_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token OP_CORCH57=null;
		Token END59=null;
		Token END61=null;
		Token CL_CORCH62=null;
		ParserRuleReturnScope expr58 =null;
		ParserRuleReturnScope expr60 =null;

		Object OP_CORCH57_tree=null;
		Object END59_tree=null;
		Object END61_tree=null;
		Object CL_CORCH62_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "blocks");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(36, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:36:8: ( OP_CORCH ( expr END ( expr END )* )? CL_CORCH )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:36:10: OP_CORCH ( expr END ( expr END )* )? CL_CORCH
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(36,10);
			OP_CORCH57=(Token)match(input,OP_CORCH,FOLLOW_OP_CORCH_in_blocks301); 
			OP_CORCH57_tree = (Object)adaptor.create(OP_CORCH57);
			adaptor.addChild(root_0, OP_CORCH57_tree);
			dbg.location(36,19);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:36:19: ( expr END ( expr END )* )?
			int alt11=2;
			try { dbg.enterSubRule(11);
			try { dbg.enterDecision(11, decisionCanBacktrack[11]);

			int LA11_0 = input.LA(1);
			if ( ((LA11_0 >= BOOLEAN && LA11_0 <= CASE)||(LA11_0 >= ID && LA11_0 <= IF)||LA11_0==ISVOID||LA11_0==LET||(LA11_0 >= NANARITA && LA11_0 <= NEW)||(LA11_0 >= NOT && LA11_0 <= NUMBER)||(LA11_0 >= OP_CORCH && LA11_0 <= OP_PARENT)||LA11_0==STRING||LA11_0==TYPE||LA11_0==WHILE) ) {
				alt11=1;
			}
			} finally {dbg.exitDecision(11);}

			switch (alt11) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:36:21: expr END ( expr END )*
					{
					dbg.location(36,21);
					pushFollow(FOLLOW_expr_in_blocks305);
					expr58=expr();
					state._fsp--;

					adaptor.addChild(root_0, expr58.getTree());
					dbg.location(36,26);
					END59=(Token)match(input,END,FOLLOW_END_in_blocks307); 
					END59_tree = (Object)adaptor.create(END59);
					adaptor.addChild(root_0, END59_tree);
					dbg.location(36,30);
					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:36:30: ( expr END )*
					try { dbg.enterSubRule(10);

					loop10:
					while (true) {
						int alt10=2;
						try { dbg.enterDecision(10, decisionCanBacktrack[10]);

						int LA10_0 = input.LA(1);
						if ( ((LA10_0 >= BOOLEAN && LA10_0 <= CASE)||(LA10_0 >= ID && LA10_0 <= IF)||LA10_0==ISVOID||LA10_0==LET||(LA10_0 >= NANARITA && LA10_0 <= NEW)||(LA10_0 >= NOT && LA10_0 <= NUMBER)||(LA10_0 >= OP_CORCH && LA10_0 <= OP_PARENT)||LA10_0==STRING||LA10_0==TYPE||LA10_0==WHILE) ) {
							alt10=1;
						}

						} finally {dbg.exitDecision(10);}

						switch (alt10) {
						case 1 :
							dbg.enterAlt(1);

							// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:36:32: expr END
							{
							dbg.location(36,32);
							pushFollow(FOLLOW_expr_in_blocks311);
							expr60=expr();
							state._fsp--;

							adaptor.addChild(root_0, expr60.getTree());
							dbg.location(36,37);
							END61=(Token)match(input,END,FOLLOW_END_in_blocks313); 
							END61_tree = (Object)adaptor.create(END61);
							adaptor.addChild(root_0, END61_tree);

							}
							break;

						default :
							break loop10;
						}
					}
					} finally {dbg.exitSubRule(10);}

					}
					break;

			}
			} finally {dbg.exitSubRule(11);}
			dbg.location(36,45);
			CL_CORCH62=(Token)match(input,CL_CORCH,FOLLOW_CL_CORCH_in_blocks319); 
			CL_CORCH62_tree = (Object)adaptor.create(CL_CORCH62);
			adaptor.addChild(root_0, CL_CORCH62_tree);

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(36, 53);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "blocks");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "blocks"


	public static class let_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "let"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:37:2: let : LET assignment ( COMA assignment )* IN expr ;
	public final COOLParser.let_return let() throws RecognitionException {
		COOLParser.let_return retval = new COOLParser.let_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token LET63=null;
		Token COMA65=null;
		Token IN67=null;
		ParserRuleReturnScope assignment64 =null;
		ParserRuleReturnScope assignment66 =null;
		ParserRuleReturnScope expr68 =null;

		Object LET63_tree=null;
		Object COMA65_tree=null;
		Object IN67_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "let");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(37, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:37:5: ( LET assignment ( COMA assignment )* IN expr )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:37:7: LET assignment ( COMA assignment )* IN expr
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(37,7);
			LET63=(Token)match(input,LET,FOLLOW_LET_in_let327); 
			LET63_tree = (Object)adaptor.create(LET63);
			adaptor.addChild(root_0, LET63_tree);
			dbg.location(37,11);
			pushFollow(FOLLOW_assignment_in_let329);
			assignment64=assignment();
			state._fsp--;

			adaptor.addChild(root_0, assignment64.getTree());
			dbg.location(37,22);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:37:22: ( COMA assignment )*
			try { dbg.enterSubRule(12);

			loop12:
			while (true) {
				int alt12=2;
				try { dbg.enterDecision(12, decisionCanBacktrack[12]);

				int LA12_0 = input.LA(1);
				if ( (LA12_0==COMA) ) {
					alt12=1;
				}

				} finally {dbg.exitDecision(12);}

				switch (alt12) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:37:24: COMA assignment
					{
					dbg.location(37,24);
					COMA65=(Token)match(input,COMA,FOLLOW_COMA_in_let333); 
					COMA65_tree = (Object)adaptor.create(COMA65);
					adaptor.addChild(root_0, COMA65_tree);
					dbg.location(37,29);
					pushFollow(FOLLOW_assignment_in_let335);
					assignment66=assignment();
					state._fsp--;

					adaptor.addChild(root_0, assignment66.getTree());

					}
					break;

				default :
					break loop12;
				}
			}
			} finally {dbg.exitSubRule(12);}
			dbg.location(37,42);
			IN67=(Token)match(input,IN,FOLLOW_IN_in_let339); 
			IN67_tree = (Object)adaptor.create(IN67);
			adaptor.addChild(root_0, IN67_tree);
			dbg.location(37,45);
			pushFollow(FOLLOW_expr_in_let341);
			expr68=expr();
			state._fsp--;

			adaptor.addChild(root_0, expr68.getTree());

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(37, 49);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "let");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "let"


	public static class case_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "case"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:38:2: case : CASE expr OF ( param IMPLICS expr )+ ESAC ;
	public final COOLParser.case_return case() throws RecognitionException {
		COOLParser.case_return retval = new COOLParser.case_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token CASE69=null;
		Token OF71=null;
		Token IMPLICS73=null;
		Token ESAC75=null;
		ParserRuleReturnScope expr70 =null;
		ParserRuleReturnScope param72 =null;
		ParserRuleReturnScope expr74 =null;

		Object CASE69_tree=null;
		Object OF71_tree=null;
		Object IMPLICS73_tree=null;
		Object ESAC75_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "case");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(38, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:38:6: ( CASE expr OF ( param IMPLICS expr )+ ESAC )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:38:8: CASE expr OF ( param IMPLICS expr )+ ESAC
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(38,8);
			CASE69=(Token)match(input,CASE,FOLLOW_CASE_in_case349); 
			CASE69_tree = (Object)adaptor.create(CASE69);
			adaptor.addChild(root_0, CASE69_tree);
			dbg.location(38,13);
			pushFollow(FOLLOW_expr_in_case351);
			expr70=expr();
			state._fsp--;

			adaptor.addChild(root_0, expr70.getTree());
			dbg.location(38,18);
			OF71=(Token)match(input,OF,FOLLOW_OF_in_case353); 
			OF71_tree = (Object)adaptor.create(OF71);
			adaptor.addChild(root_0, OF71_tree);
			dbg.location(38,21);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:38:21: ( param IMPLICS expr )+
			int cnt13=0;
			try { dbg.enterSubRule(13);

			loop13:
			while (true) {
				int alt13=2;
				try { dbg.enterDecision(13, decisionCanBacktrack[13]);

				int LA13_0 = input.LA(1);
				if ( (LA13_0==ID) ) {
					alt13=1;
				}

				} finally {dbg.exitDecision(13);}

				switch (alt13) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:38:23: param IMPLICS expr
					{
					dbg.location(38,23);
					pushFollow(FOLLOW_param_in_case357);
					param72=param();
					state._fsp--;

					adaptor.addChild(root_0, param72.getTree());
					dbg.location(38,29);
					IMPLICS73=(Token)match(input,IMPLICS,FOLLOW_IMPLICS_in_case359); 
					IMPLICS73_tree = (Object)adaptor.create(IMPLICS73);
					adaptor.addChild(root_0, IMPLICS73_tree);
					dbg.location(38,37);
					pushFollow(FOLLOW_expr_in_case361);
					expr74=expr();
					state._fsp--;

					adaptor.addChild(root_0, expr74.getTree());

					}
					break;

				default :
					if ( cnt13 >= 1 ) break loop13;
					EarlyExitException eee = new EarlyExitException(13, input);
					dbg.recognitionException(eee);

					throw eee;
				}
				cnt13++;
			}
			} finally {dbg.exitSubRule(13);}
			dbg.location(38,44);
			ESAC75=(Token)match(input,ESAC,FOLLOW_ESAC_in_case365); 
			ESAC75_tree = (Object)adaptor.create(ESAC75);
			adaptor.addChild(root_0, ESAC75_tree);

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(38, 48);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "case");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "case"


	public static class new_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "new"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:39:2: new : NEW TYPE ;
	public final COOLParser.new_return new() throws RecognitionException {
		COOLParser.new_return retval = new COOLParser.new_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token NEW76=null;
		Token TYPE77=null;

		Object NEW76_tree=null;
		Object TYPE77_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "new");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(39, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:39:6: ( NEW TYPE )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:39:8: NEW TYPE
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(39,8);
			NEW76=(Token)match(input,NEW,FOLLOW_NEW_in_new374); 
			NEW76_tree = (Object)adaptor.create(NEW76);
			adaptor.addChild(root_0, NEW76_tree);
			dbg.location(39,12);
			TYPE77=(Token)match(input,TYPE,FOLLOW_TYPE_in_new376); 
			TYPE77_tree = (Object)adaptor.create(TYPE77);
			adaptor.addChild(root_0, TYPE77_tree);

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(39, 16);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "new");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "new"


	public static class dispatch_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "dispatch"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:41:2: dispatch : ( ARROBA TYPE | PNT ) ID OP_PARENT ( expr ( COMA expr )* )? CL_PARENT ;
	public final COOLParser.dispatch_return dispatch() throws RecognitionException {
		COOLParser.dispatch_return retval = new COOLParser.dispatch_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token ARROBA78=null;
		Token TYPE79=null;
		Token PNT80=null;
		Token ID81=null;
		Token OP_PARENT82=null;
		Token COMA84=null;
		Token CL_PARENT86=null;
		ParserRuleReturnScope expr83 =null;
		ParserRuleReturnScope expr85 =null;

		Object ARROBA78_tree=null;
		Object TYPE79_tree=null;
		Object PNT80_tree=null;
		Object ID81_tree=null;
		Object OP_PARENT82_tree=null;
		Object COMA84_tree=null;
		Object CL_PARENT86_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "dispatch");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(41, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:41:10: ( ( ARROBA TYPE | PNT ) ID OP_PARENT ( expr ( COMA expr )* )? CL_PARENT )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:41:12: ( ARROBA TYPE | PNT ) ID OP_PARENT ( expr ( COMA expr )* )? CL_PARENT
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(41,12);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:41:12: ( ARROBA TYPE | PNT )
			int alt14=2;
			try { dbg.enterSubRule(14);
			try { dbg.enterDecision(14, decisionCanBacktrack[14]);

			int LA14_0 = input.LA(1);
			if ( (LA14_0==ARROBA) ) {
				alt14=1;
			}
			else if ( (LA14_0==PNT) ) {
				alt14=2;
			}

			else {
				NoViableAltException nvae =
					new NoViableAltException("", 14, 0, input);
				dbg.recognitionException(nvae);
				throw nvae;
			}

			} finally {dbg.exitDecision(14);}

			switch (alt14) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:41:13: ARROBA TYPE
					{
					dbg.location(41,13);
					ARROBA78=(Token)match(input,ARROBA,FOLLOW_ARROBA_in_dispatch387); 
					ARROBA78_tree = (Object)adaptor.create(ARROBA78);
					adaptor.addChild(root_0, ARROBA78_tree);
					dbg.location(41,20);
					TYPE79=(Token)match(input,TYPE,FOLLOW_TYPE_in_dispatch389); 
					TYPE79_tree = (Object)adaptor.create(TYPE79);
					adaptor.addChild(root_0, TYPE79_tree);

					}
					break;
				case 2 :
					dbg.enterAlt(2);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:41:26: PNT
					{
					dbg.location(41,26);
					PNT80=(Token)match(input,PNT,FOLLOW_PNT_in_dispatch392); 
					PNT80_tree = (Object)adaptor.create(PNT80);
					adaptor.addChild(root_0, PNT80_tree);

					}
					break;

			}
			} finally {dbg.exitSubRule(14);}
			dbg.location(41,31);
			ID81=(Token)match(input,ID,FOLLOW_ID_in_dispatch395); 
			ID81_tree = (Object)adaptor.create(ID81);
			adaptor.addChild(root_0, ID81_tree);
			dbg.location(41,34);
			OP_PARENT82=(Token)match(input,OP_PARENT,FOLLOW_OP_PARENT_in_dispatch397); 
			OP_PARENT82_tree = (Object)adaptor.create(OP_PARENT82);
			adaptor.addChild(root_0, OP_PARENT82_tree);
			dbg.location(41,44);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:41:44: ( expr ( COMA expr )* )?
			int alt16=2;
			try { dbg.enterSubRule(16);
			try { dbg.enterDecision(16, decisionCanBacktrack[16]);

			int LA16_0 = input.LA(1);
			if ( ((LA16_0 >= BOOLEAN && LA16_0 <= CASE)||(LA16_0 >= ID && LA16_0 <= IF)||LA16_0==ISVOID||LA16_0==LET||(LA16_0 >= NANARITA && LA16_0 <= NEW)||(LA16_0 >= NOT && LA16_0 <= NUMBER)||(LA16_0 >= OP_CORCH && LA16_0 <= OP_PARENT)||LA16_0==STRING||LA16_0==TYPE||LA16_0==WHILE) ) {
				alt16=1;
			}
			} finally {dbg.exitDecision(16);}

			switch (alt16) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:41:45: expr ( COMA expr )*
					{
					dbg.location(41,45);
					pushFollow(FOLLOW_expr_in_dispatch400);
					expr83=expr();
					state._fsp--;

					adaptor.addChild(root_0, expr83.getTree());
					dbg.location(41,50);
					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:41:50: ( COMA expr )*
					try { dbg.enterSubRule(15);

					loop15:
					while (true) {
						int alt15=2;
						try { dbg.enterDecision(15, decisionCanBacktrack[15]);

						int LA15_0 = input.LA(1);
						if ( (LA15_0==COMA) ) {
							alt15=1;
						}

						} finally {dbg.exitDecision(15);}

						switch (alt15) {
						case 1 :
							dbg.enterAlt(1);

							// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:41:52: COMA expr
							{
							dbg.location(41,52);
							COMA84=(Token)match(input,COMA,FOLLOW_COMA_in_dispatch404); 
							COMA84_tree = (Object)adaptor.create(COMA84);
							adaptor.addChild(root_0, COMA84_tree);
							dbg.location(41,57);
							pushFollow(FOLLOW_expr_in_dispatch406);
							expr85=expr();
							state._fsp--;

							adaptor.addChild(root_0, expr85.getTree());

							}
							break;

						default :
							break loop15;
						}
					}
					} finally {dbg.exitSubRule(15);}

					}
					break;

			}
			} finally {dbg.exitSubRule(16);}
			dbg.location(41,66);
			CL_PARENT86=(Token)match(input,CL_PARENT,FOLLOW_CL_PARENT_in_dispatch412); 
			CL_PARENT86_tree = (Object)adaptor.create(CL_PARENT86);
			adaptor.addChild(root_0, CL_PARENT86_tree);

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(41, 75);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "dispatch");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "dispatch"


	public static class operations_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "operations"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:43:2: operations : ( NOT expr )? lv1 ;
	public final COOLParser.operations_return operations() throws RecognitionException {
		COOLParser.operations_return retval = new COOLParser.operations_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token NOT87=null;
		ParserRuleReturnScope expr88 =null;
		ParserRuleReturnScope lv189 =null;

		Object NOT87_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "operations");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(43, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:44:3: ( ( NOT expr )? lv1 )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:44:6: ( NOT expr )? lv1
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(44,6);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:44:6: ( NOT expr )?
			int alt17=2;
			try { dbg.enterSubRule(17);
			try { dbg.enterDecision(17, decisionCanBacktrack[17]);

			int LA17_0 = input.LA(1);
			if ( (LA17_0==NOT) ) {
				alt17=1;
			}
			} finally {dbg.exitDecision(17);}

			switch (alt17) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:44:7: NOT expr
					{
					dbg.location(44,7);
					NOT87=(Token)match(input,NOT,FOLLOW_NOT_in_operations427); 
					NOT87_tree = (Object)adaptor.create(NOT87);
					adaptor.addChild(root_0, NOT87_tree);
					dbg.location(44,11);
					pushFollow(FOLLOW_expr_in_operations429);
					expr88=expr();
					state._fsp--;

					adaptor.addChild(root_0, expr88.getTree());

					}
					break;

			}
			} finally {dbg.exitSubRule(17);}
			dbg.location(44,18);
			pushFollow(FOLLOW_lv1_in_operations433);
			lv189=lv1();
			state._fsp--;

			adaptor.addChild(root_0, lv189.getTree());

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(44, 21);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "operations");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "operations"


	public static class lv1_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "lv1"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:45:3: lv1 : lv2 ( LEQ lv1 | GEQ lv1 | L lv1 | G lv1 | EQ lv1 )? ;
	public final COOLParser.lv1_return lv1() throws RecognitionException {
		COOLParser.lv1_return retval = new COOLParser.lv1_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token LEQ91=null;
		Token GEQ93=null;
		Token L95=null;
		Token G97=null;
		Token EQ99=null;
		ParserRuleReturnScope lv290 =null;
		ParserRuleReturnScope lv192 =null;
		ParserRuleReturnScope lv194 =null;
		ParserRuleReturnScope lv196 =null;
		ParserRuleReturnScope lv198 =null;
		ParserRuleReturnScope lv1100 =null;

		Object LEQ91_tree=null;
		Object GEQ93_tree=null;
		Object L95_tree=null;
		Object G97_tree=null;
		Object EQ99_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "lv1");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(45, 2);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:45:6: ( lv2 ( LEQ lv1 | GEQ lv1 | L lv1 | G lv1 | EQ lv1 )? )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:45:9: lv2 ( LEQ lv1 | GEQ lv1 | L lv1 | G lv1 | EQ lv1 )?
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(45,9);
			pushFollow(FOLLOW_lv2_in_lv1443);
			lv290=lv2();
			state._fsp--;

			adaptor.addChild(root_0, lv290.getTree());
			dbg.location(45,13);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:45:13: ( LEQ lv1 | GEQ lv1 | L lv1 | G lv1 | EQ lv1 )?
			int alt18=6;
			try { dbg.enterSubRule(18);
			try { dbg.enterDecision(18, decisionCanBacktrack[18]);

			switch ( input.LA(1) ) {
				case LEQ:
					{
					alt18=1;
					}
					break;
				case GEQ:
					{
					alt18=2;
					}
					break;
				case L:
					{
					alt18=3;
					}
					break;
				case G:
					{
					alt18=4;
					}
					break;
				case EQ:
					{
					alt18=5;
					}
					break;
			}
			} finally {dbg.exitDecision(18);}

			switch (alt18) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:45:15: LEQ lv1
					{
					dbg.location(45,15);
					LEQ91=(Token)match(input,LEQ,FOLLOW_LEQ_in_lv1447); 
					LEQ91_tree = (Object)adaptor.create(LEQ91);
					adaptor.addChild(root_0, LEQ91_tree);
					dbg.location(45,19);
					pushFollow(FOLLOW_lv1_in_lv1449);
					lv192=lv1();
					state._fsp--;

					adaptor.addChild(root_0, lv192.getTree());

					}
					break;
				case 2 :
					dbg.enterAlt(2);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:45:23: GEQ lv1
					{
					dbg.location(45,23);
					GEQ93=(Token)match(input,GEQ,FOLLOW_GEQ_in_lv1451); 
					GEQ93_tree = (Object)adaptor.create(GEQ93);
					adaptor.addChild(root_0, GEQ93_tree);
					dbg.location(45,27);
					pushFollow(FOLLOW_lv1_in_lv1453);
					lv194=lv1();
					state._fsp--;

					adaptor.addChild(root_0, lv194.getTree());

					}
					break;
				case 3 :
					dbg.enterAlt(3);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:45:31: L lv1
					{
					dbg.location(45,31);
					L95=(Token)match(input,L,FOLLOW_L_in_lv1455); 
					L95_tree = (Object)adaptor.create(L95);
					adaptor.addChild(root_0, L95_tree);
					dbg.location(45,33);
					pushFollow(FOLLOW_lv1_in_lv1457);
					lv196=lv1();
					state._fsp--;

					adaptor.addChild(root_0, lv196.getTree());

					}
					break;
				case 4 :
					dbg.enterAlt(4);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:45:37: G lv1
					{
					dbg.location(45,37);
					G97=(Token)match(input,G,FOLLOW_G_in_lv1459); 
					G97_tree = (Object)adaptor.create(G97);
					adaptor.addChild(root_0, G97_tree);
					dbg.location(45,39);
					pushFollow(FOLLOW_lv1_in_lv1461);
					lv198=lv1();
					state._fsp--;

					adaptor.addChild(root_0, lv198.getTree());

					}
					break;
				case 5 :
					dbg.enterAlt(5);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:45:43: EQ lv1
					{
					dbg.location(45,43);
					EQ99=(Token)match(input,EQ,FOLLOW_EQ_in_lv1463); 
					EQ99_tree = (Object)adaptor.create(EQ99);
					adaptor.addChild(root_0, EQ99_tree);
					dbg.location(45,46);
					pushFollow(FOLLOW_lv1_in_lv1465);
					lv1100=lv1();
					state._fsp--;

					adaptor.addChild(root_0, lv1100.getTree());

					}
					break;

			}
			} finally {dbg.exitSubRule(18);}

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(45, 50);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "lv1");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "lv1"


	public static class lv2_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "lv2"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:46:3: lv2 : lv3 ( PLUS lv2 | MINUS lv2 )? ;
	public final COOLParser.lv2_return lv2() throws RecognitionException {
		COOLParser.lv2_return retval = new COOLParser.lv2_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token PLUS102=null;
		Token MINUS104=null;
		ParserRuleReturnScope lv3101 =null;
		ParserRuleReturnScope lv2103 =null;
		ParserRuleReturnScope lv2105 =null;

		Object PLUS102_tree=null;
		Object MINUS104_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "lv2");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(46, 2);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:46:6: ( lv3 ( PLUS lv2 | MINUS lv2 )? )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:46:8: lv3 ( PLUS lv2 | MINUS lv2 )?
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(46,8);
			pushFollow(FOLLOW_lv3_in_lv2475);
			lv3101=lv3();
			state._fsp--;

			adaptor.addChild(root_0, lv3101.getTree());
			dbg.location(46,12);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:46:12: ( PLUS lv2 | MINUS lv2 )?
			int alt19=3;
			try { dbg.enterSubRule(19);
			try { dbg.enterDecision(19, decisionCanBacktrack[19]);

			int LA19_0 = input.LA(1);
			if ( (LA19_0==PLUS) ) {
				alt19=1;
			}
			else if ( (LA19_0==MINUS) ) {
				alt19=2;
			}
			} finally {dbg.exitDecision(19);}

			switch (alt19) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:46:14: PLUS lv2
					{
					dbg.location(46,14);
					PLUS102=(Token)match(input,PLUS,FOLLOW_PLUS_in_lv2479); 
					PLUS102_tree = (Object)adaptor.create(PLUS102);
					adaptor.addChild(root_0, PLUS102_tree);
					dbg.location(46,20);
					pushFollow(FOLLOW_lv2_in_lv2482);
					lv2103=lv2();
					state._fsp--;

					adaptor.addChild(root_0, lv2103.getTree());

					}
					break;
				case 2 :
					dbg.enterAlt(2);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:46:24: MINUS lv2
					{
					dbg.location(46,24);
					MINUS104=(Token)match(input,MINUS,FOLLOW_MINUS_in_lv2484); 
					MINUS104_tree = (Object)adaptor.create(MINUS104);
					adaptor.addChild(root_0, MINUS104_tree);
					dbg.location(46,31);
					pushFollow(FOLLOW_lv2_in_lv2487);
					lv2105=lv2();
					state._fsp--;

					adaptor.addChild(root_0, lv2105.getTree());

					}
					break;

			}
			} finally {dbg.exitSubRule(19);}

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(46, 36);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "lv2");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "lv2"


	public static class lv3_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "lv3"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:47:3: lv3 : lv4 ( MULT lv3 | DIV lv3 )? ;
	public final COOLParser.lv3_return lv3() throws RecognitionException {
		COOLParser.lv3_return retval = new COOLParser.lv3_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token MULT107=null;
		Token DIV109=null;
		ParserRuleReturnScope lv4106 =null;
		ParserRuleReturnScope lv3108 =null;
		ParserRuleReturnScope lv3110 =null;

		Object MULT107_tree=null;
		Object DIV109_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "lv3");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(47, 2);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:47:6: ( lv4 ( MULT lv3 | DIV lv3 )? )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:47:8: lv4 ( MULT lv3 | DIV lv3 )?
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(47,8);
			pushFollow(FOLLOW_lv4_in_lv3498);
			lv4106=lv4();
			state._fsp--;

			adaptor.addChild(root_0, lv4106.getTree());
			dbg.location(47,11);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:47:11: ( MULT lv3 | DIV lv3 )?
			int alt20=3;
			try { dbg.enterSubRule(20);
			try { dbg.enterDecision(20, decisionCanBacktrack[20]);

			int LA20_0 = input.LA(1);
			if ( (LA20_0==MULT) ) {
				alt20=1;
			}
			else if ( (LA20_0==DIV) ) {
				alt20=2;
			}
			} finally {dbg.exitDecision(20);}

			switch (alt20) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:47:13: MULT lv3
					{
					dbg.location(47,13);
					MULT107=(Token)match(input,MULT,FOLLOW_MULT_in_lv3501); 
					MULT107_tree = (Object)adaptor.create(MULT107);
					adaptor.addChild(root_0, MULT107_tree);
					dbg.location(47,19);
					pushFollow(FOLLOW_lv3_in_lv3504);
					lv3108=lv3();
					state._fsp--;

					adaptor.addChild(root_0, lv3108.getTree());

					}
					break;
				case 2 :
					dbg.enterAlt(2);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:47:23: DIV lv3
					{
					dbg.location(47,23);
					DIV109=(Token)match(input,DIV,FOLLOW_DIV_in_lv3506); 
					DIV109_tree = (Object)adaptor.create(DIV109);
					adaptor.addChild(root_0, DIV109_tree);
					dbg.location(47,28);
					pushFollow(FOLLOW_lv3_in_lv3509);
					lv3110=lv3();
					state._fsp--;

					adaptor.addChild(root_0, lv3110.getTree());

					}
					break;

			}
			} finally {dbg.exitSubRule(20);}

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(47, 32);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "lv3");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "lv3"


	public static class lv4_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "lv4"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:48:3: lv4 : ( ISVOID expr )? lv5 ;
	public final COOLParser.lv4_return lv4() throws RecognitionException {
		COOLParser.lv4_return retval = new COOLParser.lv4_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token ISVOID111=null;
		ParserRuleReturnScope expr112 =null;
		ParserRuleReturnScope lv5113 =null;

		Object ISVOID111_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "lv4");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(48, 2);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:48:6: ( ( ISVOID expr )? lv5 )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:48:8: ( ISVOID expr )? lv5
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(48,8);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:48:8: ( ISVOID expr )?
			int alt21=2;
			try { dbg.enterSubRule(21);
			try { dbg.enterDecision(21, decisionCanBacktrack[21]);

			int LA21_0 = input.LA(1);
			if ( (LA21_0==ISVOID) ) {
				alt21=1;
			}
			} finally {dbg.exitDecision(21);}

			switch (alt21) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:48:9: ISVOID expr
					{
					dbg.location(48,9);
					ISVOID111=(Token)match(input,ISVOID,FOLLOW_ISVOID_in_lv4520); 
					ISVOID111_tree = (Object)adaptor.create(ISVOID111);
					adaptor.addChild(root_0, ISVOID111_tree);
					dbg.location(48,17);
					pushFollow(FOLLOW_expr_in_lv4523);
					expr112=expr();
					state._fsp--;

					adaptor.addChild(root_0, expr112.getTree());

					}
					break;

			}
			} finally {dbg.exitSubRule(21);}
			dbg.location(48,23);
			pushFollow(FOLLOW_lv5_in_lv4526);
			lv5113=lv5();
			state._fsp--;

			adaptor.addChild(root_0, lv5113.getTree());

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(48, 26);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "lv4");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "lv4"


	public static class lv5_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "lv5"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:49:3: lv5 : ( nanarita )? lv6 ;
	public final COOLParser.lv5_return lv5() throws RecognitionException {
		COOLParser.lv5_return retval = new COOLParser.lv5_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		ParserRuleReturnScope nanarita114 =null;
		ParserRuleReturnScope lv6115 =null;


		try { dbg.enterRule(getGrammarFileName(), "lv5");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(49, 2);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:49:6: ( ( nanarita )? lv6 )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:49:8: ( nanarita )? lv6
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(49,8);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:49:8: ( nanarita )?
			int alt22=2;
			try { dbg.enterSubRule(22);
			try { dbg.enterDecision(22, decisionCanBacktrack[22]);

			int LA22_0 = input.LA(1);
			if ( (LA22_0==NANARITA) ) {
				alt22=1;
			}
			} finally {dbg.exitDecision(22);}

			switch (alt22) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:49:8: nanarita
					{
					dbg.location(49,8);
					pushFollow(FOLLOW_nanarita_in_lv5535);
					nanarita114=nanarita();
					state._fsp--;

					adaptor.addChild(root_0, nanarita114.getTree());

					}
					break;

			}
			} finally {dbg.exitSubRule(22);}
			dbg.location(49,18);
			pushFollow(FOLLOW_lv6_in_lv5538);
			lv6115=lv6();
			state._fsp--;

			adaptor.addChild(root_0, lv6115.getTree());

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(49, 21);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "lv5");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "lv5"


	public static class lv6_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "lv6"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:50:3: lv6 : ( ID | OP_PARENT expr CL_PARENT | constant ) ( dispatch )? ;
	public final COOLParser.lv6_return lv6() throws RecognitionException {
		COOLParser.lv6_return retval = new COOLParser.lv6_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token ID116=null;
		Token OP_PARENT117=null;
		Token CL_PARENT119=null;
		ParserRuleReturnScope expr118 =null;
		ParserRuleReturnScope constant120 =null;
		ParserRuleReturnScope dispatch121 =null;

		Object ID116_tree=null;
		Object OP_PARENT117_tree=null;
		Object CL_PARENT119_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "lv6");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(50, 2);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:50:6: ( ( ID | OP_PARENT expr CL_PARENT | constant ) ( dispatch )? )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:50:8: ( ID | OP_PARENT expr CL_PARENT | constant ) ( dispatch )?
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(50,8);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:50:8: ( ID | OP_PARENT expr CL_PARENT | constant )
			int alt23=3;
			try { dbg.enterSubRule(23);
			try { dbg.enterDecision(23, decisionCanBacktrack[23]);

			switch ( input.LA(1) ) {
			case ID:
				{
				alt23=1;
				}
				break;
			case OP_PARENT:
				{
				alt23=2;
				}
				break;
			case BOOLEAN:
			case NUMBER:
			case STRING:
				{
				alt23=3;
				}
				break;
			default:
				NoViableAltException nvae =
					new NoViableAltException("", 23, 0, input);
				dbg.recognitionException(nvae);
				throw nvae;
			}
			} finally {dbg.exitDecision(23);}

			switch (alt23) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:50:9: ID
					{
					dbg.location(50,9);
					ID116=(Token)match(input,ID,FOLLOW_ID_in_lv6548); 
					ID116_tree = (Object)adaptor.create(ID116);
					adaptor.addChild(root_0, ID116_tree);

					}
					break;
				case 2 :
					dbg.enterAlt(2);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:50:12: OP_PARENT expr CL_PARENT
					{
					dbg.location(50,12);
					OP_PARENT117=(Token)match(input,OP_PARENT,FOLLOW_OP_PARENT_in_lv6550); 
					OP_PARENT117_tree = (Object)adaptor.create(OP_PARENT117);
					adaptor.addChild(root_0, OP_PARENT117_tree);
					dbg.location(50,22);
					pushFollow(FOLLOW_expr_in_lv6552);
					expr118=expr();
					state._fsp--;

					adaptor.addChild(root_0, expr118.getTree());
					dbg.location(50,27);
					CL_PARENT119=(Token)match(input,CL_PARENT,FOLLOW_CL_PARENT_in_lv6554); 
					CL_PARENT119_tree = (Object)adaptor.create(CL_PARENT119);
					adaptor.addChild(root_0, CL_PARENT119_tree);

					}
					break;
				case 3 :
					dbg.enterAlt(3);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:50:37: constant
					{
					dbg.location(50,37);
					pushFollow(FOLLOW_constant_in_lv6556);
					constant120=constant();
					state._fsp--;

					adaptor.addChild(root_0, constant120.getTree());

					}
					break;

			}
			} finally {dbg.exitSubRule(23);}
			dbg.location(50,46);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:50:46: ( dispatch )?
			int alt24=2;
			try { dbg.enterSubRule(24);
			try { dbg.enterDecision(24, decisionCanBacktrack[24]);

			int LA24_0 = input.LA(1);
			if ( (LA24_0==ARROBA||LA24_0==PNT) ) {
				alt24=1;
			}
			} finally {dbg.exitDecision(24);}

			switch (alt24) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:50:47: dispatch
					{
					dbg.location(50,47);
					pushFollow(FOLLOW_dispatch_in_lv6559);
					dispatch121=dispatch();
					state._fsp--;

					adaptor.addChild(root_0, dispatch121.getTree());

					}
					break;

			}
			} finally {dbg.exitSubRule(24);}

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(50, 57);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "lv6");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "lv6"


	public static class nanarita_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "nanarita"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:52:2: nanarita : NANARITA expr ;
	public final COOLParser.nanarita_return nanarita() throws RecognitionException {
		COOLParser.nanarita_return retval = new COOLParser.nanarita_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token NANARITA122=null;
		ParserRuleReturnScope expr123 =null;

		Object NANARITA122_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "nanarita");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(52, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:52:10: ( NANARITA expr )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:52:12: NANARITA expr
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(52,12);
			NANARITA122=(Token)match(input,NANARITA,FOLLOW_NANARITA_in_nanarita572); 
			NANARITA122_tree = (Object)adaptor.create(NANARITA122);
			adaptor.addChild(root_0, NANARITA122_tree);
			dbg.location(52,21);
			pushFollow(FOLLOW_expr_in_nanarita574);
			expr123=expr();
			state._fsp--;

			adaptor.addChild(root_0, expr123.getTree());

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(52, 25);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "nanarita");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "nanarita"


	public static class constant_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "constant"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:53:3: constant : ( STRING | NUMBER | BOOLEAN );
	public final COOLParser.constant_return constant() throws RecognitionException {
		COOLParser.constant_return retval = new COOLParser.constant_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token set124=null;

		Object set124_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "constant");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(53, 2);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:53:11: ( STRING | NUMBER | BOOLEAN )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(53,11);
			set124=input.LT(1);
			if ( input.LA(1)==BOOLEAN||input.LA(1)==NUMBER||input.LA(1)==STRING ) {
				input.consume();
				adaptor.addChild(root_0, (Object)adaptor.create(set124));
				state.errorRecovery=false;
			}
			else {
				MismatchedSetException mse = new MismatchedSetException(null,input);
				dbg.recognitionException(mse);
				throw mse;
			}
			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(53, 33);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "constant");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "constant"


	public static class wsnl_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "wsnl"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:54:2: wsnl : ( WS | NL )+ ;
	public final COOLParser.wsnl_return wsnl() throws RecognitionException {
		COOLParser.wsnl_return retval = new COOLParser.wsnl_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token set125=null;

		Object set125_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "wsnl");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(54, 1);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:54:7: ( ( WS | NL )+ )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:54:9: ( WS | NL )+
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(54,9);
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:54:9: ( WS | NL )+
			int cnt25=0;
			try { dbg.enterSubRule(25);

			loop25:
			while (true) {
				int alt25=2;
				try { dbg.enterDecision(25, decisionCanBacktrack[25]);

				int LA25_0 = input.LA(1);
				if ( (LA25_0==NL||LA25_0==WS) ) {
					alt25=1;
				}

				} finally {dbg.exitDecision(25);}

				switch (alt25) {
				case 1 :
					dbg.enterAlt(1);

					// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:
					{
					dbg.location(54,9);
					set125=input.LT(1);
					if ( input.LA(1)==NL||input.LA(1)==WS ) {
						input.consume();
						adaptor.addChild(root_0, (Object)adaptor.create(set125));
						state.errorRecovery=false;
					}
					else {
						MismatchedSetException mse = new MismatchedSetException(null,input);
						dbg.recognitionException(mse);
						throw mse;
					}
					}
					break;

				default :
					if ( cnt25 >= 1 ) break loop25;
					EarlyExitException eee = new EarlyExitException(25, input);
					dbg.recognitionException(eee);

					throw eee;
				}
				cnt25++;
			}
			} finally {dbg.exitSubRule(25);}

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(54, 17);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "wsnl");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "wsnl"


	public static class compileUnit_return extends ParserRuleReturnScope {
		Object tree;
		@Override
		public Object getTree() { return tree; }
	};


	// $ANTLR start "compileUnit"
	// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:55:1: compileUnit : EOF ;
	public final COOLParser.compileUnit_return compileUnit() throws RecognitionException {
		COOLParser.compileUnit_return retval = new COOLParser.compileUnit_return();
		retval.start = input.LT(1);

		Object root_0 = null;

		Token EOF126=null;

		Object EOF126_tree=null;

		try { dbg.enterRule(getGrammarFileName(), "compileUnit");
		if ( getRuleLevel()==0 ) {dbg.commence();}
		incRuleLevel();
		dbg.location(55, 0);

		try {
			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:56:2: ( EOF )
			dbg.enterAlt(1);

			// C:\\Users\\Nardo\\Documents\\Visual Studio 2015\\Projects\\COOL\\LexingParsingCOOL\\COOL.g:56:4: EOF
			{
			root_0 = (Object)adaptor.nil();


			dbg.location(56,4);
			EOF126=(Token)match(input,EOF,FOLLOW_EOF_in_compileUnit609); 
			EOF126_tree = (Object)adaptor.create(EOF126);
			adaptor.addChild(root_0, EOF126_tree);

			}

			retval.stop = input.LT(-1);

			retval.tree = (Object)adaptor.rulePostProcessing(root_0);
			adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch (RecognitionException re) {
			reportError(re);
			recover(input,re);
			retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);
		}
		finally {
			// do for sure before leaving
		}
		dbg.location(57, 1);

		}
		finally {
			dbg.exitRule(getGrammarFileName(), "compileUnit");
			decRuleLevel();
			if ( getRuleLevel()==0 ) {dbg.terminate();}
		}

		return retval;
	}
	// $ANTLR end "compileUnit"

	// Delegated rules



	public static final BitSet FOLLOW_class_in_program29 = new BitSet(new long[]{0x0000000000000200L});
	public static final BitSet FOLLOW_EOF_in_program33 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_CLASS_in_class42 = new BitSet(new long[]{0x0040000000000000L});
	public static final BitSet FOLLOW_TYPE_in_class44 = new BitSet(new long[]{0x0000800080000000L});
	public static final BitSet FOLLOW_INHERITS_in_class47 = new BitSet(new long[]{0x0040000000000000L});
	public static final BitSet FOLLOW_TYPE_in_class49 = new BitSet(new long[]{0x0000800000000000L});
	public static final BitSet FOLLOW_OP_CORCH_in_class53 = new BitSet(new long[]{0x0000000008000400L});
	public static final BitSet FOLLOW_feature_list_in_class57 = new BitSet(new long[]{0x0000000000000400L});
	public static final BitSet FOLLOW_CL_CORCH_in_class61 = new BitSet(new long[]{0x0000000000040000L});
	public static final BitSet FOLLOW_END_in_class63 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_feature_in_feature_list73 = new BitSet(new long[]{0x0000000008000002L});
	public static final BitSet FOLLOW_feature_in_feature_list77 = new BitSet(new long[]{0x0000000008000002L});
	public static final BitSet FOLLOW_ID_in_feature87 = new BitSet(new long[]{0x0001000000010000L});
	public static final BitSet FOLLOW_attribute_in_feature90 = new BitSet(new long[]{0x0000000000040000L});
	public static final BitSet FOLLOW_methodefinition_in_feature92 = new BitSet(new long[]{0x0000000000040000L});
	public static final BitSet FOLLOW_END_in_feature95 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_DOUBLEP_in_attribute105 = new BitSet(new long[]{0x0040000000000000L});
	public static final BitSet FOLLOW_TYPE_in_attribute107 = new BitSet(new long[]{0x0000000000000022L});
	public static final BitSet FOLLOW_ASSING_in_attribute111 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_attribute113 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_OP_PARENT_in_methodefinition125 = new BitSet(new long[]{0x0000000008000800L});
	public static final BitSet FOLLOW_params_list_in_methodefinition129 = new BitSet(new long[]{0x0000000000000800L});
	public static final BitSet FOLLOW_CL_PARENT_in_methodefinition134 = new BitSet(new long[]{0x0000000000010000L});
	public static final BitSet FOLLOW_DOUBLEP_in_methodefinition137 = new BitSet(new long[]{0x0040000000000000L});
	public static final BitSet FOLLOW_TYPE_in_methodefinition140 = new BitSet(new long[]{0x0000800000000000L});
	public static final BitSet FOLLOW_OP_CORCH_in_methodefinition143 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_methodefinition146 = new BitSet(new long[]{0x0000000000000400L});
	public static final BitSet FOLLOW_CL_CORCH_in_methodefinition149 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_param_in_params_list157 = new BitSet(new long[]{0x0000000000001002L});
	public static final BitSet FOLLOW_COMA_in_params_list161 = new BitSet(new long[]{0x0000000008000000L});
	public static final BitSet FOLLOW_param_in_params_list164 = new BitSet(new long[]{0x0000000000001002L});
	public static final BitSet FOLLOW_ID_in_param173 = new BitSet(new long[]{0x0000000000010000L});
	public static final BitSet FOLLOW_DOUBLEP_in_param176 = new BitSet(new long[]{0x0040000000000000L});
	public static final BitSet FOLLOW_TYPE_in_param179 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_assignment_in_expr187 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_conditionals_in_expr194 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_loops_in_expr201 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_blocks_in_expr208 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_let_in_expr215 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_case_in_expr222 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_new_in_expr229 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_operations_in_expr236 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_TYPE_in_expr243 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_ID_in_assignment255 = new BitSet(new long[]{0x0000000000000020L});
	public static final BitSet FOLLOW_ASSING_in_assignment257 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_assignment260 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_IF_in_conditionals268 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_conditionals270 = new BitSet(new long[]{0x0020000000000000L});
	public static final BitSet FOLLOW_THEN_in_conditionals272 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_conditionals274 = new BitSet(new long[]{0x0000000000800000L});
	public static final BitSet FOLLOW_FI_in_conditionals276 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_WHILE_in_loops284 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_loops287 = new BitSet(new long[]{0x0000001000000000L});
	public static final BitSet FOLLOW_LOOP_in_loops289 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_loops291 = new BitSet(new long[]{0x0008000000000000L});
	public static final BitSet FOLLOW_POOL_in_loops293 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_OP_CORCH_in_blocks301 = new BitSet(new long[]{0x02519B09180004C0L});
	public static final BitSet FOLLOW_expr_in_blocks305 = new BitSet(new long[]{0x0000000000040000L});
	public static final BitSet FOLLOW_END_in_blocks307 = new BitSet(new long[]{0x02519B09180004C0L});
	public static final BitSet FOLLOW_expr_in_blocks311 = new BitSet(new long[]{0x0000000000040000L});
	public static final BitSet FOLLOW_END_in_blocks313 = new BitSet(new long[]{0x02519B09180004C0L});
	public static final BitSet FOLLOW_CL_CORCH_in_blocks319 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_LET_in_let327 = new BitSet(new long[]{0x0000000008000000L});
	public static final BitSet FOLLOW_assignment_in_let329 = new BitSet(new long[]{0x0000000040001000L});
	public static final BitSet FOLLOW_COMA_in_let333 = new BitSet(new long[]{0x0000000008000000L});
	public static final BitSet FOLLOW_assignment_in_let335 = new BitSet(new long[]{0x0000000040001000L});
	public static final BitSet FOLLOW_IN_in_let339 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_let341 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_CASE_in_case349 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_case351 = new BitSet(new long[]{0x0000400000000000L});
	public static final BitSet FOLLOW_OF_in_case353 = new BitSet(new long[]{0x0000000008000000L});
	public static final BitSet FOLLOW_param_in_case357 = new BitSet(new long[]{0x0000000020000000L});
	public static final BitSet FOLLOW_IMPLICS_in_case359 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_case361 = new BitSet(new long[]{0x0000000008100000L});
	public static final BitSet FOLLOW_ESAC_in_case365 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_NEW_in_new374 = new BitSet(new long[]{0x0040000000000000L});
	public static final BitSet FOLLOW_TYPE_in_new376 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_ARROBA_in_dispatch387 = new BitSet(new long[]{0x0040000000000000L});
	public static final BitSet FOLLOW_TYPE_in_dispatch389 = new BitSet(new long[]{0x0000000008000000L});
	public static final BitSet FOLLOW_PNT_in_dispatch392 = new BitSet(new long[]{0x0000000008000000L});
	public static final BitSet FOLLOW_ID_in_dispatch395 = new BitSet(new long[]{0x0001000000000000L});
	public static final BitSet FOLLOW_OP_PARENT_in_dispatch397 = new BitSet(new long[]{0x02519B09180008C0L});
	public static final BitSet FOLLOW_expr_in_dispatch400 = new BitSet(new long[]{0x0000000000001800L});
	public static final BitSet FOLLOW_COMA_in_dispatch404 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_dispatch406 = new BitSet(new long[]{0x0000000000001800L});
	public static final BitSet FOLLOW_CL_PARENT_in_dispatch412 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_NOT_in_operations427 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_operations429 = new BitSet(new long[]{0x0011110108000040L});
	public static final BitSet FOLLOW_lv1_in_operations433 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_lv2_in_lv1443 = new BitSet(new long[]{0x0000000603080002L});
	public static final BitSet FOLLOW_LEQ_in_lv1447 = new BitSet(new long[]{0x0011110108000040L});
	public static final BitSet FOLLOW_lv1_in_lv1449 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_GEQ_in_lv1451 = new BitSet(new long[]{0x0011110108000040L});
	public static final BitSet FOLLOW_lv1_in_lv1453 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_L_in_lv1455 = new BitSet(new long[]{0x0011110108000040L});
	public static final BitSet FOLLOW_lv1_in_lv1457 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_G_in_lv1459 = new BitSet(new long[]{0x0011110108000040L});
	public static final BitSet FOLLOW_lv1_in_lv1461 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_EQ_in_lv1463 = new BitSet(new long[]{0x0011110108000040L});
	public static final BitSet FOLLOW_lv1_in_lv1465 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_lv3_in_lv2475 = new BitSet(new long[]{0x0002004000000002L});
	public static final BitSet FOLLOW_PLUS_in_lv2479 = new BitSet(new long[]{0x0011110108000040L});
	public static final BitSet FOLLOW_lv2_in_lv2482 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_MINUS_in_lv2484 = new BitSet(new long[]{0x0011110108000040L});
	public static final BitSet FOLLOW_lv2_in_lv2487 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_lv4_in_lv3498 = new BitSet(new long[]{0x0000008000008002L});
	public static final BitSet FOLLOW_MULT_in_lv3501 = new BitSet(new long[]{0x0011110108000040L});
	public static final BitSet FOLLOW_lv3_in_lv3504 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_DIV_in_lv3506 = new BitSet(new long[]{0x0011110108000040L});
	public static final BitSet FOLLOW_lv3_in_lv3509 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_ISVOID_in_lv4520 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_lv4523 = new BitSet(new long[]{0x0011110008000040L});
	public static final BitSet FOLLOW_lv5_in_lv4526 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_nanarita_in_lv5535 = new BitSet(new long[]{0x0011100008000040L});
	public static final BitSet FOLLOW_lv6_in_lv5538 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_ID_in_lv6548 = new BitSet(new long[]{0x0004000000000012L});
	public static final BitSet FOLLOW_OP_PARENT_in_lv6550 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_lv6552 = new BitSet(new long[]{0x0000000000000800L});
	public static final BitSet FOLLOW_CL_PARENT_in_lv6554 = new BitSet(new long[]{0x0004000000000012L});
	public static final BitSet FOLLOW_constant_in_lv6556 = new BitSet(new long[]{0x0004000000000012L});
	public static final BitSet FOLLOW_dispatch_in_lv6559 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_NANARITA_in_nanarita572 = new BitSet(new long[]{0x02519B09180000C0L});
	public static final BitSet FOLLOW_expr_in_nanarita574 = new BitSet(new long[]{0x0000000000000002L});
	public static final BitSet FOLLOW_EOF_in_compileUnit609 = new BitSet(new long[]{0x0000000000000002L});
}
