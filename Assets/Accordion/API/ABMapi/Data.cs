using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Data  
{
	public List<BioMagneticPoint> AnatomicalBiomagneticMatrix = new List<BioMagneticPoint>();
	public bool Success;
	public string Message;
	//public bool True;
}

public class MasterData
{
	public Data aaData;
	//public bool True;
	public MasterData()
	{
		aaData = new Data();
	}
}

public class Wrapper
{
	public MasterData md;

	public Wrapper()
	{
		md = new MasterData();
	}
}
