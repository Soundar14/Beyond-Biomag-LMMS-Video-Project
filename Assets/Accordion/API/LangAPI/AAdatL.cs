using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AAdatL {

	public string Message;
	public bool Success;
//	public GenericSearchViewModel GenericSearchViewModels;
	public List<GenericSearchViewModel> GenericSearchViewModels = new List<GenericSearchViewModel>();
}

	public class LangResponce
	{
		public AAdatL aaData;

		public LangResponce()
		{
			aaData = new AAdatL();
		}

	}

	public class LangWrapper{

		public LangResponce langResponce;

		public LangWrapper()
		{
			langResponce = new LangResponce();
		}
}
