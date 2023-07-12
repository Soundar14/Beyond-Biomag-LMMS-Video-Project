using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScanPoint 
{
	public string Code;
	public string Name;
	public string SectionCodeBelonging;
	public string Location;
	public int SortingRank;

	public List<CorrespondingPair> CPairs = new List<CorrespondingPair> ();
}
