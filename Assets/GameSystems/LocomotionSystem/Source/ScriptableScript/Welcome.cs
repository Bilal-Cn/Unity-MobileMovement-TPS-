using System;
using System.Collections.Generic;
using UnityEngine;



namespace QoallaInteractiveWelcome
{
	[ExecuteInEditMode]
	[CreateAssetMenu(fileName = "Welcome Message", menuName = "Qoalla Interactive Entertainment/New Message")]
	public class Welcome : ScriptableObject
	{
		public Texture2D icon;
		public string title= "Qoalla Interactive Entertainment";

		public List<Section> sections = new List<Section>();

		public bool loadedLayout=true;


		



		[Serializable]
		public class Section
		{
			public string heading, text, linkText, url;
		}

		
	}
}
