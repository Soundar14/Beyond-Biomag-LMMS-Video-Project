using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class CasesensitiveExtensionMethod {

	public static bool Contains(this string source, string toCheck, StringComparison comp)
	{
		return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
	}
}
