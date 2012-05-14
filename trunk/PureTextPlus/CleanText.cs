using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace PureTextPlus
{
	public class CleanText
	{
		static Dictionary<char, string> _plainTranslations = null;
		static Dictionary<char, string> _htmlTranslations = null;

		public CleanText()
		{
			if (_plainTranslations != null && _htmlTranslations != null)
			{
				return;
			}

			// Initialize lookup dictionaries
			_plainTranslations = new Dictionary<char, string>();

			_plainTranslations.Add('\n', "\r\n");	//CR -> CR/LF (\r will be dropped)
			_plainTranslations.Add('“', "\"");
			_plainTranslations.Add('”', "\"");
			_plainTranslations.Add('–', "-");		// en-dash
			_plainTranslations.Add('—', "-");		// em-dash
			_plainTranslations.Add('‘', "'");
			_plainTranslations.Add('’', "'");
			_plainTranslations.Add('«', "<<");
			_plainTranslations.Add('»', ">>");
			_plainTranslations.Add(' ', " ");		// alt-0160 non-breaking space character replaced with normal space  (source: hex character code A0)
			_plainTranslations.Add('¢', "cents");
			_plainTranslations.Add('©', "(C)");
			_plainTranslations.Add('®', "(R)");
			_plainTranslations.Add('™', "(TM)");
			_plainTranslations.Add('÷', "/");
			_plainTranslations.Add('µ', "u");
			_plainTranslations.Add('·', " ");		// mid-dot replace with space
			_plainTranslations.Add('±', "+-");

			string literalPlainChars = " \t&~!@#$%^*()[]{}_-+=;:'\"/?\\|,.<>¶€£§¥áÁàÀâÂåÅãÃäÄæÆçÇéÉèÈêÊëËíÍìÌîÎïÏñÑóÓòÒôÔøØõÕöÖßúÚùÙûÛüÜÿ¡¿";

			foreach (char ch in literalPlainChars)
			{
				_plainTranslations.Add(ch, ch.ToString());
			}


			_htmlTranslations = new Dictionary<char, string>();

			_htmlTranslations.Add('\n', "\r\n");	//CR -> CR/LF (\r will be dropped)
			_htmlTranslations.Add('–', "&ndash;");
			_htmlTranslations.Add('—', "&mdash;");
			_htmlTranslations.Add('¡', "&iexcl;");
			_htmlTranslations.Add('¿', "&iquest;");
			_htmlTranslations.Add('“', "&ldquo;");
			_htmlTranslations.Add('”', "&rdquo;");
			_htmlTranslations.Add('‘', "&lsquo;");
			_htmlTranslations.Add('’', "&rsquo;");
			_htmlTranslations.Add('«', "&laquo;");
			_htmlTranslations.Add('»', "&raquo;");
			_htmlTranslations.Add(' ', "&nbsp;");		// alt-0160
			_htmlTranslations.Add('&', "&amp;");
			_htmlTranslations.Add('¢', "&cent;");
			_htmlTranslations.Add('©', "&copy;");
			_htmlTranslations.Add('÷', "&divide;");
			_htmlTranslations.Add('>', "&gt;");
			_htmlTranslations.Add('<', "&lt;");
			_htmlTranslations.Add('µ', "&micro;");
			_htmlTranslations.Add('·', "&middot;");
			_htmlTranslations.Add('¶', "&para;");
			_htmlTranslations.Add('±', "&plusmn;");
			_htmlTranslations.Add('€', "&euro;");
			_htmlTranslations.Add('£', "&pound;");
			_htmlTranslations.Add('®', "&reg;");
			_htmlTranslations.Add('§', "&sect;");
			_htmlTranslations.Add('™', "&trade;");
			_htmlTranslations.Add('¥', "&yen;");
			_htmlTranslations.Add('á', "&aacute;");
			_htmlTranslations.Add('à', "&agrave;");
			_htmlTranslations.Add('â', "&acirc;");
			_htmlTranslations.Add('å', "&aring;");
			_htmlTranslations.Add('ã', "&atilde;");
			_htmlTranslations.Add('ä', "&auml;");
			_htmlTranslations.Add('æ', "&aelig;");
			_htmlTranslations.Add('ç', "&ccedil;");
			_htmlTranslations.Add('é', "&eacute;");
			_htmlTranslations.Add('è', "&egrave;");
			_htmlTranslations.Add('ê', "&ecirc;");
			_htmlTranslations.Add('ë', "&euml;");
			_htmlTranslations.Add('í', "&iacute;");
			_htmlTranslations.Add('ì', "&igrave;");
			_htmlTranslations.Add('î', "&icirc;");
			_htmlTranslations.Add('ï', "&iuml;");
			_htmlTranslations.Add('ñ', "&ntilde;");
			_htmlTranslations.Add('ó', "&oacute;");
			_htmlTranslations.Add('ò', "&ograve;");
			_htmlTranslations.Add('ô', "&ocirc;");
			_htmlTranslations.Add('ø', "&oslash;");
			_htmlTranslations.Add('õ', "&otilde;");
			_htmlTranslations.Add('ö', "&ouml;");
			_htmlTranslations.Add('ú', "&uacute;");
			_htmlTranslations.Add('ù', "&ugrave;");
			_htmlTranslations.Add('û', "&ucirc;");
			_htmlTranslations.Add('ü', "&uuml;");
			_htmlTranslations.Add('Á', "&Aacute;");
			_htmlTranslations.Add('À', "&Agrave;");
			_htmlTranslations.Add('Â', "&Acirc;");
			_htmlTranslations.Add('Å', "&Aring;");
			_htmlTranslations.Add('Ã', "&Atilde;");
			_htmlTranslations.Add('Ä', "&Auml;");
			_htmlTranslations.Add('Æ', "&AElig;");
			_htmlTranslations.Add('Ç', "&Ccedil;");
			_htmlTranslations.Add('É', "&Eacute;");
			_htmlTranslations.Add('È', "&Egrave;");
			_htmlTranslations.Add('Ê', "&Ecirc;");
			_htmlTranslations.Add('Ë', "&Euml;");
			_htmlTranslations.Add('Í', "&Iacute;");
			_htmlTranslations.Add('Ì', "&Igrave;");
			_htmlTranslations.Add('Î', "&Icirc;");
			_htmlTranslations.Add('Ï', "&Iuml;");
			_htmlTranslations.Add('Ñ', "&Ntilde;");
			_htmlTranslations.Add('Ó', "&Oacute;");
			_htmlTranslations.Add('Ò', "&Ograve;");
			_htmlTranslations.Add('Ô', "&Ocirc;");
			_htmlTranslations.Add('Ø', "&Oslash;");
			_htmlTranslations.Add('Õ', "&Otilde;");
			_htmlTranslations.Add('Ö', "&Ouml;");
			_htmlTranslations.Add('Ú', "&Uacute;");
			_htmlTranslations.Add('Ù', "&Ugrave;");
			_htmlTranslations.Add('Û', "&Ucirc;");
			_htmlTranslations.Add('Ü', "&Uuml;");
			_htmlTranslations.Add('´', "&#180;");
			_htmlTranslations.Add('`', "&#96;");
			_htmlTranslations.Add('ÿ', "&yuml;");
			_htmlTranslations.Add('ß', "&szlig;");

			string literalHtmlChars = " \t~!@#$%^*()[]{}_-+=;:'\"/?\\|,.";

			foreach (char ch in literalHtmlChars)
			{
				_htmlTranslations.Add(ch, ch.ToString());
			}
		}

		public string ToPlain(char input)
		{
			// Literal ranges
			if ((input >= 'a' && input <= 'z') 
				|| (input >= 'A' && input <= 'Z')  
				|| (input >= '0' && input <= '9')
				)
			{
				return input.ToString();
			}

			string output = null;
			_plainTranslations.TryGetValue(input, out output);

			return output;
		}

		public string ToPlain(string input)
		{
			StringBuilder output = new StringBuilder();
			foreach(char ch in input)
			{
				string transalated = ToPlain(ch);
				if (transalated != null)
				{
					output.Append(transalated);
				}
			}

			return output.ToString();
		}

		public string ToHtml(char input)
		{
			// Literal ranges
			if ((input >= 'a' && input <= 'z') 
				|| (input >= 'A' && input <= 'Z')  
				|| (input >= '0' && input <= '9')
				)
			{
				return input.ToString();
			}

			string output = null;
			_htmlTranslations.TryGetValue(input, out output);

			return output;
		}

		public string ToHtml(string input)
		{
			StringBuilder output = new StringBuilder();
			foreach(char ch in input)
			{
				string transalated = ToHtml(ch);
				if (transalated != null)
				{
					output.Append(transalated);
				}
			}

			return output.ToString();
		}
	}
}
