
using System;
using System.Collections.Generic;

namespace olif.core {
	public class CodeParserClass {		
		public CodeParserClass() {
		}
		
		private string FCode;
		private int cchar = 0;
		private int schar = 0;
		private int echar;
		private List<string> lines = new List<string>();
		
		private bool isSpaceChar(){
			switch (FCode[cchar]) {
				case ' ':
				case '\t':
				case '\r':
				case '\n':
					return true;
				default:
					return false;
			}
		}
		
		private bool isDelimiterChar(){
			switch (FCode[cchar]) {
				//.,:;<>=~!@#$?%^&(){}[]+-*/|\
				case '.':				
				case ',':
				case ':':
				case ';':
				case '<':
				case '>':
				case '=':
				case '~':
				case '!':
				case '@':
				case '#':
				case '$':
				case '?':
				case '%':
				case '^':
				case '&':
				case '(':
				case ')':
				case '{':
				case '}':
				case '[':
				case ']':
				case '+':
				case '-':
				case '*':
				case '/':
				case '|':
				case '\\':
					return true;
				default:
					return false;
			}
		}
		
		public static bool isBadVariantName(string name) {
			return false;
		}
		
		private void scanSpaces() {
			do { cchar++; } while(isSpaceChar() && cchar < echar);
		}
		
		private string scanWord() {
			schar = cchar;
			while (cchar < echar && !isSpaceChar() && !isDelimiterChar()) cchar++;
			//if (cchar==echar) cchar++;
			return FCode.Substring(schar, cchar - schar);
		}
		
		private string scanString() {
			schar = cchar;
			do {
				cchar++;				
			} while (!(FCode[cchar]=='\"' && FCode[cchar-1]!='\\' ));
			cchar++;
			return FCode.Substring(schar, cchar - schar);
		}
		
		private string scanRegion(char rgnBegin, char rgnEnd) {
			schar = cchar;
			int rgnLevel = 1;
			do {
				cchar++;
				if (FCode[cchar] == rgnBegin) rgnLevel++;
				if (FCode[cchar] == rgnEnd) rgnLevel--;
			} while (cchar < echar && rgnLevel>0);
			cchar++;
			return FCode.Substring(schar, cchar - schar);
		}
		
		public string[] SplitCode(string code) {			
			cchar = 0;
			schar = 0;
			lines = new List<string>();
			FCode = code + ' ';
			echar = FCode.Length-1;
			while (cchar < echar) {				
				switch (code[cchar]) {
					case ' ':
					case '\t':
					case '\r':
					case '\n':
						scanSpaces();						
						continue;
					case '"':
						lines.Add(scanString());
						continue;
					case '[':
						lines.Add(scanRegion('[', ']'));
						continue;
					case '(':
						lines.Add(scanRegion('(', ')'));
						continue;
					case '{':
						lines.Add(scanRegion('{', '}'));
						continue;
					default:
						if (isDelimiterChar()) {
							lines.Add(FCode[cchar].ToString());
							cchar++;
						} else {
							lines.Add(scanWord());
						}
						continue;
				}
				//cchar++;
			}
			return lines.ToArray();				
		}
	}
}
