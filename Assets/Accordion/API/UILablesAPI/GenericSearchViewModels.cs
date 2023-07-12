using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using LitJson;

[System.Serializable]

public class genericsearchviewmodels
{

	public int    Id;
	public string Code;
	public string Value;

	public string Name;
	public bool   Status;
	public string AppTypeCode;
    public string LanguageTextCode;
	public int    LanguageTextId;
	public string UserFriendlyCode;
	public int    CreatedBy;
	public string DateCreated;
	public string ModifiedBy;
	public string DateModified; 
//	public string UserFriendlyCode;
	//public int    UpdateCount;


	//public string CompanyCode;
	//public string LanguageCode;
}
