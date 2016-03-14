using System;

namespace Test.Model.Document
{
	public class Photos : BitMobile.DbEngine.DbObject
	{
		public Photos()
		{
		}

			public bool Posted { get; set; }
			public Guid Id { get; set; }
			public bool DeletionMark { get; set; }
			public DateTime Date { get; set; }
			public String FileName { get; set; }
			public String Link { get; set; }
			}
}
	