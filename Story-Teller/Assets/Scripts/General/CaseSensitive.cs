using System;

public static class CaseSensitive  {

	public static bool Contains(this string source, string toCheck, StringComparison comp){

		return source.IndexOf(toCheck,comp)>=0;
}


}
